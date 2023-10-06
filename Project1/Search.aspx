<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Project1.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="searchDiv">
            <asp:DropDownList ID="DdlStates" runat="server" OnSelectedIndexChanged="DdlStates_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem ID="ListState1" runat="server" Text="" Value="1"></asp:ListItem>
                <asp:ListItem ID="ListState2" runat="server" Text="" Value="2"></asp:ListItem>
                <asp:ListItem ID="ListState3" runat="server" Text="" Value="3"></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DdlCities" runat="server">
                <asp:ListItem ID="ListItem1" runat="server" Text="" Value=""></asp:ListItem>
                <asp:ListItem ID="ListItem2" runat="server" Text="" Value=""></asp:ListItem>
                <asp:ListItem ID="ListItem3" runat="server" Text="" Value=""></asp:ListItem>
            </asp:DropDownList>
        </div>
    </form>
</asp:Content>
