using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    public class FamilyInfo
    {
        private int _FID;
        #region 家庭编号
        /// <summary>
        /// 家庭编号
        /// </summary>
        public int FID
        {
            get
            {
                return _FID;
            }
            set
            {
                _FID = value;
            }
        }
        #endregion

        private int _CustomerID;
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

        private string _ParentName;
        #region 家长姓名
        /// <summary>
        /// 家长姓名
        /// </summary>
        public string ParentName
        {
            get
            {
                return _ParentName;
            }
            set
            {
                _ParentName = value;
            }
        }
        #endregion

        private string _ParentBirthday;
        #region 家长生日
        /// <summary>
        /// 家长生日
        /// </summary>
        public string ParentBirthday
        {
            get
            {
                return _ParentBirthday;
            }
            set
            {
                _ParentBirthday = value;
            }
        }
        #endregion

        private string _ParentMobilephone;
        #region 家长手机
        /// <summary>
        /// 家长手机
        /// </summary>
        public string ParentMobilephone
        {
            get
            {
                return _ParentMobilephone;
            }
            set
            {
                _ParentMobilephone = value;
            }
        }
        #endregion

        private string  _ParentTelphone;
        #region 家长电话
        /// <summary>
        /// 家长电话
        /// </summary>
        public string ParentTelphone
        {
            get
            {
                return _ParentTelphone;
            }
            set
            {
                _ParentTelphone = value;
            }
        }
        #endregion

        private string _ParentWorkUnit;
        #region 家长工作单位
        /// <summary>
        /// 家长工作单位
        /// </summary>
        public string ParentWorkUnit
        {
            get
            {
                return _ParentWorkUnit;
            }
            set
            {
                _ParentWorkUnit = value;
            }
        }
        #endregion

        private string _ParentWorkPosition;
        #region 家长职位
        /// <summary>
        /// 家长职位
        /// </summary>
        public string ParentWorkPosition
        {
            get
            {
                return _ParentWorkPosition;
            }
            set
            {
                _ParentWorkPosition = value;
            }
        }
        #endregion

        private string _ParentQQ;
        #region 家长QQ
        /// <summary>
        /// 家长QQ
        /// </summary>
        public string ParentQQ
        {
            get
            {
                return _ParentQQ;
            }
            set
            {
                _ParentQQ = value;
            }
        }
        #endregion

        private int _ParentAge;
        #region 家长年龄
        /// <summary>
        /// 家长年龄
        /// </summary>
        public int ParentAge
        {
            get
            {
                return _ParentAge;
            }
            set
            {
                _ParentAge = value;
            }
        }
        #endregion

        private string _ParentMail;
        #region 家长邮箱
        /// <summary>
        /// 家长邮箱
        /// </summary>
        public string ParentMail
        {
            get
            {
                return _ParentMail;
            }
            set
            {
                _ParentMail = value;
            }
        }
        #endregion

        private string _ParentInCome;
        #region 家长收入
        /// <summary>
        /// 家长收入
        /// </summary>
        public string ParentInCome
        {
            get
            {
                return _ParentInCome;
            }
            set
            {
                _ParentInCome = value;
            }
        }
        #endregion

        private string _Relationship;
        #region 亲属关系
        /// <summary>
        /// 亲属关系
        /// </summary>
        public string Relationship
        {
            get
            {
                return _Relationship;
            }
            set
            {
                _Relationship = value;
            }
        }
        #endregion

        private int _BirthdayRemind;
        #region 生日提醒
        /// <summary>
        /// 生日提醒
        /// </summary>
        public int BirthdayRemind
        {
            get
            {
                return _BirthdayRemind;
            }
            set
            {
                _BirthdayRemind = value;
            }
        }
        #endregion

        private string _Remark;
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

        private int _ParentSex;
        #region 生日提醒
        /// <summary>
        /// 生日提醒
        /// </summary>
        public int ParentSex
        {
            get
            {
                return _ParentSex;
            }
            set
            {
                _ParentSex = value;
            }
        }
        #endregion

        private string _ParentProvince;
        #region 家长省份
        /// <summary>
        /// 家长省份
        /// </summary>
        public string ParentProvince
        {
            get
            {
                return _ParentProvince;
            }
            set
            {
                _ParentProvince = value;
            }
        }
        #endregion

        private string _ParentCity;
        #region 家长城市
        /// <summary>
        /// 家长城市
        /// </summary>
        public string ParentCity
        {
            get
            {
                return _ParentCity;
            }
            set
            {
                _ParentCity = value;
            }
        }
        #endregion

        private string _ParentCityInitial;
        #region 家长城市简写
        /// <summary>
        /// 家长城市简写
        /// </summary>
        public string ParentCityInitial
        {
            get
            {
                return _ParentCityInitial;
            }
            set
            {
                _ParentCityInitial = value;
            }
        }
        #endregion
    }
}
