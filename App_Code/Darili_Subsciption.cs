using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Newtonsoft.Json;
/// <summary>
///Darili_Subsciption 的摘要说明
/// </summary>
namespace Darili_api
{
public class Darili_Subsciption
{
	public Darili_Subsciption()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public static bool SubscribeExists(int eid,int uid)
    {
       LikeAndGoDataContext ctx=new LikeAndGoDataContext();
       var quary = (from entry in ctx.Event_Subscription
                    where entry.eid == eid && entry.uid == uid
                    select entry.sid).Count();
                  return quary>0;



    }
    public static void SubscribeEvent(int eid,XElement s_detail)
    {
        if (Darili_User.IsAuthenticated() &&Event.EventExists(eid))
        {
            int uid = Darili_User.Get_Uid_Local(HttpContext.Current.User.Identity.Name);
            Darili_Subscription_Parameters para = new Darili_Subscription_Parameters(eid);
            try
            {
                LikeAndGoDataContext ctx = new LikeAndGoDataContext();
                Event_Subscription toAdd = new Event_Subscription
                {
                    eid = eid,
                    uid = uid,
                    sdetail = new XElement("Params"),
                    stime=DateTime.Now
                };
                //处理活动报名时间段
                if (s_detail.Element("times") == null) throw new ArgumentNullException("报名时间段", "活动需求的参数未提供");
                toAdd.sdetail.Add(s_detail.Elements("times"));

                //处理活动报名参数
                foreach (XElement ele in para.root.Elements("Para"))
                {
                    if (s_detail.Element(ele.Value) == null)
                    {
                        throw new ArgumentNullException(ele.Value,"活动需求的参数未提供" );
                    }
                    toAdd.sdetail.Add(new XElement(ele.Value, s_detail.Element(ele.Value).Value));
                    
                }
                ctx.Event_Subscription.InsertOnSubmit(toAdd);
                ctx.SubmitChanges();
                
            }
            catch (ArgumentNullException exp)
            {
                throw exp;
            }
        }
    }
    
}

public class Darili_Subscription_Parameters
{
    public XElement root=new XElement("root");
    public Darili_Subscription_Parameters()
    {
    }
    public Darili_Subscription_Parameters(int eid)
    {
        LikeAndGoDataContext ctx = new LikeAndGoDataContext();
      var quary=from entry in ctx.Event_Subscription_Parameters
                where entry.eid==eid
                select entry.parameters;
      if (quary.Count() > 0 )
      {

          this.root = quary.First();
      }
      else
      {
          this.root = null;
      }


    }
    public  bool AddParameter(string parameter)
    {
        try
        {
            if (!ParameterExists(parameter))
            {
                root.Add(new XElement("Para", parameter));
                return true;
            }
            else
                return true;
        }
        catch
        {
            return false;
        }

    }
    public bool ParameterExists(string parameter)
    {
        return ((from entry in root.Elements("Para")
                 where entry.Value == parameter
                 select entry).Count() > 0);

    }
    public bool DeletePatameter(string parameter)
    {
        try
        {
            if (ParameterExists(parameter))
            {
                XElement ToDelete = (from entry in root.Elements("Para")
                                     where entry.Value == parameter
                                     select entry).First();
                ToDelete.Remove();
                return true;

            }
            else
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
  
}
}