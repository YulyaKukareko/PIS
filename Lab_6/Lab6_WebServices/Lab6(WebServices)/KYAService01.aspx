<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KYAService01.aspx.cs" Inherits="Lab6_WebServices_.KYAService01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    X : <asp:TextBox runat="server" ID="x"></asp:TextBox><br />        
    Y : <asp:TextBox runat="server" ID="y"></asp:TextBox><br /><br />

        <asp:Button runat="server" ID="but_sum" Text="+" OnClick="but_sum_Click"/>        
        <asp:Button runat="server" ID="but_sub" Text="-" OnClick="but_sub_Click"/>        
        <asp:Button runat="server" ID="but_mul" Text="*" OnClick="but_mul_Click"/>
        
        <br /><br />
    Result : <asp:Label runat="server" ID="result"></asp:Label>
        <br /><br />
    S : <asp:TextBox runat="server" ID="s"></asp:TextBox><br /><br />        
    <asp:Button runat="server" ID="Button2" Text="Add S" OnClick="Button2_Click"/> 
    <asp:Button runat="server" ID="Button1" Text="Get S" OnClick="Button1_Click"/> 
    Result : <asp:Label runat="server" ID="resultS"></asp:Label>
    </div>
    </form>
</body>
</html>
