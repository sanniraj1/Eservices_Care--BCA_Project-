<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="editProfile.aspx.cs" Inherits="editProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" style="padding-top:100px;min-height:750px;">
        <div class="row">
            <h3>Update Profile</h3>
            <br />
            <div class="col-md-4 col-md-offset-4">
                <div class="form-group">
                    <asp:Label ID="lblCaptchaMsg" runat="server" Text=""></asp:Label>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="first_name" runat="server" class="form-control" placeholder="enter your first name" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Your First Name" ControlToValidate="first_name"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="last_name" runat="server" class="form-control" placeholder="enter your last name"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="email" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="mobile" runat="server" class="form-control" placeholder="mobile" MaxLength="10"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Image ID="Image1" runat="server" Height="30px" Width="30px" /><asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
                <div class="form-group">
                    <asp:Button ID="UpdateProfile" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="UpdateProfile_Click" />
                </div>
             </div>
        </div>
    </div>
</asp:Content>

