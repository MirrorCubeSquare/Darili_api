using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Darili_api;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
///Darili_EventManuever 的摘要说明
/// </summary>
public class Darili_EventManuever
{
    public static bool IsExist(int id)
    {
        Darili_LinqDataContext ctx = new Darili_LinqDataContext();
        var quary = from entry in ctx.EventMain
                    where entry.Id == id
                    select id;
        var temp = quary.ToList();
        if (temp == null)
            return false;
        else return true;

    }
    public static Event[] SearchTime(DateTime StartTime, DateTime EndTime, string type, string subtype, bool IsAll, int perpage, int page)
    {
        List<Event> list = new List<Event>();
        var predicate = PredicateBuilder.True<EventMain>();
        return null;
    }
	  public static string AddSubscription(string input)//根据传入的JSON（单个活动）创建活动（测试，通过）
    {
        JObject obj = JObject.Parse(input);
        Event eve = new Event
        {
            Title = (string)obj["event"]["title"],
            Subtitle=(string)obj["event"]["subtitle"],
            Publisher=HttpContext.Current.User.Identity.Name,
            PublishTime=DateTime.Now,
            StartTime=DateTime.Parse((string)obj["event"]["starttime"]),
            EndTime=DateTime.Parse((string)obj["event"]["endtime"]),
            Location=(string)obj["event"]["location"],
            Type=(string)obj["event"]["type"],
            Subtype=(string)obj["event"]["subtype"],
            Context=(string)obj["event"]["context"],
            ExtraInfo=obj["event"]["extrainfo"],
            LastModified=DateTime.Now,
            IsMultipleTime=false
        };
        if (eve.Location == null || eve.Location.Trim() == "")
        {
            eve.Location = "null";
        }
        List<Event_Time> multi = new List<Event_Time>();
        try
        {
            var timelinq = from p in obj["event"]["multipletime"].Children()
                           select new
                           {
                               starttime = p["starttime"],
                               endtime = p["endtime"],
                               isroutine = p["isroutine"],
                               routinedetail = p["routinedetail"]
                           };
            
            foreach (var c in timelinq)
            {
                bool isroutine = Convert.ToBoolean((int)c.isroutine);
                multi.Add(new Event_Time
                {
                    StartTime = System.DateTime.Parse((string)c.starttime),
                    EndTime = System.DateTime.Parse((string)c.endtime),
                    IsRoutine = isroutine,
                    RoutineDetail = (string)c.routinedetail
                });
            }
        }
        catch (Exception e)
        {
        }
        if (multi != null) { eve.IsMultipleTime = true; };
        eve.MultipleTime = multi.ToArray();
        try
        {
           int id= eve.InsertEntry();
           return id.ToString();
        }
        catch (Exception e)
        {
            return "fail";
        }
         
    }
     public class IEventStarttimeComparer:IComparer<Event>
     {
         public int Compare(Event x, Event y)
         {
             Darili_LinqDataContext ctx = new Darili_LinqDataContext();
             var quaryx = from entry in ctx.Event_MultipleTime
                          where entry.Event_Id == x.Id
                          select entry;
             var quaryy = from entry in ctx.Event_MultipleTime
                          where entry.Event_Id == y.Id
                          select entry;
             DateTime timex = new DateTime();
             DateTime timey = new DateTime();
             List<Event_Time>timesx=new List<Event_Time>();
             List<Event_Time>timesy=new List<Event_Time>();
           
            
             if (quaryx.Count() == 0) timex = x.StartTime;
             else
             {
                  foreach (var entry in quaryx)
             {
                 timesx.Add(entry);
             }
                  timex = CalculateNearestStartTime(timesx.ToArray());

             }
             if (quaryy.Count() == 0) timex = y.StartTime;
             else
             {
                 foreach (var entry in quaryy)
                 {
                     timesy.Add(entry);
                 }
                 timex = CalculateNearestStartTime(timesy.ToArray());

             }
             return DateTime.Compare(timex, timey);
             throw new NotImplementedException();
         }

     }

     public static String Convert_DayOfWeek(DayOfWeek value)
     {
        switch (value)
        {
            case DayOfWeek.Sunday:
                return "0";
            case DayOfWeek.Monday:
                return "1";
            case DayOfWeek.Tuesday:
                return "2";
            case DayOfWeek.Wednesday:
                return "3";
            case DayOfWeek.Thursday:
                return "4";
            case DayOfWeek.Friday:
                return "5";
            case DayOfWeek.Saturday:
                return "6";
             default:
                return "7";
        }
     }
     public static void Add_ExtraInfo(string type,JToken extrainfo)
     {

     }
     public static DateTime CalculateNearestStartTime(Event_Time[] times)//根据多时间段的时间，返回离目前最近的开始时间
     {
         List<DateTime> time = new List<DateTime>();
         foreach (var t in times)
         {
             if (t.IsRoutine == false)
             {
                 time.Add(t.StartTime);
             }
             else
             {
                 DateTime q = t.StartTime;
                 while (q < t.EndTime)
                 {
                     if(t.RoutineDetail.IndexOf(Convert_DayOfWeek(q.DayOfWeek))!= -1)
                     {
                         time.Add(q);
                         q = q + new TimeSpan(1, 0, 0, 0);

                     }
                 }
             }
             
          

             }
         var quary = from obj in time
                     where obj>DateTime.Now
                     orderby obj ascending
                     select obj;

         if (quary.ToArray().Length == 0)
         {
             return DateTime.Now;
         }
         else 
         {
             return quary.ToArray().First();
         }
     }
}