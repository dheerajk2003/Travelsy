<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Project1.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/css/Search.css" rel="stylesheet" />
    <style>
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" class="pt-5">
        <div class="mt-5 d-flex flex-row justify-content-between align-items-center">
            <h2>
                <asp:Label runat="server" ID="lblUser" Text="Label">User</asp:Label>
            </h2>
            <div class="">
                <asp:Button Style="background-color: #e43c5c" runat="server" ID="btnLogout" Text="Logout" class="h-75 text-white bx-border-radius redColor border-0 rounded-1" OnClick="btnLogout_Click" />
            </div>
        </div>
        <div class="w-100 mw-100 d-flex flex-column justify-content-center text-wrap">
            <%--<div class="w-100 mw-100 d-flex flex-row justify-content-around">
                <div>
                    <p class="">Image</p>
                </div>
                <p>Name</p>
                <p>State</p>
                <p>City</p>
                <p>Likes</p>
                <p>Date</p>
                <p>Description</p>
                <p>Tips</p>
                <p>Maps</p>
            </div>--%>

            <div class=" h-25 d-flex flex-column border border-2 border-dark mb-4">
                <div class="d-flex flex-row justify-content-between w-100">
                    <div class="col-lg-2 col-md-4 col-sm-6 border border-1 border-dark">
                        <p class="text-wrap">Image</p>
                    </div>
                    <div class="col-lg-2 col-md-4 col-sm-6 border border-1 border-dark">
                        <p class="text-wrap">Name</p>
                    </div>
                    <div class="col-lg-2 col-md-4 col-sm-6 border border-1 border-dark">
                        <p class="text-wrap">State</p>
                    </div>
                    <div class="col-lg-2 col-md-4 col-sm-6 border border-1 border-dark">
                        <p class="text-wrap">City</p>
                    </div>
                    <div class="col-lg-2 col-md-4 col-sm-6 border border-1 border-dark">
                        <p class="text-wrap">Likes</p>
                    </div>
                    <div class="col-lg-2 col-md-4 col-sm-6 border border-1 border-dark">
                        <p class="text-wrap">Date</p>
                    </div>
                </div>
                <div class="d-flex flex-row justify-content-between w-100">
                    <div class="w-25 border border-1 border-dark">
                        <p class="text-wrap">Description</p>
                    </div>
                    <div class="w-25 border border-1 border-dark">
                        <p class="text-wrap">Tips</p>
                    </div>
                    <div class="w-25 border border-1 border-dark">
                        <p class="text-wrap text-truncate">Location</p>
                    </div>
                    <div class="w-25 d-flex flex-column justify-content-around align-items-center border border-1 border-dark">
                        <p class="w-25 bx-border-radius redColor border-0 rounded-1 m-0">Edit</p>
                        <p class="w-25 bx-border-radius redColor border-0 rounded-1 m-0">Delete</p>
                    </div>
                </div>
            </div>

            <asp:ScriptManager ID="scpt" runat="server"></asp:ScriptManager>
            <asp:Repeater ID="rptMyBlogs" runat="server">
                <ItemTemplate>
                    <%--<div class="w-100 mw-100 d-flex flex-row justify-content-around">
                            <div>
                                <img src='<%# "images/" + Eval("_img") %>' alt="not found" class="img-fluid" />
                            </div>
                            <p class="text-wrap"><%# Eval("_name") %></p>
                            <p class="text-wrap"><%# Eval("_state") %></p>
                            <p class="text-wrap"><%# Eval("_city") %></p>
                            <p class="text-wrap"><%# Eval("_likes") %></p>
                            <p class="text-wrap"><%# Eval("_datetime") %></p>
                            <p class="text-wrap"><%# Eval("_description") %></p>
                            <p class="text-wrap"><%# Eval("_tips") %></p>
                            <p class="text-wrap"><%# Eval("_mapsAddress") %></p>
                        </div>--%>
                    <div class="d-flex flex-column border border-1 border-dark mb-4" style="background-color: #fff5f5">
                        <div class="d-flex flex-row justify-content-between w-100">
                            <div class="col-lg-2 col-md-4 col-sm-6 border border-1 border-dark">
                                <img src='<%# "images/" + Eval("_img") %>' alt="not found" class="img-fluid" />
                            </div>
                            <div class="p-1 col-lg-2 col-md-4 col-sm-6 border border-1 border-dark">
                                <p class="text-wrap"><%# Eval("_name") %></p>
                            </div>
                            <div class="col-lg-2 col-md-4 col-sm-6 border border-1 border-dark">
                                <p class="text-wrap"><%# Eval("_state") %></p>
                            </div>
                            <div class="col-lg-2 col-md-4 col-sm-6 border border-1 border-dark">
                                <p class="text-wrap"><%# Eval("_city") %></p>
                            </div>
                            <div class="col-lg-2 col-md-4 col-sm-6 border border-1 border-dark">
                                <p class="text-wrap"><%# Eval("_likes") %></p>
                            </div>
                            <div class="col-lg-2 col-md-4 col-sm-6 border border-1 border-dark">
                                <p class="text-wrap"><%# Eval("_datetime") %></p>
                            </div>
                        </div>
                        <div class="d-flex flex-row justify-content-between w-100">
                            <div class="w-25 border border-1 border-dark">
                                <p class="text-wrap"><%# Eval("_description") %></p>
                            </div>
                            <div class="w-25 border border-1 border-dark">
                                <p class="text-wrap"><%# Eval("_tips") %></p>
                            </div>
                            <div class="w-25 border border-1 border-dark">
                                <p class="text-wrap text-truncate"><%# Eval("_mapsAddress") %></p>
                            </div>
                            <div class="w-25 d-flex flex-column justify-content-around align-items-center border border-1 border-dark">
                                <asp:Button Style="background-color: #e43c5c" runat="server" ID="btnEdit" Text="Edit" OnClick="btnEdit_Click" class="w-25 text-white bx-border-radius redColor border-0 rounded-1 m-1"  />
                                <asp:Button Style="background-color: #e43c5c" runat="server" ID="Button1" Text="Delete" class="w-25 text-white bx-border-radius redColor border-0 rounded-1 m-1" CommandArgument='<%#Eval("_bid")%>' CommandName="delBtnClick" OnClick="Button1_Click"/>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </form>

</asp:Content>

<%--<tbody>
    <!-- Displaying data in the table -->
    <tr>
        <td>
            <img src='<%# "images/" + Eval("_img") %>' alt="not found" class="img-fluid w-50"></td>
        <td><%# Eval("_name") %></td>
        <td><%# Eval("_state") %></td>
        <td><%# Eval("_city") %></td>
        <td><%# Eval("_likes") %></td>
        <td><%# Eval("_datetime") %></td>
        <td colspan="2" class="text-wrap"><%# Eval("_description") %></td>
        <td colspan="2" class="text-wrap"><%# Eval("_tips") %></td>
        <td colspan="2" class="text-wrap text-truncate"><%# Eval("_mapsAddress") %></td>
    </tr>
</tbody>--%>
