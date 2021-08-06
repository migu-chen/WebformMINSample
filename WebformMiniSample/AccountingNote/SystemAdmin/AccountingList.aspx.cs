using AccountingNote.DBsource;
using DBClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class AccountingList1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {  // check is logined
            if (this.Session["UserLoginInfo"] == null)
            {
                Response.Redirect("/login.aspx");
            }
            string account = this.Session["UserLoginInfo"] as string;
            var dr1 = DBsource.UserInfoManager.GetUserInfoListtest(account);

            if (dr1 == null)
            {
                Response.Redirect("/login.aspx");
                return;
            }

            var dt = AccountingManager.GetAccounttingList(dr1["ID"].ToString());

            if(dt.Rows .Count > 0)
            {
             this.gvAccountList.DataSource = dt;
             this.gvAccountList.DataBind();
            }
            else
            {
                this.gvAccountList.Visible = false;
                this.plcNodata.Visible = true;
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //處理'GridView' 的控制項 'GridView' 必須置於有 runat=server 的表單標記之中
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/AccountingDetail.aspx");
        }

        protected void gvAccountingList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;

            if(row.RowType == DataControlRowType.DataRow)
            {

            
              //e.Row.DataItem as DataControlRowState;
              // Literal lt4 = row.FindControl("ItActType") as Literal;
               Label lb4 = row.FindControl("Ib4ActType") as Label;
                var dr = row.DataItem as DataRowView;
               int actType = dr.Row.Field<int>("ActType");

               if (actType == 0)
                {
                    //lt4.Text = "支出" ;
                    lb4.Text = "支出";
                }
                else
                {
                     //lt4.Text = "收入";
                     lb4.Text = "收入";
                }
                
               if (dr.Row.Field <int>("Amount") > 1500)
                {
                    lb4.ForeColor = Color.Red;
                }
            }
        }
    }
}