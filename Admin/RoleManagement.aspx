<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleManagement.aspx.cs" Inherits="Admin_RoleManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table style="width: 100%;">
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="MemberDataSource">
           
                <HeaderTemplate><table border="1" width="100%">
<tr>
<th>User_Id</th>
<th>User_RealName</th>
<th>User_LastLoginTime</th>
<th>User_NickName</th>
</tr></HeaderTemplate>
<ItemTemplate>
<tr>
<td><%# DataBinder.Eval(Container.DataItem,"User_Id").ToString()%> </td>
<td><%#(string)DataBinder.Eval(Container.DataItem,"User_RealName").ToString()%> </td>
<td><%# (string)DataBinder.Eval(Container.DataItem,"User_LastLoginTime").ToString() %> </td>
<td><%# (string)DataBinder.Eval(Container.DataItem,"User_NickName").ToString() %> </td>
</tr>
</ItemTemplate>
            <FooterTemplate></table></FooterTemplate>
        </asp:Repeater>
          </table>
        <asp:SqlDataSource ID="MemberDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:416ConnectionString %>" 
            SelectCommand="SELECT [User_Id], [User_NickName], [User_Event_Like], [User_Event_Go], [User_CellPhone], [User_Realname], [User_LastLoginTime] FROM [Event_Users] ORDER BY [User_Id]">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
