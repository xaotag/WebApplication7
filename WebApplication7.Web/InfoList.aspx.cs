using System;
using System.Web.UI.WebControls;
using WebApplication7.BLL;
using WebApplication7.Model;
using System.Data;
using System.Text;

namespace WebApplication7.Web
{
    public partial class Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillRep();
            try
            {
                Session["AdminUser"].ToString();
                d1.Visible = false;
                //Response.Write();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
        /// <summary>
        /// 把数据填充到repeater控件上
        /// </summary>
        private void FillRep()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("IsDelete = 0");
            /*
            if (Session["AdminUser"] != null)
            {
                String admin = Session["AdminUser"].ToString();
                strSql.Append("and CreateUser = '" + admin.ToString() + "'");
            }
            */
           
            DataSet ds = new V_Logs_User_BLL().GetList(strSql.ToString());
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {   //LogID 用户ID
            var LogID = ((HiddenField)e.Item.FindControl("LogID")).Value;
            switch ((String)e.CommandName)
            {
                case "Title":
                    Detail(LogID);
                    break;
                case "del":
                    DelInfoLog(LogID);
                    break;
                case "modify":
                    ADDInfoInfoLog(LogID);
                    break;
            }
        }

        /// <summary>
        /// 跳转到LogDetail.aspx
        /// logID 用户ID
        /// </summary>
        /// <param name="LogID"></param>
        protected void Detail(String LogID)
        {
            if (!String.IsNullOrEmpty(LogID))
            {
                Response.Redirect("LogDetail.aspx?ID=" + LogID);
            }
        }
        /// <summary>
        ///  添加数据
        /// </summary>
        /// <param name="LogID">用户ID</param>
        protected void ADDInfoInfoLog(String LogID)
        {
            if (!String.IsNullOrEmpty(LogID) && Session["AdminUser"] != null)
            {
                Response.Redirect("AddInfoLog.aspx?ID=" + LogID + "&modify=1");
            }
            else
            {
                NoLogin();
            }
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="LogID"></param>
        protected void DelInfoLog(String LogID)
        {
            Info_Logs_Model logs = new Info_Logs_BLL().GetModel(new Guid(LogID));

            if (logs != null && Session["AdminUser"] != null)
            {
                logs.isDelete = true;
                new Info_Logs_BLL().Update(logs);
                FillRep();
            }
            else
            {
                NoLogin();
            }
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string admin = Session["AdminUser"].ToString();
                Response.Redirect("AddInfoLog.aspx");
            }
            catch (Exception)
            {
                NoLogin();
            }
        }

        /// <summary>
        ///  弹出未登录信息
        /// </summary>
        private void NoLogin()
        {
            Response.Write("<script>alert('账号未登录')</script>");
        }
    }
}