using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    public class CopywriterDeductIncom
    {
        private int _CopywriterDeductID;//文案提成编号
        private int _ApplicationCountryID;//申请国家编号
        private int _ApplicationSortID;//申请类别编号
        private int _CopywriterID;//文案员工编号
        private string _ContractID;//客户签署合同编号

        #region 文案提成编号
        public int CopywriterDeductID
        {
            get
            {
                return _CopywriterDeductID;
            }
            set
            {
                _CopywriterDeductID = value;
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

        #region 文案员工编号
        public int CopywriterID
        {
            get
            {
                return _CopywriterID;
            }
            set
            {
                _CopywriterID = value;
            }
        }
        #endregion

        #region 客户签署合同编号
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
    }
}
