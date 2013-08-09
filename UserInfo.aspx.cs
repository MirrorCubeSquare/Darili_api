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
            if (type == "simple")
            {
                root.Add(new XElement("Nickname"), Page.User.Identity.Name);
                root.Add(new XElement("IsInitialized"), Darili_User.IsInitialized());
                if (Darili_User.IsInitialized())
                {
                    root.Add(new XElement("User_Id", Darili_User.Get_Uid_Local(Page.User.Identity.Name)));
                }
            }

        }
    }
}