using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    public class ConsultantRule
    {
        private int _RateID;//提成点数编号
        private string _CommisionName;//提成点数名称
        private double _CommisionRate;//普通顾问提成点数数据
        private double _InternCommisionPoint;//实习顾问提成点数数据
        #region 提成点数编号
        public int RateID
        {
            get
            {
                return _RateID;
            }
            set
            {
                _RateID = value;
            }
        }
        #endregion
        #region 提成点数名称
        public string CommisionName
        {
            get
            {
                return _CommisionName;
            }
            set
            {
                _CommisionName = value;
            }
        }
        #endregion
        #region 普通顾问提成点数数据
        public double CommisionRate
        {
            get
            {
                return _CommisionRate;
            }
            set
            {
                _CommisionRate = value;
            }
        }
        #endregion
        #region 实习顾问提成点数数据
        public double InternCommisionPoint
        {
            get
            {
                return _InternCommisionPoint;
            }
            set
            {
                _InternCommisionPoint = value;
            }
        }
        #endregion
    }
}
