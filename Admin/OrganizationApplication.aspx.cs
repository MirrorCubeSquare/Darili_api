using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Darili_api;

public partial class Admin_OrganizationApplication : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "comButton1") //触发点击事件
        {
            string id = e.CommandArgument.ToString();
            //获取回发的值
            Event_orgDataContext ctx = new Event_orgDataContext();
            var data = ctx.Event_Org.Where(p => p.id == int.Parse(id)).Select(p => p).First();
            data.IsProved = true;
            ctx.SubmitChanges();
            Roles.AddUserToRole(data.NickName, "Organization");
            Label1.Text = ("Add NickName:" + data.NickName + " to Organization:" + data.Org_Name + " successful.");

        }
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        
    }
}