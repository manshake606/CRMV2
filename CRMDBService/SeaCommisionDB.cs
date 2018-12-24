using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using ModelService;

namespace CRMDBService
{
    public class SeaCommisionDB
    {
        DataSet ds = new DataSet();
        DbHelper myDbHelper = new DbHelper();

        #region 查询海佣缴费记录
        public DataSet SelectSeaCommision()
        {
            string str = "SELECT SeaCommisionID,SeaCommisionTotalAmount,SeaCommisionLimit,CONVERT(varchar(100),SeaCommisionCallsDate,23) AS SeaCommisionCallsDate,SeaCommisionActualAmount,CONVERT(varchar(100),SeaCommisionGetDate,23) AS SeaCommisionGetDate,ContractID,CustomerID from [Seacommison]";
            DbCommand cmd = myDbHelper.GetSqlStringCommond(str);
            DataSet ds =myDbHelper.ExecuteDataSet(cmd);
            return ds;
        }
        #endregion

        #region 通过合同编号查询海佣缴费记录
        public DataSet SelectParam(string ParamID)
        {
            string str = "SELECT SeaCommisionID,SeaCommisionTotalAmount,SeaCommisionLimit,CONVERT(varchar(100),SeaCommisionCallsDate,23) AS SeaCommisionCallsDate,SeaCommisionActualAmount,CONVERT(varchar(100),SeaCommisionGetDate,23) AS SeaCommisionGetDate,ContractID,CustomerID from [Seacommison] where ContractID='"+ParamID+"'";
            DbCommand cmd = myDbHelper.GetSqlStringCommond(str);
            DataSet ds = myDbHelper.ExecuteDataSet(cmd);
            return ds;
        }
        #endregion

        #region 通过合同编号查询是否有海佣缴费记录
        public DataSet SelectByContractID(SeaCommision mySeaCommision)
        {
            string str = "SELECT SeaCommisionID,SeaCommisionTotalAmount,SeaCommisionLimit,CONVERT(varchar(100),SeaCommisionCallsDate,23) AS SeaCommisionCallsDate,SeaCommisionActualAmount,CONVERT(varchar(100),SeaCommisionGetDate,23) AS SeaCommisionGetDate,ContractID,CustomerID from [Seacommison] where ContractID='" + mySeaCommision.ContractID + "'";
            DbCommand cmd = myDbHelper.GetSqlStringCommond(str);
            DataSet ds = myDbHelper.ExecuteDataSet(cmd);
            return ds;
        }
        #endregion

        #region 插入海佣缴费记录
        public int InsertSeaCommision(SeaCommision mySeaCommision)
        {
            int returnValue = 0;
            string sql = "Insert into Seacommison([SeaCommisionTotalAmount],SeaCommisionLimit,SeaCommisionCallsDate,SeaCommisionActualAmount,SeaCommisionGetDate,ContractID,CustomerID) values(@SeaCommisionTotalAmount,@SeaCommisionLimit,@SeaCommisionCallsDate,@SeaCommisionActualAmount,@SeaCommisionGetDate,@ContractID,@CustomerID)";
            SqlParameter[] prams = new SqlParameter[] { new SqlParameter("SeaCommisionTotalAmount",mySeaCommision.SeaCommisionTotalAmount),
            new SqlParameter("SeaCommisionLimit",mySeaCommision.SeaCommisionLimit),
            new SqlParameter("SeaCommisionCallsDate",mySeaCommision.SeaCommisionCallsDate),
            new SqlParameter("SeaCommisionActualAmount",mySeaCommision.SeaCommisionActualAmount),
            new SqlParameter("SeaCommisionGetDate",mySeaCommision.SeaCommisionGetDate),
            new SqlParameter("ContractID",mySeaCommision.ContractID),
            new SqlParameter("CustomerID",mySeaCommision.CustomerID)};
            returnValue = myDbHelper.ExecuteNonQuery(sql, prams, CommandType.Text);
            return returnValue;
        }
        #endregion

    }
}
