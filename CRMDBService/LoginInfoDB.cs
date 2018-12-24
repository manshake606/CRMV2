using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Configuration;


namespace CRMDBService
{
    public class LoginInfoDB
    {    
        
        public DataTable GetStaffInfoPasswordFromStaffID(string LoginName)
        {
            DbHelper db = new DbHelper();
            string sql = "select * from StaffInfo where LoginName='"+LoginName+"'";
            DbCommand cmd = db.GetSqlStringCommond(sql);
            DataTable dt = db.ExecuteDataTable(cmd);
            return dt;                   
        }
               
    }
}
