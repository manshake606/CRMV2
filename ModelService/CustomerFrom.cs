using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    public class CustomerFrom
    {
        //客户来源ID
        private int _CFID;
        //客户ID
        private int _CustomerID;
        //客户来源（0代表客户来源不明，1代表名单预约，2代表客户推荐，3代表移民推荐，4代表常州推荐，5代表主动上门，6代表网络来源，7代表个人渠道）
        private int _CustomerFr;
        //推荐备注
        private string _FromRemark;
        //推荐人
        private string _Reference;
        //数据来源
        private string _FromData;
        //备注
        private string _Remark;


        #region 客户来源ID
        /// <summary>
        /// 客户来源ID
        /// </summary>
        public int CFID
        {
            get
            {
                return _CFID;
            }
            set
            {
                _CFID = value;
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

        #region 客户来源
        /// <summary>
        /// 客户来源
        /// </summary>
        public int CustomerFr
        {
            get
            {
                return _CustomerFr;
            }
            set
            {
                _CustomerFr = value;
            }
        }
        #endregion

        #region 推荐备注
        /// <summary>
        /// 推荐备注
        /// </summary>
        public string FromRemark
        {
            get
            {
                return _FromRemark;
            }
            set
            {
                _FromRemark = value;
            }
        }
        #endregion

        #region 推荐人
        /// <summary>
        /// 推荐人
        /// </summary>
        public string Reference
        {
            get
            {
                return _Reference;
            }
            set
            {
                _Reference = value;
            }
        }
        #endregion

        #region 数据来源
        /// <summary>
        /// 数据来源
        /// </summary>
        public string FromData
        {
            get
            {
                return _FromData;
            }
            set
            {
                _FromData = value;
            }
        }
        #endregion

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


    }
}
