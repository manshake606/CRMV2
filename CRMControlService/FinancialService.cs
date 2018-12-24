using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Configuration;
using System.Data;
using CRMDBService;
using ModelService;

namespace CRMControlService
{
    public class FinancialService
    {
        FinancialDB myFinancialDB = new FinancialDB();
        DataSet ds = new DataSet();
        #region 实现查询所有合同信息数据
        public DataSet SelectFinancialInfo(string GetStartDate,string GetEndDate)
        {
            return myFinancialDB.SelectFinancialInfo(GetStartDate,GetEndDate);
        }
        #endregion

        public DataSet SelectFinancialInfo()
        {
            return myFinancialDB.SelectFinancialInfo();
        }

        #region 根据客户编号查询合同编号
        public DataSet GetContractIDInfo(int CustomerID)
        {
            return myFinancialDB.GetContractID(CustomerID);
        }
        #endregion

        #region 根据合同编号查询所需数据
        public DataSet SelectFinancialInfo(string paramID)
        {
            return myFinancialDB.SelectFinancialInfo(paramID);
        }

        #endregion

        #region 实现更新签约合同信息数据

        public int UpdateFinancialInfo(MoFinancial myMoFinancial)
       {
           return myFinancialDB.UpdateFinancialInfos(myMoFinancial);
       }
        #endregion

        #region 添加客户签约合同信息
       public int AddContractInfo(MoFinancial myMoFinancial)
       {
           return myFinancialDB.AddContractInfo(myMoFinancial);
       }
        #endregion

        #region 根据所给查询条件查询合同信息 
       public DataSet SelectInfo(MoFinancial myMoFinancial,string EndDate,string LastDate)
       {
           return myFinancialDB.SelectInfo(myMoFinancial,EndDate,LastDate);
       }
        #endregion

        #region 查询缴费记录信息
       public DataSet SelectPayment()
       {
           return myFinancialDB.SelectPayment();
       }
        #endregion

        #region 查询缴费记录带参数
       public DataSet SelectPayment(string paramID)
       {
           return myFinancialDB.SelectPayment(paramID);
       }
       #endregion

        #region 更新缴款记录
       public int UpdatePayment(MoPayment myMoPayment)
       {
           return myFinancialDB.UpdatePayment(myMoPayment);
       }
        #endregion

        #region 添加缴费记录信息 
       public int InsertPayment(MoPayment myMoPayment)
       {
           return myFinancialDB.InsertPayment(myMoPayment);
       }
        #endregion

        #region 查询缴费金额是否等于合同金额
       public DataSet SelectFees(MoPayment myMoPayment)
       {
           return myFinancialDB.SelectFees(myMoPayment);
       }
        #endregion

        #region 通过客户编号查询合同编号是否存在
       public DataSet SelectByparamID(int ParamID)
       {
           return myFinancialDB.SelectByparamID(ParamID);
       }
        #endregion
    }
}
