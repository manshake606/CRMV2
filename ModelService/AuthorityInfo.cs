using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    public class AuthorityInfo
    {
        //权限ID
        private int _AuthorityID;
        //权限描述
        private string _AuthorityDes; 

        #region 权限ID
        /// <summary>
        /// 权限ID
        /// </summary>
        public int AuthorityID
        {
            get
            {
                return _AuthorityID;
            }
            set
            {
                _AuthorityID = value;
            }
        }
        #endregion
     
        #region 权限描述
        /// <summary>
        /// 权限描述
        /// </summary>
        public string AuthorityDes
        {
            get
            {
                return _AuthorityDes;
            }
            set
            {
                _AuthorityDes = value;
            }
        }
        #endregion
    }
}
