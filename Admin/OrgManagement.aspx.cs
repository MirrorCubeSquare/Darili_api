using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Darili_api;


public partial class Admin_OrgManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var roles = Roles.GetUsersInRole("Organization");
        foreach (var element in roles)
        {
            Response.Write(element + "\r\n");
        }
        Response.Write(Session["OrgName"]);
        Response.Write(Event_RoleControl.IsOrgManager((string)Session["OrgName"], Page.User.Identity.Name));
    }
}