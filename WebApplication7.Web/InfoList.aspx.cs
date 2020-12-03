using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication7.BLL;
using WebApplication7.DAL;
using WebApplication7.Model;
using System.Data;

namespace WebApplication7.Web
{
    public partial class Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillRep();
            if (!this.IsPostBack)
            {
                try
                {

                    String admin = Session["AdminUser"].ToString();
                    d1.Visible = false;
                    //Response.Write();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

            }
        }

        private void FillRep()
        {
            DataSet ds = new V_Logs_User_BLL().GetList("IsDelete =0");
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {


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

        protected void Detail(String LogID)
        {
            if (!String.IsNullOrEmpty(LogID))
            {
                Response.Redirect("LogDetail.aspx?ID=" + LogID);
            }
        }
        protected void ADDInfoInfoLog(String LogID)
        {
            if (!String.IsNullOrEmpty(LogID) && Session["AdminUser"] != null)
            {
                Response.Redirect("AddInfoLog.aspx?ID=" + LogID + "&modify=1");
            }
        }

        protected void DelInfoLog(String LogID)
        {
            Info_Logs_Model logs = new Info_Logs_BLL().GetModel(new Guid(LogID));

            if (logs != null && Session["AdminUser"] != null)
            {
                logs.isDelete = true;
                new Info_Logs_BLL().Update(logs);
                FillRep();
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
                Response.Write("<script>alert('账号未登录')</script>");
            }
        }
    }
}