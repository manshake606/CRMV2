using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Configuration;
using ModelService;

namespace CRMDBService
{
    public class StaffInfoDB
    {
        public DataSet GetStaffNamebyStaffID(int staffID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "select ";
            str += "StaffInfo.StaffID";
            str += ",";
            str += "StaffInfo.StaffName";
            str += ",";
            str += "StaffInfo.CompanyProvice";
            str += ",";
            str += "StaffInfo.CompanyAddress";
            str += " from";
            str += " StaffInfo";
            str += " where";
            str += " StaffID='" + staffID + "'";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public DataSet GetStaffPIDByName(string StaffName)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "select ";
            str += "StaffInfo.StaffID";
            str += ",";
            str += "StaffInfo.StaffName";
            str += ",";
            str += "StaffInfo.PostID";
            str += " from";
            str += " StaffInfo";
            str += " where";
            str += " StaffName='" + StaffName + "'";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public DataSet GetGetCopyWriterNamebyAddessStaffDirect(int staffID, string Address)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "select ";
            str += "StaffInfo.StaffID";
            str += ",";
            str += "StaffInfo.StaffName";
            str += ",";
            str += "StaffInfo.CompanyProvice";
            str += ",";
            str += "StaffInfo.CompanyAddress";
            str += " from";
            str += " StaffInfo";
            str += " where";
            str += " StaffInfo.DirectlyID = (select StaffInfo.DirectlyID from StaffInfo where StaffInfo.StaffID='"+staffID+"')";
            str += "and (PostID = '2' or PostID='3' or PostID='4') and CompanyAddress='"+Address+"'";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }


        public DataSet GetStaffNamebyDirectlyID(int directlyID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "select ";
            str += "StaffInfo.StaffID";
            str += ",";
            str += "StaffInfo.StaffName";
            str += " from";
            str += " StaffInfo";
            str += " where";
            str += " DirectlyID='" + directlyID + "'";
            str += " and (PostID = '6' or PostID='7' or PostID='8' or PostID='9')";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public DataSet GetGWNamebyAddessDirectlyID(int directlyID,string Address)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "select ";
            str += "StaffInfo.StaffID";
            str += ",";
            str += "StaffInfo.StaffName";
            str += " from";
            str += " StaffInfo";
            str += " where";
            str += " DirectlyID='" + directlyID + "'";
            str += " and (PostID = '6' or PostID='7' or PostID='8' or PostID='9')";
            str += " and StaffInfo.CompanyAddress='" + Address + "'";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public DataSet GetCopyWriterNamebyAddessDirectlyID(int directlyID, string Address)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "select ";
            str += "StaffInfo.StaffID";
            str += ",";
            str += "StaffInfo.StaffName";
            str += " from";
            str += " StaffInfo";
            str += " where";
            str += " DirectlyID='" + directlyID + "'";
            str += " and (PostID = '2' or PostID='3' or PostID='4')";
            str += " and StaffInfo.CompanyAddress='" + Address + "'";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }


        #region 无参数查询所有员工信息
        public DataSet SelectAll(int Enable)
        {
            
            DbHelper db = new DbHelper();
            string str = "";
            if (Enable==0)
            {
             str = "SELECT [StaffID],[StaffName],[Password],CONVERT(varchar(100),Birthday,23) as [Birthday],[StaffSex],[Phone],[Email],[PostID],[DirectlyID],CONVERT(varchar(100),EmployeeDate,23) as [EmployeeDate],[Authority],[CompanyAddress],[Enable],[CompanyProvice],[StaffProperty],[LoginName] FROM [CRMDB].[dbo].[StaffInfo] where enable='0'";
            }
            else
            {
             str = "SELECT [StaffID],[StaffName],[Password],CONVERT(varchar(100),Birthday,23) as [Birthday],[StaffSex],[Phone],[Email],[PostID],[DirectlyID],CONVERT(varchar(100),EmployeeDate,23) as [EmployeeDate],[Authority],[CompanyAddress],[Enable],[CompanyProvice],[StaffProperty],[LoginName] FROM [CRMDB].[dbo].[StaffInfo]";
            }
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }
        #endregion



        #region 查询所有员工信息通过员工ID
        public DataSet SelectAllbyStaffID(int StaffID)
        {
            DbHelper db = new DbHelper();
            string str = "SELECT [StaffID],[StaffName],[Password],CONVERT(varchar(100),Birthday,23) as [Birthday],[StaffSex],[Phone],[Email],[PostID],[DirectlyID],CONVERT(varchar(100),EmployeeDate,23) as [EmployeeDate],[Authority],[CompanyAddress],[Enable],[CompanyProvice],[StaffProperty],[LoginName] FROM [CRMDB].[dbo].[StaffInfo] where StaffID='" + StaffID + "'";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }
        #endregion

        #region 查询员工职位信息
        public DataSet SelectPost()
        {
            DbHelper db = new DbHelper();
            string str = "SELECT PostID,PostName from PositionInfo";
            DbCommand cmd = db.GetSqlStringCommond(str);
            return db.ExecuteDataSet(cmd);
        }
        #endregion

        #region 查询员工直属上司信息
        public DataSet SelectDirect()
        {
            DbHelper db = new DbHelper();
            string str = "SELECT StaffID,StaffName from StaffInfo inner join PositionInfo on StaffInfo.PostID=PositionInfo.PostID  where DirectlyID=0 and StaffInfo.PostID=1";
            DbCommand cmd = db.GetSqlStringCommond(str);
            return db.ExecuteDataSet(cmd);
        }
        #endregion


        #region 添加员工基本信息
        public int InsertStaff(StaffInfo myStaffInfo)
        {
            int returnValue = 0;
            DbHelper myDbHelper = new DbHelper();
            string sql = "INSERT StaffInfo(StaffName,Password,Birthday,StaffSex,Phone,Email,PostID,DirectlyID,EmployeeDate,Authority,CompanyAddress,Enable,CompanyProvice,StaffProperty,LoginName) VALUES(@StaffName,@Password,@Birthday,@StaffSex,@Phone,@Email,@PostID,@DirectlyID,@EmployeeDate,@Authority,@CompanyAddress,@Enable,@CompanyProvice,@StaffProperty,@LoginName)";
            SqlParameter[] prams = new SqlParameter[] { new SqlParameter("@StaffName",myStaffInfo.StaffName), 
            new SqlParameter("@Password",myStaffInfo.Password),
            new SqlParameter("@Birthday",myStaffInfo.Birthday),
            new SqlParameter("@StaffSex",myStaffInfo.StaffSex),
            new SqlParameter("@Phone",myStaffInfo.Phone),
            new SqlParameter("@Email",myStaffInfo.Email),
            new SqlParameter("@PostID",myStaffInfo.PostID),
            new SqlParameter("@DirectlyID",myStaffInfo.DirectlyID),
            new SqlParameter("@EmployeeDate",myStaffInfo.EmployeeDate),
            new SqlParameter("@Authority",myStaffInfo.Authority),
            new SqlParameter("@CompanyAddress",myStaffInfo.CompanyAddress),
            new SqlParameter("@Enable",myStaffInfo.Enable),
            new SqlParameter("@CompanyProvice",myStaffInfo.CompanyProvice),
            new SqlParameter("@StaffProperty",myStaffInfo.StaffProperty),
            new SqlParameter("@LoginName",myStaffInfo.LoginName)};
            returnValue = myDbHelper.ExecuteNonQuery(sql, prams, CommandType.Text);
            return returnValue;
        }
        #endregion

        #region 根据员工编号查询所有员工信息
        public DataSet GetStaffAll(int paramID)
        {
            DbHelper db = new DbHelper();
            string str = "SELECT [StaffID],[StaffName],[Password],CONVERT(varchar(100),Birthday,23) as [Birthday],[StaffSex],[Phone],[Email],[PostID],[DirectlyID],CONVERT(varchar(100),EmployeeDate,23) as [EmployeeDate],[Authority],[CompanyAddress],[Enable],[CompanyProvice],[StaffProperty],[LoginName] FROM [CRMDB].[dbo].[StaffInfo] where StaffID="+paramID;
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }
        #endregion

        #region 更新员工基本信息
        public int UpdateStaff(StaffInfo myStaffInfo)
        {
            int returnValue = 0;
            DbHelper myDbHelper = new DbHelper();
            string sql = "UPDATE StaffInfo SET StaffName=@StaffName,Password=@Password,Birthday=@Birthday,StaffSex=@StaffSex,Phone=@Phone,Email=@Email,PostID=@PostID,DirectlyID=@DirectlyID,EmployeeDate=@EmployeeDate,Authority=@Authority,CompanyAddress=@CompanyAddress,Enable=@Enable,CompanyProvice=@CompanyProvice,StaffProperty=@StaffProperty,LoginName=@LoginName where StaffID=" + myStaffInfo.StaffID; 
            SqlParameter[] prams = new SqlParameter[] { new SqlParameter("@StaffName",myStaffInfo.StaffName), 
            new SqlParameter("@Password",myStaffInfo.Password),
            new SqlParameter("@Birthday",myStaffInfo.Birthday),
            new SqlParameter("@StaffSex",myStaffInfo.StaffSex),
            new SqlParameter("@Phone",myStaffInfo.Phone),
            new SqlParameter("@Email",myStaffInfo.Email),
            new SqlParameter("@PostID",myStaffInfo.PostID),
            new SqlParameter("@DirectlyID",myStaffInfo.DirectlyID),
            new SqlParameter("@EmployeeDate",myStaffInfo.EmployeeDate),
            new SqlParameter("@Authority",myStaffInfo.Authority),
            new SqlParameter("@CompanyAddress",myStaffInfo.CompanyAddress),
            new SqlParameter("@Enable",myStaffInfo.Enable),
            new SqlParameter("@CompanyProvice",myStaffInfo.CompanyProvice),
            new SqlParameter("@StaffProperty",myStaffInfo.StaffProperty),
            new SqlParameter("@LoginName",myStaffInfo.LoginName)};

            returnValue = myDbHelper.ExecuteNonQuery(sql, prams, CommandType.Text);
            return returnValue;
        }
        #endregion


        #region 根据所给参数查询员工信息
        public DataSet SelectParam(StaffInfo myStaffInfo)
        {
            DbHelper db = new DbHelper();
            string str = "SELECT [StaffID],[StaffName],[Password],CONVERT(varchar(100),Birthday,23) as [Birthday],[StaffSex],[Phone],[Email],[PostID],[DirectlyID],CONVERT(varchar(100),EmployeeDate,23) as [EmployeeDate],[Authority],[CompanyAddress],[Enable],[CompanyProvice],[StaffProperty] FROM [CRMDB].[dbo].[StaffInfo] where StaffName like '%" + myStaffInfo.StaffName + "%'";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }
        #endregion

        #region 根据员工姓名模糊查询
        public DataSet SelectParamName(StaffInfo myStaffInfo)
        {
            DbHelper db = new DbHelper();
            string str = "SELECT [StaffID],[StaffName],[Password],CONVERT(varchar(100),Birthday,23) as [Birthday],[StaffSex],[Phone],[Email],[PostID],[DirectlyID],CONVERT(varchar(100),EmployeeDate,23) as [EmployeeDate],[Authority],[CompanyAddress],[Enable],[CompanyProvice],[StaffProperty] FROM [CRMDB].[dbo].[StaffInfo] where  StaffID like '%" + myStaffInfo.StaffID + "%'";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            return ds;
        }
        #endregion

        #region 根据员工编号查询员工职位
        public DataSet SelectPostID(StaffInfo myStaffInfo)
        {
            DbHelper db = new DbHelper();
            string str = "SELECT PostID from StaffInfo where StaffID='" + myStaffInfo.StaffID + "'";
            DbCommand cmd = db.GetSqlStringCommond(str);
            return db.ExecuteDataSet(cmd);
        }
        #endregion

        #region 根据员工登录名验证是否存在重复
        public DataSet SelectLoginName(string paramValue)
        {
            DbHelper db = new DbHelper();
            string str = "SELECT LoginName from StaffInfo where LoginName='" + paramValue + "'";
            DbCommand cmd = db.GetSqlStringCommond(str);
            return db.ExecuteDataSet(cmd);
        }
        #endregion
    }
}
