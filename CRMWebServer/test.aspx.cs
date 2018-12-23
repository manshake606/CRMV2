using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using CRMControlService;
using CRMDBService;

namespace CRMWebServer
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string province = Request["ddlUProvince"];
            string city = Request["ddlUCity"]; 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        String ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CRMDB"].ConnectionString;
        //    SqlConnection objConnection = new SqlConnection(ConnectionString);
        //    objConnection.Open();
        //    SqlCommand myCommand=new SqlCommand("Insert into LoginInfo values (20)",objConnection);
        //    myCommand.ExecuteNonQuery();
        //    objConnection.Close();

            //String ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CRMDB"].ConnectionString;
            //SqlConnection objConnection = new SqlConnection(ConnectionString);
            //objConnection.Open();
            //SqlCommand sqlc = new SqlCommand("select * from LogInfo", objConnection);
            //SqlDataAdapter adpt = new SqlDataAdapter(sqlc);
            //sqlc.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            //adpt.Fill(dt);
            //objConnection.Close();
            //int kkk=Convert.ToInt32(dt.Rows[0]["DStaffID"]);
            //TextBox1.Text = kkk.ToString();

            
            //CRMDBService.LoginInfoDB log = new LoginInfoDB();
            //int kkk = 0;
            //string datatable = log.GetLoginInfo(kkk);
            //TextBox1.Text = datatable;

        //SqlConnection conn = new SqlConnection(ConnectionString);
        //conn.Open();
        //SqlCommand cmd = new SqlCommand("TestSelect", conn);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@test", SqlDbType.NVarChar, 50).Value = TextBox1.Text;
        //cmd.Parameters.Add("@addd", SqlDbType.Int);
        //cmd.Parameters["@addd"].Direction = ParameterDirection.ReturnValue;
        //cmd.Parameters.Add("@testing", SqlDbType.Int);.
        //cmd.Parameters["@testing"].Direction = ParameterDirection.ReturnValue;
        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //cmd.ExecuteNonQuery();
        //DataTable dt = new DataTable();
        //sda.Fill(dt);
        //conn.Close();
        //TextBox2.Text = cmd.Parameters["@addd"].Value.ToString();

        //try
        //{
        //    CRMControlService.LoginInfoService LogService = new LoginInfoService();
        //    DataTable dt = LogService.GetLoginInfoFromCustomerID_Service(1);
        //}
        //catch(Exception ex)
        //{
        //    throw new Exception(ex.ToString());
        //}

        //int kkk = int.Parse(TextBox1.Text);
            
        //DataTable dt = log.GetLoginInfo(kkk);
        //TextBox1.Text = dt.Rows[0]["DStraffID"].ToString();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            CRMDBService.ModifyCustomerDB MDB = new ModifyCustomerDB();
            DataSet DS = new DataSet();
            DS=MDB.ExcelToDS(@"D:\Uploadfile\CustomerTemp.xlsx");
        }
    }
}
