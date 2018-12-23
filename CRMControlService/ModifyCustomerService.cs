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
using ModelService;


namespace CRMControlService
{
    public class ModifyCustomerService
    {
        CRMDBService.ModifyCustomerDB MCDB = new ModifyCustomerDB();
        AssignStateDB ASDB = new AssignStateDB();
        LogInfoDB LIDB = new LogInfoDB();
        DataSet DS = new DataSet();
        CustomerInfo CIF = new CustomerInfo();

        ModelService.Intention IT = new Intention();
        ModelService.LanguageSkills LS=new LanguageSkills();
        CRMControlService.StaffInfoService SIS = new StaffInfoService();


        public int UpdateCustomerInfobyCustomerID_Service(CustomerInfo CIF)
        {
            int Pass = 0;
            try
            {
                MCDB.UpdateCustomerInfobyCustomerID(CIF);
            }
            catch
            {
                Pass = 1;

            }
            return Pass;
        }


        public void LoadCustomer(DataRow DR)
        {
            CIF.CustomerName = DR["CustomerName"].ToString().Trim();
            CIF.Telphone = DR["TelPhone"].ToString().Trim();
            CIF.CProvince = DR["CProvince"].ToString().Trim();
            CIF.CCity = DR["CCity"].ToString().Trim();
            CIF.EnglishName = DR["EnglishName"].ToString().Trim();
            CIF.Birthday = DR["Birthday"].ToString().Trim();
            if (CIF.Birthday == "" || CIF.Birthday == null)
            {
                CIF.Age = 0;
            }
            else
            {
                CIF.Age = DateTime.Now.Year - Convert.ToDateTime(CIF.Birthday.Trim()).Year + 1;
            }
            if (DR["Sex"].ToString() == "" || DR["Sex"].ToString() == "")
            {
                CIF.Sex = 0;
            }
            else
            {
                if (DR["Sex"].ToString() == "男")
                {
                    CIF.Sex = 0;
                }
                else if (DR["Sex"].ToString() == "女")
                {
                    CIF.Sex = 1;
                }
            }
            CIF.CQQ = DR["CQQ"].ToString().Trim();
            CIF.Phone = DR["Phone"].ToString().Trim();
            CIF.BackUpTel = DR["BackUpTel"].ToString().Trim();
            CIF.CityInitial = GetPYString(CIF.CCity).ToUpper().Trim();
            CIF.ProfessionName = DR["ProfessionName"].ToString().Trim();
            CIF.Cemail = DR["Cemail"].ToString().Trim();
            CIF.CAddress = DR["CAddress"].ToString().Trim();
            CIF.OtherContact = DR["OtherContact"].ToString().Trim();
            CIF.OtherContactPhone = DR["OtherContactPhone"].ToString().Trim();
            CIF.Policymaker = DR["Policymaker"].ToString().Trim();
            CIF.PolicymakerName = DR["PolicymakerName"].ToString().Trim();
            if (DR["CustomerClass"].ToString() == "" || DR["CustomerClass"].ToString() == null)
            {
                CIF.CustomerClass = 0;
            }
            else
            {
                if (DR["CustomerClass"].ToString() == "未分类")
                {
                    CIF.CustomerClass = 0;
                }
                else if (DR["CustomerClass"].ToString() == "短期潜在")
                {
                    CIF.CustomerClass = 1;
                }
                else if (DR["CustomerClass"].ToString() == "长期潜在")
                {
                    CIF.CustomerClass = 2;
                }
                else if(DR["CustomerClass"].ToString() == "意向不明")
                {
                    CIF.CustomerClass = 3;
                }
                else if(DR["CustomerClass"].ToString() == "已经签约")
                {
                    CIF.CustomerClass = 4;
                }
                else if(DR["CustomerClass"].ToString() == "已经流失")
                {
                    CIF.CustomerClass = 5;
                }
                
            }
            if (DR["DrainTowards"].ToString() == "" || DR["DrainTowards"].ToString() == null)
            {
                CIF.DrainTowards = 0;
            }
            else
            {
                if (DR["DrainTowards"].ToString() == "未流失")
                {
                    CIF.DrainTowards = 0;
                }
                else if (DR["DrainTowards"].ToString() == "本地留学中介")
                {
                    CIF.DrainTowards = 1;
                }
                else if (DR["DrainTowards"].ToString() == "外地留学中介")
                {
                    CIF.DrainTowards = 2;
                }
                else if (DR["DrainTowards"].ToString() == "语言培训机构")
                {
                    CIF.DrainTowards = 3;
                }
                else if (DR["DrainTowards"].ToString() == "学校统一办理")
                {
                    CIF.DrainTowards = 4;
                }
                else if (DR["DrainTowards"].ToString() == "学生自己办理")
                {
                    CIF.DrainTowards = 5;
                }
               
            }
            
            CIF.Sname = DR["Sname"].ToString().Trim();
            CIF.Grade = DR["Grade"].ToString().Trim();
            if (DR["CustomerImportance"].ToString() == "" || DR["CustomerImportance"].ToString() == null)
            {
                CIF.CustomerImportance = 1;
            }
            else
            {
                if (DR["CustomerImportance"].ToString() == "不重要")
                {
                    CIF.CustomerImportance = 0;
                }
                else if (DR["CustomerImportance"].ToString() == "一般")
                {
                    CIF.CustomerImportance = 1;
                }
                else if (DR["CustomerImportance"].ToString() == "重要")
                {
                    CIF.CustomerImportance = 2;
                }
                else if (DR["CustomerImportance"].ToString() == "特别重要")
                {
                    CIF.CustomerImportance = 3;
                }
                
            }

            if (DR["CustomerFrom"].ToString() == "" || DR["CustomerFrom"].ToString() == null)
            {
                CIF.CustomerFrom = 0;
            }
            else
            {
                if (DR["CustomerFrom"].ToString() == "来源不明")
                {
                    CIF.CustomerFrom = 0;
                }
                else if (DR["CustomerFrom"].ToString() == "名单预约")
                {
                    CIF.CustomerFrom = 1;
                }
                else if (DR["CustomerFrom"].ToString() == "客户推荐")
                {
                    CIF.CustomerFrom = 2;
                }
                else if (DR["CustomerFrom"].ToString() == "移民推荐")
                {
                    CIF.CustomerFrom = 3;
                }
                else if (DR["CustomerFrom"].ToString() == "常州推荐")
                {
                    CIF.CustomerFrom = 4;
                }
                else if (DR["CustomerFrom"].ToString() == "主动上门")
                {
                    CIF.CustomerFrom = 5;
                }
                else if (DR["CustomerFrom"].ToString() == "网络来源")
                {
                    CIF.CustomerFrom = 6;
                }
                else if (DR["CustomerFrom"].ToString() == "个人渠道")
                {
                    CIF.CustomerFrom = 7;
                }
                
            }
            CIF.Reference = DR["Reference"].ToString().Trim();
            CIF.FromData = DR["FromData"].ToString().Trim();
            CIF.ReferenceRemark = DR["ReferenceRemark"].ToString().Trim();
            //CIF.ImportingPeople = DR["ImportingPeople"].ToString().Trim();
            CIF.ImportingDate = DateTime.Now;
            CIF.Remark = DR["Remark"].ToString().Trim();
            IT.BetterWantpriTo = 0;
            IT.IntentionCountry = DR["IntentionCountry"].ToString().Trim();
            IT.IntentionPhase = 0;
            IT.IntentionProfession = "";
            IT.IntentionSchool = "";
            IT.Remark = "";
            IT.IntentionCity = "";
        }



        public int DoInsertBusiness(CustomerInfo CIF,int StaffID,Intention ITA)
        {
            int error = 0;
            DataSet dSF = new DataSet();
            dSF = SIS.GetStaffNamebyStaffID_Service(StaffID);
            string StaffName = dSF.Tables[0].Rows[0]["StaffName"].ToString();
            Trans t = new Trans();
            try
            {
                MCDB.InsertCustomerInfo(CIF, StaffName);
                DS = MCDB.GetCustomerInfobyTelphone(CIF.Telphone);
                CIF.CustomerID = int.Parse(DS.Tables[0].Rows[0]["CustomerID"].ToString());
                ITA.CustomerID = CIF.CustomerID;
                InsertCustomerIntention＿Service(ITA);
                ASDB.InsertAssignState(StaffID, CIF.CustomerID);
                LIDB.InsertLogInfo(StaffID, CIF.CustomerID,  0, 0, "");
                t.Commit();
            }
            catch
            {
                error = 1;
                t.RollBack();
                
            }
            return error;
               
        }

        public DataSet GetCustomerInfobyTelphone_Service(string Telphone)
        {
            DS = MCDB.GetCustomerInfobyTelphone(Telphone);
            return DS;
        }

        public DataSet GetCustomerInfobyCustomerID_Service(int CustomerID)
        {
            DS = MCDB.GetCustomerInfobyCustomerID(CustomerID);
            return DS;
        }

        public int UpdateAdmissionInfobyCustomerID_Service(CustomerInfo CIF)
        {
            int Pass = 0;
            try
            {
                MCDB.UpdateAdmissionInfobyCustomerID(CIF);
            }
            catch
            {
                Pass = 1;
            }
            return Pass;
        }


        public string doBatchInsert(string Path, int StaffID, ref int inputnum, ref int exist, ref int Errornum)
        {
            string AllError = "";
            try
            {
                DS = MCDB.ExcelToDS(Path);
            }
            catch(Exception ex)
            {
                ex.ToString();
                AllError = "文件读取异常，请检查是否已经打开！";
                return AllError;
            }
            
            int count=DS.Tables[0].Rows.Count;
            if (count == 0)
            {
                AllError = "模板数据为空！";
                return AllError;
            }
            DataSet dSF=new DataSet();
            dSF = SIS.GetStaffNamebyStaffID_Service(StaffID);
            string StaffName = dSF.Tables[0].Rows[0]["StaffName"].ToString();
            string ErrorName = "";
            int ErrorCount = 0;
            int Exist = 0;
            string ExistName = "";
            
            foreach (DataRow row in DS.Tables[0].Rows)
            {
                LoadCustomer(row);
                try
                {
                    DataSet dst = new DataSet();
                    dst=MCDB.GetCustomerInfobyTelphone(CIF.Telphone);
                    if (dst.Tables[0].Rows.Count > 0)
                    {
                        if (Exist == 0)
                        {
                            ExistName += CIF.CustomerName;
                        }
                        else
                        {
                            ExistName += "," + CIF.CustomerName;
                        }
                        Exist++;
                        continue;
                    }
                    MCDB.InsertCustomerInfo(CIF, StaffName);
                    DS = MCDB.GetCustomerInfobyTelphone(CIF.Telphone);
                    CIF.CustomerID = int.Parse(DS.Tables[0].Rows[0]["CustomerID"].ToString());
                    IT.CustomerID = CIF.CustomerID;
                    MCDB.InsertCustomerIntention(IT);
                    ASDB.InsertAssignState(StaffID, CIF.CustomerID);
                    LIDB.InsertLogInfo(StaffID, CIF.CustomerID, 0, 0, "");

                }
                catch
                {


                    if (ErrorCount == 0)
                    {
                        ErrorName += CIF.CustomerName;
                    }
                    else
                    {
                        ErrorName += "," + CIF.CustomerName;
                    }
                    ErrorCount++;
                }

                

                
            }
            if (ExistName != "")
            {
                AllError += ExistName + "手机号已经存在!";
            }
            if (ErrorName != "")
            {
                AllError += ExistName + "导入失败!";
            }
            exist = Exist;
            Errornum = ErrorCount;
            inputnum = count - Exist - ErrorCount;

            return AllError;
        }


        public int InsertCustomerIntention＿Service(Intention IT)
        {
            int Pass=0;
            try
            {
                MCDB.InsertCustomerIntention(IT);
            }
            catch
            {
                Pass = 1;
            }
            return Pass;
        }

        public int InsertLanguageSkills_Service(LanguageSkills LS)
        {
            int Pass = 0;
            try
            {
                MCDB.InsertLanguageSkills(LS);
            }
            catch
            {
                Pass = 1;
            }
            return Pass;
        }

        public int UpdateCustomerIntention_Service(Intention IT)
        {
            int Pass = 0;
            try
            {
                MCDB.UpdateCustomerIntention(IT);
            }
            catch
            {
                Pass = 1;
            }
            return Pass;
        }

        public int UpdateLanguageSkills_Service(LanguageSkills LS)
        {
            int Pass = 0;
            try
            {
                MCDB.UpdateLanguageSkills(LS);
            }
            catch
            {
                Pass = 1;
            }
            return Pass; 
        }


        public int DeleteCustomerIntentionbyITTID_Service(int ITTID)
        {
            int Pass = 0;
            try
            {
                MCDB.DeleteCustomerIntentionbyITTID(ITTID);
            }
            catch
            {
                Pass = 1;
            }
            return Pass;

        }

        public int DeleteLanguageSkillsbyLGID(int LGID)
        {
            int Pass = 0;
            try
            {
                MCDB.DeleteLanguageSkillsbyLGID(LGID);
            }
            catch
            {
                Pass = 1;
            }
            return Pass;
        }

        public DataSet GetCustomerIntentionbyCustomerID_Service(int CustomerID)
        {
            DS = MCDB.GetCustomerIntentionbyCustomerID(CustomerID);
            return DS;
        }


        public DataSet GetLanguageSkillsbyCustomerID_Service(int CustomerID)
        {
            DS = MCDB.GetLanguageSkillsbyCustomerID(CustomerID);
            return DS;
        }


        public DataSet GetSchoolInfobyCustomerID_Service(int CustomerID)
        {
            DS = MCDB.GetSchoolInfobyCustomerID(CustomerID);
            return DS;
        }

        public int UpdateSchoolInfo_Service(string AverageScore, string Ranking, string SchoolOtherInfo, string CustomerID)
        {
            int Pass = 0;
            try
            {
                MCDB.UpdateSchoolInfo(AverageScore, Ranking, SchoolOtherInfo, CustomerID);
            }
            catch
            {
                Pass = 1;
            }
            return Pass;
        }

        public int DeleteSchoolInfo_Service(string AverageScore, string Ranking, string SchoolOtherInfo, string CustomerID)
        {
            int Pass = 0;
            try
            {
                MCDB.DeleteSchoolInfo(AverageScore, Ranking, SchoolOtherInfo, CustomerID);
            }
            catch
            {
                Pass = 1;
            }
            return Pass;
        }


        public int InsertFamilyInfo_Service(FamilyInfo FI)
        {
            int Pass = 0;
            try
            {
                MCDB.InsertFamilyInfo(FI);
            }
            catch
            {
                Pass = 1;
            }
            return Pass;
        }

        public int UpdateFamilyInfo_Service(FamilyInfo FI)
        {
            int Pass = 0;
            try
            {
                MCDB.UpdateFamilyInfo(FI);
            }
            catch
            {
                Pass = 1;
            }
            return Pass;
        }

        public int DeleteFamilyInfobyFID_Service(int FID)
        {
            int Pass = 0;
            try
            {
                MCDB.DeleteFamilyInfobyFID(FID);
            }
            catch
            {
                Pass = 1;
            }
            return Pass;
        }

        public DataSet GetFamilyInfobyCustomerID_Service(int CustomerID)
        {
            DS = MCDB.GetFamilyInfobyCustomerID(CustomerID);
            return DS;
        }

        public DataSet GetFamilyInfobyFID_Service(int FID)
        {
            DS = MCDB.GetFamilyInfobyFID(FID);
            return DS;
        }

        public string GetPYString(string str)
        {
            string tempStr = "";
            foreach (char c in str)
            {
                if ((int)c >= 0 && (int)c <= 160)
                {//字母和符号原样保留十位数   
                    //tempStr += c.ToString();
                    tempStr += Convert.ToString(char.ToUpper(c));
                }
                else
                {//累加拼音声母    
                    tempStr += GetPYChar(c.ToString());

                }
            }
            return tempStr;
        }

        ///     
        /// 取单个字符的拼音声母    
        ///     
        /// 要转换的单个汉字    
        /// 拼音声母    
        public string GetPYChar(string c)
        {
            System.Text.Encoding GB2312 = System.Text.Encoding.GetEncoding("GB2312");//英文系统默认是一个汉字占一个字节，首先把汉字转换成GB2312编码方式
            byte[] array = new byte[2];
            array = GB2312.GetBytes(c);
            //array = System.Text.Encoding.Default.GetBytes(c);
            int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));
            if (i < 0xB0A1) return "*";
            if (i < 0xB0C5) return "a";
            if (i < 0xB2C1) return "b";
            if (i < 0xB4EE) return "c";
            if (i < 0xB6EA) return "d";
            if (i < 0xB7A2) return "e";
            if (i < 0xB8C1) return "f";
            if (i < 0xB9FE) return "g";
            if (i < 0xBBF7) return "h";
            if (i < 0xBFA6) return "j";
            if (i < 0xC0AC) return "k";
            if (i < 0xC2E8) return "l";
            if (i < 0xC4C3) return "m";
            if (i < 0xC5B6) return "n";
            if (i < 0xC5BE) return "o";
            if (i < 0xC6DA) return "p";
            if (i < 0xC8BB) return "q";
            if (i < 0xC8F6) return "r";
            if (i < 0xCBFA) return "s";
            if (i < 0xCDDA) return "t";
            if (i < 0xCEF4) return "w";
            if (i < 0xD1B9) return "x";
            if (i < 0xD4D1) return "y";
            if (i < 0xD7FA) return "z";
            return "*";
        }
    }
}
