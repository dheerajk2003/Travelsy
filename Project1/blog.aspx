<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="blog.aspx.cs" Inherits="Project1.blog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta content="width=device-width, initial-scale=1.0" name="viewport">

    <title>Blog - Tempo Bootstrap Template</title>
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
    <link href="assets/css/style.css" rel="stylesheet">

    <!-- =======================================================
    * Template Name: Tempo
    * Updated: Sep 18 2023 with Bootstrap v5.3.2
    * Template URL: https://bootstrapmade.com/tempo-free-onepage-bootstrap-theme/
    * Author: BootstrapMade.com
    * License: https://bootstrapmade.com/license/
    ======================================================== -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <main id="main">

    <!-- ======= Breadcrumbs ======= -->
    <section id="breadcrumbs" class="breadcrumbs">
      <div class="container">

        <ol>
          <li><a href="index.aspx">Home</a></li>
          <li>Blog</li>
            <li><a href="CreateBlog.aspx">Create</a></li>
        </ol>
        <h2>Blog</h2>

      </div>
    </section><!-- End Breadcrumbs -->

    <!-- ======= Blog Section ======= -->
    <section id="blog" class="blog">
        <form runat="server">
      <div class="container" data-aos="fade-up">

        <div class="row">

          <div class="col-lg-8 entries">

              <%--<img src="assets/img/goingMerry.jpg" alt="no image" />--%>
               <%--<asp:ScriptManager ID="scptMngr" runat="server"></asp:ScriptManager>
            <div>
   
    <asp:UpdatePanel ID="UpdtMngr" runat="server">
        <ContentTemplate>
            <asp:Label ID="lbltext" runat="server" Text="hello"></asp:Label>
            <asp:Button ID="btnuts" runat="server" Text="click" OnClick="btnuts_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
</div>

              <div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lbltext_1" runat="server" Text="hello"></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="click" OnClick="btnuts_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
</div>

              <div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Label ID="lbltext_2" runat="server" Text="hello"></asp:Label>
            <asp:Button ID="Button2" runat="server" Text="click" OnClick="btnuts_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
</div>--%>
            <asp:ScriptManager ID="scpt" runat="server"></asp:ScriptManager>
            <asp:Repeater ID="rptBlogs" runat="server">
                <ItemTemplate>
                    <article class="entry">
                        
                        
                        <div class="entry-img">
                        <img src =' <%# "images/" + Eval("_img") %>' alt="not found" class="img-fluid">
                        </div>

                        <h2 class="entry-title">
                            <asp:Label ID="txtPlaceName" runat="server" Text='<%#Eval("_name") %>' ></asp:Label>
                        </h2>

                        <div class="entry-meta">
                        <ul>
                            <asp:UpdatePanel ID="updt" runat="server">
                            <ContentTemplate>
                            <li class="d-inline-flex align-items-center">
                                    <asp:HiddenField ID="idHidden" runat="server" ClientIDMode="Static" Value='<%# Eval("_bid") %>' />
                                    <%--onClientClick="return false"--%>
                                    <asp:Label ID="numLikes" runat="server" ClientIDMode="Static"><%# Eval("_likes") %></asp:Label>
                                    <span>Likes</span>
                            </li>
                            <li class="d-inline-flex align-items-center"><i class="bi bi-clock"></i> <a href="blog-single.html"><asp:Label ID="blogmTime" runat="server"><%# Eval("_dateTime") %></asp:Label></a></li>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </ul>
                        </div>

                        <div class="entry-content">
                        <asp:Label ID="txtPlaceDesc" runat="server" Text='<%#Eval("_description") %>' ></asp:Label>
                        <div class="read-more">
                            <a href="SingleBlog.aspx?idb=<%#Eval("_bid") %>">Read More</a>
                        </div>
                        </div>

                    </article><!-- End blog entry -->
                </ItemTemplate>
            </asp:Repeater>

            <%--<div class="blog-pagination">
              <ul class="justify-content-center">
                <li><a href="#">1</a></li>
                <li class="active"><a href="#">2</a></li>
                <li><a href="#">3</a></li>
              </ul>
            </div>--%>

          </div><!-- End blog entries list -->

          <div class="col-lg-4">

            <div class="sidebar">

              <h3 class="sidebar-title">Search</h3>
              <div class="sidebar-item search-form">
                <%--<form>--%>
                  <%--<input type="text">
                  <button type="submit"><i class="bi bi-search"></i></button>--%>
                  <asp:TextBox runat="server" ID="txtSearchBlog" placeholder="Search Place"></asp:TextBox>
                  <asp:Button runat="server" ID="btnSearchBlog" OnClick="btnSearchBlog_Click" Text="Srch" />
                <%--</form>--%>
                <%--<form runat="server" class="blogForm">--%>
                    <div class="searchDiv">
                        <asp:DropDownList ID="DdlStates" runat="server" OnSelectedIndexChanged="DdlStates_SelectedIndexChanged" AutoPostBack="true" placeholder="State">
                            
                        </asp:DropDownList>
                        <asp:DropDownList ID="DdlCities" runat="server" placeholder="City" OnSelectedIndexChanged="DdlCities_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem ID="Licity" runat="server" placeholder="None" />
                        </asp:DropDownList>
                    </div>
                <%--</form>--%>
              </div><!-- End sidebar search formn-->

              <%--<h3 class="sidebar-title">Categories</h3>
              <div class="sidebar-item categories">
                <ul>
                  <li><a href="#">General <span>(25)</span></a></li>
                  <li><a href="#">Lifestyle <span>(12)</span></a></li>
                  <li><a href="#">Travel <span>(5)</span></a></li>
                  <li><a href="#">Design <span>(22)</span></a></li>
                  <li><a href="#">Creative <span>(8)</span></a></li>
                  <li><a href="#">Educaion <span>(14)</span></a></li>
                </ul>
              </div>--%><!-- End sidebar categories-->

              <%--<h3 class="sidebar-title">Recent Posts</h3>
              <div class="sidebar-item recent-posts">
                <div class="post-item clearfix">
                  <img src="assets/img/blog/blog-recent-1.jpg" alt="">
                  <h4><a href="blog-single.html">Nihil blanditiis at in nihil autem</a></h4>
                  <time datetime="2020-01-01">Jan 1, 2020</time>
                </div>

                <div class="post-item clearfix">
                  <img src="assets/img/blog/blog-recent-2.jpg" alt="">
                  <h4><a href="blog-single.html">Quidem autem et impedit</a></h4>
                  <time datetime="2020-01-01">Jan 1, 2020</time>
                </div>

                <div class="post-item clearfix">
                  <img src="assets/img/blog/blog-recent-3.jpg" alt="">
                  <h4><a href="blog-single.html">Id quia et et ut maxime similique occaecati ut</a></h4>
                  <time datetime="2020-01-01">Jan 1, 2020</time>
                </div>

                <div class="post-item clearfix">
                  <img src="assets/img/blog/blog-recent-4.jpg" alt="">
                  <h4><a href="blog-single.html">Laborum corporis quo dara net para</a></h4>
                  <time datetime="2020-01-01">Jan 1, 2020</time>
                </div>

                <div class="post-item clearfix">
                  <img src="assets/img/blog/blog-recent-5.jpg" alt="">
                  <h4><a href="blog-single.html">Et dolores corrupti quae illo quod dolor</a></h4>
                  <time datetime="2020-01-01">Jan 1, 2020</time>
                </div>

              </div>--%><!-- End sidebar recent posts-->

              <%--<h3 class="sidebar-title">Tags</h3>
              <div class="sidebar-item tags">
                <ul>
                  <li><a href="#">App</a></li>
                  <li><a href="#">IT</a></li>
                  <li><a href="#">Business</a></li>
                  <li><a href="#">Mac</a></li>
                  <li><a href="#">Design</a></li>
                  <li><a href="#">Office</a></li>
                  <li><a href="#">Creative</a></li>
                  <li><a href="#">Studio</a></li>
                  <li><a href="#">Smart</a></li>
                  <li><a href="#">Tips</a></li>
                  <li><a href="#">Marketing</a></li>
                </ul>
              </div>--%><!-- End sidebar tags-->

            </div><!-- End sidebar -->

          </div><!-- End blog sidebar -->

        </div>

      </div>
        </form>
    </section><!-- End Blog Section -->

  </main><!-- End #main -->
</asp:Content>
