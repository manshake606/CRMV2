using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    public class MoPayment
    {
        //缴款编号
        private int _PaymentID;
        //合同金额
        private double _FeesTotal;
        //缴款金额
        private double _PaymentFees;
        //缴款日期
        private string _PaymentDate;
        //合同编号
        private string _ContractID;
        //客户编号
        private int _CustomerID;

        #region 缴款编号
        /// <summary>
        /// 缴款编号
        /// </summary>
        public int PaymentID
        {
            get
            {
                return _PaymentID;
            }
            set
            {
                _PaymentID = value;
            }
        }
        #endregion


        #region 合同金额
        /// <summary>
        /// 合同金额
        /// </summary>
        public double FeesTotal
        {
            get
            {
                return _FeesTotal;
            }
            set
            {
                _FeesTotal = value;
            }
        }
        #endregion


        #region 缴款金额
        /// <summary>
        /// 缴款金额
        /// </summary>
        public double PaymentFees
        {
            get
            {
                return _PaymentFees;
            }
            set
            {
                _PaymentFees = value;
            }
        }
        #endregion


        #region 缴款日期
        /// <summary>
        /// 缴款日期
        /// </summary>
        public string PaymentDate
        {
            get
            {
                return _PaymentDate;
            }
            set
            {
                _PaymentDate = value;
            }
        }
        #endregion


        #region 合同编号
        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractID
        {
            get
            {
                return _ContractID;
            }
            set
            {
                _ContractID = value;
            }
        }
        #endregion


        #region 客户编号
        /// <summary>
        /// 客户编号
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
    }
}
