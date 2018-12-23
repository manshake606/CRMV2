using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    public class BindState
    {
        //绑定ID
        private int _BindID;
        //客户ID
        private int _CustomerID;
        //员工ID
        private int _StaffID;
        //绑定状态
        private int _BindStatus;


        #region 绑定ID
        /// <summary>
        /// 绑定ID
        /// </summary>
        public int BindID
        {
            get
            {
                return _BindID;
            }
            set
            {
                _BindID = value;
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

        #region 员工ID
        /// <summary>
        /// 员工ID
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

        #region 绑定状态
        /// <summary>
        /// 绑定状态
        /// </summary>
        public int BindStatus
        {
            get
            {
                return _BindStatus;
            }
            set
            {
                _BindStatus = value;
            }
        }
        #endregion

    }
}
