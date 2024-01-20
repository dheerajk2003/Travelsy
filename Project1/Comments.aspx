<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="Project1.Comments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mt-5">
        <asp:Repeater ID="cmntRptr" runat="server">
            <ItemTemplate>
                <asp:Label ID="cmnt" runat="server"><%# Eval("_comment") %></asp:Label>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <form id="formReg" runat="server">
  <div class="row mt-5">
    <div class=" form-group mt-3">
        <asp:TextBox ID="txtComment" runat="server" CssClass="form-control" placeholder="enter comment" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvname" runat="server" ControlToValidate="txtComment" ErrorMessage="*" ForeColor="Red" ValidationGroup="comment" ></asp:RequiredFieldValidator>
    </div>
  <div class="text-center">
      <asp:Button ID="btnComment" runat="server" CssClass="btnsubmit" OnClick="btnComment_Click" style="background: #e43c5c;border: 0;padding: 10px 28px;color: #fff; transition: 0.4s;border-radius: 50px;" Text="Comment" ValidationGroup="comment" />

  </div>
    
</form>
</asp:Content>
