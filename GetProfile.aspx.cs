using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class GetProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(JsonConvert.SerializeXNode(Darili_User.Validate_StuDeatil(Request.Cookies["webpy_session_id"]).Translate_Xml(),Formatting.None,true));

    }
}