using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    public class Intention
    {
        private int _ITTID;
        #region 意向国家编号
        /// <summary>
        /// 意向国家编号
        /// </summary>
        public int ITTID
        {
            get
            {
                return _ITTID;
            }
            set
            {
                _ITTID = value;
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

        private string _IntentionCountry;
        #region 意向国家名称
        /// <summary>
        /// 意向国家名称
        /// </summary>
        public string IntentionCountry
        {
            get
            {
                return _IntentionCountry;
            }
            set
            {
                _IntentionCountry = value;
            }
        }
        #endregion

        private string _IntentionCity;
        #region 意向城市
        /// <summary>
        /// 意向城市
        /// </summary>
        public string IntentionCity
        {
            get
            {
                return _IntentionCity;
            }
            set
            {
                _IntentionCity = value;
            }
        }
        #endregion

        private string _IntentionSchool;
        #region 意向学校
        /// <summary>
        /// 意向学校
        /// </summary>
        public string IntentionSchool
        {
            get
            {
                return _IntentionSchool;
            }
            set
            {
                _IntentionSchool = value;
            }
        }
        #endregion

        private string _IntentionProfession;
        #region 意向专业
        /// <summary>
        /// 意向专业
        /// </summary>
        public string IntentionProfession
        {
            get
            {
                return _IntentionProfession;
            }
            set
            {
                _IntentionProfession = value;
            }
        }
        #endregion

        private int _BetterWantpriTo;
        #region 意向优先级
        /// <summary>
        /// 意向优先级
        /// </summary>
        public int BetterWantpriTo
        {
            get
            {
                return _BetterWantpriTo;
            }
            set
            {
                _BetterWantpriTo = value;
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

        private int _IntentionPhase;
        #region 学习阶段
        /// <summary>
        /// 学习阶段
        /// </summary>
        public int IntentionPhase
        {
            get
            {
                return _IntentionPhase;
            }
            set
            {
                _IntentionPhase = value;
            }
        }
        #endregion

        private DateTime _Intentiondate;
        /// <summary>
        /// 意向时间
        /// </summary>
        public DateTime Intentiondate
        {
            get
            {
                return _Intentiondate;
            }
            set
            {
                _Intentiondate = value;
            }
        }
    }
}
