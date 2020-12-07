using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication7.BLL;

namespace WebApplication7.Web
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Repeater1.DataSource = new Info_User_BLL().GetList("UserlD = '" + Session["AdminUser"].ToString() + "'");
                DataBind();
            }
            catch (Exception )
            {
               Response.Redirect("Login.aspx");
            }
        }
    }
}