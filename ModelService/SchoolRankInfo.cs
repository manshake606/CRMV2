using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    public class SchoolRankInfo
    {

        //成绩编号ID
        private int _RankID;
        //客户ID
        private int _CustomerID;
        //客户的平均成绩
        private float _AverageScore;
        //成绩排名
        private int _Ranking;
        //学生其他学习情况
        private string _SchoolOtherInfo;
        //备注
        private string _Remark;
        //在读学校
        private string _CurrentSchool;
        //专业
        private string _Major;


        #region 成绩编号ID
        /// <summary>
        /// 成绩编号ID
        /// </summary>
        public int RankID
        {
            get
            {
                return _RankID;
            }
            set
            {
                _RankID = value;
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

        #region 客户的平均成绩
        /// <summary>
        /// 客户的平均成绩
        /// </summary>
        public float AverageScore
        {
            get
            {
                return _AverageScore;
            }
            set
            {
                _AverageScore = value;
            }
        }
        #endregion

        #region 成绩排名
        /// <summary>
        /// 成绩排名
        /// </summary>
        public int Ranking
        {
            get
            {
                return _Ranking;
            }
            set
            {
                _Ranking = value;
            }
        }
        #endregion

        #region 学生其他学习情况
        /// <summary>
        /// 学生其他学习情况
        /// </summary>
        public string SchoolOtherInfo
        {
            get
            {
                return _SchoolOtherInfo;
            }
            set
            {
                _SchoolOtherInfo = value;
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

        #region 在读学校
        /// <summary>
        /// 在读学校
        /// </summary>
        public string CurrentSchool
        {
            get
            {
                return _CurrentSchool;
            }
            set
            {
                _CurrentSchool = value;
            }
        }
        #endregion

        #region 专业
        /// <summary>
        /// 专业
        /// </summary>
        public string Major
        {
            get
            {
                return _Major;
            }
            set
            {
                _Major = value;
            }
        }
        #endregion
    }
}
