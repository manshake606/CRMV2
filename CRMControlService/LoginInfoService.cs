using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using CRMDBService;

namespace CRMControlService
{
    public class LoginInfoService
    {
        #region 通过登陆名从员工表获取员工信息
        public DataTable GetLoginInfoFromStaffID_Service(string LoginName)
        {
            CRMDBService.LoginInfoDB LoginInfo = new LoginInfoDB();
            DataTable dt = LoginInfo.GetStaffInfoPasswordFromStaffID(LoginName);
            return dt;
        }
        #endregion

        #region 验证用户名和密码是否允许登陆
        public int CheckStaff(string txtLoginName, string txtpwd)
        {
            int value = 0;
            if (txtLoginName != "")
            {                
                DataTable dt = GetLoginInfoFromStaffID_Service(txtLoginName);
                if (dt.Rows.Count != 0 )
                {
                     string pwd = dt.Rows[0][2].ToString();
                     string isEnablestr= dt.Rows[0][12].ToString();
                     int isEnable = Convert.ToInt32(isEnablestr);
                    if (pwd.Equals(txtpwd))
                    {
                        if (isEnable == 0)
                            return 3;                       //用户名正确，转向主页
                        else return 4;                      //用户名正确，但是没有权限登录该系统
                    }                                         
                    else  value = 2;                        //请输入正确的密码
                }else  value = 1;                           //用户名不存在
            } else   value =0;                              //请输入正确的用户名和密码
            return value ;
        }
        #endregion

        #region  通过登陆名获取职位ID
        public int GetPostIDFromLoginName(string LoginName)
        {

            DataTable dt = GetLoginInfoFromStaffID_Service(LoginName);
            string   postIDstr = dt .Rows [0][7].ToString ();
            int postID = Convert.ToInt32(postIDstr );
            return postID ;
        }
        #endregion

        #region 通过登陆名获取员工ID
        public int GetStaffIDFromLoginName(string LoginName)
        {
            DataTable dt = GetLoginInfoFromStaffID_Service(LoginName);
            string staffIDstr = dt.Rows[0][0].ToString();
            int staffID = Convert.ToInt32(staffIDstr );
            return staffID;           
        }
        #endregion

        #region  通过登陆名获取员工是否被允许登陆
        public int GetEnableFromLoginName(string LoginName)
        {
            DataTable dt = GetLoginInfoFromStaffID_Service(LoginName);
            string  isEnablestr= dt.Rows[0][12].ToString();
            int isEnable = Convert.ToInt32(isEnablestr);
            return isEnable;
        }
        #endregion

        //public bool CheckStaffNumber(string txtstaffID)
        //{
        //    bool value = false ;
        //    for (int i = 0; i < txtstaffID.Length; i++)
        //    {
        //        if ((txtstaffID[i] >= '0' && txtstaffID[i] <= '9'))
        //        {
        //            return value = true;
        //        }
        //        else return value = false;
        //    }
        //    return value ;
        //}

    }
}
