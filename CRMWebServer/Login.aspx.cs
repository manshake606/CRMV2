using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CRMControlService;

namespace CRMWebServer
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoginInfoService login = new LoginInfoService();
            string loginName = txtLoginName.Value.ToString().Trim();
            //string paramProperty = loginName.Substring(0, 1).ToString();
            //int paramID = Convert.ToInt32(loginName.Substring(1, 5));
            string passwordstr = txtPassword.Value.ToString().Trim();
            int value = login.CheckStaff(loginName, passwordstr);

            switch (value)
            {
                case 0: Response.Write("<script language = 'javascript'> alert ('请输入正确的用户名和密码');</script>"); break;
                case 1: Response.Write("<script language = 'javascript'> alert ('该用户名不存在');</script>"); break;
                case 2: Response.Write("<script language = 'javascript'> alert ('请输入正确的密码');</script>"); break;
                case 3:
                    {
                        Session["staffID"] = Convert.ToInt32(login .GetStaffIDFromLoginName (loginName));
                        Session["positionID"] = Convert.ToInt32(login.GetPostIDFromLoginName(loginName));
                        Response.Redirect("index.aspx");
                    } break;
                case 4: Response.Write("<script language = 'javascript'> alert ('对不起，您没有登陆权限，请及时联系管理员获取权限');</script>"); break;
                default: Response.Write("<script language = 'javascript'> alert ('请输入正确的用户名和密码');</script>"); break;
            }
        }

    }
}
