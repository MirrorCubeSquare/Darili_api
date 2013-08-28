using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class g_Poster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "image/jpeg";
        int eid = Request.QueryString["id"] != "" ? int.Parse(Request.QueryString["id"]) : 0;
        var ctx = new PosterDataContext();
        var quary = ctx.Event_Poster.Where(p => p.Event_id == eid).Select(p=>p.thumb_stream);
        if (quary.Count() > 0)
        {
            var result = quary.First();
            Response.BinaryWrite(result.ToArray());
        }
        else
        {
            var nopic = System.Drawing.Image.FromFile(Server.MapPath("./") + "/img/pic-bigger.png");
            var str = new System.IO.MemoryStream();
            nopic.Save(str, nopic.RawFormat);
            Response.BinaryWrite(str.ToArray());
            nopic.Dispose();
            str.Dispose();

        }

    }
}