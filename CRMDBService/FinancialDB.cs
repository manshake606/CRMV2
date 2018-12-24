using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using CRMDBService;
using ModelService;

namespace CRMDBService
{
    public class FinancialDB
    {
        DataSet ds = new DataSet();
        DbHelper myDbHelper = new DbHelper();
        #region 通过sql条件语句执行查询签约合同信息
        public DataSet SelectFinancialInfo(string GetStartDate,string GetEndDate)
        {
            string sql = "SELECT  [ContractID],CONVERT(varchar(100),SignDate,23) AS[SignDate],CONVERT(varchar(100),EndDate,23) AS[EndDate],[Proxy],[ProxyName],[RecommendPeople],[ReferralFees],CONVERT(varchar(100),ReferralFeesPayDate,23) AS[ReferralFeesPayDate],[OutSourcing],[OutSourcingPeople],[OutSourcingFees],CONVERT(varchar(100),OutSourcingPayDate,23) AS[OutSourcingPayDate],[OutSourcingDirections],[OtherFees],[CustomerName] FROM Financial inner join CustomerInfo on Financial.CustomerID=CustomerInfo.CustomerID where SignDate>='" + GetStartDate + "' and SignDate<='" + GetEndDate + "' order by CONVERT(varchar(100),SignDate,23) DESC";
            DbCommand cmd = myDbHelper.GetSqlStringCommond(sql);
            return myDbHelper.ExecuteDataSet(cmd);
        }
        #endregion

        #region 查询所有合同信息
        public DataSet SelectFinancialInfo()
        {
            string sql = "SELECT  [ContractID],CONVERT(varchar(100),SignDate,23) AS[SignDate],CONVERT(varchar(100),EndDate,23) AS[EndDate],[Proxy],[ProxyName],[RecommendPeople],[ReferralFees],CONVERT(varchar(100),ReferralFeesPayDate,23) AS[ReferralFeesPayDate],[OutSourcing],[OutSourcingPeople],[OutSourcingFees],CONVERT(varchar(100),OutSourcingPayDate,23) AS[OutSourcingPayDate],[OutSourcingDirections],[OtherFees],[CustomerName] FROM Financial inner join CustomerInfo on Financial.CustomerID=CustomerInfo.CustomerID order by CONVERT(varchar(100),SignDate,23) DESC";
            DbCommand cmd = myDbHelper.GetSqlStringCommond(sql);
            return myDbHelper.ExecuteDataSet(cmd);
        }
        #endregion

        #region 通过客户ID查询客户的合同编号
        public DataSet GetContractID(int CustomerID)
        {
            string sqlstr = "";
            sqlstr += "select ";
            sqlstr += " ContractID";
            sqlstr += " ,";
            sqlstr += " CustomerID";
            sqlstr += " from ";
            sqlstr += " Financial ";
            sqlstr += " where CustomerID=" + CustomerID + "";
            DbCommand cmd = myDbHelper.GetSqlStringCommond(sqlstr);
            DataSet ds = myDbHelper.ExecuteDataSet(cmd);
            myDbHelper.ExecuteNonQuery(cmd);
            return ds;
        }
        #endregion

        #region 根据合同编号查询合同信息
        public DataSet SelectFinancialInfo(string paramID)
        {
            string sql = "SELECT  [ContractID],CONVERT(varchar(100),SignDate,23) AS[SignDate],CONVERT(varchar(100),EndDate,23) AS[EndDate],[Proxy],[ProxyName],[RecommendPeople],[ReferralFees],CONVERT(varchar(100),ReferralFeesPayDate,23) AS[ReferralFeesPayDate],[OutSourcing],[OutSourcingPeople],[OutSourcingFees],CONVERT(varchar(100),OutSourcingPayDate,23) AS[OutSourcingPayDate],[OutSourcingDirections],[OtherFees],[CustomerName] FROM Financial inner join CustomerInfo on Financial.CustomerID=CustomerInfo.CustomerID where ContractID='" + paramID + "'";
            DbCommand cmd = myDbHelper.GetSqlStringCommond(sql);
            return myDbHelper.ExecuteDataSet(cmd);
        }
        #endregion

        #region 通过Model层传递所需更新参数
        public int UpdateFinancialInfos(MoFinancial myMoFinancial)
        {
            int returnValue = 0;
            string sql = "UPDATE Financial SET SignDate=@SignDate,EndDate=@EndDate,Proxy=@Proxy,ProxyName=@ProxyName,RecommendPeople=@RecommendPeople,ReferralFees=@ReferralFees,ReferralFeesPayDate=@ReferralFeesPayDate,OutSourcing=@OutSourcing,OutSourcingPeople=@OutSourcingPeople,OutSourcingFees=@OutSourcingFees,OutSourcingPayDate=@OutSourcingPayDate,OutSourcingDirections=@OutSourcingDirections,OtherFees=@OtherFees where ContractID=@ContractID";
            SqlParameter[] prams = new SqlParameter[] { new SqlParameter("@ContractID",myMoFinancial.ContractID),
                new SqlParameter("@SignDate", myMoFinancial.SignDate),
            new SqlParameter("@EndDate",myMoFinancial.EndDate),
            new SqlParameter("@Proxy",myMoFinancial.Proxy),
            new SqlParameter("@ProxyName",myMoFinancial.ProxyName),
            new SqlParameter("@RecommendPeople",myMoFinancial.RecommendPeople),
            new SqlParameter("@ReferralFees",Convert.ToInt32( myMoFinancial.ReferralFees)),
            new SqlParameter("@ReferralFeesPayDate",myMoFinancial.ReferralFeesPayDate),
            new SqlParameter("@OutSourcing",myMoFinancial.OutSourcing),
            new SqlParameter("@OutSourcingPeople",myMoFinancial.OutSourcingPeople),
            new SqlParameter("@OutSourcingFees",Convert.ToInt32( myMoFinancial.OutSourcingFees)),
            new SqlParameter("@OutSourcingPayDate",myMoFinancial.OutSourcingPayDate),
            new SqlParameter("@OutSourcingDirections",myMoFinancial.OutSourcingDirections),
            new SqlParameter("@OtherFees",myMoFinancial.OtherFees)};
            returnValue = myDbHelper.ExecuteNonQuery(sql, prams, CommandType.Text);
            return returnValue;
        }
        #endregion

        #region 添加客户签订合同信息
        public int AddContractInfo(MoFinancial myMoFinancial)
        {
            int returnValue = 0;
            
            string sql = "INSERT Financial(ContractID,SignDate,Proxy,ProxyName,RecommendPeople,ReferralFees,ReferralFeesPayDate,OutSourcing,OutSourcingPeople,OutSourcingFees,OutSourcingPayDate,OutSourcingDirections,OtherFees,CustomerID) VALUES(@ContractID,@SignDate,@Proxy,@ProxyName,";

            sql+="@RecommendPeople,@ReferralFees,";
            
            if(myMoFinancial.ReferralFeesPayDate==null||myMoFinancial.ReferralFeesPayDate=="")
            {
                sql += "NULL,";
            }
            else
            {
                sql += "@ReferralFeesPayDate,";
            }
            sql +="@OutSourcing,@OutSourcingPeople,@OutSourcingFees,";
            if(myMoFinancial.OutSourcingPayDate==null||myMoFinancial.OutSourcingPayDate=="")
            {
                sql += "NULL,";
            }
            else
            {
                sql += "@OutSourcingPayDate,";
            }
            sql +="@OutSourcingDirections,@OtherFees,@CustomerID)";
            SqlParameter[] prams = new SqlParameter[] { new SqlParameter("@ContractID",myMoFinancial.ContractID), 
            new SqlParameter("@SignDate", myMoFinancial.SignDate),
            new SqlParameter("@Proxy",Convert.ToInt32(myMoFinancial.Proxy)),
            new SqlParameter("@ProxyName",myMoFinancial.ProxyName),
            new SqlParameter("@RecommendPeople",myMoFinancial.RecommendPeople),
            new SqlParameter("@ReferralFees",Convert.ToInt32( myMoFinancial.ReferralFees)),
            new SqlParameter("@ReferralFeesPayDate",myMoFinancial.ReferralFeesPayDate),
            new SqlParameter("@OutSourcing",myMoFinancial.OutSourcing),
            new SqlParameter("@OutSourcingPeople",myMoFinancial.OutSourcingPeople),
            new SqlParameter("@OutSourcingFees",Convert.ToInt32( myMoFinancial.OutSourcingFees)),
            new SqlParameter("@OutSourcingPayDate",myMoFinancial.OutSourcingPayDate),
            new SqlParameter("@OutSourcingDirections",myMoFinancial.OutSourcingDirections),
            new SqlParameter("@OtherFees",myMoFinancial.OtherFees),
            new SqlParameter("@CustomerID",myMoFinancial.CustomerID)};
            returnValue = myDbHelper.ExecuteNonQuery(sql, prams, CommandType.Text);
            return returnValue;
        }
        #endregion

        #region 根据所给参数条件查询合同信息
        public DataSet SelectInfo(MoFinancial myMoFinancial,string OverDate,string LastDate)
        {
            string sql = "SELECT  [ContractID],CONVERT(varchar(100),SignDate,23) AS[SignDate],CONVERT(varchar(100),EndDate,23) AS[EndDate],[Proxy],[ProxyName],[RecommendPeople],[ReferralFees],CONVERT(varchar(100),ReferralFeesPayDate,23) AS[ReferralFeesPayDate],[OutSourcing],[OutSourcingPeople],[OutSourcingFees],CONVERT(varchar(100),OutSourcingPayDate,23) AS[OutSourcingPayDate],[OutSourcingDirections],[OtherFees],[CustomerName] FROM Financial inner join CustomerInfo on Financial.CustomerID=CustomerInfo.CustomerID where (ContractID='" + myMoFinancial.ContractID + "' or SignDate='" + myMoFinancial.SignDate + "' or EndDate='" + myMoFinancial.EndDate + "') or (SignDate >='" + myMoFinancial.SignDate + "' and SignDate<='" + OverDate + "') or (EndDate >='" + myMoFinancial.EndDate + "' and EndDate<='" + LastDate + "') order by CONVERT(varchar(100),SignDate,23) DESC";
            DbCommand cmd = myDbHelper.GetSqlStringCommond(sql);
            return myDbHelper.ExecuteDataSet(cmd);
        }
        #endregion

        #region 查询所有缴费记录
        public DataSet SelectPayment()
        {
            string sql = "SELECT PaymentID,FeesTotal,PaymentFees,CONVERT(varchar(100),PaymentDate,23) AS[PaymentDate],ContractID,CustomerID from Payment";
            DbCommand cmd = myDbHelper.GetSqlStringCommond(sql);
            return myDbHelper.ExecuteDataSet(cmd);
        }
        #endregion

        #region 根据合同编号查询缴费记录
        public DataSet SelectPayment(string paramID)
        {
            string sql = "SELECT PaymentID,FeesTotal,PaymentFees,CONVERT(varchar(100),PaymentDate,23) AS[PaymentDate],ContractID,CustomerID from Payment where ContractID='"+paramID+"'";
            DbCommand cmd = myDbHelper.GetSqlStringCommond(sql);
            return myDbHelper.ExecuteDataSet(cmd);
        }
        #endregion

        #region 更新缴费记录信息
        public int UpdatePayment(MoPayment myMoPayment)
        {
            int returnValue = 0;
            string sql = "UPDATE [Payment] SET PaymentFees=@PaymentFees,PaymentDate=@PaymentDate where PaymentID=@PaymentID";
            SqlParameter[] prams = new SqlParameter[] { new SqlParameter("PaymentID",myMoPayment.PaymentID),
                new SqlParameter("@PaymentFees",myMoPayment.PaymentFees),
                new SqlParameter("@PaymentDate", myMoPayment.PaymentDate)};
            returnValue = myDbHelper.ExecuteNonQuery(sql, prams, CommandType.Text);
            return returnValue;
        }
        #endregion

        #region 添加缴费记录信息
        public int InsertPayment(MoPayment myMoPayment)
        {
            int returnValue = 0;
            string sql = "Insert into [Payment](FeesTotal,PaymentFees,PaymentDate,ContractID,CustomerID) values(@FeesTotal,@PaymentFees,@PaymentDate,@ContractID,@CustomerID)";
            SqlParameter[] prams = new SqlParameter[] { new SqlParameter("FeesTotal",myMoPayment.FeesTotal),
            new SqlParameter("PaymentFees",myMoPayment.PaymentFees),
            new SqlParameter("PaymentDate",myMoPayment.PaymentDate),
            new SqlParameter("ContractID",myMoPayment.ContractID),
            new SqlParameter("CustomerID",myMoPayment.CustomerID)};
            returnValue = myDbHelper.ExecuteNonQuery(sql,prams,CommandType.Text);
            return returnValue;
        }
        #endregion

        #region 查询缴费总金额
        public DataSet SelectFees(MoPayment myMoPayment)
        {
            string sql = "select Sum(FeesTotal)/Count(ContractID),Sum(PaymentFees) from Payment where ContractID='"+myMoPayment.ContractID+"'";
            DbCommand cmd = myDbHelper.GetSqlStringCommond(sql);
            return myDbHelper.ExecuteDataSet(cmd);
        }
        #endregion

        #region 根据客户编号查询是否存在合同编号(防止重复插入数据)
        public DataSet SelectByparamID(int ParamID)
        {
            string sql = "select ContractID from Financial where CustomerID="+ParamID;
            DbCommand cmd = myDbHelper.GetSqlStringCommond(sql);
            return myDbHelper.ExecuteDataSet(cmd);
        }
        #endregion
    }
}
