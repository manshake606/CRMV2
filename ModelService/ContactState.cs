using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    public class ContactState
    {
        private int _CSID;
        #region 联系编号
        /// <summary>
        /// 联系编号
        /// </summary>
        public int CSID
        {
            get
            {
                return _CSID;
            }
            set
            {
                _CSID = value;
            }
        }
        #endregion

        private int _CustomerID;
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

        private string _CSContent;
        #region 联系的内容
        /// <summary>
        /// 联系的内容
        /// </summary>
        public string CSContent
        {
            get
            {
                return _CSContent;
            }
            set
            {
                _CSContent = value;
            }
        }
        #endregion

        private DateTime _CSDate;
        #region 联系的时间
        /// <summary>
        /// 联系的时间
        /// </summary>
        public DateTime CSDate
        {
            get
            {
                return _CSDate;
            }
            set
            {
                _CSDate = value;
            }
        }
        #endregion

        private string _Remark;
        #region 备注
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
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

        private int _StaffID;
        #region 员工编号
        /// <summary>
        /// 员工编号
        /// </summary>
        public int StaffID
        {
            get
            {
                return _StaffID;
            }
            set
            {
                _StaffID = value;
            }
        }
        #endregion



    }
}
