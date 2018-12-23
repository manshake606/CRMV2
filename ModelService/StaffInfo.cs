using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    public class StaffInfo
    {
        //员工编号
        private int _StaffID;
        //员工姓名
        private string _StaffName;
        //员工密码
        private string _Password;
        //生日
        private string _Birthday;
        //员工性别
        private int _StaffSex;
        //员工电话
        private string _Phone;
        //员工邮箱
        private string _Email;
        //职位编号
        private int _PostID;
        //员工直属上司
        private int _DirectlyID;
        //员工入职日期
        private string _EmployeeDate;
        //权限
        private string _Authority;
        //员工公司地址
        private string _CompanyAddress;
        //公司省份
        private string _CompanyProvice;
        //员工属性
        private string _StaffProperty;
        //是否允许登录
        private int _Enable;
        //员工登录名
        private string _LoginName;

        #region 员工编号
        /// <summary>
        /// 员工编号
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

        #region 员工姓名
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string StaffName
        {
            get
            {
                return _StaffName;
            }
            set
            {
                _StaffName = value;
            }
        }
        #endregion


        #region 员工密码
        /// <summary>
        /// 员工密码
        /// </summary>
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }
        #endregion

        
        #region 生日
        /// <summary>
        /// 生日
        /// </summary>
        public string Birthday
        {
            get
            {
                return _Birthday;
            }
            set
            {
                _Birthday = value;
            }
        }
        #endregion

        
        #region 员工性别
        /// <summary>
        /// 员工性别
        /// </summary>
        public int StaffSex
        {
            get
            {
                return _StaffSex;
            }
            set
            {
                _StaffSex = value;
            }
        }
        #endregion

        
        #region 员工电话
        /// <summary>
        /// 员工电话
        /// </summary>
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                _Phone = value;
            }
        }
        #endregion

        
        #region 员工邮箱
        /// <summary>
        /// 员工邮箱
        /// </summary>
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }
        #endregion

        
        #region 职位编号
        /// <summary>
        /// 职位编号
        /// </summary>
        public int PostID
        {
            get
            {
                return _PostID;
            }
            set
            {
                _PostID = value;
            }
        }
        #endregion

        
        #region 员工直属上司
        /// <summary>
        /// 员工直属上司
        /// </summary>
        public int DirectlyID
        {
            get
            {
                return _DirectlyID;
            }
            set
            {
                _DirectlyID = value;
            }
        }
        #endregion

        
        #region 员工入职日期
        /// <summary>
        /// 员工入职日期
        /// </summary>
        public string EmployeeDate
        {
            get
            {
                return _EmployeeDate;
            }
            set
            {
                _EmployeeDate = value;
            }
        }
        #endregion

                
        #region 权限
        /// <summary>
        /// 权限
        /// </summary>
        public string Authority
        {
            get
            {
                return _Authority;
            }
            set
            {
                _Authority = value;
            }
        }
        #endregion

        #region 员工公司地址
        /// <summary>
        /// 员工公司地址
        /// </summary>
        public string CompanyAddress
        {
            get
            {
                return _CompanyAddress;
            }
            set
            {
                _CompanyAddress = value;
            }
        }
        #endregion


        #region 公司省份
        public string CompanyProvice
        {
            get
            {
                return _CompanyProvice;
            }
            set
            {
                _CompanyProvice = value;
            }
        }
        #endregion

        #region 员工属性
        public string StaffProperty
        {
            get
            {
                return _StaffProperty;
            }
            set
            {
                _StaffProperty = value;
            }
        }
        #endregion

        #region 是否允许登录
        public int Enable
        {
            get
            {
                return _Enable;
            }
            set
            {
                _Enable = value;
            }
        }
        #endregion

        #region 员工登录名
        public string LoginName
        {
            get
            {
                return _LoginName;
            }
            set
            {
                _LoginName = value;
            }
        }
        #endregion
    }
}
