using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    public class SeaCommision
    {
        private int _SeaCommisionID; //海佣缴费编号
        private double _SeaCommisionTotalAmount;//海佣预估金额
        private int _SeaCommisionLimit;//海佣缴费预估年限
        private string _SeaCommisionCallsDate;// 海佣催缴时间
        private double _SeaCommisionActualAmount;//海佣实收金额
        private string _SeaCommisionGetDate;//海佣收到时间
        private string _ContractID;//合同编号
        private int _CustomerID;//客户编号ID

        #region 海佣缴费编号
        public int SeaCommisionID
        {
            get
            {
                return _SeaCommisionID;
            }
            set
            {
                _SeaCommisionID = value;
            }
        }
        #endregion

        #region 海佣预估金额
        public double SeaCommisionTotalAmount
        {
            get
            {
                return _SeaCommisionTotalAmount;
            }
            set
            {
                _SeaCommisionTotalAmount = value;
            }
        }
        #endregion

        #region 海佣缴费预估年限
        public int SeaCommisionLimit
        {
            get
            {
                return _SeaCommisionLimit;
            }
            set
            {
                _SeaCommisionLimit = value;
            }
        }
        #endregion

        #region 海佣催缴时间
        public string SeaCommisionCallsDate
        {
            get
            {
                return _SeaCommisionCallsDate;
            }
            set
            {
                _SeaCommisionCallsDate = value;
            }
        }
        #endregion

        #region 海佣实收金额
        public double SeaCommisionActualAmount
        {
            get
            {
                return _SeaCommisionActualAmount;
            }
            set
            {
                _SeaCommisionActualAmount = value;
            }
        }
        #endregion

        #region 海佣收到时间
        public string SeaCommisionGetDate
        {
            get
            {
                return _SeaCommisionGetDate;
            }
            set
            {
                _SeaCommisionGetDate = value;
            }
        }
        #endregion

        #region 合同编号
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

        #region 客户编号ID
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
