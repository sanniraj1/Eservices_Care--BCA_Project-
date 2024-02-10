<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="addcarpenter.aspx.cs" Inherits="admin_addcarpenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Add Carpenter Profile</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-9 col-lg-offset-1">
                <div class="panel panel-default">
                    <div class="panel-heading">
                       Add Carpenter Details
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="flot-chart">
                            <asp:Label ID="lblMsgReg" runat="server" Text=""></asp:Label>
                            <div class="form-group">
                              <label class="control-label col-sm-3" for="name">Name :</label>
                              <div class="col-sm-9">
                                <asp:TextBox ID="name" runat="server" name="name" placeholder="Full Name" class="form-control"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="name" ErrorMessage="Enter your name" CssClass="text-danger"></asp:RequiredFieldValidator>
                              </div>
                            </div>
                            <div class="clearfix">&nbsp;</div>
                            <div class="form-group">
                              <label class="control-label col-sm-3" for="per_hour_charge">Per Hour Charge :</label>
                              <div class="col-sm-9">
                                <asp:TextBox ID="per_hour_charge" runat="server" name="per_hour_charge" placeholder="per_hour_charge" class="form-control"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="per_hour_charge" ErrorMessage="Enter per_hour_charge" CssClass="text-danger"></asp:RequiredFieldValidator>
                              </div>
                            </div>
                            <div class="clearfix">&nbsp;</div>
                            <div class="form-group">
                              <label class="control-label col-sm-3" for="email_address">Email Address :</label>
                              <div class="col-sm-9">          
                                <asp:TextBox ID="email_address" runat="server" name="email_address" placeholder="email_address" class="form-control"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter email address" ControlToValidate="email_address" CssClass="text-danger"></asp:RequiredFieldValidator>
                              </div>
                            </div>
                            <div class="clearfix">&nbsp;</div>
                            <div class="form-group">
                              <label class="control-label col-sm-3" for="password">Password :</label>
                              <div class="col-sm-9">          
                                <asp:TextBox ID="password" runat="server" name="password" placeholder="password" class="form-control"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Password" ControlToValidate="password" CssClass="text-danger"></asp:RequiredFieldValidator>
                              </div>
                            </div>
                            <div class="clearfix">&nbsp;</div>
                            <div class="form-group">
                              <label class="control-label col-sm-3" for="mobile">Mobile :</label>
                              <div class="col-sm-9">          
                                <asp:TextBox ID="mobile" runat="server" name="mobile" MaxLength="10" placeholder="Mobile" class="form-control"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter mobile number" ControlToValidate="mobile" CssClass="text-danger"></asp:RequiredFieldValidator>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="mobile" ErrorMessage="Number only" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                              </div>
                            </div>
                            <div class="clearfix">&nbsp;</div>
                            <div class="form-group">
                              <label class="control-label col-sm-3" for="photo">Photo :<asp:Label ID="lblfarImg" runat="server" Text=""></asp:Label></label>
                              <div class="col-sm-9">          
                                  <asp:FileUpload ID="FileUpload1" runat="server" />
                              </div>
                            </div>
                            <div class="clearfix">&nbsp;</div>
                            <div class="form-group">
                              <label class="control-label col-sm-3" for="address">Address :</label>
                              <div class="col-sm-9">          
                                <asp:TextBox id="address" TextMode="multiline" name="form-address" Columns="30" Rows="5" runat="server" class="form-control" style=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="address" ErrorMessage="Enter address" class="text-danger"></asp:RequiredFieldValidator>
                              </div>
                            </div>
                            <div class="clearfix">&nbsp;</div>
                            <div class="form-group">        
                              <div class="col-sm-offset-3 col-sm-9">
                                <asp:Button ID="addCarpenter" runat="server" Text="Add addCarpenter" CssClass="btn btn-primary" OnClick="addCarpenter_Click" />
                              </div>
                            </div>

                        </div>
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
        </div>
            <!-- /.row -->
    </div>
    <!-- /#page-wrapper -->
</asp:Content>

