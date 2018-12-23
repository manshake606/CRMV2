using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    
        public class PositionInfo
        {

            //ID
            private int _ID;
            //职位编号
            private int _PostID;
            //职位
            private string _PostName;
            //职位指标
            private int _Myindex;

            #region ID
            /// <summary>
            /// ID
            /// </summary>
            public int ID
            {
                get
                {
                    return _ID;
                }
                set
                {
                    _ID = value;
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

            #region 职位
            /// <summary>
            /// 职位
            /// </summary>
            public string PostName
            {
                get
                {
                    return _PostName;
                }
                set
                {
                    _PostName = value;
                }
            }
            #endregion

            #region 职位指标
            /// <summary>
            /// 职位指标
            /// </summary>
            public int Myindex
            {
                get
                {
                    return _Myindex;
                }
                set
                {
                    _Myindex = value;
                }
            }
            #endregion

           
        }
   
}
