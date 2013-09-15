using System;
using System.Collections.Generic;
using System.Linq;
using Darili_api;
using System.Web;
using System.Web.Security;

/// <summary>
///Event_RoleControl 的摘要说明
/// </summary>
namespace Darili_api
{
    public class Event_RoleControl
    {
        public static bool IsOwner(int eid)
        {
            Darili_LinqDataContext ctx = new Darili_LinqDataContext();
            string NickName = HttpContext.Current.User.Identity.Name;
            var Publisher = ctx.EventMain.Where(P => P.Id == eid).Select(p => p.Publisher).First();
            var ctx2 = new Event_orgDataContext();
            string OrgName = ctx2.Event_Org.Where(p => p.NickName == NickName).Select(p => p.Org_Name).First();
            return (Publisher == NickName || Publisher == OrgName);

        }
        public Event_RoleControl()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public static bool IsAdmin(string NickName)
        {
            return Roles.IsUserInRole(NickName, "Admin");
        }
        public static bool OwnerOrAdmin(int eid)
        {
            return IsAdmin(HttpContext.Current.User.Identity.Name) || IsOwner(eid);
        }
        public static void RequireOrganization(string OrganizeName,string type)
        {
            if ((!HttpContext.Current.User.IsInRole("Blocked")))
            {
                Event_orgDataContext ctx = new Event_orgDataContext();
                Event_Org orga = new Event_Org
                {
                    NickName = HttpContext.Current.User.Identity.Name,
                    Org_Name = OrganizeName,
                    IsProved = false,
                    Type=type
                };
                ctx.Event_Org.InsertOnSubmit(orga);
                ctx.SubmitChanges();

            }
            else
            {
                HttpContext.Current.Response.StatusCode = 403;
                HttpContext.Current.Response.End();
            }
        }
        public  enum RoleControlLevel
        {
            AllAcceptable = -1,
            NeedOrganization = 1,
            AdminOnly = 2
        }
        public bool AllowAccess(RoleControlLevel PermissionLevel)
        {
            switch (PermissionLevel)
            {
                case RoleControlLevel.AdminOnly:
                    return HttpContext.Current.User.IsInRole("Admin");
                case RoleControlLevel.NeedOrganization:
                    return HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Organization");
                case RoleControlLevel.AllAcceptable:
                    return true;
                default:
                    return HttpContext.Current.User.Identity.Name != "";
            }

        }
        public static Event_ViewControl.ViewLevel Viewlevel()
        {
            //创建活动时使用，默认为权限拥有者可以使用的最高等级
            if (HttpContext.Current.User.IsInRole("Admin"))
            {
                return Event_ViewControl.ViewLevel.PublicViewable;
            }
            else if (HttpContext.Current.User.IsInRole("Organization")||HttpContext.Current.User.IsInRole("MinorOrg"))
            {
                return Event_ViewControl.ViewLevel.PublicViewable;
            }
            else
            {
                return Event_ViewControl.ViewLevel.Internal;
            }
        }
    }
    public class Event_ViewControl
    {
        public Event_ViewControl()
        {
        }
        public enum ViewLevel : int
        {
            Locked = -3,
            Internal = -1,
            Closed = -2,
            PublicViewable = 1,
            HotEvent = 2,
            FixedTop = 999

        };
    }
}