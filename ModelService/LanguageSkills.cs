using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
   public  class LanguageSkills
    {

        //语种编号ID
        private int _LGID;
        //客户ID
        private int _CustomerID;
        //语种名称
        private string _LGIName;
        //语言分数
        private string _Score;
        //导入时间
        private DateTime _ImportingDate;
        //备注
        private string _Remark;

        #region 语种编号ID
        /// <summary>
        /// 语种编号ID
        /// </summary>
        public int LGID
        {
            get
            {
                return _LGID;
            }
            set
            {
                _LGID = value;
            }
        }
        #endregion

        #region 客户ID
        /// <summary>
        /// 客户ID
        /// </summary>
        public int CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
            }
        }
        #endregion

        #region 语种名称
        /// <summary>
        /// 语种名称
        /// </summary>
        public string LGIName
        {
            get
            {
                return _LGIName;
            }
            set
            {
                _LGIName = value;
            }
        }
        #endregion

        #region 语言分数
        /// <summary>
        /// 语言分数
        /// </summary>
        public string Score
        {
            get
            {
                return _Score;
            }
            set
            {
                _Score = value;
            }
        }
        #endregion

        #region 导入时间
        /// <summary>
        /// 导入时间
        /// </summary>
        public DateTime ImportingDate
        {
            get
            {
                return _ImportingDate;
            }
            set
            {
                _ImportingDate = value;
            }
        }
        #endregion

        #region 备注
        /// <summary>
        /// 备注
        /// </summary>
        public String Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
            }
        }
        #endregion
    }
}
