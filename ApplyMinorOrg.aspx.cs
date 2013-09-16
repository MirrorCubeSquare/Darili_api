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
        string nickname = String.IsNullOrEmpty(Request.QueryString["NickName"])?null:Request.QueryString["NickName"];
        string OrgName = Request.QueryString["OrgName"];
        Event_orgDataContext ctx = new Event_orgDataContext();
        var predicate = PredicateBuilder.True<Event_Org>();
        predicate = predicate.And(p => p.NickName == nickname).And(p => p.Org_Name == OrgName).And(p=>p.IsProved==true);
        var count = ctx.Event_Org.Where(predicate).Select(p => p);
        if (count.Count() > 0)
        {
            if (Darili_User.IsInitialized(nickname))
            {
                Event_MinorOrg toAdd = new Event_MinorOrg
                {
                    NickName = nickname,
                    Org_Name = OrgName
                };

            }
            else
            {
                Response.StatusCode = 500;
                Response.Write("目标用户未初始化，请目标用户从Event主页登录一次");

            }
            
        }
    }
}