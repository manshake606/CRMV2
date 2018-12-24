using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CRMDBService;
using ModelService;

namespace CRMControlService
{
    public class SeaCommisionService
    {
        SeaCommisionDB mySeaCommisionDB = new SeaCommisionDB();
        #region 查询所有海佣缴费记录
        public DataSet SelectSeaCommision()
        {
            return mySeaCommisionDB.SelectSeaCommision();
        }
        #endregion

        #region 通过合同编号查询缴费记录信息
        public DataSet SelectParam(string paramID)
        {
            return mySeaCommisionDB.SelectParam(paramID);
        }
        #endregion

        #region 根据合同编号查询是否有海佣缴费记录
        public DataSet SelectByContractID(SeaCommision mySeaCommision)
        {
            return mySeaCommisionDB.SelectByContractID(mySeaCommision);
        }
        #endregion

        #region 插入海佣缴费记录
        public int InsertSeaCommision(SeaCommision mySeaCommision)
        {
            return mySeaCommisionDB.InsertSeaCommision(mySeaCommision);
        }
        #endregion
    }
}
