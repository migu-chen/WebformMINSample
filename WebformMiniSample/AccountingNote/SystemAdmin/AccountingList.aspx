
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="AccountingNote.SystemAdmin.AccountingList1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
           <table > 
            <tr>
                <td colspam="2">
                    <h1>流水帳管理系統 - 後台</h1>
                </td>
             </tr>
               <td>
                  <a href ="UserInfo.aspx" >使用者資訊</a><br />
                  <a href ="AccountingList.aspx" >流水帳管理</a>
                </td>
           <td>
               <!--這裡放主要內容-->
           <asp:Button ID="btnCreate" runat="server" Text="Add Accounting" OnClick = "btnCreate_Click" />
           <asp:GridView ID="gvAccountList" runat="server" AutoGenerateColumns ="False" OnRowDataBound ="gvAccountingList_RowDataBound"  >
              
               <Columns >
                   <asp:BoundField  HeaderText = "標題" DataField ="Caption" />
                   <asp:BoundField  HeaderText = "金額" DataField ="Amount"/>  
                   <asp:TemplateField  HeaderText = "In/Out" > 
                       <ItemTemplate>
                         <%--  <%# ((int)Eval("actType") == 0) ? "支出":"收入" %>--%>
                           <asp:Literal ID="ItActType" runat="server"></asp:Literal>
                           <asp:Label ID="Ib4ActType" runat="server" ></asp:Label>
                       </ItemTemplate>
                    </asp:TemplateField>
                   <asp:BoundField HeaderText ="建立日期" DataField ="CreateDate" DataFormatString ="{0:yyyy-MM-dd}" /> 
                   
                    <asp:TemplateField HeaderText="Act">
                        <ItemTemplate>
                            <a href ="/SystemAdmin/AccountingDetail.aspx?ID=<%# Eval("ID") %>">Edit</a>
                          
                        </ItemTemplate>
                    </asp:TemplateField>     
               </Columns>
               <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
               <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
               <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
               <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
               <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
               <SortedAscendingCellStyle BackColor="#FDF5AC" />
               <SortedAscendingHeaderStyle BackColor="#4D0000" />
               <SortedDescendingCellStyle BackColor="#FCF6C0" />
               <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
               
           <asp:PlaceHolder ID="plcNodata" runat="server" Visible ="false" >
             <p>
                   No data in your Accounting Note. 
             </p>
           </asp:PlaceHolder>
          </td>
          
        </table>
    </form>
</body>
</html>
