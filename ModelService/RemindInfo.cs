using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    public class RemindInfo
    {

        //提醒编号
        private int _RIID;
        //客户ID
        private int _CustomerID;
        //提醒标识
        private int _IsRemind;
        //下次提醒时间（提醒了下次联系）
        private DateTime _NextContactTime;
        //备注
        private string _Remark;

        #region 提醒编号
        /// <summary>
        /// 提醒编号
        /// </summary>
        public int RIID
        {
            get
            {
                return _RIID;
            }
            set
            {
                _RIID = value;
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

        #region 提醒标识
        /// <summary>
        /// 提醒标识
        /// </summary>
        public int IsRemind
        {
            get
            {
                return _IsRemind;
            }
            set
            {
                _IsRemind = value;
            }
        }
        #endregion

        #region 下次提醒时间
        /// <summary>
        /// 下次提醒时间
        /// </summary>
        public DateTime NextContactTime
        {
            get
            {
                return _NextContactTime;
            }
            set
            {
                _NextContactTime = value;
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
