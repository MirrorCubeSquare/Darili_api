using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class ApplyMinorOrg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string nickname = Page.User.Identity.Name;
        string OrgName = Request.QueryString["OrgName"];
        Event_orgDataContext ctx = new Event_orgDataContext();
        var predicate = PredicateBuilder.True<Event_Org>();
        predicate = predicate.And(p => p.NickName == nickname).And(p => p.Org_Name == OrgName).And(p=>p.IsProved==true);
        var count = ctx.Event_Org.Where(predicate).Select(p => p.id).Count();
        if (count > 0)
        {
            if (Darili_User.IsInitialized(nickname))
            {
                ctx.Event_Org.InsertOnSubmit(new Event_Org
                {
                    NickName = nickname,
                    Org_Name = OrgName
                });

                ctx.SubmitChanges();
                Roles.AddUserToRole(nickname, OrgName);
                Response.Write(1);
            }
            else
            {
                Response.StatusCode = 500;
                Response.Write("目标用户未初始化，请目标用户从Event主页登录一次");

            }
            
        }
    }
}