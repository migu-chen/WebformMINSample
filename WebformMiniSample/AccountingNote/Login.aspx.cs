using AccountingNote.DBsource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["UserLOgInfo"] != null)
            {
              this.plcLogin.Visible = false;
               Response.Redirect("/SystemAdmin/UserInfo.aspx");
            }
            else
            {
                this.plcLogin.Visible = true;
            }
         }
            
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            //String db_acct = "admin";
            //String db_apwd = "12345";

            string inp_acct = this.txtaccount.Text;
            string inp_pwd = this.txtPWD.Text;

            if (string.IsNullOrWhiteSpace(inp_pwd) || string.IsNullOrWhiteSpace(inp_acct))
            {
                this.ItlMsg.Text = "Account/PWD is required.";
                return;
            }

            var dr = UserInfoManager.GetUserInfoListtest(inp_acct);
            if (dr == null)
            {
                this.ItlMsg .Text = "Account doesn`t exists";
                    return;
            }

            if(string .Compare (dr["Account"].ToString()  ,inp_acct ,true) == 0 &&
                 string .Compare (dr["PWD"].ToString(), inp_pwd ,false) == 0)
            {
                this.Session["UserLoginInfo"] = dr["Account"].ToString ();
                Response.Redirect("/SystemAdmin/UserInfo.aspx");
            }
            else
            {
                this.ItlMsg.Text = "Login fail,Please check Account /PWD .";
                return;
            }
        }
    }
}