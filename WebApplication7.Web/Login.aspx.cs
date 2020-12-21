using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication7.BLL;

namespace WebApplication7.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            UserLogin();

        }

        /// <summary>
        /// 登录
        /// </summary>
        private void UserLogin()
        {
            int userNum = Convert.ToInt32(TextBox1.Text.Trim());
            string pwd = TextBox2.Text.Trim();
            if (new Info_User_BLL().Exists(userNum, pwd))
            {
                Session["AdminUser"] = new Info_User_BLL().GetModel(userNum, pwd).UserlD.ToString();
                Response.Redirect("Home.aspx");
            }
        }
    }
}