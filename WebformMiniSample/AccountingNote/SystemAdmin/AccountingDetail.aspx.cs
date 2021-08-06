using AccountingNote.DBsource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class AccountingDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // check is logined
          if (this.Session["UserLoginInfo"] == null)
          {
                Response.Redirect("/login.aspx");
          }
            
           string account = this.Session["UserLoginInfo"] as string;

           var drUserInfo = DBsource.UserInfoManager.GetUserInfoListtest(account);

           if (drUserInfo == null)
           {
                Response.Redirect("/login.aspx");
                return;
           }


       if (this.IsPostBack != null)
        {
         
           //Check is create mode or edit mode
           if(this.Request.QueryString ["ID"] == null)
           {
                this.btnDelete.Visible = false;
           }
           else
           {
              this.btnDelete.Visible = true;

              string idText = this.Request.QueryString["ID"];
              int id;

              if(int.TryParse (idText , out id))
              {
                     // var drAccounting = AccountingManager.GetAccounting(id);
                 var drAccounting = AccountingManager.GetAccounting(id ,drUserInfo
                     ["ID"].ToString ()) ;
               
                        
                        
                  if (drAccounting == null)
                  {
                      this.ItMsage.Text = "Data does`t exist";
                      this.btnSave.Visible = false;
                      this.btnDelete.Visible = false;
                  }
                  else
                  {
                      this.ddIActType.SelectedValue = drAccounting["ActType"].ToString();
                      this.txtAmount.Text = drAccounting["Amount"].ToString();
                      this.txtCaption.Text = drAccounting["Caption"].ToString();
                      this.txtDesc.Text = drAccounting["Body"].ToString();
                  }
               }
               else
               {
                    this.ItMsage.Text = "ID is required .";
                    this.btnSave.Visible = false;
                    this.btnSave.Visible = false;
               }
                   
              }
            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<string> msglist = new List<string>();
            if(!this.CheckInput (out msglist))
            {
                this.ItMsage.Text = string.Join("<br/>", msglist);
                return;
            }

            string account = this.Session["UserLoginInfo"] as string;
            var dr1 = UserInfoManager.GetUserInfoListtest(account);

            if (dr1 == null)
            {
                Response.Redirect("/login.aspx");
                return;
            }

            string userID = dr1["ID"].ToString();////
            string actTypetext = this.ddIActType.SelectedValue;
            string amounttext = this.txtAmount.Text;
            string caption = this.txtCaption.Text;
            string body = this.txtDesc.Text;

            int amount = Convert.ToInt32(amounttext);
            int actType = Convert.ToInt32(actTypetext);
    //        AccountingManager.CreateAccounting(
      //          userID, caption, amount, actType, body);

            string idText = this.Request.QueryString["ID"];
            if(string .IsNullOrWhiteSpace(idText))
            {
                //Execut `Insert into db`
                AccountingManager.CreateAccounting (userID, caption,
            amount, actType, body);
            }
            else
            {
                int id;
                if(int.TryParse (idText, out id))
                {
                    // Execute `updata db`
                    AccountingManager.UpdateAccounting(id, userID, caption,
                     amount, actType, body);
                }
            }

            Response.Redirect("/SystemAdmin/AccountingList.aspx");
            
        }


        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msgList = new List<string>();

            if(this.ddIActType.SelectedValue  != "0" 
                && this.ddIActType .SelectedValue != "1")
            {
                msgList.Add("AType must be 0 or 1.");
            }

            if(string.IsNullOrWhiteSpace (this.txtAmount.Text))
            {
                msgList.Add("Amount is required");
            }
            else
            {
                int tempInt;
                if (!int.TryParse (this.txtAmount.Text, out tempInt))
                {
                    msgList.Add("Type must be a number");
                }
                if(tempInt <0 || tempInt >1000000)
                {
                    msgList.Add("Amount must between 0 and 1000000.");
                }
            }

            errorMsgList = msgList;
            if (msgList.Count == 0)
                return true;
            else
                return false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idText = this.Request.QueryString["ID"];

            if (string.IsNullOrWhiteSpace(idText))
                return;
            
            int id;
            if (int.TryParse(idText, out id))
            {
               //Execute `DELETE db`
               AccountingManager.DeleteAccounting(id);
            } 

            Response.Redirect("/SystemAdmin/AccountingList.aspx");

        }
    }
}