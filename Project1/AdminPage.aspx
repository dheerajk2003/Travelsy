<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Project1.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta content="width=device-width, initial-scale=1.0" name="viewport">

    <title>Tempo Bootstrap Template - Index</title>
    <meta content="" name="description">
    <meta content="" name="keywords">

    <!-- Favicons -->
    <link href="assets/img/favicon.png" rel="icon">
    <link href="assets/img/apple-touch-icon.png" rel="apple-touch-icon">

    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Nunito:300,300i,400,400i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet">

    <!-- Vendor CSS Files -->
    <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href="assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet">
    <link href="assets/vendor/boxicons/css/boxicons.min.css" rel="stylesheet">
    <link href="assets/vendor/glightbox/css/glightbox.min.css" rel="stylesheet">
    <link href="assets/vendor/remixicon/remixicon.css" rel="stylesheet">
    <link href="assets/vendor/swiper/swiper-bundle.min.css" rel="stylesheet">

    <!-- Template Main CSS File -->
    <link href="assets/css/Search.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet">
</head>
<body>
    <form runat="server" class="pt-5">
        <div class="d-flex flex-row justify-content-between align-items-center">
            <h1>
                <asp:Label runat="server" ID="lblUser" Text="Label">Admin</asp:Label>
            </h1>
            <div class="">
                <asp:Button Style="background-color: #e43c5c" runat="server" ID="btnLogout" Text="Logout" class="h-75 text-white bx-border-radius redColor border-0 rounded-1" OnClick="btnLogout_Click" />
            </div>
        </div>
        <div class="w-100 mw-100 d-flex flex-column justify-content-center text-wrap">
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
                    <div class="w-25 d-flex flex-row justify-content-center align-items-center gap-2 border border-1 border-dark text-white">
                        <p class="w-25 redColor border-0 rounded-1 m-0">Delete</p>
                    </div>
                </div>
            </div>

            <asp:ScriptManager ID="scpt" runat="server"></asp:ScriptManager>
            <asp:Repeater ID="rptMyBlogs" runat="server">
                <ItemTemplate>
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
                                <p class="text-wrap text-truncate"><a href="<%# Eval("_mapsAddress") %>">Location</a></p>
                            </div>
                            <div class="w-25 d-flex flex-row justify-content-center align-items-center gap-3 border border-1 border-dark">
                                <asp:Button Style="background-color: #e43c5c" runat="server" ID="Button1" Text="Delete" class="w-25 text-white bx-border-radius redColor border-0 rounded-1 m-1" CommandArgument='<%#Eval("_bid")%>' CommandName="delBtnClick" OnClick="Button1_Click" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </form>
</body>
</html>
