<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="services.aspx.cs" Inherits="services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="admin/assetsadmin/css/bootstrap.min.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
    <link href="admin/assetsadmin/css/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="admin/assetsadmin/css/sb-admin-2.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
    <script language="Javascript">
        //$(function() {
        //    Morris.Donut({
        //        element: 'morris-donut-chart',
        //        data: [{
        //            label: "Student",
        //            value: 12
        //        }, {
        //            label: "Lectures",
        //            value: 30
        //        }],
        //        resize: true
        //    });
        //});
    </script>
    <div id="page-wrapper1">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Services</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-4 col-md-4">
                    <div class="panel panel-green">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-tasks fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <asp:Label ID="lblTotalLecCount" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div>Total Carpenters</div>
                                </div>
                            </div>
                        </div>
                        <a href="carpenters.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View List</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4">
                    <div class="panel panel-green">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-tasks fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <asp:Label ID="lbltotalplumbers" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div>Total Plumbers</div>
                                </div>
                            </div>
                        </div>
                        <a href="plumbers.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View List</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4">
                    <div class="panel panel-yellow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-tasks fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <asp:Label ID="lblTotaltotalelectrician" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div>Total Electrician</div>
                                </div>
                            </div>
                        </div>
                        <a href="electrician.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View List</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
               <%-- <div class="col-lg-3 col-md-6">
                    <div class="panel panel-yellow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-shopping-cart fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">124</div>
                                    <div>New Orders!</div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-red">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-support fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">13</div>
                                    <div>Support Tickets!</div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>--%>
            </div>
            
            <!-- /.row -->
        </div>
        <!-- /#page-wrapper -->
    </div>
</asp:Content>

