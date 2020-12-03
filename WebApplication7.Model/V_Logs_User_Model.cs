using System;


namespace WebApplication7.Model
{
	/// <summary>
	/// V_Logs_User_Model:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class V_Logs_User_Model
	{
		public V_Logs_User_Model()
		{ }
		#region Model
		private Guid _logsid;
		private string _logstitle;
		private string _logscontent;
		private string _coverpictureurl;
		private Guid _createuser;
		private DateTime _createtime;
		private Guid _updateuser;
		private DateTime? _updatetime;
		private bool _isdelete;
		private string _remark;
		private string _username;
		/// <summary>
		/// 
		/// </summary>
		public Guid LogsID
		{
			set { _logsid = value; }
			get { return _logsid; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string LogsTitle
		{
			set { _logstitle = value; }
			get { return _logstitle; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string LogsContent
		{
			set { _logscontent = value; }
			get { return _logscontent; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string CoverPictureUrl
		{
			set { _coverpictureurl = value; }
			get { return _coverpictureurl; }
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid CreateUser
		{
			set { _createuser = value; }
			get { return _createuser; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateTime
		{
			set { _createtime = value; }
			get { return _createtime; }
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid UpdateUser
		{
			set { _updateuser = value; }
			get { return _updateuser; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			set { _updatetime = value; }
			get { return _updatetime; }
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isDelete
		{
			set { _isdelete = value; }
			get { return _isdelete; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set { _remark = value; }
			get { return _remark; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set { _username = value; }
			get { return _username; }
		}
		#endregion Model

	}
}

