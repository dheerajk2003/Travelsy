<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="Project1.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section id="contact" class="contact">
  <div class="container mt-5">

    <div class="section-title">
      <%--<h2>Registratin</h2>--%>
      <h3>Sign <span>Up</span></h3>
      <%--<p>Ut possimus qui ut temporibus culpa velit eveniet modi omnis est adipisci expedita at voluptas atque vitae autem.</p>--%>
    </div>

    <%--<div>
      <iframe style="border:0; width: 100%; height: 270px;" src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12097.433213460943!2d-74.0062269!3d40.7101282!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xb89d1fe6bc499443!2sDowntown+Conference+Center!5e0!3m2!1smk!2sbg!4v1539943755621" frameborder="0" allowfullscreen></iframe>
    </div>--%>

    <div class="row w-full flex justify-content-center align-items-center">

      <%--<div class="col-lg-4">
        <div class="info">
          <div class="address">
            <i class="bi bi-geo-alt"></i>
            <h4>Location:</h4>
            <p>A108 Adam Street, New York, NY 535022</p>
          </div>

          <div class="email">
            <i class="bi bi-envelope"></i>
            <h4>Email:</h4>
            <p>info@example.com</p>
          </div>

          <div class="phone">
            <i class="bi bi-phone"></i>
            <h4>Call:</h4>
            <p>+1 5589 55488 55s</p>
          </div>

        </div>

      </div>--%>

      <div class="col-lg-8 mt-5 mt-lg-0 w-6/12">

        <form id="formReg" runat="server">
          <div class="row">
            <div class=" form-group mt-3">
                <asp:TextBox ID="txtname" runat="server" CssClass="form-control" placeholder="Your Name" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvname" runat="server" ControlToValidate="txtname" ErrorMessage="*" ForeColor="Red" ValidationGroup="registration" ></asp:RequiredFieldValidator>
            </div>
            <div class=" form-group mt-3">
                <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" placeholder="Your Email" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtemail" ErrorMessage="*" ForeColor="Red" ValidationGroup="registration" ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revemail" runat="server" ControlToValidate="txtemail" ForeColor="Red" ValidationGroup="registration" ErrorMessage="Not an Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group mt-3">
                <asp:TextBox TextMode="Password" ID="txtPass" runat="server" CssClass="form-control" placeholder="Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass" ErrorMessage="*" ForeColor="Red" ValidationGroup="registration" ></asp:RequiredFieldValidator>
            </div>
            <div class="form-group mt-3">
                <asp:TextBox TextMode="Password" ID="txtCnfPass" runat="server" CssClass="form-control" placeholder="Confirm Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCnfPass" runat="server" ControlToValidate="txtPass" ErrorMessage="*" ForeColor="Red" ValidationGroup="registration" ></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvPass" runat="server" ControlToCompare="txtPass" ControlToValidate="txtCnfPass" ErrorMessage="Password must be same" ValidationGroup="registration" ForeColor="Red"></asp:CompareValidator>
            </div>
          </div>
          
          <%--<div class="form-group mt-3">
            <textarea class="form-control" name="message" rows="5" placeholder="Message" required></textarea>
          </div>--%>
          <div class="my-3">
            <%--<div class="loading">Loading</div>--%>
            <div class="error-message"></div>
            <%--<div class="sent-message">Your message has been sent. Thank you!</div>--%>
          </div>
            <div class="regloglink">
                <p>Already have an account? </p><a href="signin.aspx">login now</a>
            </div>
          <div class="text-center">
              <%--<button type="submit">Send Message</button>--%>
              <asp:Button ID="btnsubmit" runat="server" CssClass="btnsubmit" OnClick="btnsubmit_Click" style="background: #e43c5c;border: 0;padding: 10px 28px;color: #fff; transition: 0.4s;border-radius: 50px;" Text="Register" ValidationGroup="registration" />

          </div>
            
        </form>

      </div>

    </div>

  </div>
</section><!-- End Contact Section -->

</asp:Content>
