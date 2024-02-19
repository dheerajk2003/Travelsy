<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Project1.AdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="contact" class="contact">
        <div class="container mt-5">

            <div class="section-title">
                <h3>Sign <span>In</span></h3>
            </div>

            <div class="row w-full flex justify-content-center align-items-center">
                <div class="col-lg-8 mt-5 mt-lg-0 w-6/12">

                    <form id="formReg" runat="server">
                        <div class="row">
                            <div class=" form-group mt-3">
                                <asp:TextBox ID="txtname" runat="server" CssClass="form-control" placeholder="Your Name" required></asp:TextBox>
                            </div>
                            <div class="form-group mt-3">
                                <asp:TextBox TextMode="Password" ID="txtPass" runat="server" CssClass="form-control" placeholder="Password" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="my-3">
                            <div class="error-message">
                                <asp:Label ID="txtlbl" runat="server"></asp:Label></div>
                        </div>
                        <div class="text-center">
                            <asp:Button ID="btnsubmit" runat="server" CssClass="btnsubmit" OnClick="btnsubmit_Click" Style="background: #e43c5c; border: 0; padding: 10px 28px; color: #fff; transition: 0.4s; border-radius: 50px;" Text="Login" />

                        </div>

                    </form>
                </div>

            </div>

        </div>
    </section>
</asp:Content>
