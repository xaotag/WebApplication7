﻿using System;
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
	/// 数据访问类:V_Logs_User_DAL
	/// </summary>
	public partial class V_Logs_User_DAL
	{
		public V_Logs_User_DAL()
		{ }
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid LogsID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from V_Logs_User");
			strSql.Append(" where LogsID=@LogsID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LogsID", SqlDbType.UniqueIdentifier,16)            };
			parameters[0].Value = LogsID;

			return DbHelperSQL.Exists(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(V_Logs_User_Model model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into V_Logs_User(");
			strSql.Append("LogsID,LogsTitle,LogsContent,CoverPictureUrl,CreateUser,CreateTime,UpdateUser,UpdateTime,isDelete,Remark,UserName)");
			strSql.Append(" values (");
			strSql.Append("@LogsID,@LogsTitle,@LogsContent,@CoverPictureUrl,@CreateUser,@CreateTime,@UpdateUser,@UpdateTime,@isDelete,@Remark,@UserName)");
			SqlParameter[] parameters = {
					new SqlParameter("@LogsID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@LogsTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@LogsContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@CoverPictureUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@CreateUser", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@isDelete", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,255)};
			parameters[0].Value = Guid.NewGuid();
			parameters[1].Value = model.LogsTitle;
			parameters[2].Value = model.LogsContent;
			parameters[3].Value = model.CoverPictureUrl;
			parameters[4].Value = Guid.NewGuid();
			parameters[5].Value = model.CreateTime;
			parameters[6].Value = Guid.NewGuid();
			parameters[7].Value = model.UpdateTime;
			parameters[8].Value = model.isDelete;
			parameters[9].Value = model.Remark;
			parameters[10].Value = model.UserName;

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
		public bool Update(V_Logs_User_Model model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update V_Logs_User set ");
			strSql.Append("LogsID=@LogsID,");
			strSql.Append("LogsTitle=@LogsTitle,");
			strSql.Append("LogsContent=@LogsContent,");
			strSql.Append("CoverPictureUrl=@CoverPictureUrl,");
			strSql.Append("CreateUser=@CreateUser,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateUser=@UpdateUser,");
			strSql.Append("UpdateTime=@UpdateTime,");
			strSql.Append("isDelete=@isDelete,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("UserName=@UserName");
			strSql.Append(" where LogsID=@LogsID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LogsID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@LogsTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@LogsContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@CoverPictureUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@CreateUser", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@isDelete", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.LogsID;
			parameters[1].Value = model.LogsTitle;
			parameters[2].Value = model.LogsContent;
			parameters[3].Value = model.CoverPictureUrl;
			parameters[4].Value = model.CreateUser;
			parameters[5].Value = model.CreateTime;
			parameters[6].Value = model.UpdateUser;
			parameters[7].Value = model.UpdateTime;
			parameters[8].Value = model.isDelete;
			parameters[9].Value = model.Remark;
			parameters[10].Value = model.UserName;

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
		public bool Delete(Guid LogsID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from V_Logs_User ");
			strSql.Append(" where LogsID=@LogsID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LogsID", SqlDbType.UniqueIdentifier,16)            };
			parameters[0].Value = LogsID;

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
		public bool DeleteList(string LogsIDlist)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from V_Logs_User ");
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
		public V_Logs_User_Model GetModel(Guid LogsID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 LogsID,LogsTitle,LogsContent,CoverPictureUrl,CreateUser,CreateTime,UpdateUser,UpdateTime,isDelete,Remark,UserName from V_Logs_User ");
			strSql.Append(" where LogsID=@LogsID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LogsID", SqlDbType.UniqueIdentifier,16)            };
			parameters[0].Value = LogsID;

			V_Logs_User_Model model = new V_Logs_User_Model();
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
		public V_Logs_User_Model DataRowToModel(DataRow row)
		{
			V_Logs_User_Model model = new V_Logs_User_Model();
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
			strSql.Append("select LogsID,LogsTitle,LogsContent,CoverPictureUrl,CreateUser,CreateTime,UpdateUser,UpdateTime,isDelete,Remark,UserName ");
			strSql.Append(" FROM V_Logs_User ");
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
			strSql.Append(" LogsID,LogsTitle,LogsContent,CoverPictureUrl,CreateUser,CreateTime,UpdateUser,UpdateTime,isDelete,Remark,UserName ");
			strSql.Append(" FROM V_Logs_User ");
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
			strSql.Append("select count(1) FROM V_Logs_User ");
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
			strSql.Append(")AS Row, T.*  from V_Logs_User T ");
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
			parameters[0].Value = "V_Logs_User";
			parameters[1].Value = "LogsID";
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

