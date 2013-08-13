using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using Darili_api;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        XElement ele = new XElement("root",
                                         new XElement("Para", "Cellphone"),
                                         new XElement("Para", "Realname"));
        LikeAndGoDataContext ctx = new LikeAndGoDataContext();
        Event_Subscription_Parameters para = new Event_Subscription_Parameters
        {
            eid = 23,
            parameters = ele
        };
        ctx.Event_Subscription_Parameters.InsertOnSubmit(para);
        ctx.SubmitChanges();
        Response.ClearContent();
        Response.Write("success");
    }
}