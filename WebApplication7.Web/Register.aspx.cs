using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication7.Model;
using WebApplication7.BLL;


namespace WebApplication7.Web
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RegisterUser();
        }

        private void RegisterUser()
        {
            String UserName = TextBox1.Text.Trim();
            String UserNum = TextBox2.Text.Trim();
            String pwd = TextBox3.Text.Trim();
            if (!String.IsNullOrEmpty(UserName) && !String.IsNullOrEmpty(UserNum) && !String.IsNullOrEmpty(pwd))
            {
                Info_User_Model infoUserModel = new Info_User_Model();
                infoUserModel.UserlD = Guid.NewGuid();
                infoUserModel.UserName = UserName;
                infoUserModel.UserPhone = Convert.ToInt32(UserNum);
                infoUserModel.Pwd = pwd;
                infoUserModel.CreateUser = Guid.NewGuid();
                infoUserModel.CreateTime = DateTime.Now;
                infoUserModel.IsDelete = false;
                new Info_User_BLL().Add(infoUserModel);

            }
            else
            {
                Response.Write("<Script>alert(\"不能有空值\")<Script>");
            }
        }
    }
}