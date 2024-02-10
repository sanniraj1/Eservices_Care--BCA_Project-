<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="resetPassword.aspx.cs" Inherits="resetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="ftco-section contact-section">
      <div class="container">
        <div class="row block-9">
			<div class="col-md-4 contact-info ftco-animate bg-light p-4">
				<div class="row">
					<div class="col-md-12 mb-4">
	                    <h2 class="h4">Reset Password</h2>
	                </div>
	                <div class="col-md-12 mb-3">
	                    <p>Please login with your valid credentials.</p>
	            
	                </div>
				</div>
			</div>
			<div class="col-md-1"></div>
                <div class="col-md-6 ftco-animate">
                    <asp:Label ID="lblMsgReg" runat="server" Text=""></asp:Label>
                    <div class="form-group">
                        <asp:TextBox ID="password" runat="server" TextMode="Password" PlaceHolder="Enter password" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="password" ErrorMessage="Password is required" CssClass="requiredField"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="confirm_password" runat="server" TextMode="Password" PlaceHolder="Enter Confirm Password"  class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="confirm_password" ErrorMessage="Confirm Password is required" CssClass="requiredField"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="password" ControlToValidate="confirm_password" ErrorMessage="Password and confirm password should be same." CssClass="requiredField"></asp:CompareValidator>
                    </div>
                    <div class="form-group">
                        <asp:button ID="button1" runat="server" Text="submit" class="btn btn-primary py-3 px-5" OnClick="MySubmit_Click"></asp:button>
                    </div>
                </div>
            </div>
            </div>
        </section>
    
</asp:Content>

