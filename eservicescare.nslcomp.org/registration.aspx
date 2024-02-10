<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="ftco-section contact-section">
      <div class="container">
        <div class="row block-9">
			<div class="col-md-4 contact-info ftco-animate bg-light p-4">
				<div class="row">
					<div class="col-md-12 mb-4">
	                    <h2 class="h4">Register</h2>
	                </div>
	                <div class="col-md-12 mb-3">
	                    <p>write something for registration</p>
	                </div>
				</div>
			</div>
			<div class="col-md-1"></div>
                <div class="col-md-6 ftco-animate">
                    <asp:Label ID="lblCaptchaMsg" runat="server" Text=""></asp:Label>
            	    <div class="row">
            		    <div class="col-md-6">
	                    <div class="form-group">
	                        <asp:TextBox ID="fname" runat="server" placeholder="Enter your first name" class="form-control"></asp:TextBox><br>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter your first name" ControlToValidate="fname" ForeColor="Red"></asp:RequiredFieldValidator>
	                    </div>
                    </div>
                    <div class="col-md-6">
	                    <div class="form-group">
	                        <asp:TextBox ID="lname" runat="server" placeholder="Enter your last name" class="form-control"></asp:TextBox><br>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter your first name" ControlToValidate="lname" ForeColor="Red"></asp:RequiredFieldValidator>
	                    </div>
	                    </div>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="mobile" runat="server" placeholder="enter your mobile number" onkeydown = "return (!((event.keyCode>=65 && event.keyCode <= 95) || event.keyCode >= 106) && event.keyCode!=32);" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter your first name" ControlToValidate="mobile" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="address" runat="server" placeholder="enter your address" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter your first name" ControlToValidate="address" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="email" runat="server" placeholder="enter your email" class="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="email" ErrorMessage="Invalid Email Format" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TextBox3" runat="server" placeholder="enter your password" TextMode="Password" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter your password" ControlToValidate="TextBox3" ForeColor="Red"></asp:RequiredFieldValidator><br />
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TextBox4" runat="server" placeholder="enter your conformpassword" TextMode="Password" class="form-control"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password and confirm password should be same." ControlToCompare="TextBox3" ControlToValidate="TextBox4" ForeColor="Red"></asp:CompareValidator>
                    </div>
                    <div class="form-group">
                        <asp:FileUpload ID="FileUpload1" runat="server"  class="form-control"/>
                    </div>
                    <div class="form-group">
                    <asp:button ID="button" runat="server" Text="submit" class="btn btn-primary py-3 px-5" OnClick="button_Click"></asp:button>
                    </div>
                </div>
            </div>
            </div>
        </section>
</asp:Content>

