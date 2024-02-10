<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewCarpenter.aspx.cs" Inherits="viewCarpenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" style="padding-top:100px;min-height:750px;">
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12">
            <div class="well well-sm">
                <div class="row">
                    <div class="col-sm-6 col-md-6">
                        <asp:Image ID="Image1" runat="server" Width="300px" />
                        <h4><asp:Label ID="name" runat="server" Text=""></asp:Label> </h4>
                        <small><cite title=""><asp:Label ID="address" runat="server" Text=""></asp:Label></cite></small>
                        <p><i class="glyphicon glyphicon-envelope"></i><asp:Label ID="email" runat="server" Text=""></asp:Label></p>
                        <p>Mobile : <asp:Label ID="mobile" runat="server" Text=""></asp:Label></p>
                        <p>Per Hour Charge : <asp:Label ID="per_hour_charge" runat="server" Text=""></asp:Label></p>
                    </div>
                    <div class="col-sm-6 col-md-6">
                        <h3>Request Order for Carpenter</h3>
                        <asp:Label ID="lblMsgReg" runat="server" Text=""></asp:Label>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <asp:Label ID="first_name" runat="server" Text=""></asp:Label> <asp:Label ID="last_name" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">          
                                 <asp:Label ID="email_address" runat="server" Text=""></asp:Label>                               
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                            <asp:TextBox id="location_address" TextMode="multiline" name="form-location_address" PlaceHolder="Enter your address" Columns="30" Rows="5" runat="server" class="form-control" style=""/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="location_address" ErrorMessage="Enter location_address" class="text-danger"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                            <asp:TextBox id="details" TextMode="multiline" name="form-report" PlaceHolder="Enter Details" Columns="30" Rows="5" runat="server" class="form-control" style=""/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="details" ErrorMessage="Enter Details" class="text-danger"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">        
                            <div class="col-sm-offset-3 col-sm-9">
                            <asp:Button ID="addOrder" runat="server" Text="Add Order" CssClass="btn btn-primary" OnClick="addOrder_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>

