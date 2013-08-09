using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;
using Darili_api;

public partial class Comment_Make : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                
                string Event_id = Request.QueryString["eid"];
                string Content = String.IsNullOrWhiteSpace(Request.QueryString["content"]) ? null : Request.QueryString["content"];
                //测试用代码
                string User_id = Request.QueryString["uid"] == null ? "999" : Request.QueryString["uid"];
                if (Darili_api.Event.EventExists(int.Parse(Event_id)) > 0 && (Content != null || Content != ""))
                {
                    //测试期间，固定用户昵称为TEST,ID为999
                    //测试期间，不对用户是否登录进行验证（重要）
                    int cid=Darili_Comments.MakeComment(int.Parse(User_id), int.Parse(Event_id), Content);
                    XElement Result = new XElement("MakeComment",new XElement("success", 1),new XElement("cid",cid));
                    Response.Write( JsonConvert.SerializeXNode(Result));
                }
            }
            catch
            {
                XElement Result = new XElement("MakeComment",new XElement("success", 0));
                Response.Write( JsonConvert.SerializeXNode(Result));
            }
           
        }
    }
}