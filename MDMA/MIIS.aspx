<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MIIS.aspx.cs" Inherits="MDMA.MIIS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #CustDetail {
            height: 135px;
            width: 614px;
        }
        #VechileDetail {
            height: 137px;
            width: 607px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
         <asp:TextBox ID="txtRN" runat="server">йр82051311</asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Driver" /></div>
       <div>
           <textarea id="CustDetail" runat="server"></textarea>
       </div>
         <div>
         <asp:TextBox ID="txtVN" runat="server">0144УНБ</asp:TextBox>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Vechile" /></div>
       <div>
           <textarea id="VechileDetail" runat="server"></textarea>
       </div>
&nbsp;&nbsp;
    </form>
</body>
</html>
