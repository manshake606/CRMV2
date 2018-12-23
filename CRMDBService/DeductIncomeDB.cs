using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CRMDBService
{
    public class DeductIncomeDB
    {
        DataSet ds = new DataSet();
        DbHelper myDbHelper = new DbHelper();
        #region 查询所有顾问提成信息

        public DataSet SelectInfo()
        {
            string sql = "select DeductID,DeductIncome,CONVERT(varchar(100),DeductDate,23) AS DeductDate,ConsultantID,ContractID from ConsultantIncome";
            DbCommand cmd = myDbHelper.GetSqlStringCommond(sql);
            return myDbHelper.ExecuteDataSet(cmd);
        }
        #endregion

        #region 绑定DropDownList控件
        public DataSet SelectItem()
        {
            string sql = "Select RateID,CommisionName from ConsultantRule";
            DbCommand cmd = myDbHelper.GetSqlStringCommond(sql);
            return myDbHelper.ExecuteDataSet(cmd);
        }
        #endregion

        #region 更新提成发放日期
        public int UpdateInfo(int pramID,string paramDate)
        {
            int returnValue = 0;
            string sql = "UPDATE ConsultantIncome SET DeductDate='"+paramDate+"' where DeductID=" + pramID + "";
            DbCommand cmd = myDbHelper.GetSqlStringCommond(sql);
            returnValue = myDbHelper.ExecuteNonQuery(cmd);
            return returnValue;
        }
        #endregion

    }
}
