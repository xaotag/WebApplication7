using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebApplication7.Model
{
    /// <summary>
    /// Info_Comments_Model:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Info_Comments_Model
    {
        public Info_Comments_Model()
        { }
        #region Model
        private Guid _comment;
        private Guid _logid;
        private string _comcontent;
        private Guid _commentators;
        private DateTime _commenttime = DateTime.Now;
        private bool _isdelete;
        /// <summary>
        /// 评论ID

        /// </summary>
        public Guid Comment
        {
            set { _comment = value; }
            get { return _comment; }
        }
        /// <summary>
        /// 日志ID

        /// </summary>
        public Guid LogID
        {
            set { _logid = value; }
            get { return _logid; }
        }
        /// <summary>
        /// 回复
        /// </summary>
        public string ComContent
        {
            set { _comcontent = value; }
            get { return _comcontent; }
        }
        /// <summary>
        /// 评论人
        /// </summary>
        public Guid Commentators
        {
            set { _commentators = value; }
            get { return _commentators; }
        }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime CommentTime
        {
            set { _commenttime = value; }
            get { return _commenttime; }
        }
        /// <summary>
        /// 逻辑删除
        /// </summary>
        public bool isDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        #endregion Model

    }
}

