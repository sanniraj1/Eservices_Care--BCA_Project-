<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="changePassword.aspx.cs" Inherits="changePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" style="padding-top:100px;min-height:750px;">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <h3>Change Password</h3>
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                <div class="form-group">
                    <asp:TextBox ID="oldpassword" runat="server" class="form-control" placeholder="Enter your Old Password" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="oldpassword" ErrorMessage="Enter your oldpassword" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="newpassword" runat="server" class="form-control" placeholder="Enter your newpassword" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Password" ControlToValidate="newpassword" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="cpassword" runat="server" class="form-control" placeholder="Enter your cpassword" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" ControlToCompare="newpassword" ControlToValidate="cpassword"></asp:CompareValidator>
                </div>
                <div class="form-group">
                    <asp:Button ID="submit" runat="server" class="btn btn-primary" Text="Submit" OnClick="submit_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

