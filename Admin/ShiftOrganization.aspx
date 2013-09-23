<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShiftOrganization.aspx.cs" Inherits="ShiftOrganization" %>

<form id="form1" runat="server">
组织名：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
用户名：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="查看组织状态" />
转移到：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
<asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="转移组织权限" />
<br />
<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</form>


