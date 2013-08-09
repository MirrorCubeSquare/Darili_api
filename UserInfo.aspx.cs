using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class UserInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            string type = Request.QueryString["type"] != "" ? Request.QueryString["type"] : "simple";
            if (type == "simple")
            {
               
            }
        }
    }
}