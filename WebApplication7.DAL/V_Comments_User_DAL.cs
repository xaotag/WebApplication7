using System;
using System.Collections.Generic;
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
	/// 数据访问类:V_Comments_User_DAL
	/// </summary>
	public partial class V_Comments_User_DAL
	{
		public V_Comments_User_DAL()
		{ }
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid Comment)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from V_Comments_User");
			strSql.Append(" where Comment=@Comment ");
			SqlParameter[] parameters = {
					new SqlParameter("@Comment", SqlDbType.UniqueIdentifier,16)           };
			parameters[0].Value = Comment;

			return DbHelperSQL.Exists(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(V_Comments_User_Model model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into V_Comments_User(");
			strSql.Append("Comment,LogID,ComContent,Commentators,CommentTime,isDelete,UserName)");
			strSql.Append(" values (");
			strSql.Append("@Comment,@LogID,@ComContent,@Commentators,@CommentTime,@isDelete,@UserName)");
			SqlParameter[] parameters = {
					new SqlParameter("@Comment", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@LogID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ComContent", SqlDbType.VarChar,255),
					new SqlParameter("@Commentators", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CommentTime", SqlDbType.DateTime),
					new SqlParameter("@isDelete", SqlDbType.Bit,1),
					new SqlParameter("@UserName", SqlDbType.NVarChar,255)};
			parameters[0].Value = Guid.NewGuid();
			parameters[1].Value = Guid.NewGuid();
			parameters[2].Value = model.ComContent;
			parameters[3].Value = Guid.NewGuid();
			parameters[4].Value = model.CommentTime;
			parameters[5].Value = model.isDelete;
			parameters[6].Value = model.UserName;

			int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
		public bool Update(V_Comments_User_Model model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update V_Comments_User set ");
			strSql.Append("Comment=@Comment,");
			strSql.Append("LogID=@LogID,");
			strSql.Append("ComContent=@ComContent,");
			strSql.Append("Commentators=@Commentators,");
			strSql.Append("CommentTime=@CommentTime,");
			strSql.Append("isDelete=@isDelete,");
			strSql.Append("UserName=@UserName");
			strSql.Append(" where Comment=@Comment ");
			SqlParameter[] parameters = {
					new SqlParameter("@Comment", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@LogID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ComContent", SqlDbType.VarChar,255),
					new SqlParameter("@Commentators", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CommentTime", SqlDbType.DateTime),
					new SqlParameter("@isDelete", SqlDbType.Bit,1),
					new SqlParameter("@UserName", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.Comment;
			parameters[1].Value = model.LogID;
			parameters[2].Value = model.ComContent;
			parameters[3].Value = model.Commentators;
			parameters[4].Value = model.CommentTime;
			parameters[5].Value = model.isDelete;
			parameters[6].Value = model.UserName;

			int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(Guid Comment)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from V_Comments_User ");
			strSql.Append(" where Comment=@Comment ");
			SqlParameter[] parameters = {
					new SqlParameter("@Comment", SqlDbType.UniqueIdentifier,16)           };
			parameters[0].Value = Comment;

			int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Commentlist)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from V_Comments_User ");
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
		public V_Comments_User_Model GetModel(Guid Comment)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 Comment,LogID,ComContent,Commentators,CommentTime,isDelete,UserName from V_Comments_User ");
			strSql.Append(" where Comment=@Comment ");
			SqlParameter[] parameters = {
					new SqlParameter("@Comment", SqlDbType.UniqueIdentifier,16)           };
			parameters[0].Value = Comment;

			V_Comments_User_Model model = new V_Comments_User_Model();
			DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
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
		public V_Comments_User_Model DataRowToModel(DataRow row)
		{
			V_Comments_User_Model model = new V_Comments_User_Model();
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
				if (row["UserName"] != null)
				{
					model.UserName = row["UserName"].ToString();
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
			strSql.Append("select Comment,LogID,ComContent,Commentators,CommentTime,isDelete,UserName ");
			strSql.Append(" FROM V_Comments_User ");
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
			strSql.Append(" Comment,LogID,ComContent,Commentators,CommentTime,isDelete,UserName ");
			strSql.Append(" FROM V_Comments_User ");
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
			strSql.Append("select count(1) FROM V_Comments_User ");
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
			strSql.Append(")AS Row, T.*  from V_Comments_User T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "V_Comments_User";
			parameters[1].Value = "Comment";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

