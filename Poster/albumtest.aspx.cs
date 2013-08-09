using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class albumtest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 1;
        var result = Darili_Extra.GetAlbum(id,Server.MapPath("./"));
        Response.Write(result);
    }
}