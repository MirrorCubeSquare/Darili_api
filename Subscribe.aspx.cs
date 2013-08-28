using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Darili_api;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Subscribe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
       // string json = @"{'root':{'Cellphone':'18817361921','Realname':'徐一唯','times':[{'starttime':'2013-08-01 0:01:02','endtime':'2013-08-03 2:22:22'},{'starttime':'2013-08-04 0:01:02','endtime':'2013-08-06 2:22:22'}]}} ";
        Response.AddHeader("Access-Control-Allow-Origin", "*");
        if (!IsPostBack)
        {

            if (Page.User.Identity.IsAuthenticated)
            {
                try
                {
                    string json = Request.QueryString[0];
                    var Jobject = JObject.Parse(json);
                    int eid = int.Parse((string)Jobject["id"]);
                    int uid=Darili_User.Get_Uid_Local(Page.User.Identity.Name);
                    if (Event.EventExists(eid))
                    {
                        if(!Darili_Subsciption.SubscribeExists(eid,uid))
                        {
                        //var json = JsonConvert.SerializeXNode(Ele);

                        Darili_Subsciption.SubscribeEvent(eid, Jobject);
                        Response.Write(1);
                        }
                        else
                        {
                            var ctx = new LikeAndGoDataContext();
                            var predicate = PredicateBuilder.True<Event_Subscription>();
                            predicate = predicate.And(p => p.eid == eid).And(p => p.uid == uid);
                            var result=ctx.Event_Subscription.Where(predicate).Select(p=>p).First();
                            ctx.Event_Subscription.DeleteOnSubmit(result);
                            try
                            {
                                ctx.SubmitChanges();
                            }
                            catch (Exception exp)
                            {
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    Response.Write(exp);
                    Response.StatusCode = 406;

                    Response.End();

                }
            }
        }
    }
}