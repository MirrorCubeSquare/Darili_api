using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darili_api;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GetParameters : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int eid = new int();

            int.TryParse(Request.QueryString["eid"],out eid);
        Darili_Subscription_Parameters param = new Darili_Subscription_Parameters(eid);
        XElement result_root = Darili_Extra.ForceArray(new XElement("root"), true);
        if (param.root != null)
        {

            if (param.root.Elements().Count() > 0)
            {
                foreach (XElement child in param.root.Elements())
                {
                    result_root.Add(Darili_Extra.ForceArray(child, false));
                }
            }
        }
        Response.Write(JsonConvert.SerializeXNode(result_root,Newtonsoft.Json.Formatting.None,true));

    }
}