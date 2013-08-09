using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Subscribe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //用户已登录
            //测试用，固定报名ID为2
            if (Page.User.Identity.IsAuthenticated)
            {

                Darili_User.Subscribe(2);

            }
        }
    }
}