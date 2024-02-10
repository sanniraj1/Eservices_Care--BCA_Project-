<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="carpenters.aspx.cs" Inherits="carpenters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="admin/assetsadmin/css/bootstrap.min.css" rel="stylesheet"/>
    <!-- MetisMenu CSS -->
    <link href="admin/assetsadmin/css/metisMenu.min.css" rel="stylesheet"/>
    <!-- Custom CSS -->
    <link href="admin/assetsadmin/css/sb-admin-2.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div id="page-wrapper1">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Carpenters</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <asp:Label runat="server" id="lblEmp"></asp:Label>
            </div>
            <!-- /.row -->
        </div>
            <!-- /#page-wrapper -->
    </div>
</asp:Content>

