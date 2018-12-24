using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    public class CopywriterRule
    {
        private int _ApplicationSortID;//申请类别编号
        private string _ApplicationName;//申请类别名称
        private int _ApplicationCountryID;//申请国家编号
        private string _ApplicationCountryName;//申请国家名称
        private double _ApplicationMoney;//申请国家金额
        private DateTime _GrantMoneyDate;//提成发放日期
        #region 申请类别编号
        public int ApplicationSortID
        {
            get
            {
                return _ApplicationSortID;
            }
            set
            {
                _ApplicationSortID = value;
            }
        }
        #endregion
        #region 申请类别名称
        public string ApplicationName
        {
            get
            {
                return _ApplicationName;
            }
            set
            {
                _ApplicationName = value;
            }
        }
        #endregion
        #region 申请国家编号
        public int ApplicationCountryID
        {
            get
            {
                return _ApplicationCountryID;
            }
            set
            {
                _ApplicationCountryID = value;
            }
        }
        #endregion
        #region 申请国家名称
        public string ApplicationCountryName
        {
            get
            {
                return _ApplicationCountryName;
            }
            set
            {
                _ApplicationCountryName = value;
            }
        }
        #endregion
        #region 申请国家金额
        public double ApplicationMoney
        {
            get
            {
                return _ApplicationMoney;
            }
            set
            {
                _ApplicationMoney = value;
            }
        }
        #endregion
        #region 提成发放日期
        public DateTime GrantMoneyDate
        {
            get
            {
                return _GrantMoneyDate;
            }
            set
            {
                _GrantMoneyDate = value;
            }
        }
        #endregion
    }
}
