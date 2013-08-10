using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Xml.Linq;

public partial class UserInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            XElement root = new XElement("User");
            string type = Request.QueryString["type"] != "" ? Request.QueryString["type"] : "simple";
            root.Add(new XElement("Nickname"), Page.User.Identity.Name);
            root.Add(new XElement("IsInitialized"), Darili_User.IsInitialized());
            //测试用，远程调用 TODO：改为本地调用(stuno)
            var user_info = Darili_User.Validate_StuCommon(Request.Cookies["webpy_session_id"]);
            if (user_info != null)
            {
                root.Add(new XElement("stuno", user_info.Item2));
            }
            if (Darili_User.IsInitialized())
            {
                root.Add(new XElement("uid", Darili_User.Get_Uid_Local(Page.User.Identity.Name)));
            }
            if (type == "detailed")
            {
                
            }
           

        }
    }
}