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
using ModelService;
using System.Data.OleDb;

namespace CRMDBService
{
    public class ModifyCustomerDB
    {
        ModelService.CustomerInfo CIF = new CustomerInfo();
        ModelService.Intention IT=new Intention();
        ModelService.LanguageSkills LS = new LanguageSkills();
        ModelService.FamilyInfo FI = new FamilyInfo();

        public void InsertCustomerInfo(CustomerInfo CI,string staffName)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "Insert into CustomerInfo ";
            str += "(";
            str += "[CustomerName],";
            str += "[EnglishName],";
            str += "[Sex],";
            str += "[Birthday],";
            str += "[Age],";
            str += "[Phone],";
            str += "[TelPhone],";
            str += "[BackUpTel],";
            str += "[CProvince],";
            str += "[CCity],";
            str += "[CAddress],";
            str += "[CQQ],";
            str += "[Cemail],";
            str += "[OtherContact],";
            str += "[OtherContactPhone],";
            str += "[CustomerImportance],";
            str += "[Policymaker],";
            str += "[PolicymakerName],";
            str += "[CustomerClass],";
            str += "[DrainTowards],";
            str += "[ImportingPeople],";
            str += "[ImportingDate],";
            str += "[Sname],";
            str += "[Grade],";
            str += "[ProfessionName],";
            str += "[Remark],";
            str += "[CityInitial],";
            str += "[CustomerFrom],";
            str += "[FromData],";
            str += "[Reference],";
            str += "[ReferenceRemark],";
            str += "[ContractNum],";
            str += "[CustomerImprove],";
            str += "[WorkExperience],";
            str += "[AgentInfo])";
            str += " VALUES(";
            if (CI.CustomerName == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.CustomerName + "',";
            }
            if (CI.EnglishName == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.EnglishName + "',";
            }
            str += "" + CI.Sex + ",";
            if (CI.Birthday == ""|| CI.Birthday ==null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.Birthday + "',";
            }
            str += "" + CI.Age + ",";
            if (CI.Phone == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.Phone + "',";
            }
            if (CI.Telphone == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.Telphone + "',";
            }
            if (CI.BackUpTel == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.BackUpTel + "',";
            }
            if (CI.CProvince == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.CProvince + "',";
            }
            if (CI.CCity == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.CCity + "',";
            }
            if (CI.CAddress == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.CAddress + "',";
            }
            if (CI.CQQ == null)
            {
                str += "NULL";
            }
            else
            {
                str += "'" + CI.CQQ + "',";
            }
            if (CI.Cemail == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.Cemail + "',";
            }
            if (CI.OtherContact == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.OtherContact + "',";
            }
            if (CI.OtherContactPhone == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.OtherContactPhone + "',";
            }
            str += "" + CI.CustomerImportance + ",";
            if (CI.Policymaker == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.Policymaker + "',";
            }
            if (CI.PolicymakerName == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.PolicymakerName + "',";
            }

                

            str += "" + CI.CustomerClass + ",";


            str += "" + CI.DrainTowards + ",";

            str += "'" + staffName + "',";

            str += "'" + CI.ImportingDate + "',";

            if (CI.Sname == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.Sname + "',";
            }
            if (CI.Grade == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.Grade + "',";
            }
            if (CI.ProfessionName == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.ProfessionName + "',";
            }
            if (CI.Remark == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.Remark + "',";
            }
            if (CI.CityInitial == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.CityInitial + "',";
            }

                str += "" + CI.CustomerFrom + ",";

            if (CI.FromData == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.FromData + "',";
            }
            if (CI.Reference == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.Reference + "',";
            }
            if (CI.ReferenceRemark == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.ReferenceRemark + "',";
            }
            if (CI.ContractNum == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.ContractNum + "',";
            }
            str += "" + CI.CustomerImprove + ",";
            if (CI.WorkExperience == null)
            {
                str += "NULL,";
            }
            else
            {
                str += "'" + CI.WorkExperience + "',";
            }
            if (CI.AgentInfo == null)
            {
                str += "NULL)";
            }
            else
            {
                str += "'" + CI.AgentInfo + "')";
            }
            
            DbCommand cmd = db.GetSqlStringCommond(str);
            db.ExecuteNonQuery(cmd);

        }

        public void UpdateCustomerInfobyCustomerID(CustomerInfo CIF)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "Update CustomerInfo set ";

            str += "[CustomerName]='" + CIF.CustomerName+"',";
            str += "[EnglishName]='" + CIF.EnglishName + "',";
            str += "[Sex]='" + CIF.Sex + "',";
            str += "[Birthday]='" + CIF.Birthday + "',";
            str += "[Age]='" + CIF.Age + "',";
            str += "[Phone]='" + CIF.Phone + "',";
            str += "[TelPhone]='" + CIF.Telphone + "',";
            str += "[BackUpTel]='" + CIF.BackUpTel + "',";
            str += "[CProvince]='" + CIF.CProvince + "',";
            str += "[CCity]='" + CIF.CCity + "',";
            str += "[CAddress]='" + CIF.CAddress + "',";
            str += "[CQQ]='" + CIF.CQQ + "',";
            str += "[Cemail]='" + CIF.Cemail + "',";
            str += "[OtherContact]='" + CIF.OtherContact + "',";
            str += "[OtherContactPhone]='" + CIF.OtherContactPhone + "',";
            str += "[CustomerImportance]='" + CIF.CustomerImportance + "',";
            str += "[Policymaker]='" + CIF.Policymaker + "',";
            str += "[PolicymakerName]='" + CIF.PolicymakerName + "',";
            str += "[CustomerClass]='" + CIF.CustomerClass + "',";
            str += "[DrainTowards]='" + CIF.DrainTowards + "',";
            str += "[ImportingPeople]='" + CIF.ImportingPeople + "',";
            str += "[ImportingDate]='" + CIF.ImportingDate + "',";
            str += "[Sname]='" + CIF.Sname + "',";
            str += "[Grade]='" + CIF.Grade + "',";
            str += "[ProfessionName]='" + CIF.ProfessionName + "',";
            str += "[Remark]='" + CIF.Remark + "',";
            str += "[CityInitial]='" + CIF.CityInitial + "',";
            str += "[CustomerFrom]='" + CIF.CustomerFrom + "',";
            str += "[FromData]='" + CIF.FromData + "',";
            str += "[Reference]='" + CIF.Reference + "',";
            str += "[ReferenceRemark]='" + CIF.ReferenceRemark + "',";
            str += "[ContractNum]='" + CIF.ContractNum + "',";
            str += "[CustomerImprove]='" + CIF.CustomerImprove + "',";
            str += "[WorkExperience]='" + CIF.WorkExperience + "',";
            str += "[AgentInfo]='" + CIF.AgentInfo + "'";
            str += " From CustomerInfo";
            str += " where ";
            str += "CustomerInfo.CustomerID='" + CIF.CustomerID + "'";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            db.ExecuteNonQuery(cmd);

        }

        public DataSet GetCustomerInfobyTelphone(string Telphone)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "select ";
            str += "[CustomerID],";
            str += "[CustomerName],";
            str += "[EnglishName],";
            str += "[Sex],";
            str += "[Birthday],";
            str += "[Age],";
            str += "[Phone],";
            str += "[TelPhone],";
            str += "[BackUpTel],";
            str += "[CProvince],";
            str += "[CCity],";
            str += "[CAddress],";
            str += "[CQQ],";
            str += "[Cemail],";
            str += "[OtherContact],";
            str += "[OtherContactPhone],";
            str += "[CustomerImportance],";
            str += "[Policymaker],";
            str += "[PolicymakerName],";
            str += "[CustomerClass],";
            str += "[DrainTowards],";
            str += "[ImportingPeople],";
            str += "[ImportingDate],";
            str += "[Sname],";
            str += "[Grade],";
            str += "[ProfessionName],";
            str += "[AdmissionCountry],";
            str += "[AdmissionCity],";
            str += "[AdmissionSname],";
            str += "[AdmissionProfessionName],";
            str += "[AdmissionDate],";
            str += "[Remark],";
            str += "[CityInitial],";
            str += "[CustomerFrom],";
            str += "[FromData],";
            str += "[AdmissionPhase],";
            str += "[Reference],";
            str += "[ReferenceRemark],";
            str += "[ContractNum],";
            str += "[CustomerImprove],";
            str += "[WorkExperience],";
            str += "[AgentInfo]";
            str += " From CustomerInfo";
            str += " where ";
            str += "TelPhone='" + Telphone + "'";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            db.ExecuteNonQuery(cmd);
            cmd.Dispose();
            return ds;
        }

        public DataSet GetCustomerInfobyCustomerID(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "select ";
            str += "[CustomerID],";
            str += "[CustomerName],";
            str += "[EnglishName],";
            str += "[Sex],";
            str += "[Birthday],";
            str += "[Age],";
            str += "[Phone],";
            str += "[TelPhone],";
            str += "[BackUpTel],";
            str += "[CProvince],";
            str += "[CCity],";
            str += "[CAddress],";
            str += "[CQQ],";
            str += "[Cemail],";
            str += "[OtherContact],";
            str += "[OtherContactPhone],";
            str += "[CustomerImportance],";
            str += "[Policymaker],";
            str += "[PolicymakerName],";
            str += "[CustomerClass],";
            str += "[DrainTowards],";
            str += "[ImportingPeople],";
            str += "[ImportingDate],";
            str += "[Sname],";
            str += "[Grade],";
            str += "[ProfessionName],";
            str += "[AdmissionCountry],";
            str += "[AdmissionCity],";
            str += "[AdmissionSname],";
            str += "[AdmissionProfessionName],";
            str += "[AdmissionDate],";
            str += "[AdmissionPhase],";
            str += "[Remark],";
            str += "[CityInitial],";
            str += "[CustomerFrom],";
            str += "[FromData],";
            str += "[Reference],";
            str += "[ReferenceRemark],";
            str += "[ContractNum],";
            str += "[CustomerImprove],";
            str += "[WorkExperience],";
            str += "[AgentInfo]";
            str += " From CustomerInfo";
            str += " where ";
            str += "CustomerID=" + CustomerID + "";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            db.ExecuteNonQuery(cmd);
            cmd.Dispose();
            return ds;
        }

        public CustomerInfo GetCustomerInfobyCustomerIDtoCIF(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "select ";
            str += "[CustomerID],";
            str += "[CustomerName],";
            str += "[EnglishName],";
            str += "[Sex],";
            str += "[Birthday],";
            str += "[Age],";
            str += "[Phone],";
            str += "[TelPhone],";
            str += "[BackUpTel],";
            str += "[CProvince],";
            str += "[CCity],";
            str += "[CAddress],";
            str += "[CQQ],";
            str += "[Cemail],";
            str += "[OtherContact],";
            str += "[OtherContactPhone],";
            str += "[CustomerImportance],";
            str += "[Policymaker],";
            str += "[PolicymakerName],";
            str += "[CustomerClass],";
            str += "[DrainTowards],";
            str += "[ImportingPeople],";
            str += "[ImportingDate],";
            str += "[Sname],";
            str += "[Grade],";
            str += "[ProfessionName],";

            str += "[Remark],";
            str += "[CityInitial],";
            str += "[CustomerFrom],";
            str += "[FromData],";
            str += "[Reference],";
            str += "[ReferenceRemark],";
            str += "[ContractNum],";
            str += "[CustomerImprove],";
            str += "[WorkExperience],";
            str += "[AgentInfo]";
            str += " From CustomerInfo";
            str += " where ";
            str += "CustomerID=" + CustomerID + "";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            db.ExecuteNonQuery(cmd);
            CIF.CustomerID = int.Parse(ds.Tables[0].Rows[0]["CustomerID"].ToString());
            CIF.CustomerName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
            CIF.EnglishName = ds.Tables[0].Rows[0]["EnglishName"].ToString();
            CIF.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
            CIF.Birthday = ds.Tables[0].Rows[0]["Birthday"].ToString();
            CIF.Age = int.Parse(ds.Tables[0].Rows[0]["Age"].ToString());
            CIF.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
            CIF.Telphone = ds.Tables[0].Rows[0]["Telphone"].ToString();
            CIF.BackUpTel = ds.Tables[0].Rows[0]["BackUpTel"].ToString();
            CIF.CProvince = ds.Tables[0].Rows[0]["CProvince"].ToString();
            CIF.CCity = ds.Tables[0].Rows[0]["CCity"].ToString();
            CIF.CAddress = ds.Tables[0].Rows[0]["CAddress"].ToString();
            CIF.CQQ = ds.Tables[0].Rows[0]["CQQ"].ToString();
            CIF.Cemail = ds.Tables[0].Rows[0]["Cemail"].ToString();
            CIF.OtherContact = ds.Tables[0].Rows[0]["OtherContact"].ToString();
            CIF.OtherContactPhone = ds.Tables[0].Rows[0]["OtherContactPhone"].ToString();
            CIF.CustomerImportance = int.Parse(ds.Tables[0].Rows[0]["CustomerImportance"].ToString());
            CIF.Policymaker = ds.Tables[0].Rows[0]["Policymaker"].ToString();
            CIF.PolicymakerName = ds.Tables[0].Rows[0]["PolicymakerName"].ToString();
            CIF.CustomerClass = int.Parse(ds.Tables[0].Rows[0]["CustomerClass"].ToString());
            CIF.DrainTowards = int.Parse(ds.Tables[0].Rows[0]["DrainTowards"].ToString());
            CIF.ImportingPeople = ds.Tables[0].Rows[0]["ImportingPeople"].ToString();
            CIF.ImportingDate =Convert.ToDateTime(ds.Tables[0].Rows[0]["ImportingDate"].ToString());
            CIF.Sname = ds.Tables[0].Rows[0]["Sname"].ToString();
            CIF.Grade = ds.Tables[0].Rows[0]["Grade"].ToString();
            CIF.ProfessionName = ds.Tables[0].Rows[0]["ProfessionName"].ToString();
           
            CIF.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
            CIF.CityInitial = ds.Tables[0].Rows[0]["CityInitial"].ToString();
            CIF.CustomerFrom = int.Parse(ds.Tables[0].Rows[0]["CustomerFrom"].ToString());
            CIF.FromData = ds.Tables[0].Rows[0]["FromData"].ToString();
            CIF.Reference = ds.Tables[0].Rows[0]["Reference"].ToString();
            CIF.ReferenceRemark = ds.Tables[0].Rows[0]["ReferenceRemark"].ToString();
            CIF.ContractNum = ds.Tables[0].Rows[0]["ContractNum"].ToString();
            CIF.CustomerImprove = ds.Tables[0].Rows[0]["CustomerImprove"].ToString()==""?1:int.Parse(ds.Tables[0].Rows[0]["CustomerImprove"].ToString());
            CIF.WorkExperience = ds.Tables[0].Rows[0]["WorkExperience"].ToString();
            CIF.AgentInfo = ds.Tables[0].Rows[0]["AgentInfo"].ToString();
            return CIF;
        }

        public CustomerInfo GetAdmissionCustomerInfobyCustomerIDtoCIF(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "select ";
            str += "[CustomerID],";
            str += "[AdmissionCountry],";
            str += "[AdmissionCity],";
            str += "[AdmissionSname],";
            str += "[AdmissionProfessionName],";
            str += "[AdmissionDate],";
            str += "[AdmissionPhase],";
            str += "[AdmissionRemark]";
            str += " From CustomerInfo";
            str += " where ";
            str += "CustomerID=" + CustomerID + "";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            db.ExecuteNonQuery(cmd);
            CIF.AdmissionCity = ds.Tables[0].Rows[0]["AdmissionCity"].ToString();
            CIF.AdmissionCountry = ds.Tables[0].Rows[0]["AdmissionCountry"].ToString();
            CIF.AdmissionSname = ds.Tables[0].Rows[0]["AdmissionSname"].ToString();
            CIF.AdmissionProfessionName = ds.Tables[0].Rows[0]["AdmissionProfessionName"].ToString();
            if (ds.Tables[0].Rows[0]["AdmissionDate"].ToString() == "" || ds.Tables[0].Rows[0]["AdmissionDate"].ToString() == null)
            {
                CIF.AdmissionDate = "";
            }
            else
            {
                CIF.AdmissionDate = ds.Tables[0].Rows[0]["AdmissionDate"].ToString();
            }
            
            CIF.AdmissionRemark = ds.Tables[0].Rows[0]["AdmissionRemark"].ToString();
            return CIF;

        }

        public void UpdateAdmissionInfobyCustomerID(CustomerInfo CIF)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "Update CustomerInfo set";
            str += " [AdmissionCountry]='" + CIF.AdmissionCountry + "',";
            str += " [AdmissionCity]='" + CIF.AdmissionCity + "',";
            str += " [AdmissionSname]='" + CIF.AdmissionSname + "',";
            str += " [AdmissionProfessionName]='" + CIF.AdmissionProfessionName + "',";
            str += " [AdmissionDate]='" + CIF.AdmissionDate + "',";
            str += " [ReferenceRemark]='" + CIF.ReferenceRemark + "',";
            str += " [AdmissionPhase]='" + CIF.AdmissionPhase + "'";
            str += " where CustomerInfo.CustomerID=" + CIF.CustomerID;
            DbCommand cmd = db.GetSqlStringCommond(str);
            db.ExecuteNonQuery(cmd);
        }

        

        public void InsertCustomerIntention(Intention IT)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str +="INSERT INTO Intention";
            str +="([CustomerID]";
            str +=" ,[IntentionCountry]";
            str +=" ,[IntentionCity]";
            str +=",[IntentionSchool]";
            str +=",[IntentionProfession]";
            str +=",[BetterWantTo]";
            str +=",[Remark]";
            str +=",[Intentiondate]";
            str +=",[ApplyStatus]";
            str +=",[ApplyEndDate]";
            str +=",[FileID]";
            str +=",[IntentionPhase])";
            str +=" VALUES";
            str += "(";
            str += IT.CustomerID;
            if (IT.IntentionCountry.ToString() == "" || IT.IntentionCountry == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + IT.IntentionCountry.ToString() + "'";
            }
            if (IT.IntentionCity.ToString() == "" || IT.IntentionCity == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + IT.IntentionCity.ToString() + "'";
            }
            if (IT.IntentionSchool.ToString() == "" || IT.IntentionSchool == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + IT.IntentionSchool.ToString() + "'";
            }
            if (IT.IntentionProfession.ToString() == "" || IT.IntentionProfession == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + IT.IntentionProfession.ToString() + "'";
            }
            str += "," + IT.BetterWantpriTo.ToString();
            if (IT.Remark.ToString() == "" || IT.Remark == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + IT.Remark.ToString() + "'";
            }
            if (IT.Intentiondate.ToString() == "" || IT.Intentiondate == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + IT.Intentiondate.ToString() + "'";
            }
            if (IT.ApplyStatus.ToString() == "" || IT.ApplyStatus == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + IT.ApplyStatus.ToString() + "'";
            }
            if (IT.ApplyEndDate.ToString() == "" || IT.ApplyEndDate == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + IT.ApplyEndDate.ToString() + "'";
            }
            if (IT.FileID.ToString() == "0" || IT.FileID == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + IT.FileID.ToString() + "'";
            }
            str += "," + IT.IntentionPhase.ToString();
            str += ")";
            DbCommand cmd = db.GetSqlStringCommond(str);
            db.ExecuteNonQuery(cmd);
        }

        public void DeleteFileInfoRelationbyFileID(int FileID)
        {
            DbHelper db = new DbHelper();
            string sqlstr = "";
            sqlstr += "Update ";
            sqlstr += " Intention set";
            sqlstr += " FileID=NULL";
            sqlstr += " where Intention.FileID='" + FileID + "'";
            DbCommand cmd = db.GetSqlStringCommond(sqlstr);
            db.ExecuteNonQuery(cmd);
        }


        public void InsertFamilyInfo(FamilyInfo FI)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "INSERT INTO FamilyInfo";
            str += "([CustomerID]";
            str += " ,[ParentName]";
            str += " ,[ParentBirthday]";
            str += ",[ParentMobilephone]";
            str += ",[ParentTelphone]";
            str += ",[ParentWorkUnit]";
            str += ",[ParentWorkPosition]";
            str += ",[ParentQQ]";
            str += ",[ParentAge]";
            str += ",[ParentMail]";
            str += ",[ParentInCome]";
            str += ",[Relationship]";
            str += ",[BirthdayRemind]";
            str += ",[Remark]";
            str += ",[ParentProvince]";
            str += ",[ParentCity]";
            str += ",[ParentCityInitial]";
            str += ",[Sex])";
            str += " VALUES";
            str += "(";
            str += FI.CustomerID;
            if (FI.ParentName.ToString() == "" || FI.ParentName == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + FI.ParentName.ToString() + "'";
            }
            if (FI.ParentBirthday.ToString() == "" || FI.ParentBirthday == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + FI.ParentBirthday.ToString() + "'";
            }
            if (FI.ParentMobilephone.ToString() == "" || FI.ParentMobilephone == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + FI.ParentMobilephone.ToString() + "'";
            }
            if (FI.ParentTelphone.ToString() == "" || FI.ParentTelphone == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + FI.ParentTelphone.ToString() + "'";
            }
            if (FI.ParentWorkUnit.ToString() == "" || FI.ParentWorkUnit == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + FI.ParentWorkUnit.ToString() + "'";
            }
            if (FI.ParentWorkPosition.ToString() == "" || FI.ParentWorkPosition == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + FI.ParentWorkPosition.ToString() + "'";
            }
            if (FI.ParentQQ.ToString() == "" || FI.ParentQQ == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + FI.ParentQQ.ToString() + "'";
            }
            if (FI.ParentAge.ToString() == "")
            {
                str += ",0";
            }
            else
            {
                str += ",'" + FI.ParentAge.ToString() + "'";
            }
            if (FI.ParentMail.ToString() == "" || FI.ParentMail == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + FI.ParentMail.ToString() + "'";
            }
            if (FI.ParentInCome.ToString() == "" || FI.ParentInCome == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + FI.ParentInCome.ToString() + "'";
            }
            if (FI.Relationship.ToString() == "" || FI.Relationship == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + FI.Relationship.ToString() + "'";
            }
                str += ",'" + FI.BirthdayRemind.ToString() + "'";
            if (FI.Remark.ToString() == "" || FI.Remark == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + FI.Remark.ToString() + "'";
            }
            if (FI.ParentProvince.ToString() == "" || FI.ParentProvince == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + FI.ParentProvince.ToString() + "'";
            }
            if (FI.ParentCity.ToString() == "" || FI.ParentCity == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + FI.ParentCity.ToString() + "'";
            }
            if (FI.ParentCityInitial.ToString() == "" || FI.ParentCityInitial == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + FI.ParentCityInitial.ToString() + "'";
            }
            str += ",'" + FI.ParentSex + "')";
            DbCommand cmd = db.GetSqlStringCommond(str);
            db.ExecuteNonQuery(cmd);
        }

        public void UpdateFamilyInfo(FamilyInfo FI)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "Update FamilyInfo set";
            str += " [ParentName]='" + FI.ParentName + "',";
            if (FI.ParentBirthday == "")
            {
                str += " [ParentBirthday]=NULL,";
            }
            else
            {
                str += " [ParentBirthday]='" + FI.ParentBirthday + "',";
            }
            str += " [ParentMobilephone]='" + FI.ParentMobilephone + "',";
            str += " [ParentTelphone]='" + FI.ParentTelphone + "',";
            str += " [ParentWorkUnit]='" + FI.ParentWorkUnit + "',";
            str += " [ParentWorkPosition]='" + FI.ParentWorkPosition + "',";
            str += " [ParentQQ]='" + FI.ParentQQ + "',";
            str += " [ParentAge]='" + FI.ParentAge.ToString() + "',";
            str += " [ParentInCome]='" + FI.ParentInCome + "',";
            str += " [Relationship]='" + FI.Relationship + "',";
            str += " [BirthdayRemind]='" + FI.BirthdayRemind + "',";
            str += " [Remark]='" + FI.Remark + "',";
            str += " [Sex]='" + FI.ParentSex + "',";
            str += " [ParentProvince]='" + FI.ParentProvince + "',";
            str += " [ParentCity]='" + FI.ParentCity + "',";
            str += " [ParentCityInitial]='" + FI.ParentCityInitial + "'";
            str += " where FamilyInfo.FID=" + FI.FID;
            DbCommand cmd = db.GetSqlStringCommond(str);
            db.ExecuteNonQuery(cmd);
        }


        public void DeleteFamilyInfobyFID(int FID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "Delete From FamilyInfo where FamilyInfo.FID=" + FID.ToString();
            DbCommand cmd = db.GetSqlStringCommond(str);
            db.ExecuteNonQuery(cmd);
        }

        public void UpdateCustomerIntention(Intention IT)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "Update Intention set";
            str += " [IntentionCountry]='"+IT.IntentionCountry+"',";
            str += " [IntentionCity]='" + IT.IntentionCity + "',";
            str += " [IntentionSchool]='" + IT.IntentionSchool + "',";
            str += " [IntentionProfession]='" + IT.IntentionProfession + "',";
            str += " [BetterWantTo]=" + IT.BetterWantpriTo.ToString() + ",";
            str += " [Remark]='" + IT.Remark + "',";
            str += " [IntentionPhase]=" + IT.IntentionPhase + ",";
            str += "[Intentiondate]='" + IT.Intentiondate + "',";
            str += "[ApplyStatus]=" + IT.ApplyStatus + ",";
            str += "[ApplyEndDate]='" + IT.ApplyEndDate + "',";
            str += "[FileID]='" + IT.FileID + "'";
            str += " where Intention.ITTID=" + IT.ITTID;
            DbCommand cmd = db.GetSqlStringCommond(str);
            db.ExecuteNonQuery(cmd);
        }

        public void DeleteCustomerIntentionbyITTID(int ITTID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "Delete From Intention where Intention.ITTID=" + ITTID.ToString();
            DbCommand cmd = db.GetSqlStringCommond(str);
            db.ExecuteNonQuery(cmd);
        }

        public DataSet GetCustomerIntentionbyCustomerID(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str +="SELECT ";
            str +="[ITTID],";
            str +="[CustomerID],";
            str +="[IntentionCountry],";
            str +="[IntentionCity],";
            str +="[IntentionSchool],";
            str +="[IntentionProfession],";
            str +="[BetterWantTo],";
            str +="[Remark],";
            str +="[IntentionPhase],";
            str +="[Intentiondate],";
            str +="[ApplyStatus],";
            str +="[ApplyEndDate],";
            str +="[FileID]";
            str +=" FROM ";
            str +=" Intention ";
            str +=" WHERE ";
            str +=" Intention.CustomerID="+CustomerID.ToString();
            str += " order by Intention.BetterWantTo";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            db.ExecuteNonQuery(cmd);
            //IT.ITTID = int.Parse(ds.Tables[0].Rows[0]["ITTID"].ToString().Trim());
            //IT.CustomerID = int.Parse(ds.Tables[0].Rows[0]["CustomerID"].ToString().Trim());
            //IT.IntentionCountry = ds.Tables[0].Rows[0]["IntentionCountry"].ToString().Trim();
            //IT.IntentionCity = ds.Tables[0].Rows[0]["IntentionCity"].ToString().Trim();
            //IT.IntentionSchool = ds.Tables[0].Rows[0]["IntentionSchool"].ToString().Trim();
            //IT.IntentionProfession = ds.Tables[0].Rows[0]["IntentionProfession"].ToString().Trim();
            //IT.BetterWantpriTo = int.Parse(ds.Tables[0].Rows[0]["BetterWantTo"].ToString().Trim());
            //IT.Remark = ds.Tables[0].Rows[0]["Remark"].ToString().Trim();
            //IT.IntentionPhase = int.Parse(ds.Tables[0].Rows[0]["IntentionPhase"].ToString().Trim());
            return ds;
        }

        public DataSet GetFamilyInfobyCustomerID(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "SELECT ";
            str += "[FID],";
            str += "[CustomerID],";
            str += "[ParentName],";
            str += "[ParentBirthday],";
            str += "[ParentMobilephone],";
            str += "[ParentTelphone],";
            str += "[ParentWorkUnit],";
            str += "[ParentWorkPosition],";
            str += "[ParentQQ],";
            str += "[ParentAge],";
            str += "[ParentMail],";
            str += "[ParentInCome],";
            str += "[Relationship],";
            str += "[BirthdayRemind],";
            str += "[Remark],";
            str += "[Sex],";
            str += "[ParentProvince],";
            str += "[ParentCity],";
            str += "[ParentCityInitial]";
            str += " FROM ";
            str += " FamilyInfo ";
            str += " WHERE ";
            str += " FamilyInfo.CustomerID=" + CustomerID.ToString();
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            db.ExecuteNonQuery(cmd);
            //IT.ITTID = int.Parse(ds.Tables[0].Rows[0]["ITTID"].ToString().Trim());
            //IT.CustomerID = int.Parse(ds.Tables[0].Rows[0]["CustomerID"].ToString().Trim());
            //IT.IntentionCountry = ds.Tables[0].Rows[0]["IntentionCountry"].ToString().Trim();
            //IT.IntentionCity = ds.Tables[0].Rows[0]["IntentionCity"].ToString().Trim();
            //IT.IntentionSchool = ds.Tables[0].Rows[0]["IntentionSchool"].ToString().Trim();
            //IT.IntentionProfession = ds.Tables[0].Rows[0]["IntentionProfession"].ToString().Trim();
            //IT.BetterWantpriTo = int.Parse(ds.Tables[0].Rows[0]["BetterWantTo"].ToString().Trim());
            //IT.Remark = ds.Tables[0].Rows[0]["Remark"].ToString().Trim();
            //IT.IntentionPhase = int.Parse(ds.Tables[0].Rows[0]["IntentionPhase"].ToString().Trim());
            return ds;
        }

        public DataSet GetFamilyInfobyFID(int FID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "SELECT ";
            str += "[FID],";
            str += "[CustomerID],";
            str += "[ParentName],";
            str += "[ParentBirthday],";
            str += "[ParentMobilephone],";
            str += "[ParentTelphone],";
            str += "[ParentWorkUnit],";
            str += "[ParentWorkPosition],";
            str += "[ParentQQ],";
            str += "[ParentAge],";
            str += "[ParentMail],";
            str += "[ParentInCome],";
            str += "[Relationship],";
            str += "[BirthdayRemind],";
            str += "[Remark],";
            str += "[Sex],";
            str += "[ParentProvince],";
            str += "[ParentCity],";
            str += "[ParentCityInitial]";
            str += " FROM ";
            str += " FamilyInfo ";
            str += " WHERE ";
            str += " FamilyInfo.FID=" + FID.ToString();
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            db.ExecuteNonQuery(cmd);
            //IT.ITTID = int.Parse(ds.Tables[0].Rows[0]["ITTID"].ToString().Trim());
            //IT.CustomerID = int.Parse(ds.Tables[0].Rows[0]["CustomerID"].ToString().Trim());
            //IT.IntentionCountry = ds.Tables[0].Rows[0]["IntentionCountry"].ToString().Trim();
            //IT.IntentionCity = ds.Tables[0].Rows[0]["IntentionCity"].ToString().Trim();
            //IT.IntentionSchool = ds.Tables[0].Rows[0]["IntentionSchool"].ToString().Trim();
            //IT.IntentionProfession = ds.Tables[0].Rows[0]["IntentionProfession"].ToString().Trim();
            //IT.BetterWantpriTo = int.Parse(ds.Tables[0].Rows[0]["BetterWantTo"].ToString().Trim());
            //IT.Remark = ds.Tables[0].Rows[0]["Remark"].ToString().Trim();
            //IT.IntentionPhase = int.Parse(ds.Tables[0].Rows[0]["IntentionPhase"].ToString().Trim());
            return ds;
        }


        public DataSet GetLanguageSkillsbyCustomerID(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "SELECT ";
            str += "[LGID],";
            str += "[CustomerID],";
            str += "[LGIName],";
            str += "[Score],";
            str += "[ImportingDate],";
            str += "[Remark]";
            str += " FROM ";
            str += " LanguageSkills ";
            str += " WHERE ";
            str += " LanguageSkills.CustomerID=" + CustomerID.ToString();
            str += " order by LanguageSkills.ImportingDate DESC";
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            db.ExecuteNonQuery(cmd);
            return ds;
        }


        public void InsertLanguageSkills(LanguageSkills LS)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "INSERT INTO LanguageSkills";
            str += "([CustomerID]";
            str += " ,[LGIName]";
            str += " ,[Score]";
            str += ",[ImportingDate]";
            str += ",[Remark]";
            str += ")";
            str += " VALUES ";
            str += "(";
            str += LS.CustomerID;
            if (LS.LGIName.ToString() == "" || LS.LGIName == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + LS.LGIName.ToString() + "'";
            }
            if (LS.Score.ToString() == "" || LS.Score == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + LS.Score.ToString() + "'";
            }
            str += ",'" + LS.ImportingDate.ToString() + "'";
            if (LS.Remark.ToString() == "" || LS.Remark == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + LS.Remark.ToString() + "'";
            }
            str += ")";
            DbCommand cmd = db.GetSqlStringCommond(str);
            db.ExecuteNonQuery(cmd);
        }

        public void UpdateLanguageSkills(LanguageSkills LS)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "Update LanguageSkills set";
            str += " [CustomerID]='" + LS.CustomerID + "',";
            str += " [LGIName]='" + LS.LGIName + "',";
            str += " [Score]='" + LS.Score + "',";
            str += " [ImportingDate]='" + LS.ImportingDate + "',";
            if (LS.Remark.ToString() == "" || LS.Remark == null)
            {
                str += " [Remark]=NULL";
            }
            else
            {
                str += " [Remark]=" + LS.Remark.ToString() + "";
            }
            str += " where LanguageSkills.LGID=" + LS.LGID;
            DbCommand cmd = db.GetSqlStringCommond(str);
            db.ExecuteNonQuery(cmd);
        }






        public void DeleteLanguageSkillsbyLGID(int LGID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "Delete From LanguageSkills where LanguageSkills.LGID=" + LGID.ToString();
            DbCommand cmd = db.GetSqlStringCommond(str);
            db.ExecuteNonQuery(cmd);
        }

        public void InsertSchoolRankInfo(SchoolRankInfo SRI)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "INSERT INTO SchoolRankInfo";
            str += "([CustomerID]";
            str += " ,[AverageScore]";
            str += " ,[Ranking]";
            str += ",[SchoolOtherInfo]";
            str += ",[Remark]";
            str += ",[CurrentSchool]";
            str += ",[Major]";
            str += ")";
            str += " VALUES ";
            str += "(";
            str += SRI.CustomerID;
            if (SRI.AverageScore.ToString() == "" || SRI.AverageScore == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + SRI.AverageScore.ToString() + "'";
            }
            if (SRI.Ranking.ToString() == "" || SRI.Ranking == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + SRI.Ranking.ToString() + "'";
            }
            if (SRI.SchoolOtherInfo == "" || SRI.SchoolOtherInfo == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + SRI.SchoolOtherInfo.ToString() + "'";
            }
            if (SRI.Remark == "" || SRI.Remark == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + SRI.Remark.ToString() + "'";
            }
            if (SRI.CurrentSchool.ToString() == "" || SRI.CurrentSchool == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + SRI.CurrentSchool.ToString() + "'";
            }
            if (SRI.Major.ToString() == "" || SRI.Major == null)
            {
                str += ",NULL";
            }
            else
            {
                str += ",'" + SRI.Major.ToString() + "'";
            }
            str += ")";
            DbCommand cmd = db.GetSqlStringCommond(str);
            db.ExecuteNonQuery(cmd);
        }

        public DataSet GetSchoolInfobyCustomerID(int CustomerID)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "SELECT ";
            str += "[AverageScore],";
            str += "[CustomerID],";
            str += "[Ranking],";
            str += "[SchoolOtherInfo],";
            str += "[CurrentSchool],";
            str += "[Major]";
            str += " FROM ";
            str += " SchoolRankInfo ";
            str += " WHERE ";
            str += " SchoolRankInfo.CustomerID=" + CustomerID.ToString();
            DbCommand cmd = db.GetSqlStringCommond(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            db.ExecuteNonQuery(cmd);
            return ds;
        }

        public void UpdateSchoolInfo(string AverageScore, string Ranking, string SchoolOtherInfo, string CustomerID, string CurrentSchool, string Major)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "Update SchoolRankInfo set";
            str += " [AverageScore]='" + AverageScore + "',";
            str += " [Ranking]='" + Ranking + "',";
            str += " [SchoolOtherInfo]='" + SchoolOtherInfo + "',";
            str += " [Major]='" + Major + "',";
            str += " [CurrentSchool]='" + CurrentSchool + "'";
            str += " where SchoolRankInfo.CustomerID=" + CustomerID;
            DbCommand cmd = db.GetSqlStringCommond(str);
            db.ExecuteNonQuery(cmd);
        }

        public void DeleteSchoolInfo(string AverageScore, string Ranking, string SchoolOtherInfo, string CustomerID, string CurrentSchool, string Major)
        {
            DbHelper db = new DbHelper();
            string str = "";
            str += "Update SchoolRankInfo set";
            str += " [AverageScore]='',";
            str += " [Ranking]='',";
            str += " [CurrentSchool]='',";
            str += " [Major]='',";
            str += " [SchoolOtherInfo]=''";
            str += " where SchoolRankInfo.CustomerID=" + CustomerID;
            DbCommand cmd = db.GetSqlStringCommond(str);
            db.ExecuteNonQuery(cmd);
        }



        public DataSet ExcelToDS(string Path) 
        {
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Path + ";" + "Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'"; 
            OleDbConnection conn = new OleDbConnection(strConn); 
            conn.Open(); 
            string strExcel = ""; 
            OleDbDataAdapter myCommand = null; 
            DataSet ds = null; 
            strExcel = "select * from [sheet1$]"; 
            myCommand = new OleDbDataAdapter(strExcel, strConn); 
            ds = new DataSet(); 
            myCommand.Fill(ds, "table1");
            conn.Close();
            return ds; 
        }  

    }
}
