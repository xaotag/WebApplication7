using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WebApplication7.DBUtility;
using WebApplication7.Model;


namespace WebApplication7.DAL
{
	/// <summary>
	/// 数据访问类:Info_Logs_DAL
	/// </summary>
	public partial class Info_Logs_DAL
	{
		public Info_Logs_DAL()
		{ }
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid LogsID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from Info_Logs");
			strSql.Append(" where LogsID='" + LogsID + "' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Info_Logs_Model model)
		{
			StringBuilder strSql = new StringBuilder();
			StringBuilder strSql1 = new StringBuilder();
			StringBuilder strSql2 = new StringBuilder();
			if (model.LogsID != null)
			{
				strSql1.Append("LogsID,");
                strSql2.Append("'" + model.LogsID + "',");
			}
			if (model.LogsTitle != null)
			{
				strSql1.Append("LogsTitle,");
				strSql2.Append("'" + model.LogsTitle + "',");
			}
			if (model.LogsContent != null)
			{
				strSql1.Append("LogsContent,");
				strSql2.Append("'" + model.LogsContent + "',");
			}
			if (model.CoverPictureUrl != null)
			{
				strSql1.Append("CoverPictureUrl,");
				strSql2.Append("'" + model.CoverPictureUrl + "',");
			}
			if (model.CreateUser != null)
			{
				strSql1.Append("CreateUser,");
				strSql2.Append("'" + model.CreateUser+ "',");
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
			if (model.isDelete != null)
			{
				strSql1.Append("isDelete,");
				strSql2.Append("" + (model.isDelete ? 1 : 0) + ",");
			}
			if (model.Remark != null)
			{
				strSql1.Append("Remark,");
				strSql2.Append("'" + model.Remark + "',");
			}
			strSql.Append("insert into Info_Logs(");
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
		public bool Update(Info_Logs_Model model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update Info_Logs set ");
			if (model.LogsTitle != null)
			{
				strSql.Append("LogsTitle='" + model.LogsTitle + "',");
			}
			if (model.LogsContent != null)
			{
				strSql.Append("LogsContent='" + model.LogsContent + "',");
			}
			if (model.CoverPictureUrl != null)
			{
				strSql.Append("CoverPictureUrl='" + model.CoverPictureUrl + "',");
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
			if (model.isDelete != null)
			{
				strSql.Append("isDelete=" + (model.isDelete ? 1 : 0) + ",");
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
			strSql.Append(" where LogsID='" + model.LogsID + "' ");
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
		public bool Delete(Guid LogsID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from Info_Logs ");
			strSql.Append(" where LogsID='" + LogsID + "' ");
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
		public bool DeleteList(string LogsIDlist)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from Info_Logs ");
			strSql.Append(" where LogsID in (" + LogsIDlist + ")  ");
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
		public Info_Logs_Model GetModel(Guid LogsID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" LogsID,LogsTitle,LogsContent,CoverPictureUrl,CreateUser,CreateTime,UpdateUser,UpdateTime,isDelete,Remark ");
			strSql.Append(" from Info_Logs ");
			strSql.Append(" where LogsID='" + LogsID + "' ");
			Info_Logs_Model model = new Info_Logs_Model();
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
		public Info_Logs_Model DataRowToModel(DataRow row)
		{
			Info_Logs_Model model = new Info_Logs_Model();
			if (row != null)
			{
				if (row["LogsID"] != null && row["LogsID"].ToString() != "")
				{
					model.LogsID = new Guid(row["LogsID"].ToString());
				}
				if (row["LogsTitle"] != null)
				{
					model.LogsTitle = row["LogsTitle"].ToString();
				}
				if (row["LogsContent"] != null)
				{
					model.LogsContent = row["LogsContent"].ToString();
				}
				if (row["CoverPictureUrl"] != null)
				{
					model.CoverPictureUrl = row["CoverPictureUrl"].ToString();
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
				if (row["isDelete"] != null && row["isDelete"].ToString() != "")
				{
					if ((row["isDelete"].ToString() == "1") || (row["isDelete"].ToString().ToLower() == "true"))
					{
						model.isDelete = true;
					}
					else
					{
						model.isDelete = false;
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
			strSql.Append("select LogsID,LogsTitle,LogsContent,CoverPictureUrl,CreateUser,CreateTime,UpdateUser,UpdateTime,isDelete,Remark ");
			strSql.Append(" FROM Info_Logs ");
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
			strSql.Append(" LogsID,LogsTitle,LogsContent,CoverPictureUrl,CreateUser,CreateTime,UpdateUser,UpdateTime,isDelete,Remark ");
			strSql.Append(" FROM Info_Logs ");
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
			strSql.Append("select count(1) FROM Info_Logs ");
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
				strSql.Append("order by T.LogsID desc");
			}
			strSql.Append(")AS Row, T.*  from Info_Logs T ");
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

