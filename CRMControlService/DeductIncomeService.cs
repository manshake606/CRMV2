using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CRMDBService;
using ModelService;

namespace CRMControlService
{
   public class DeductIncomeService
   {
       DeductIncomeDB myDeductIncomeDB = new DeductIncomeDB();
       #region 查询所有顾问提成记录
       public DataSet SelectInfo()
       {
           return myDeductIncomeDB.SelectInfo();
       }
       #endregion

       #region 绑定DropDownList控件
       public DataSet SelectItem()
       {
           return myDeductIncomeDB.SelectItem();
       }
       #endregion

       #region 更新提成发放日期
       public int UpdateInfo(int paramID,string paramDate)
       {
           return myDeductIncomeDB.UpdateInfo(paramID,paramDate);
       }
       #endregion
   }
}
