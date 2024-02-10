<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="myOrders.aspx.cs" Inherits="myOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container"  style="padding-top:100px;min-height:750px;">
        <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">My Orders List</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            My Orders
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="flot-chart">
                                <div class="flot-chart-content" id="flot-line-chart">

                                    <asp:GridView ID="GridView1" CssClass="table table-hover" GridLines="None"  runat="server" AutoGenerateColumns="False" >
                                        <Columns>
                                            <asp:BoundField DataField="order_for" HeaderText="order_for" SortExpression="order_for" />
                                            <asp:BoundField DataField="order_by_email" HeaderText="order_by_email" SortExpression="order_by_email" />
                                            <asp:BoundField DataField="worker_name" HeaderText="worker_name" SortExpression="worker_name" />
                                            <asp:BoundField DataField="worker_email" HeaderText="worker_email" SortExpression="worker_email" />
                                            <asp:BoundField DataField="location_address" HeaderText="location_address" SortExpression="location_address" />
                                            <asp:BoundField DataField="per_hour_charge" HeaderText="per_hour_charge" SortExpression="per_hour_charge" />
                                            <asp:BoundField DataField="details" HeaderText="details" SortExpression="details" />
                                            <asp:BoundField DataField="order_on" HeaderText="order_on" SortExpression="order_on" />
                                        </Columns>
                                    </asp:GridView>
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
    </div>
</asp:Content>

