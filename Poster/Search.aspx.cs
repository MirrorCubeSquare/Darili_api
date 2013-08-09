using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darili_api;
using System.Linq.Expressions;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string q=Request.QueryString["q"];
            
            Darili_LinqDataContext ctx = new Darili_LinqDataContext();
            //添加内容：标题符合
            var predicate = PredicateBuilder.False<EventMain>();
            predicate = predicate.Or(p => p.Title.Contains(q));
            predicate = predicate.Or(p => p.Subtitle.Contains(q));
            predicate = predicate.Or(p => p.Location.Contains(q));
            predicate = predicate.Or(p => p.Series.Contains(q));
            var quary = ctx.EventMain.Where(predicate).Select(p => p.Id);
            var result = quary.ToList();
            Response.Write(result);




        }
    }
}