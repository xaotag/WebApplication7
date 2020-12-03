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
	/// 数据访问类:Info_Comments_DAL
	/// </summary>
	public partial class Info_Comments_DAL
	{
		public Info_Comments_DAL()
		{ }
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid Comment)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from Info_Comments");
			strSql.Append(" where Comment='" + Comment + "' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Info_Comments_Model model)
		{
			StringBuilder strSql = new StringBuilder();
			StringBuilder strSql1 = new StringBuilder();
			StringBuilder strSql2 = new StringBuilder();
			if (model.Comment != null)
			{
				strSql1.Append("Comment,");
				strSql2.Append("'" +model.Comment + "',");
			}
			if (model.LogID != null)
			{
				strSql1.Append("LogID,");
				strSql2.Append("'" +model.LogID + "',");
			}
			if (model.ComContent != null)
			{
				strSql1.Append("ComContent,");
				strSql2.Append("'" + model.ComContent + "',");
			}
			if (model.Commentators != null)
			{
				strSql1.Append("Commentators,");
				strSql2.Append("'" + model.Commentators + "',");
			}
			if (model.CommentTime != null)
			{
				strSql1.Append("CommentTime,");
				strSql2.Append("'" + model.CommentTime + "',");
			}
			if (model.isDelete != null)
			{
				strSql1.Append("isDelete,");
				strSql2.Append("" + (model.isDelete ? 1 : 0) + ",");
			}
			strSql.Append("insert into Info_Comments(");
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
		public bool Update(Info_Comments_Model model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update Info_Comments set ");
			if (model.LogID != null)
			{
				strSql.Append("LogID='" + model.LogID + "',");
			}
			if (model.ComContent != null)
			{
				strSql.Append("ComContent='" + model.ComContent + "',");
			}
			if (model.Commentators != null)
			{
				strSql.Append("Commentators='" + model.Commentators + "',");
			}
			if (model.CommentTime != null)
			{
				strSql.Append("CommentTime='" + model.CommentTime + "',");
			}
			if (model.isDelete != null)
			{
				strSql.Append("isDelete=" + (model.isDelete ? 1 : 0) + ",");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where Comment='" + model.Comment + "' ");
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
		public bool Delete(Guid Comment)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from Info_Comments ");
			strSql.Append(" where Comment='" + Comment + "' ");
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
		public bool DeleteList(string Commentlist)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from Info_Comments ");
			strSql.Append(" where Comment in (" + Commentlist + ")  ");
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
		public Info_Comments_Model GetModel(Guid Comment)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" Comment,LogID,ComContent,Commentators,CommentTime,isDelete ");
			strSql.Append(" from Info_Comments ");
			strSql.Append(" where Comment='" + Comment + "' ");
			Info_Comments_Model model = new Info_Comments_Model();
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
		public Info_Comments_Model DataRowToModel(DataRow row)
		{
			Info_Comments_Model model = new Info_Comments_Model();
			if (row != null)
			{
				if (row["Comment"] != null && row["Comment"].ToString() != "")
				{
					model.Comment = new Guid(row["Comment"].ToString());
				}
				if (row["LogID"] != null && row["LogID"].ToString() != "")
				{
					model.LogID = new Guid(row["LogID"].ToString());
				}
				if (row["ComContent"] != null)
				{
					model.ComContent = row["ComContent"].ToString();
				}
				if (row["Commentators"] != null && row["Commentators"].ToString() != "")
				{
					model.Commentators = new Guid(row["Commentators"].ToString());
				}
				if (row["CommentTime"] != null && row["CommentTime"].ToString() != "")
				{
					model.CommentTime = DateTime.Parse(row["CommentTime"].ToString());
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select Comment,LogID,ComContent,Commentators,CommentTime,isDelete ");
			strSql.Append(" FROM Info_Comments ");
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
			strSql.Append(" Comment,LogID,ComContent,Commentators,CommentTime,isDelete ");
			strSql.Append(" FROM Info_Comments ");
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
			strSql.Append("select count(1) FROM Info_Comments ");
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
				strSql.Append("order by T.Comment desc");
			}
			strSql.Append(")AS Row, T.*  from Info_Comments T ");
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

