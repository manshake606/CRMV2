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

namespace CRMControlService
{
    public class AuthorityService
    {
        public int CheckAuthorityByStaffID_Service(int staffID,string moduleID)
        {
            CRMDBService.AuthorityDB adb = new AuthorityDB();
            string[] Auto = adb.GetAuthorityByStaffID(staffID);
            int k = 0;
            switch (char.Parse(moduleID))
            {
                case '1':
                    for (int i = 0; i < Auto.Length; i++)
                    {
                        
                        if (Auto[i] == "1")
                        {
                            k = int.Parse(Auto[i]);
                        }
                        if (Auto[i] == "2")
                        {
                            k = int.Parse(Auto[i]);
                            break;
                        }
                    }
                    break;
                case '2':
                    for (int i = 0; i < Auto.Length; i++)
                    {

                        if (Auto[i] == "3")
                        {
                            k = int.Parse(Auto[i]);
                        }
                        if (Auto[i] == "4")
                        {
                            k = int.Parse(Auto[i]);
                            break;
                        }
                    }
                    break;
                case '3':
                    for (int i = 0; i < Auto.Length; i++)
                    {

                        if (Auto[i] == "5")
                        {
                            k = int.Parse(Auto[i]);
                        }
                        if (Auto[i] == "6")
                        {
                            k = int.Parse(Auto[i]);
                            break;
                        }
                    }
                    break;
                case '4':
                    for (int i = 0; i < Auto.Length; i++)
                    {

                        if (Auto[i] == "7")
                        {
                            k = int.Parse(Auto[i]);
                        }
                        if (Auto[i] == "8")
                        {
                            k = int.Parse(Auto[i]);
                        }
                        if (Auto[i] == "9")
                        {
                            k = int.Parse(Auto[i]);
                            break;
                        }
                    }
                    break;
                case '5':
                    for (int i = 0; i < Auto.Length; i++)
                    {

                        if (Auto[i] == "10")
                        {
                            k = int.Parse(Auto[i]);
                        }
                        if (Auto[i] == "11")
                        {
                            k = int.Parse(Auto[i]);
                            break;
                        }
                    }
                    break;
                case '6':
                    for (int i = 0; i < Auto.Length; i++)
                    {

                        if (Auto[i] == "12")
                        {
                            k = int.Parse(Auto[i]);
                        }
                        if (Auto[i] == "13")
                        {
                            k = int.Parse(Auto[i]);
                            break;
                        }
                    }
                    break;
                case '7':
                    for (int i = 0; i < Auto.Length; i++)
                    {

                        if (Auto[i] == "14")
                        {
                            k = int.Parse(Auto[i]);
                        }
                        if (Auto[i] == "15")
                        {
                            k = int.Parse(Auto[i]);
                            break;
                        }
                    }
                    break;
                case '8':
                    for (int i = 0; i < Auto.Length; i++)
                    {

                        if (Auto[i] == "16")
                        {
                            k = int.Parse(Auto[i]);
                        }
                        if (Auto[i] == "17")
                        {
                            k = int.Parse(Auto[i]);
                        }
                    }
                    break;
            }
            return k;

        }
    }
}
