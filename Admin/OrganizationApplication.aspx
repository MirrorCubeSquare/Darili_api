<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrganizationApplication.aspx.cs" Inherits="Admin_OrganizationApplication" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" 
            onitemcommand="Repeater1_ItemCommand">
            <HeaderTemplate>
            <table border="1" width="100%">
<tr>
<th>Id</th>
<th>NickName</th>
<th>OrgName</th>
<th>Type</th>
<th>Approved</th>
<th>Approve It!</th>
</tr>
            </HeaderTemplate>
            <ItemTemplate>
            <tr>
            <td><%# Eval("id").ToString()%></td>
            <td><%#Eval("NickName").ToString() %></td>
            <td><%#Eval("Org_Name").ToString() %></td>
            <td><%#Eval("Type").ToString() %></td>
            <td><%#Eval("IsProved").ToString() %></td>
            <td> <asp:Button ID="Button1" runat="server" CommandName="comButton1" CommandArgument='<%#Eval("id") %>' Text='Approve It!' /></td>
            </tr>
            </ItemTemplate>
        </asp:Repeater>
    
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:416ConnectionString %>" 
        
        
        SelectCommand="SELECT [id], [NickName], [Org_Name], [Type], [IsProved] FROM [Event_Org]" 
        onselecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
