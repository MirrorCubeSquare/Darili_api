using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Remove("OrgName");
        Session.Remove("IsMinorOrg");
        Session.Clear();
        FormsAuthentication.SignOut();
        Response.Redirect("http://stu.fudan.edu.cn/user/logout?returnurl=http://stu.fudan.edu.cn/event/main.html");
    }
}