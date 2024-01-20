<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homes.aspx.cs" Inherits="UpdatePnlDemo.homes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="updtPanel" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lbl" runat="server" Text="hello" ></asp:Label>
                    <asp:Button ID="btn" runat="server" Text="click" OnClick="btn_Click"  />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
