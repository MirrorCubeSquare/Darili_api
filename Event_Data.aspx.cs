using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using System.Web.UI.WebControls;
using Darili_api;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//Event_Data.aspx 按时间段/类型输出简单活动信息
//版本号 V1-rc1
//抛弃之前的繁琐功能选择
//by小胖
public partial class Event_Data : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "application/json";
        Response.Charset = "utf-8";
        if (!IsPostBack)
        {
            string cat = Request.QueryString["cat"]==null?"":Request.QueryString["cat"];
            string subcat = Request.QueryString["subcat"]==null?"":Request.QueryString["subcat"];
            string timeoffset = Request.QueryString["timeoffset"]==null?"0":Request.QueryString["timeoffset"];
            string page = Request.QueryString["page"]!=null?Request.QueryString["page"]:"0";
            string perpage = Request.QueryString["perpage"]!=null?Request.QueryString["perpage"]:"5";
            DateTime date = Request.QueryString["d"] != null ? DateTime.Parse(Request.QueryString["d"]) :DateTime.MinValue;
            XElement Xml_Root = new XElement("allevents", null);
            Darili_LinqDataContext ctx = new Darili_LinqDataContext();
            Event[] events=new Event[1];
            try
            {
                if (date != DateTime.MinValue)
                {
                    events = Event.GetTimeSpan(date.Date, date.Date + new TimeSpan(1, 0, 0, 0), cat, subcat, true, int.Parse(perpage), int.Parse(page));
                }
                else
                {
                    if (timeoffset == "0" || timeoffset == "1")
                        events = Event.GetTimeSpan(DateTime.Now.Date, DateTime.Now.Date + new TimeSpan(Int32.Parse(timeoffset) + 1, 0, 0, 0), cat, subcat, true, int.Parse(perpage), int.Parse(page));
                    if (timeoffset == "2")
                    {
                        int offset1 = int.Parse(Darili_EventManuever.Convert_DayOfWeek(DateTime.Now.DayOfWeek));
                        events = Event.GetTimeSpan(DateTime.Now.Date + new TimeSpan(-offset1, 0, 0, 0), DateTime.Now.Date + new TimeSpan(-offset1 + 7, 0, 0, 0), cat, subcat, true, int.Parse(perpage), int.Parse(page));
                    }
                    if (timeoffset == "3")
                    {
                        int offset1 = int.Parse(Darili_EventManuever.Convert_DayOfWeek(DateTime.Now.DayOfWeek));
                        events = Event.GetTimeSpan(DateTime.Now.Date + new TimeSpan(-offset1 + 7, 0, 0, 0), DateTime.Now.Date + new TimeSpan(-offset1 + 14, 0, 0, 0), cat, subcat, true, int.Parse(perpage), int.Parse(page));

                    }
                    if (timeoffset != "0" && timeoffset != "1" && timeoffset != "2" && timeoffset != "3")
                    {
                        events = Event.GetTimeSpan(DateTime.Parse("1990/1/1"), DateTime.Parse("2013/9/1"), cat, subcat, true, int.Parse(perpage), int.Parse(page));
                    }
                }
                if (events.Count() == 1)
                {
                    List<Event> list = events.ToList();

                    events = list.ToArray();
                }
                XElement[] Elements = Event.Translte_Xml(events).ToArray();

                if (Elements != null&&events[0]!=null)
                {
                    foreach (XElement element in Elements)
                    {
                        Xml_Root.Add(element);
                    }
                    Xml_Root.Add(new XElement("success", 1));
                }
                Response.Clear();
                Response.Write(JsonConvert.SerializeXNode(Xml_Root));
            }

            catch (Exception exp)
            {
                Xml_Root.RemoveAll();
                Xml_Root.Add(new XElement("ErrorMessage", exp.Message));
                Xml_Root.Add(new XElement("success",0));
                Response.Clear();
                Response.Write(JsonConvert.SerializeXNode(Xml_Root));
            }
        }
    }
}