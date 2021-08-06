using AccountingNote.DBsource;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e )
        {
            // string account = this.Session["UserLoginInfo"] as string;
            string account = "Admin";
            var dr1 = DBsource.UserInfoManager.GetUserInfoListtest(account);
            var dt = AccountingManager.GetAccounttingList(dr1["ID"].ToString());

            if (dt.Rows.Count > 0)
            {
                this.gvAccountList.DataSource = dt;
                this.gvAccountList.DataBind();
            }
            else
            {
                this.gvAccountList.Visible = false;
                //this.plcNodata.Visible = true;
            }

            this.txrBox1.Text = dt.Rows[0]["CreateDate"].ToString();
            int vn = dt.Rows.Count;
            this.txrBox3.Text = vn.ToString();
            vn = vn - 1;
            this.txrBox2.Text = dt.Rows[vn]["CreateDate"].ToString();

            //GettestcounttingList
            //var dt1 = UserInfoManager.GetUserInfoListtest(account);
            var dt1 = UserInfoManager.aGetUserInfoListtest(account);
            var dt2 = AccountingManager.GetAccounttingList(dr1["ID"].ToString());
            DataTable table = dt1;
            int vn1 = table.Rows.Count;
                     
            this.txrBox4.Text = vn1.ToString();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
         Response.Redirect("/SystemAdmin/UserInfo.aspx");
        }
    }
}