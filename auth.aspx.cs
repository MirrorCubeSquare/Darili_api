using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Security;
using Newtonsoft.Json;
public partial class auth : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       var result= Darili_User.Validate_StuCommon(Request.Cookies["webpy_session_id"]);
        if (result.Item1 == true)
        {
            if (!Darili_User.IsInitialized(result.Item3))
            {
                //初始化本地用户数据库
                int uid = Darili_User.Get_StuId(Request.Cookies["webpy_session_id"]);
                string nickname = result.Item3;
                if (Darili_User.Initialize(nickname, uid) != uid) throw new Exception();
            }
            Darili_User.RecordLoginTime(result.Item3);
            RedictFromLoginPage(result.Item3, result.Item2);
            Session.Remove("OrgName");
            Session.Remove("IsMinorOrg");
            // RedictFromLoginPage(result.Item3, result.Item2,Request.Cookies["webpy_session_id"]);
        }
        else
        {
            Response.Redirect("main.html");
        }
    }
    private void RedictFromLoginPage(string nickname, string stuno)
    {
        HttpCookie cookie = new HttpCookie("stuno");
        cookie.HttpOnly = true;
        cookie.Value = stuno;
        Response.Cookies.Add(cookie);
        Response.Write("");
        FormsAuthentication.RedirectFromLoginPage(nickname, false);
    }
    private void RedictFromLoginPage(string nickname, string stuno, HttpCookie webpy)
    {
        HttpCookie cookie = new HttpCookie("stuno");
        cookie.HttpOnly = true;
        cookie.Value = stuno;
        Response.Cookies.Add(cookie);
        Response.Write("");
        Response.AppendCookie(webpy);
        FormsAuthentication.RedirectFromLoginPage(nickname, false);
    }
}