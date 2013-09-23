using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using Darili_api;


public partial class ShiftOrganization : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool IsOrg=Event_RoleControl.IsOrg(TextBox1.Text, TextBox2.Text);
        Label1.Text = IsOrg.ToString();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //Check If Target is SuperManager
        if(Event_RoleControl.IsOrg(TextBox1.Text, TextBox2.Text))
        {
            Label1.Text="";
            Label1.Text += "Check If Target is BigOrg:Complete" + System.Environment.NewLine;
            Event_orgDataContext ctx = new Event_orgDataContext();
            var toModify = ctx.Event_Org.Where(p => p.NickName == TextBox2.Text).Select(p => p).First();
            if (Darili_User.IsInitialized(TextBox3.Text))
            {
                var count1 = ctx.Event_Org.Where(p => p.NickName == TextBox2.Text).Select(p => p).Count();
                var count2 = ctx.Event_Org.Where(p => p.NickName == TextBox3.Text).Select(p => p).Count();
                Label1.Text += "Target User：" + TextBox3.Text + "Exists,excecuting shift" +System.Environment.NewLine;
                //更改User库内的数据
                toModify.NickName = TextBox3.Text;
                ctx.SubmitChanges();
                if (count1 == 1)
                {
                    Roles.RemoveUserFromRole(TextBox2.Text, "Organization");
                }
                Label1.Text += "Remove Complete." + System.Environment.NewLine;
                if (count2 == 0)
                {
                    Roles.AddUserToRole(TextBox3.Text, "Organization");
                    Label1.Text += "Add Complete." + System.Environment.NewLine;
                }

            }
        }
    }
}