using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using  Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
namespace Darili_api
{
    //重写后的Event主类
    //数据类型参见EventMain.dbml(linq to sql class)说明。。。。 
    //by 小胖
    //id:主键，唯一标示
    //各种time：自己看
    //viewflag:大于0允许公众访问
    //Context：详细内容
    //Type：类别
    //Location：地点
    //Publisher:发布者（创建者）
    public class Event_Time
    {
        public int sub_id;
        public DateTime StartTime;
        public DateTime EndTime;
        public bool IsRoutine;
        public string RoutineDetail;
        
        public static implicit operator Event_MultipleTime(Event_Time value)
        {
            return new Event_MultipleTime
            {
                SubTime_Id=value.sub_id,
                StartDate = value.StartTime,
                EndDate = value.EndTime,
                IsRoutine = value.IsRoutine,
                routine = value.RoutineDetail
            };
        }
        public static implicit operator Event_Time(Event_MultipleTime value)
        {
            return new Event_Time
            {
                sub_id=value.SubTime_Id,
                StartTime = value.StartDate,
                EndTime = value.EndDate,
                IsRoutine = value.IsRoutine,
                RoutineDetail = value.routine
            };
        }
        }
    public class Event
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime PublishTime { get; set; }
        public DateTime LastModified { get; set; }
        public string Publisher { get; set; }
        public JToken ExtraInfo { get; set; }
        public string Speaker { get; set; }
        public string Class { get; set; }
        public Event_Time[] MultipleTime { get; set; }
        public bool ShouldSerializeMultipleTime()
        {
            return (this.IsMultipleTime);
        }
        public string Subtype { get; set; }
        public bool IsMultipleTime { get; set; }
        public string Subtitle { get; set; }
        public short ViewFlag { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Context { get; set; }
        public static XElement Exception(string value)
        {
            return new XElement("Exception", value.ToString());
        }
        public static XElement Translate_Xml(Event value)
        {
            if (value.ToString() == "")
                return null;
            try
            {
                XElement Xml = new XElement("Event", new XElement("Id", value.Id));
                XElement MultipleTime=new XElement("MultipleTime","");
                foreach (var time in value.MultipleTime)
                {
                    MultipleTime.Add(new XElement("Time", new XElement("sub_id", time.sub_id),
                                             new XElement("starttime", time.StartTime),
                                             new XElement("endtime", time.EndTime),
                                             new XElement("isroutine", Convert.ToInt32(time.IsRoutine)),
                                             new XElement("routinedetail", time.RoutineDetail)));

                }
                if (value.Speaker != null)
                {
                    Xml.Add(new XElement("speaker", value.Speaker.Trim()),
                            new XElement("Class", value.Class.Trim()));
                } 
                var timeleft=Darili_Extra.TimeLeft(value);
                Xml.Add(new XElement("Title", value.Title),
                        new XElement("Location", value.Location),
                        new XElement("Subtype",value.Subtype),
                        new XElement("StartTime", value.StartTime),
                        new XElement("EndTime", value.EndTime),
                        new XElement("PublishTime", value.PublishTime),
                        new XElement("Publisher", value.Publisher),
                        new XElement("Context", value.Context),
                        new XElement("ViewFlag", value.ViewFlag),
                        new XElement("tag",Darili_Extra.GetTag(value.Id)),
                        new XElement("love-num",Darili_Extra.GetLikeNum(value.Id)),
                        new XElement("pin-num",Darili_Extra.GetSubscriptionNum(value.Id)),
                        new XElement("share-num",Darili_Extra.GetShareNum(value.Id)),
                        new XElement("timeleft",new XElement("day",timeleft.Item1),new XElement("hour",timeleft.Item2),new XElement("min",timeleft.Item3)),
                        new XElement("Type", value.Type));
                Xml.Add(MultipleTime);

                return Xml;
            }
            catch (Exception exp)
            {
                return new XElement("Exception",exp.ToString());
            }

        }
        public XElement Translate_Xml()
        {
            return Translate_Xml(this);
        }
        public static IEnumerable<XElement> Translte_Xml(Event[] value)
        {
            XElement Xml_Root = new XElement("Root", "");
            foreach (Event eve in value)
            {
                Xml_Root.Add(eve.Translate_Xml());
            }
            return Xml_Root.Elements();

        }
        public static implicit operator Event(EventMain value)
        {
            return new Event((int)value.Id, (DateTime)value.StartTime, (DateTime)value.EndTime, (DateTime)value.PublishTime, (DateTime)value.LastModified, (String)value.Publisher, (short)value.ViewFlag, (String)value.Type, (String)value.SubType, (String)value.Title, (String)value.Subtitle, (String)value.Location, (String)value.Context);
        }


        #region 构造函数
        public Event() { }
        public Event(int _Id, DateTime _StartTime, DateTime _EndTime, DateTime _PublishTime, DateTime _LastModified, string _Publisher, short _ViewFlag, string _Type, string _Subtype, string _Title, string _Subtitle, string _Location, string _Context)
        {
            Id = _Id;
            StartTime = _StartTime;
            EndTime = _EndTime;
            PublishTime = _PublishTime;
            LastModified = _LastModified;
            Publisher = _Publisher;
            ViewFlag = _ViewFlag;
            Type = _Type;
            Subtitle = _Subtitle;
            Title = _Title;
            Location = _Location;
            Context = _Context;
            Subtype = _Subtype;
        }

        #endregion


        public bool loadExtra() { return false; }
        public int InsertEntry()
        {
            Darili_LinqDataContext ctx = new Darili_LinqDataContext();
            EventMain eve = new EventMain
            {
                StartTime = this.StartTime,
                EndTime = this.EndTime,
                PublishTime = this.PublishTime,
                LastModified = this.LastModified,
                Publisher = this.Publisher,
                ViewFlag = this.ViewFlag,
                Type = this.Type,
                Title = this.Title,
                Location = this.Location,
                Context = this.Context,
                Subtitle = this.Subtitle,
                SubType = this.Subtype
            };
            if (this.IsMultipleTime == true)
            {
                foreach (var time in MultipleTime)
                {
                    eve.Event_MultipleTime.Add(time);
                }
            }
            if (ExtraInfo != null)
            {
                eve.Lecture = new Lecture
                {
                    Speaker = (string)ExtraInfo["speaker"],
                    Class = (string)ExtraInfo["class"]
                };
                 

            }
            ctx.EventMain.InsertOnSubmit(eve);
            try
            {
                ctx.SubmitChanges();
                return eve.Id;
            }
            catch
            {
                return -1;
            }


        }
        //删除指定ID的记录
        public bool DeleteID(int id)
        {
            Darili_LinqDataContext ctx = new Darili_LinqDataContext();
            var quary = from entry in ctx.EventMain
                        where entry.Id == id
                        select entry;
            foreach (var entry in quary)
            {
                ctx.EventMain.DeleteOnSubmit(entry);
            }
            try
            {
                ctx.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;

            }


        }
        public static Event GetEventById(int id)
        {
            Darili_LinqDataContext ctx = new Darili_LinqDataContext();
            var quary = from entry in ctx.EventMain
                        where entry.Id == id
                        select entry;
           
            Event result = quary.First();
            try
            {
                var quary2 = (from entry in ctx.Lecture
                              where entry.Event_Id == id
                              select entry).First();
                if (quary2 != null)
                {
                    result.Speaker = quary2.Speaker;
                    result.Class = quary2.Class;
                }
            }
            catch (Exception e)
            {
            }
           

            result.MultipleTime = GetMultipleTime(id);
            if (result.MultipleTime != null) result.IsMultipleTime = true; else result.IsMultipleTime = false;
            return result;
        }
        
        //获取指定发布人的发布记录
        public static Event[] GetPublisherEntries(string people, int count)
        {
            Darili_LinqDataContext ctx = new Darili_LinqDataContext();
            var quary = (from entry in ctx.EventMain
                         where entry.Publisher == people
                         orderby entry.PublishTime descending
                         select entry).Take(count);
            EventMain[] temp = quary.ToArray();
            List<Event> list = new List<Event>();
            foreach (EventMain t in temp)
            {
                list.Add(t);

            }
            return list.ToArray();
        }
        public static Event[] GetPublisherEntries(string people)
        {
            Darili_LinqDataContext ctx = new Darili_LinqDataContext();
            var quary = from entry in ctx.EventMain
                        where entry.Publisher == people
                        orderby entry.PublishTime descending
                        select entry;
            EventMain[] temp = quary.ToArray();
            List<Event> list = new List<Event>();
            foreach (EventMain t in temp)
            {
                list.Add(t);

            }
            return list.ToArray();
        }

        //外部调用：显示所有公共可访问的活动
        public static Event[] GetTimeSpan(DateTime ST, DateTime ET,bool isAll)
        {
            Darili_LinqDataContext ctx = new Darili_LinqDataContext();
            var quary = from entry in ctx.EventMain
                        where entry.StartTime >= ST && entry.EndTime <= ET && entry.ViewFlag >= 0
                        orderby entry.PublishTime descending
                        select entry;
            if (isAll == true)
            {
               quary = from entry in ctx.EventMain
                            where entry.StartTime >= ST && entry.EndTime <= ET
                            orderby entry.PublishTime descending
                            select entry;
            }
            EventMain[] temp = quary.ToArray();
            List<Event> list = new List<Event>();
            foreach (EventMain t in temp)
            {
                list.Add(t);

            }
            foreach (Event t in list)
            {
                t.MultipleTime = GetMultipleTime(t.Id);
                if (t.MultipleTime != null) t.IsMultipleTime = true; else t.IsMultipleTime = false;
                try
                {
                    var quary2 = (from entry in ctx.Lecture
                                  where entry.Event_Id == t.Id
                                  select entry).First();
                    if (quary2 != null)
                    {
                        t.Speaker = quary2.Speaker;
                        t.Class = quary2.Class;
                    }
                }
                catch (Exception e)
                {
                }

            }
            var comp=new Darili_EventManuever.IEventStarttimeComparer();
            list.Sort(comp);
            return list.ToArray();


        }
        public static Event[] GetTimeSpan(DateTime ST, DateTime ET, string type,string subtype,bool IsAll)
        {
            if (subtype == "") return GetTimeSpan(ST, ET, type, IsAll);

            Darili_LinqDataContext ctx = new Darili_LinqDataContext();
            var quary = from entry in ctx.EventMain
                        where entry.StartTime >= ST && entry.EndTime <= ET && entry.ViewFlag >= 0 && entry.Type == type && entry.SubType == subtype
                        orderby entry.PublishTime descending
                        select entry;
            if (IsAll == true)
            {
                quary = from entry in ctx.EventMain
                        where entry.StartTime >= ST && entry.EndTime <= ET &&entry.Type==type &&entry.SubType==subtype
                        orderby entry.PublishTime descending
                        select entry;
            }
            EventMain[] temp = quary.ToArray();
            List<Event> list = new List<Event>();
            foreach (EventMain t in temp)
            {
                list.Add(t);

            }
            foreach (Event t in list)
            {
                t.MultipleTime = GetMultipleTime(t.Id);
                if (t.MultipleTime != null) t.IsMultipleTime = true; else t.IsMultipleTime = false;

            }
            var comp = new Darili_EventManuever.IEventStarttimeComparer();
            list.Sort(comp);
            return list.ToArray();

        }
        public static Event[] GetTimeSpan(DateTime StartTime, DateTime EndTime, string type, bool IsAll)
        {
            if (type == "") return GetTimeSpan(StartTime, EndTime, IsAll);
            Darili_LinqDataContext ctx = new Darili_LinqDataContext();
            var quary = from entry in ctx.EventMain
                        where entry.StartTime >= StartTime && entry.EndTime <=EndTime && entry.ViewFlag >= 0 && entry.Type == type 
                        orderby entry.PublishTime descending
                        select entry;
            if (IsAll == true)
            {
                quary = from entry in ctx.EventMain
                        where entry.StartTime >= StartTime && entry.EndTime <= EndTime && entry.Type == type
                        orderby entry.PublishTime descending
                        select entry;
            }
            EventMain[] temp = quary.ToArray();
            List<Event> list = new List<Event>();
            foreach (EventMain t in temp)
            {
                list.Add(t);

            }
            foreach (Event t in list)
            {
                t.MultipleTime = GetMultipleTime(t.Id);
                if (t.MultipleTime != null) t.IsMultipleTime = true; else t.IsMultipleTime = false;

            }
            var comp = new Darili_EventManuever.IEventStarttimeComparer();
            list.Sort(comp);
            return list.ToArray();
        }
        public static Event[] GetTimeSpan(DateTime StartTime, TimeSpan Span,bool IsAll)

        {
            return GetTimeSpan(StartTime, StartTime.Add(Span),"","",IsAll);
        }
        public static Event[] GetTimeSpan(DateTime StartTime, DateTime EndTime, int take)
        {
            Darili_LinqDataContext ctx = new Darili_LinqDataContext();
            var quary = (from entry in ctx.EventMain
                         where entry.StartTime >= StartTime && entry.EndTime <= EndTime && entry.ViewFlag >= 0
                         orderby entry.PublishTime descending
                         select entry).Take(take);
            EventMain[] temp = quary.ToArray();
            List<Event> list = new List<Event>();
            foreach (EventMain t in temp)
            {
                list.Add(t);

            }
            foreach (Event t in list)
            {
                t.MultipleTime = GetMultipleTime(t.Id);
                if (t.MultipleTime != null) t.IsMultipleTime = true; else t.IsMultipleTime = false;

            }
            return list.ToArray();


        }
        public static Event[] GetTimeSpan(DateTime StartTime, DateTime EndTime, int take,bool IsAll)
        {
            Darili_LinqDataContext ctx = new Darili_LinqDataContext();
            var quary = (from entry in ctx.EventMain
                         where entry.StartTime >= StartTime && entry.EndTime <= EndTime && entry.ViewFlag >= 0
                         orderby entry.PublishTime descending
                         select entry).Take(take);
            if(IsAll==true)
                quary = (from entry in ctx.EventMain
                         where entry.StartTime >= StartTime && entry.EndTime <= EndTime
                         orderby entry.PublishTime descending
                         select entry).Take(take);
            EventMain[] temp = quary.ToArray();
            List<Event> list = new List<Event>();
            foreach (EventMain t in temp)
            {
                list.Add(t);

            }
            foreach (Event t in list)
            {
                t.MultipleTime = GetMultipleTime(t.Id);
                if (t.MultipleTime != null) t.IsMultipleTime = true; else t.IsMultipleTime = false;

            }
            return list.ToArray();


        }
        public static Event_Time[] GetMultipleTime(int id)
        {
            Darili_LinqDataContext ctx = new Darili_LinqDataContext();
            var quary = from entry in ctx.Event_MultipleTime
                        where entry.Event_Id == id
                        select entry;
            List<Event_Time> list = new List<Event_Time>();
            foreach (var e in quary)
            {
                list.Add(e);
            }
            if (list != null) return list.ToArray();
            return null;
        }

    }
}