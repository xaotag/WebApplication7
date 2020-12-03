using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WebApplication7.Model;
using WebApplication7.DBUtility;


namespace WebApplication7.DAL
{
    /// <summary>
    /// 数据访问类:Info_User_DAL
    /// </summary>
    public partial class Info_User_DAL
    {
        public Info_User_DAL()
        { }
        #region  Method


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid UserlD)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Info_User");
            strSql.Append(" where UserlD='" + UserlD + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserPhone, string Pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Info_User");
            strSql.Append(" where  UserPhone = " + UserPhone + " and  Pwd='" + Pwd + "'");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Info_User_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.UserlD != null)
            {
                strSql1.Append("UserlD,");
                strSql2.Append("'" + model.UserlD + "',");
            }
            if (model.UserName != null)
            {
                strSql1.Append("UserName,");
                strSql2.Append("'" + model.UserName + "',");
            }
            if (model.UserAvatar != null)
            {
                strSql1.Append("UserAvatar,");
                strSql2.Append("'" + model.UserAvatar + "',");
            }
            if (model.UserSex != null)
            {
                strSql1.Append("UserSex,");
                strSql2.Append("" + model.UserSex + ",");
            }
            if (model.UserPhone != null)
            {
                strSql1.Append("UserPhone,");
                strSql2.Append("" + model.UserPhone + ",");
            }
            if (model.AccountNum != null)
            {
                strSql1.Append("AccountNum,");
                strSql2.Append("'" + model.AccountNum + "',");
            }
            if (model.Pwd != null)
            {
                strSql1.Append("Pwd,");
                strSql2.Append("'" + model.Pwd + "',");
            }
            if (model.CreateUser != null)
            {
                strSql1.Append("CreateUser,");
                strSql2.Append("'" + model.CreateUser + "',");
            }
            if (model.CreateTime != null)
            {
                strSql1.Append("CreateTime,");
                strSql2.Append("'" + model.CreateTime + "',");
            }
            if (model.UpdateUser != null)
            {
                strSql1.Append("UpdateUser,");
                strSql2.Append("'" + model.UpdateUser + "',");
            }
            if (model.UpdateTime != null)
            {
                strSql1.Append("UpdateTime,");
                strSql2.Append("'" + model.UpdateTime + "',");
            }
            if (model.IsDelete != null)
            {
                strSql1.Append("IsDelete,");
                strSql2.Append("" + (model.IsDelete ? 1 : 0) + ",");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            strSql.Append("insert into Info_User(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Info_User_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Info_User set ");
            if (model.UserName != null)
            {
                strSql.Append("UserName='" + model.UserName + "',");
            }
            else
            {
                strSql.Append("UserName= null ,");
            }
            if (model.UserAvatar != null)
            {
                strSql.Append("UserAvatar='" + model.UserAvatar + "',");
            }
            else
            {
                strSql.Append("UserAvatar= null ,");
            }
            if (model.UserSex != null)
            {
                strSql.Append("UserSex=" + model.UserSex + ",");
            }
            else
            {
                strSql.Append("UserSex= null ,");
            }
            if (model.UserPhone != null)
            {
                strSql.Append("UserPhone=" + model.UserPhone + ",");
            }
            else
            {
                strSql.Append("UserPhone= null ,");
            }
            if (model.AccountNum != null)
            {
                strSql.Append("AccountNum='" + model.AccountNum + "',");
            }
            else
            {
                strSql.Append("AccountNum= null ,");
            }
            if (model.Pwd != null)
            {
                strSql.Append("Pwd='" + model.Pwd + "',");
            }
            else
            {
                strSql.Append("Pwd= null ,");
            }
            if (model.CreateUser != null)
            {
                strSql.Append("CreateUser='" + model.CreateUser + "',");
            }
            if (model.CreateTime != null)
            {
                strSql.Append("CreateTime='" + model.CreateTime + "',");
            }
            if (model.UpdateUser != null)
            {
                strSql.Append("UpdateUser='" + model.UpdateUser + "',");
            }
            else
            {
                strSql.Append("UpdateUser= null ,");
            }
            if (model.UpdateTime != null)
            {
                strSql.Append("UpdateTime='" + model.UpdateTime + "',");
            }
            else
            {
                strSql.Append("UpdateTime= null ,");
            }
            if (model.IsDelete != null)
            {
                strSql.Append("IsDelete=" + (model.IsDelete ? 1 : 0) + ",");
            }
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where UserlD='" + model.UserlD + "' ");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid UserlD)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Info_User ");
            strSql.Append(" where UserlD='" + UserlD + "' ");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }       /// <summary>
                /// 批量删除数据
                /// </summary>
        public bool DeleteList(string UserlDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Info_User ");
            strSql.Append(" where UserlD in (" + UserlDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Info_User_Model GetModel(Guid UserlD)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" UserlD ");
            strSql.Append(" from Info_User ");
            strSql.Append(" where UserlD='" + UserlD + "' ");
            Info_User_Model model = new Info_User_Model();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Info_User_Model GetModel(int UserPhone, string Pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" UserlD,UserName,UserAvatar,UserSex,UserPhone,AccountNum,Pwd,CreateUser,CreateTime,UpdateUser,UpdateTime,IsDelete,Remark ");
            strSql.Append(" from Info_User ");
            strSql.Append(" where UserPhone='" + UserPhone + "' and  Pwd = '"+Pwd+"'");
            Info_User_Model model = new Info_User_Model();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Info_User_Model DataRowToModel(DataRow row)
        {
            Info_User_Model model = new Info_User_Model();
            if (row != null)
            {
                if (row["UserlD"] != null && row["UserlD"].ToString() != "")
                {
                    model.UserlD = new Guid(row["UserlD"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["UserAvatar"] != null)
                {
                    model.UserAvatar = row["UserAvatar"].ToString();
                }
                if (row["UserSex"] != null && row["UserSex"].ToString() != "")
                {
                    model.UserSex = int.Parse(row["UserSex"].ToString());
                }
                if (row["UserPhone"] != null && row["UserPhone"].ToString() != "")
                {
                    model.UserPhone = int.Parse(row["UserPhone"].ToString());
                }
                if (row["AccountNum"] != null)
                {
                    model.AccountNum = row["AccountNum"].ToString();
                }
                if (row["Pwd"] != null)
                {
                    model.Pwd = row["Pwd"].ToString();
                }
                if (row["CreateUser"] != null && row["CreateUser"].ToString() != "")
                {
                    model.CreateUser = new Guid(row["CreateUser"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["UpdateUser"] != null && row["UpdateUser"].ToString() != "")
                {
                    model.UpdateUser = new Guid(row["UpdateUser"].ToString());
                }
                if (row["UpdateTime"] != null && row["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
                }
                if (row["IsDelete"] != null && row["IsDelete"].ToString() != "")
                {
                    if ((row["IsDelete"].ToString() == "1") || (row["IsDelete"].ToString().ToLower() == "true"))
                    {
                        model.IsDelete = true;
                    }
                    else
                    {
                        model.IsDelete = false;
                    }
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserlD,UserName,UserAvatar,UserSex,UserPhone,AccountNum,Pwd,CreateUser,CreateTime,UpdateUser,UpdateTime,IsDelete,Remark ");
            strSql.Append(" FROM Info_User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" UserlD,UserName,UserAvatar,UserSex,UserPhone,AccountNum,Pwd,CreateUser,CreateTime,UpdateUser,UpdateTime,IsDelete,Remark ");
            strSql.Append(" FROM Info_User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Info_User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.UserlD desc");
            }
            strSql.Append(")AS Row, T.*  from Info_User T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
		*/

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

