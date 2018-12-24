using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Configuration;
using System.Text;

namespace CRMDBService
{
    public class AuthorityDB
    {
        public string[] GetAuthorityByStaffID(int StaffID)
        {
            string[] Auth = new string[400];
            DbHelper db = new DbHelper();
            DbCommand cmd = db.GetStoredProcCommond("GetAuthorityByStaffID");
            db.AddInParameter(cmd, "@StaffID", DbType.Int32, StaffID);
            db.AddOutParameter(cmd, "@Authority", DbType.String, 400);
            db.ExecuteNonQuery(cmd);
            string authority = db.GetParameter(cmd, "@Authority").Value as string;
            Auth = authority.Split(',');
            return Auth;
        }
    }
}
