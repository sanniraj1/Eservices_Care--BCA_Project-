<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="ftco-section contact-section">
      <div class="container">
        <div class="row block-9">
			<div class="col-md-4 contact-info ftco-animate bg-light p-4">
				<div class="row">
					<div class="col-md-12 mb-4">
	                    <h2 class="h4">Contact Us</h2>
	                </div>
	                <div class="col-md-12 mb-3">
	                    <p>Addresss: Ranchi</p>
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
                        <asp:TextBox ID="email" runat="server" placeholder="enter your email" class="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="email" ErrorMessage="Invalid Email Format" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <asp:TextBox id="message" TextMode="multiline" name="form-message" Columns="30" Rows="5" runat="server" class="form-control" placeHolder="Enter your message" style=""/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter your Subject" ControlToValidate="message" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                    <asp:button ID="button" runat="server" Text="submit" class="btn btn-primary py-3 px-5" OnClick="button_Click" ></asp:button>
                    </div>
                </div>
            </div>
            </div>
        </section>
</asp:Content>

