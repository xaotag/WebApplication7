using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication7.BLL;
using WebApplication7.Model;

namespace WebApplication7.Web
{
    public partial class AddInfoLog : System.Web.UI.Page
    {
        protected int modify;
        protected String LogsID;

        protected void Page_Load(object sender, EventArgs e)
        {
            modify = Convert.ToInt32(Request["modify"]);
            LogsID = Request["ID"];
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(LogsID))
                {
                    FillData();
                }
            }

            try
            {
                //Session 为空时触发异常
                Session["AdminUser"].ToString();
            }
            catch (Exception exception)
            {
                Response.Redirect("Login.aspx");
                Console.WriteLine(exception);
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {

            switch (modify)
            {
                case 1:
                    //修改数据
                    modifyData();
                    break;
                default:
                    //添加数据
                    addInfo();
                    break;
            }


        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        private void addInfo()
        {
            string admin = Session["AdminUser"].ToString();
            string title = TextBox1.Text;
            string info = TxtAr.Value;
            if (!String.IsNullOrEmpty(title) && !String.IsNullOrEmpty(info))
            {
                Info_Logs_Model usermodel = new Info_Logs_Model();
                usermodel.LogsID = Guid.NewGuid();
                usermodel.LogsTitle = title;
                usermodel.LogsContent = info;
                usermodel.CoverPictureUrl = "/img/1.jpg";
                usermodel.CreateUser = new Guid(admin);
                usermodel.CreateTime = DateTime.Now;
                usermodel.isDelete = false;
                new Info_Logs_BLL().Add(usermodel);
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void FillData()
        {

            Info_Logs_Model logsModel = new Info_Logs_BLL().GetModel(new Guid(LogsID));
            TextBox1.Text = logsModel.LogsTitle;
            TxtAr.Value = logsModel.LogsContent;
            Button1.Text = "更新";
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        private void modifyData()
        {
            Info_Logs_Model logsModel = new Info_Logs_BLL().GetModel(new Guid(LogsID));
            logsModel.LogsContent = TxtAr.Value;
            logsModel.LogsTitle = TextBox1.Text;
            new Info_Logs_BLL().Update(logsModel);
        }
    }
}