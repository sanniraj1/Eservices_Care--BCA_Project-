<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="contactus.aspx.cs" Inherits="admin_contactus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Contact Message List</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Contact Message
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="flot-chart">
                            <div class="flot-chart-content" id="flot-line-chart">

                                <asp:GridView ID="GridView1" CssClass="table table-hover" GridLines="None"  runat="server" AutoGenerateColumns="False" >
                                    <Columns>
                                        <asp:BoundField DataField="first_name" HeaderText="First Name" SortExpression="first_name" />
                                        <asp:BoundField DataField="last_name" HeaderText="Last Name" SortExpression="last_name" />
                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                        <asp:BoundField DataField="message" HeaderText="message" SortExpression="message" />
                                        <asp:BoundField DataField="mobile" HeaderText="Mobile" SortExpression="mobile" />
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
    <%--<script src="assetsadmin/js/jquery.min.js"></script>
    <script src="assetsadmin/js/bootstrap.min.js"></script>
    <script src="assetsadmin/js/jquery.dataTables.min.js"></script>--%>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $('#ContentPlaceHolder1_GridView1').DataTable({
                "paging": true,
                "ordering": false,
                "info": false
            });
        });
    </script>--%>
</asp:Content>

