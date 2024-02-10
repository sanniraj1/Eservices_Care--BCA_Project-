<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="ftco-section contact-section">
      <div class="container">
        <div class="row block-9">
			<div class="col-md-4 contact-info ftco-animate bg-light p-4">
				<div class="row">
					<div class="col-md-12 mb-4">
	                    <h2 class="h4">Login</h2>
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
                        <asp:TextBox ID="email" runat="server" placeholder="enter your email" class="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="email" ErrorMessage="Invalid Email Format" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="password" runat="server" placeholder="enter your password" TextMode="Password" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter your password" ControlToValidate="password" ForeColor="Red"></asp:RequiredFieldValidator><br />
                    </div>
                    <div class="form-group">
                        <asp:button ID="button1" runat="server" Text="submit" class="btn btn-primary py-3 px-5" OnClick="button_Click"></asp:button>
                    </div>
                    <div class="form-group">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/forgotPassword.aspx">Forgot password?</asp:HyperLink>
                    </div>
                </div>
            </div>
            </div>
        </section>
   
</asp:Content>

