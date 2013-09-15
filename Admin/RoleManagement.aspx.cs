using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Admin_RoleManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Console.Write(sender);
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "comButton1") //触发点击事件
        {
            string nickname =e.CommandArgument.ToString(); //获取回发的值
            Roles.AddUserToRole(nickname, "Admin");
            Label1.Text = "Set Admin:" + nickname + "Successful.";
        }
    }
}