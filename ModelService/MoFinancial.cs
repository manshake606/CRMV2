using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    public class MoFinancial
    {
        private string _ContractID;//合同编号
        private string _SignDate;//签约日期
        private string _EndDate;//结案日期
        private int _Proxy;//是有有代理:0默认表示无,1表示有
        private string _ProxyName;//代理名称
        private string _RecommendPeople;//推荐人是除公司外人员
        private double _ReferralFees;//推荐费用
        private string _ReferralFeesPayDate;//推荐费支付时间
        private int _OutSourcing;//是否有外包:0表示无,1表示有
        private string _OutSourcingPeople;//外包人名字
        private double _OutSourcingFees;//外包人费用
        private string _OutSourcingPayDate;//外包费用支付时间
        private string _OutSourcingDirections;//外包说明备注
        private double _OtherFees;//其它费用支出
        private int _CustomerID;//客户编号ID
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
        #region 签约日期
        public string SignDate
        {
            get
            {
                return _SignDate;
            }
            set
            {
                _SignDate = value;
            }
        }
        #endregion
        #region 结案日期
        public string EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                _EndDate = value;
            }
        }
        #endregion
        #region 是有有代理信息
        public int Proxy
        {
            get
            {
                return _Proxy;
            }
            set
            {
                _Proxy = value;
            }
        }
        #endregion
        #region 代理名称
        public string ProxyName
        {
            get
            {
                return _ProxyName;
            }
            set
            {
                _ProxyName = value;
            }
        }
        #endregion
        #region 推荐人名称
        public string RecommendPeople
        {
            get
            {
                return _RecommendPeople;
            }
            set
            {
                _RecommendPeople = value;
            }
        }
        #endregion
        #region 推荐人费用金额
        public double ReferralFees
        {
            get
            {
                return _ReferralFees;
            }
            set
            {
                _ReferralFees = value;
            }
        }
        #endregion
        #region 推荐人费用支付日期
        public string ReferralFeesPayDate
        {
            get
            {
                return _ReferralFeesPayDate;
            }
            set
            {
                _ReferralFeesPayDate = value;
            }
        }
        #endregion
        #region 是有有外包
        public int OutSourcing
        {
            get
            {
                return _OutSourcing;
            }
            set
            {
                _OutSourcing = value;
            }
        }
        #endregion
        #region 外包人姓名
        public string OutSourcingPeople
        {
            get
            {
                return _OutSourcingPeople;
            }
            set
            {
                _OutSourcingPeople = value;
            }
        }
        #endregion
        #region 外包费用金额
        public double OutSourcingFees
        {
            get
            {
                return _OutSourcingFees;
            }
            set
            {
                _OutSourcingFees = value;
            }
        }
        #endregion
        #region 外包费用支付时间
        public string OutSourcingPayDate
        {
            get
            {
                return _OutSourcingPayDate;
            }
            set
            {
                _OutSourcingPayDate = value;
            }
        }
        #endregion
        #region 外包说明备注
        public string OutSourcingDirections
        {
            get
            {
                return _OutSourcingDirections;
            }
            set
            {
                _OutSourcingDirections = value;
            }
        }
        #endregion
        #region 其它费用支出
        public double OtherFees
        {
            get
            {
                return _OtherFees;
            }
            set
            {
                _OtherFees = value;
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
