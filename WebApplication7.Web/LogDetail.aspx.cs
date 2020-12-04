using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using WebApplication7.BLL;
using WebApplication7.Model;

namespace WebApplication7.Web
{
    public partial class LogDetail : System.Web.UI.Page
    {
        protected String LogDetailID;

        protected void Page_Init(object sender, EventArgs e)
        {
            LogDetailID = Request["ID"];
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LogDetailID = Request["ID"];
                if (!String.IsNullOrEmpty(LogDetailID))
                {
                    Info_Logs_Model logModel = new Info_Logs_BLL().GetModel(new Guid(LogDetailID));
                    TextDiv1.InnerText = logModel.LogsContent;
                    Title.InnerText = logModel.LogsTitle;
                    AddComment();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string UserGuid = Session["AdminUser"].ToString();
                string ComContext = TextBox1.Text;
                if (!String.IsNullOrEmpty(ComContext))
                {
                    Info_Comments_Model infoComments = new Info_Comments_Model();
                    infoComments.Comment = Guid.NewGuid();
                    infoComments.LogID = new Guid(LogDetailID);
                    infoComments.ComContent = ComContext;
                    infoComments.Commentators = new Guid(UserGuid);
                    // Response.Write(UserGuid.ToString());
                    new Info_Comments_BLL().Add(infoComments);
                }

                AddComment();
            }
            catch (Exception)
            {
                Response.Write("<script>alert(\"账号未登录\")</script>");
                Response.Redirect("Login.aspx");
                throw;
            }
        }
        /// <summary>
        ///  添加评论
        /// </summary>
        public void AddComment()
        {
            Repeater1.DataSource = new V_Comments_User_BLL().GetList("LogID = '" + LogDetailID + "'");
            Repeater1.DataBind();
        }
    }
}