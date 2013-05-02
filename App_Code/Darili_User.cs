﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Security;
using Darili_api;
using System.Xml;
using System.Data.Linq;
using System.Xml.Linq;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
///Darili_User 的摘要说明
/// </summary>
public class Darili_User
{
    // if (HttpContext.Current.User.Identity.Name != null)
    //Darili_LinqDataContext ctx = new Darili_LinqDataContext();
 
    //从stu_info中获取用户名信息
    public static Tuple<bool,string,string> Validate_StuCommon(HttpCookie oCookie)
    {
        CookieContainer cookies = new CookieContainer();
        HttpWebRequest request = WebRequest.Create("http://stu.fudan.edu.cn/user/info") as HttpWebRequest;
        request.CookieContainer = cookies;
       
           
            Cookie oC = new Cookie();

            // Convert between the System.Net.Cookie to a System.Web.HttpCookie...
            oC.Domain = request.RequestUri.Host;
            oC.Expires = oCookie.Expires;
            oC.Name = oCookie.Name;
            oC.Path = oCookie.Path;
            oC.Secure = oCookie.Secure;
            oC.Value = oCookie.Value;

            request.CookieContainer.Add(oC);
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.4 (KHTML, like Gecko) Chrome/22.0.1229.94 Safari/537.4";
        request.Accept = "text/plain,text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        request.Timeout = 0x1388;
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] byteArray = encoding.GetBytes("tucao=411whatthefuck");
        Stream newStream = request.GetRequestStream();
        newStream.Write(byteArray, 0, byteArray.Length);//写入参数
        newStream.Close();
        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
       
        if (response.StatusCode.Equals(HttpStatusCode.OK))
        {
            string content = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GB2312")).ReadToEnd();
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
            String success;
            if (values.TryGetValue("success", out success))
            {
                if (success.Equals("1"))
                {
                    String stuno;
                    String nickname;
                    values.TryGetValue("stuno", out stuno);
                    values.TryGetValue("nickname", out nickname);
                    return new Tuple<bool,string,string>(true,stuno,nickname);
                }
                else
                {
                    return null;
                }
            }
        }
        return null;
    }
    //获取当前登陆用户的信息(姓名，昵称，手机号)，如果没有登陆则返回null
    public static XElement GetUserInfo()
    {
        if (HttpContext.Current.User.Identity.Name != null)
        {
            string name =HttpContext.Current.User.Identity.Name;
            var ctx = new Darili_UserDataContext();
            var quary = from entry in ctx.Event_Users
                        where (entry.User_NickName == name|| entry.User_Realname == name)
                        select new
                        {
                            Id=entry.User_Id,
                            Cellphone = entry.User_CellPhone,
                            Nickname = entry.User_NickName,
                            Realname = entry.User_Realname
                        };
            var user = quary.First();
            XElement xml = new XElement("User", new XAttribute("Id", user.Id));
            xml.Add(new XElement("Cellphone", user.Cellphone),
                    new XElement("Nickname", user.Nickname),
                    new XElement("Realname", user.Realname));
            return xml;
        }
        else return null;
    }
    //以当前用户的身份订阅指定ID的活动
    public static XElement Subscribe(int id)
    {
        string name = HttpContext.Current.User.Identity.Name;

        if (HttpContext.Current.User.Identity.Name != null)
        {
            var ctx = new Darili_UserDataContext();
            var main = new Darili_LinqDataContext();
            var user = from entry in ctx.Event_Users
                       where entry.User_NickName == HttpContext.Current.User.Identity.Name
                       select entry;
            var subscription_user = user.First().User_Event_Go;
            if (subscription_user == null) subscription_user = new XElement("root", null);
            var tar = from entry in main.EventMain
                      where entry.Id == id
                      select entry;
            if (tar.First() == null) return new XElement("Event", new XAttribute("success", 0), new XAttribute("exception", "未找到活动"));
            else
            {

                var subscription_event = tar.First().Subscription;
                if (subscription_event == null) subscription_event = new XElement("root", null);
                XElement xml_event = new XElement("User", new XAttribute("Id", user.First().User_Id), new XAttribute("Name", user.First().User_NickName));
                //待添加：其他需要放在里面的东西（手机号等)
                //xml_event.add(new XElement("Cellphone",user.First().User_CellPhone);←像这样，待敲定
                XElement xml_user = new XElement("Event", new XAttribute("Id", tar.First().Id));
                //由于不是多时段的所以无需写入时段信息
               //为了节约空间，这里只存储ID，可以通过Event.GetEventById(int Id)方法调去详细信息
                subscription_event.Add(xml_event);
                subscription_user.Add(xml_user);
               

                tar.First().Subscription = subscription_event;
                user.First().User_Event_Go = subscription_user;
                try
                {

                    ctx.SubmitChanges();
                    return new XElement("Subscribe",new XAttribute("success",1));
                }
                catch (Exception exp)
                {
                     return new XElement("Subscribe",new XAttribute("success",0));
                }
                



            }

            
        }
        return new XElement("Subscribe", new XAttribute("success", 0));
    }
   
   //判断本地用户信息库是否已存在该用户
    public static bool IsInitialized(string NickName)
    {
        var ctx = new Darili_UserDataContext();
        var quary = (from entry in ctx.Event_Users
                     where entry.User_NickName == NickName
                     select entry).ToArray().Length;
        return (quary != 0);
    }
    public static bool IsInitialized()
    {
        if (HttpContext.Current.User.Identity.Name != null)
        {
            return IsInitialized(HttpContext.Current.User.Identity.Name);
        }
        else return false;
    }
    public static bool IsAuthenticated()
    {
        return HttpContext.Current.User.Identity.IsAuthenticated;
    }
    //根据NickName 和UserId 初始化本地的表单
    //返回值：正数代表成功（为返回的UserId）
     //0表示查无此用户或其他异常
    //-1表示发生编辑冲突，未对数据库做出变动
    public static int Initialize(string NickName,int UserId)
    {
        int status = 0;
        if (IsInitialized() == false && IsAuthenticated() == true)
        {
            var ctx = new Darili_UserDataContext();

            Event_Users user = new Event_Users
            {
                User_NickName = NickName,
                User_Id = UserId
            };
            try
            {
                ctx.Event_Users.InsertOnSubmit(user);
                ctx.SubmitChanges();
                status = user.User_Id;
            }
            catch (ChangeConflictException)
            {
                foreach (ObjectChangeConflict confict in ctx.ChangeConflicts)
                {
                    confict.Resolve(RefreshMode.OverwriteCurrentValues);
                }
                status = -1;
                ctx.SubmitChanges();
            }
            finally
            {
                
            }
        }
        else status = 0;
        return status;

    }
    //编辑用户信息（预留管理用借口）
    //1=成功 0=异常 -1=编辑冲突（覆盖前值）
    public static int UpdateUserInfo(string NickName,string RealName, string cellphone)
    {
        int status=0;
        var ctx = new Darili_UserDataContext();
        if (IsInitialized(NickName))
        {
            var user = ctx.Event_Users.Single(c => c.User_NickName == NickName);
            if (RealName != null)
            {
                user.User_Realname = RealName;
            }
            if (cellphone != null)
            {
                user.User_CellPhone = cellphone;
            }
            try
            {
                ctx.SubmitChanges();
                status=1;
            }
            catch (ChangeConflictException)
            {
                foreach (ObjectChangeConflict confict in ctx.ChangeConflicts)
                {
                    confict.Resolve(RefreshMode.OverwriteCurrentValues);
                }
                status = -1;
                ctx.SubmitChanges();
            }
            finally
            {
               
            }
           
        }
        return status;
    }
    public static int UpdateUserInfo(string RealName, string cellphone)
    {
        string user = HttpContext.Current.User.Identity.Name;
        if (IsAuthenticated() && IsInitialized())
        {
            return UpdateUserInfo(user, RealName, cellphone);
        }
        else return 0;
    }
    //输出用户信息(JSON格式）
    public static string GetUserInfo(string NickName,bool RequireDetailInfo,bool RequireRoles)
    {
        var ctx = new Darili_UserDataContext();
        XElement User_Root = new XElement("User");
        if (IsInitialized(NickName))
        {
            //用户存在，输出用户基本信息
            var user = ctx.Event_Users.Single(c => c.User_NickName == NickName);
            
                User_Root.Add("NickName", user.User_NickName);
                if (RequireDetailInfo)
                {
                    User_Root.Add("RealName", user.User_Realname);
                    User_Root.Add("CellPhone", user.User_CellPhone);
                    User_Root.Add("UserId", user.User_Id);
                }
                #region 是否获取角色信息
                if (RequireRoles)
                {
                    try
                    {
                        var roles = Roles.GetRolesForUser(NickName);
                        foreach (string role in roles)
                        {
                            User_Root.Add("Role", role);
                        }

                    }
                    catch (Exception e)
                    {
                        User_Root.Add("success",0);
                        User_Root.Add("exception", e.Message);
                    }
                }
                #endregion


        }
        else//用户不存在或用户未初始化
        {
            User_Root.Add("success", 0);
            User_Root.Add("exception", "用户不存在或未初始化");
        }
        return JsonConvert.SerializeXNode(User_Root);
    }

}