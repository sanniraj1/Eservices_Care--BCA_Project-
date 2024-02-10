<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="carpenters.aspx.cs" Inherits="admin_carpenters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Carpenters List</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Users
                        <asp:HyperLink ID="addfarmer" runat="server" style="float:right;" NavigateUrl="~/admin/addCarpenter.aspx" CssClass="btn" >Add Carpenter</asp:HyperLink>
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="flot-chart">
                            <div class="flot-chart-content" id="flot-line-chart">

                                <asp:GridView ID="GridView1" CssClass="table table-hover" GridLines="None"  runat="server" AutoGenerateColumns="False"  OnRowDataBound = "OnRowDataBound" >
                                    <Columns>
                                        <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                                        <asp:BoundField DataField="per_hour_charge" HeaderText="per_hour_charge" SortExpression="per_hour_charge" />
                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                        <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address" />
                                        <asp:BoundField DataField="mobile" HeaderText="Mobile" SortExpression="mobile" />
                                        <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                                        <asp:TemplateField HeaderText="Photo">
                                            <ItemTemplate>
                                                <asp:Image Width="50px" ID="Image1" ImageUrl='<%# String.Format("~/Admin/carpenterHandler.ashx?carpenter_id={0}",Eval("carpenter_id")) %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# String.Format("~/admin/editCarpenter.aspx?carpenter_id={0}",Eval("carpenter_id")) %>'>Edit</asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
</asp:Content>

