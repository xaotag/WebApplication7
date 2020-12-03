using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WebApplication7.Model;
using WebApplication7.DAL;

namespace WebApplication7.BLL
{
	/// <summary>
	/// Info_Comments_BLL
	/// </summary>
	public partial class Info_Comments_BLL
    {
        private readonly Info_Comments_DAL dal = new Info_Comments_DAL();
		                                            
        public Info_Comments_BLL()
		{ }
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid Comment)
		{
			return dal.Exists(Comment);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Info_Comments_Model model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Info_Comments_Model model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(Guid Comment)
		{

			return dal.Delete(Comment);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Commentlist)
		{
			return dal.DeleteList(Commentlist);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Info_Comments_Model GetModel(Guid Comment)
		{

			return dal.GetModel(Comment);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
            DataSet ds =dal.GetList(strWhere);
            return ds;
        }
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			return dal.GetList(Top, strWhere, filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Info_Comments_Model> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Info_Comments_Model> DataTableToList(DataTable dt)
		{
			List<Info_Comments_Model> modelList = new List<Info_Comments_Model>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Info_Comments_Model model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
		//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

