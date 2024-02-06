<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="Project1.EditPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section id="contact" class="contact">
  <div class="container mt-5">

    <div class="section-title">
      <h3>Edit <span>Blog</span></h3>
    </div>

    <div class="row w-full flex justify-content-center align-items-center">

      <div class="col-lg-8 mt-5 mt-lg-0 w-6/12">

        <form ID="formReg" runat="server">
          <div class="row">
            <div class=" form-group mt-3">
                <asp:TextBox ID="txtname" runat="server" CssClass="form-control" placeholder="Place Name" required></asp:TextBox>
            </div>
            <div class=" form-group mt-3">
                <asp:TextBox ID="txtdesc" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="Description" required></asp:TextBox>
            </div>
            <div class="form-group mt-3">
                <asp:TextBox ID="txtState" runat="server" CssClass="form-control" placeholder="State" required></asp:TextBox>
            </div>
            <div class="form-group mt-3">
                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="City" required></asp:TextBox>
            </div>
            <div class="form-group mt-3">
                <asp:TextBox ID="txttips" runat="server" CssClass="form-control" placeholder="Some Tips"></asp:TextBox>
            </div>
            <div class="form-group mt-3">
                <asp:TextBox ID="txtMaps" runat="server" CssClass="form-control" placeholder="Maps link" required></asp:TextBox>
            </div>
            <div class="form-group mt-3">
                <asp:FileUpload ID="imgPlace" runat="server" CssClass="form-control" placeholder="Place Image" />
            </div>
          </div>
          
          <div class="text-center">
              <asp:Button ID="btnEditBlog" runat="server" CssClass="btnsubmit" style="background: #e43c5c;border: 0;padding: 10px 28px;color: #fff; transition: 0.4s;border-radius: 50px;" Text="Update" OnClick="btnEditBlog_Click" />

          </div>
            
        </form>

      </div>

    </div>

  </div>
</section>
<!-- End Contact Section -->
</asp:Content>
