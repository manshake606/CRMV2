using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    public class ConsultantInCome
    {
        private int _DeductID;//顾问提成编号
        private double _Deduct;//顾问提成金额
        private DateTime _DeductDate;//顾问提成发放日期
        private int _StaffID;//员工编号ID
        private string _ContractID;//签约合同编号
        private int _PecentID;//提成基数编号
        #region 顾问提成编号
        public int DeductID
        {
            get
            {
                return _DeductID;
            }
            set
            {
                _DeductID = value;
            }
        }
        #endregion
        #region 顾问提成金额
        public double Deduct
        {
            get
            {
                return _Deduct;
            }
            set
            {
                _Deduct = value;
            }
        }
        #endregion
        #region 顾问提成金额发放日期
        public DateTime DeductDate
        {
            get
            {
                return _DeductDate;
            }
            set
            {
                _DeductDate = value;
            }
        }
        #endregion
        #region 顾问员工编号
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
        #region 签约合同编号
        public string  ContractID
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
        #region 顾问提成基数编号
        public int PecentID
        {
            get
            {
                return _PecentID;
            }
            set
            {
                _PecentID = value;
            }
        }
        #endregion
    }
}
