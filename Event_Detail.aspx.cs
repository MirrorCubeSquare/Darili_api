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
        int id = 23;
            int.TryParse(Request.QueryString["id"] == null ? "23" : Request.QueryString["id"],out id);
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
         result_root.Add(new XElement("Type",result.Type));
            result_root.Add(new XElement("Subtype",result.Subtype));
            result_root.Add(new XElement("Title",result.Title));
            result_root.Add(new XElement("Publisher", result.Publisher));
            result_root.Add(new XElement("Location", result.Location));
            result_root.Add(new XElement("series", result.series));
            //处理HOST
            var Raiser = Darili_Extra.GetRaiser(id);
            foreach (var entry in Raiser)
            {
                result_root.Add(new XElement("Raiser",entry));
            }
            var LectureEx = Extra_Lecture.GetExtraInfo(id);
            if (LectureEx != null)
            {
                result_root.Add(new XElement("speakerinf", LectureEx.speakerinfo));
                result_root.Add(new XElement("brand", LectureEx.Brand));
            }
            result_root.Add(new XElement("speaker", result.Speaker));
            Comment[] comments = Darili_Comments.GetCommentsById(id);
            if (comments != null)
            {
                result_root.Add(new XElement("reply-num",comments.Length));
                foreach (var entry in comments)
                {
                    //备注：本地获取nickname
                    
                    string nickname = Darili_User.Get_Nickname_Local(entry.User_Id);
                    result_root.Add(new XElement("responses",new XElement("personID", entry.User_Id), new XElement("time", entry.time), new XElement("content", entry.content),new XElement("name",nickname),new XElement("cid",entry.id)));

                }
               
            }
            result_root.Add(new XElement("share-num",Darili_Extra.GetShareNum(id)));
            result_root.Add(Darili_Extra.GetAlbum(id,Server.MapPath("./")));
            result_root.Add(new XElement("success", "1"));
            
            Response.Write(JsonConvert.SerializeXNode(result_root));


        }


    }
}