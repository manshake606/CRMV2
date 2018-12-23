using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    public class AssignState
    {
        //指派编号
        private int _AssignID;
        //指派员工编号
        private int _DStaffID;
        //客户编号
        private int _CustomerID;
        //被指派员工号
        private int _GStaffID;
        //记录状态
        private int _CustomerBindStatus;
        //指派状态
        private int _AssignStatus;
        //指派的时间
        private DateTime _AssignTime;


        #region 记录编号
        /// <summary>
        /// 记录编号
        /// </summary>
        public int AssignID
        {
            get
            {
                return _AssignID;
            }
            set
            {
                _AssignID = value;
            }
        }
        #endregion


        #region 指派员工编号
        /// <summary>
        /// 指派员工编号
        /// </summary>
        public int DStaffID
        {
            get
            {
                return _DStaffID;
            }
            set
            {
                _DStaffID = value;
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


        #region 被指派员工号
        /// <summary>
        /// 被指派员工号
        /// </summary>
        public int GStaffID
        {
            get
            {
                return _GStaffID;
            }
            set
            {
                _GStaffID = value;
            }
        }
        #endregion


        #region 记录状态
        /// <summary>
        /// 记录状态
        /// </summary>
        public int CustomerBindStatus
        {
            get
            {
                return _CustomerBindStatus;
            }
            set
            {
                _CustomerBindStatus = value;
            }
        }
        #endregion


        #region 指派状态
        /// <summary>
        /// 指派状态
        /// </summary>
        public int AssignStatus
        {
            get
            {
                return _AssignStatus;
            }
            set
            {
                _AssignStatus = value;
            }
        }
        #endregion


        #region 绑定的时间
        /// <summary>
        /// 绑定的时间
        /// </summary>
        public DateTime AssignTime
        {
            get
            {
                return _AssignTime;
            }
            set
            {
                _AssignTime = value;
            }
        }
        #endregion
    }
}
