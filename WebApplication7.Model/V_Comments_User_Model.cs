using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebApplication7.Model
{
    /// <summary>
    /// V_Comments_User_Model:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class V_Comments_User_Model
    {
        public V_Comments_User_Model()
        { }
        #region Model
        private Guid _comment;
        private Guid _logid;
        private string _comcontent;
        private Guid _commentators;
        private DateTime _commenttime;
        private bool _isdelete;
        private string _username;
        /// <summary>
        /// 
        /// </summary>
        public Guid Comment
        {
            set { _comment = value; }
            get { return _comment; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid LogID
        {
            set { _logid = value; }
            get { return _logid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ComContent
        {
            set { _comcontent = value; }
            get { return _comcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid Commentators
        {
            set { _commentators = value; }
            get { return _commentators; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CommentTime
        {
            set { _commenttime = value; }
            get { return _commenttime; }
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
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        #endregion Model

    }
}


