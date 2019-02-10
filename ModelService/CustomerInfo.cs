using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    public class CustomerInfo
    {
        private int _TableID;
        #region TableID 
        /// <summary>
        /// Table ID
        /// </summary>
        public int TableID
        {
            get
            {
                return _TableID;
            }
            set
            {
                _TableID = value;
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

        private string _CustomerName;
        #region 客户姓名
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                _CustomerName = value;
            }
        }
        #endregion

        private string _EnglishName;
        #region 客户英文名字
        /// <summary>
        /// 客户英文名字
        /// </summary>
        public string EnglishName
        {
            get
            {
                return _EnglishName;
            }
            set
            {
                _EnglishName = value;
            }
        }
        #endregion

        private int _Sex;
        #region 性别
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex
        {
            get
            {
                return _Sex;
            }
            set
            {
                _Sex = value;
            }
        }
        #endregion

        private string _Birthday;
        #region 客户生日
        /// <summary>
        /// 客户生日
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

        private int _Age;
        #region 客户年龄
        /// <summary>
        /// 客户年龄
        /// </summary>
        public int Age
        {
            get
            {
                return _Age;
            }
            set
            {
                _Age = value;
            }
        }
        #endregion

        private string _Phone;
        #region 客户电话
        /// <summary>
        /// 客户电话
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

        private string _Telphone;
        #region 客户手机
        /// <summary>
        /// 客户手机
        /// </summary>
        public string Telphone
        {
            get
            {
                return _Telphone;
            }
            set
            {
                _Telphone = value;
            }
        }
        #endregion

        private string _BackUpTel;
        #region 客户备份手机号
        /// <summary>
        /// 客户备份手机号
        /// </summary>
        public string BackUpTel
        {
            get
            {
                return _BackUpTel;
            }
            set
            {
                _BackUpTel = value;
            }
        }
        #endregion

        private string _CProvince;
        #region 所在省份
        /// <summary>
        /// 所在省份
        /// </summary>
        public string CProvince
        {
            get
            {
                return _CProvince;
            }
            set
            {
                _CProvince = value;
            }
        }
        #endregion

        private string _CCity;
        #region 所在城市
        /// <summary>
        /// 所在城市
        /// </summary>
        public string CCity
        {
            get
            {
                return _CCity;
            }
            set
            {
                _CCity = value;
            }
        }
        #endregion

        private string _CAddress;
        #region 联系地址
        /// <summary>
        /// 联系地址
        /// </summary>
        public string CAddress
        {
            get
            {
                return _CAddress;
            }
            set
            {
                _CAddress = value;
            }
        }
        #endregion

        private string _CQQ;
        #region QQ号码
        /// <summary>
        /// QQ号码
        /// </summary>
        public string CQQ
        {
            get
            {
                return _CQQ;
            }
            set
            {
                _CQQ = value;
            }
        }
        #endregion

        private string _Cemail;
        #region 客户Email
        /// <summary>
        /// 客户Email
        /// </summary>
        public string Cemail
        {
            get
            {
                return _Cemail;
            }
            set
            {
                _Cemail = value;
            }
        }
        #endregion

        private string _OtherContact;
        #region 其他联系人
        /// <summary>
        /// 其他联系人
        /// </summary>
        public string OtherContact
        {
            get
            {
                return _OtherContact;
            }
            set
            {
                _OtherContact = value;
            }
        }
        #endregion

        private string _OtherContactPhone;
        #region 其他联系人电话
        /// <summary>
        /// 其他联系人电话
        /// </summary>
        public string  OtherContactPhone
        {
            get
            {
                return _OtherContactPhone;
            }
            set
            {
                _OtherContactPhone = value;
            }
        }
        #endregion

        private int _CustomerImportance;
        #region 客户重要性
        /// <summary>
        /// 客户重要性
        /// </summary>
        public int CustomerImportance
        {
            get
            {
                return _CustomerImportance;
            }
            set
            {
                _CustomerImportance = value;
            }
        }
        #endregion
        
        private string _Policymaker;
        #region 决策人与客户关系
        /// <summary>
        /// 决策人与客户关系
        /// </summary>
        public string Policymaker
        {
            get
            {
                return _Policymaker;
            }
            set
            {
                _Policymaker = value;
            }
        }
        #endregion

        private string _PolicymakerName;
        #region 决策人姓名
        /// <summary>
        /// 决策人姓名
        /// </summary>
        public string PolicymakerName
        {
            get
            {
                return _PolicymakerName;
            }
            set
            {
                _PolicymakerName = value;
            }
        }
        #endregion

        private int _CustomerClass;
        #region 客户分类
        /// <summary>
        /// 客户分类
        /// </summary>
        public int CustomerClass
        {
            get
            {
                return _CustomerClass;
            }
            set
            {
                _CustomerClass = value;
            }
        }
        #endregion

        private int _DrainTowards;
        #region 流失去向
        /// <summary>
        /// 流失去向
        /// </summary>
        public int DrainTowards
        {
            get
            {
                return _DrainTowards;
            }
            set
            {
                _DrainTowards = value;
            }
        }
        #endregion

        private string _ImportingPeople;
        #region 导入人
        /// <summary>
        /// 导入人
        /// </summary>
        public string ImportingPeople
        {
            get
            {
                return _ImportingPeople;
            }
            set
            {
                _ImportingPeople = value;
            }
        }
        #endregion

        private DateTime _ImportingDate;
        #region 导入时间
        /// <summary>
        /// 导入时间
        /// </summary>
        public DateTime ImportingDate
        {
            get
            {
                return _ImportingDate;
            }
            set
            {
                _ImportingDate = value;
            }
        }
        #endregion

        private string _Sname;
        #region 客户学校名称
        /// <summary>
        /// 客户学校名称
        /// </summary>
        public string Sname
        {
            get
            {
                return _Sname;
            }
            set
            {
                _Sname = value;
            }
        }
        #endregion

        private string _Grade;
        #region 客户年级
        /// <summary>
        /// 客户年级
        /// </summary>
        public string Grade
        {
            get
            {
                return _Grade;
            }
            set
            {
                _Grade = value;
            }
        }
        #endregion

        private string _ProfessionName;
        #region 专业名字
        /// <summary>
        /// 专业名字
        /// </summary>
        public string ProfessionName
        {
            get
            {
                return _ProfessionName;
            }
            set
            {
                _ProfessionName = value;
            }
        }
        #endregion

        private string _AdmissionCountry;
        #region 被录取的国家
        /// <summary>
        /// 被录取的国家
        /// </summary>
        public string AdmissionCountry
        {
            get
            {
                return _AdmissionCountry;
            }
            set
            {
                _AdmissionCountry = value;
            }
        }
        #endregion

        private string _AdmissionCity;
        #region 被录取的城市
        /// <summary>
        /// 被录取的城市
        /// </summary>
        public string AdmissionCity
        {
            get
            {
                return _AdmissionCity;
            }
            set
            {
                _AdmissionCity = value;
            }
        }
        #endregion

        private string _AdmissionSname;
        #region 客户被录取学校名称
        /// <summary>
        /// 客户被录取学校名称
        /// </summary>
        public string AdmissionSname
        {
            get
            {
                return _AdmissionSname;
            }
            set
            {
                _AdmissionSname = value;
            }
        }
        #endregion

        private string _AdmissionProfessionName;
        #region 被录取的专业
        /// <summary>
        /// 被录取的专业
        /// </summary>
        public string AdmissionProfessionName
        {
            get
            {
                return _AdmissionProfessionName;
            }
            set
            {
                _AdmissionProfessionName = value;
            }
        }
        #endregion

        private string _AdmissionDate;
        #region 被录取日期
        /// <summary>
        /// 被录取日期（只有录取的时候才插入日期的）
        /// </summary>
        public string AdmissionDate
        {
            get
            {
                return _AdmissionDate;
            }
            set
            {
                _AdmissionDate = value;
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

        private string _AdmissionRemark;
        #region 录取备注
        /// <summary>
        /// 录取备注
        /// </summary>
        public string AdmissionRemark
        {
            get
            {
                return _AdmissionRemark;
            }
            set
            {
                _AdmissionRemark = value;
            }
        }
        #endregion

        private string _CityInitial;
        #region 所在城市首字母
        /// <summary>
        /// 所在城市首字母
        /// </summary>
        public string CityInitial
        {
            get
            {
                return _CityInitial;
            }
            set
            {
                _CityInitial = value;
            }
        }
        #endregion
        private int _CustomerFrom;
        #region 客户来源
        /// <summary>
        /// 客户来源
        /// </summary>
        public int CustomerFrom
        {
            get
            {
                return _CustomerFrom;
            }
            set
            {
                _CustomerFrom = value;
            }
        }
        #endregion
        private string _FromData;
        #region 数据来源
        /// <summary>
        /// 数据来源
        /// </summary>
        public string FromData
        {
            get
            {
                return _FromData;
            }
            set
            {
                _FromData = value;
            }
        }
        #endregion
        private string _Reference;
        #region 推荐人
        /// <summary>
        /// 推荐人
        /// </summary>
        public string Reference
        {
            get
            {
                return _Reference;
            }
            set
            {
                _Reference = value;
            }
        }
        #endregion
        private string _ReferenceRemark;
        #region 推荐人备注
        /// <summary>
        /// 推荐人备注
        /// </summary>
        public string ReferenceRemark
        {
            get
            {
                return _ReferenceRemark;
            }
            set
            {
                _ReferenceRemark = value;
            }
        }
        #endregion



        private int _AdmissionPhase;
        #region 学习阶段
        /// <summary>
        /// 流失去向
        /// </summary>
        public int AdmissionPhase
        {
            get
            {
                return _AdmissionPhase;
            }
            set
            {
                _AdmissionPhase = value;
            }
        }
        #endregion

        private string _ContractNum;
        #region 合同编号
        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractNum
        {
            get
            {
                return _ContractNum;
            }
            set
            {
                _ContractNum = value;
            }
        }
        #endregion 

        private int _CustomerImprove;
        #region 是否参与背景提升
        /// <summary>
        /// 是否参与背景提升
        /// </summary>
        public int CustomerImprove
        {
            get
            {
                return _CustomerImprove;
            }
            set
            {
                _CustomerImprove = value;
            }
        }
        #endregion 

        private string _WorkExperience;
        #region 工作经验
        /// <summary>
        /// 是否参与背景提升
        /// </summary>
        public string WorkExperience
        {
            get
            {
                return _WorkExperience;
            }
            set
            {
                _WorkExperience = value;
            }
        }
        #endregion 

        private string _AgentInfo;
        #region 代理信息
        /// <summary>
        /// 代理信息
        /// </summary>
        public string AgentInfo
        {
            get
            {
                return _AgentInfo;
            }
            set
            {
                _AgentInfo = value;
            }
        }
        #endregion 


    }
}
