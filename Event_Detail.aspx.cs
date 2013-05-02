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


public partial class Event_Detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string user = HttpContext.Current.User.Identity.Name;
        //int id = Int32.Parse(Request.QueryString["id"]);
        int id=1;
        Darili_LinqDataContext ctx = new Darili_LinqDataContext();
        if (Darili_EventManuever.IsExist(id) != false)
        {
            Event result = Event.GetEventById(id);
            //输出格式不同，懒得再在类里面再写了（好吧我错了），完全把设计思想抛在脑后233max
            XElement result_root = new XElement("Eventdetail");
            result_root.Add(new XElement("Id", id));
            result_root.Add(new XElement("StartTime", result.StartTime));
            result_root.Add(new XElement("EndTime", result.EndTime));
            result_root.Add(new XElement("Context",result.Context));
            Comment[] comments = Darili_Comments.GetCommentsById(id);
            if (comments != null)
            {
                result_root.Add(new XElement("reply-num",comments.Length));
                foreach (var entry in comments)
                {
                    //User_id暂缺
                    result_root.Add(new XElement("name", entry.name), new XElement("time", entry.time), new XElement("content", entry.content));

                }
            }
            result_root.Add(new XElement("share-num"), Darili_Extra.GetShareNum(id));
            result_root.Add(Darili_Extra.GetAlbum(id,Server.MapPath("./")));
            result_root.Add("success", 1);
            
            Response.Write(JsonConvert.SerializeXNode(result_root));


        }


    }
}