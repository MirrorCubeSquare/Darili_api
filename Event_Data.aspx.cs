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
            string cat = Request.QueryString["cat"];
            string subcat = Request.QueryString["subcat"];
            string timeoffset = Request.QueryString["timeoffset"];
            XElement Xml_Root = new XElement("allevents", null);
            Darili_LinqDataContext ctx = new Darili_LinqDataContext();
            try
            {
                
                Event[] events = Event.GetTimeSpan(DateTime.Now.Date, DateTime.Now.Date + new TimeSpan(Int32.Parse(timeoffset) + 1, 0, 0, 0), cat, subcat, true);
              
                XElement[] Elements = Event.Translte_Xml(events).ToArray();
                if (Elements != null)
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