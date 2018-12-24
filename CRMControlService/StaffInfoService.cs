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
using ModelService;

namespace CRMControlService
{
    public class StaffInfoService
    {
        CRMDBService.StaffInfoDB staffdb = new StaffInfoDB();
        public DataSet GetStaffNamebyStaffID_Service(int staffID)
        {  
            return staffdb.GetStaffNamebyStaffID(staffID);
        }

        public DataSet GetStaffPIDByName_Service(string StaffName)
        {
            return staffdb.GetStaffPIDByName(StaffName);
        }

        public DataSet GetStaffNamebyDirectlyID_Service(int directlyID)
        {
            return staffdb.GetStaffNamebyDirectlyID(directlyID);
        }

        public DataSet GetGWNamebyAddressDirectlyID_Service(int directlyID,string Address)
        {
            return staffdb.GetGWNamebyAddessDirectlyID(directlyID, Address);
        }

        public DataSet GetCopyWriterNamebyAddessDirectlyID_Service(int directlyID, string Address)
        {
            return staffdb.GetCopyWriterNamebyAddessDirectlyID(directlyID, Address);
        }

        public DataSet GetGetCopyWriterNamebyAddessStaffDirect_Service(int staffID, string Address)
        {
            return staffdb.GetGetCopyWriterNamebyAddessStaffDirect(staffID, Address);
        }

        #region  查询所有员工信息无参数
        public DataSet SelectAll(int Enable)
        {
            return staffdb.SelectAll(Enable);

        }
        #endregion

        public DataSet SelectStaffInfoByID(int staffID)
        {
            return staffdb.SelectAllbyStaffID(staffID);
        }

        #region 查询员工职位
        public DataSet SelectPost()
        {
            return staffdb.SelectPost();
        }
        #endregion

        #region 查询员工直属上司编号
        public DataSet SelectDirect()
        {
            return staffdb.SelectDirect();
        }
        #endregion

        #region 添加员工信息
        public int InsertStaff(StaffInfo myStaffInfo)
        {
            return staffdb.InsertStaff(myStaffInfo);
        }
        #endregion

        #region 根据员工编号查询员工所有信息
        public DataSet GetStaffAll(int staffID)
        {
            return staffdb.GetStaffAll(staffID);
        }
        #endregion

        #region 根据员工编号更新员工信息
        public int UpdateStaff(StaffInfo myStaffInfo)
        {
            return staffdb.UpdateStaff(myStaffInfo);
        }
        #endregion

        #region 根据所给参数查询员工信息
        public DataSet SelectParam(StaffInfo myStaffInfo)
        {
            return staffdb.SelectParam(myStaffInfo);
        }
        #endregion

        #region 根据姓名模糊查询
        public DataSet SelectParamName(StaffInfo myStaffInfo)
        {
            return staffdb.SelectParamName(myStaffInfo);
        }
        #endregion

        #region 根据员工编号查询员工职位
        public DataSet SelectPostID(StaffInfo myStaffInfo)
        {
            return staffdb.SelectPostID(myStaffInfo);
        }
        #endregion

        #region 根据员工登录名验证是否有重复
        public DataSet SelectLoginName(string paramValue)
        {
            return staffdb.SelectLoginName(paramValue);
        }
        #endregion
    }
}
