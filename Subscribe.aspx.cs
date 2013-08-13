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
        XElement Ele=new XElement("root",
            new XElement("Cellphone",18817361921),
            new XElement("Realname","徐一唯"),
            new XElement("times",new XElement("starttime","2013-08-01 0:01:02"),
                                 new XElement("endtime","2013-08-03 2:22:22")),
            new XElement("times", new XElement("starttime", "2013-08-04 0:01:02"),
                                 new XElement("endtime", "2013-08-06 2:22:22"))
                                 );

        string json = @"{'root':{'Cellphone':'18817361921','Realname':'徐一唯','times':[{'starttime':'2013-08-01 0:01:02','endtime':'2013-08-03 2:22:22'},{'starttime':'2013-08-04 0:01:02','endtime':'2013-08-06 2:22:22'}]}} ";

        if (!IsPostBack)
        {
           
            if (Page.User.Identity.IsAuthenticated)
            {
                int eid = int.Parse(Request.QueryString["id"]);
                if (Event.EventExists(eid))
                {
                    //var json = JsonConvert.SerializeXNode(Ele);

                   var param=XElement.Parse(JsonConvert.DeserializeXmlNode(json).InnerXml);
                   Darili_Subsciption.SubscribeEvent(eid, param);

                   Response.Write(param.ToString());
                }
            }
        }
    }
}