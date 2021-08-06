<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AccountingNote.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
        <div><h1>流水帳系統</h1>
        </div>
        <asp:Label ID="Label1" runat="server" Text="何時有第一筆記錄"></asp:Label>
        <asp:TextBox ID="txrBox1" runat="server" Width="56px"></asp:TextBox>


       <br />
        <asp:Label ID="Label2" runat="server" Text="最新一筆為何時"> </asp:Label>
        <asp:TextBox ID="txrBox2" runat="server" Width="56px"></asp:TextBox>


          <br />
        <asp:Label ID="Label3" runat="server" Text="系統共紀錄了 n 筆流水帳"> </asp:Label>
        <asp:TextBox ID="txrBox3" runat="server" Width="56px"></asp:TextBox>


        <br />
        <asp:TextBox ID="txrBox4" runat="server" Width="124px" Height="16px"></asp:TextBox>


        <br />
       <asp:Label ID="Label4" runat="server" Text="系統共有幾位使用者"></asp:Label>


        <asp:GridView ID="gvAccountList" runat="server" AutoGenerateColumns ="false" >
               <Columns >
                   <asp:BoundField  HeaderText = "標題" DataField ="Caption" />
                   <asp:BoundField  HeaderText = "金額" DataField ="Amount"/>  
                   <asp:TemplateField  HeaderText = "In/Out" > 
                       <ItemTemplate>
                            <%# ((int)Eval("actType") == 0) ? "支出":"收入" %>
                       </ItemTemplate>
                    </asp:TemplateField>
                   <asp:BoundField HeaderText ="建立日期" DataField ="CreateDate" DataFormatString ="{0:yyyy-MM-dd}" /> 
                   
                    <asp:TemplateField HeaderText="Act">
                        <ItemTemplate>
                            <a href ="/SystemAdmin/AccountingDetail.aspx?ID=<%# Eval("ID") %>">Edit</a>
                          
                        </ItemTemplate>
                    </asp:TemplateField>     
               </Columns>
            </asp:GridView>

        <asp:Button ID="Button1" runat="server" Text="登入" OnClick="Button1_Click" />
    </form>
</body>
</html>
