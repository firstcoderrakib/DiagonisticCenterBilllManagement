﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteView.Master" AutoEventWireup="true" CodeBehind="TypeWiseReport.aspx.cs" Inherits="DiagonisticCenterBilllManagement.UI.TypeReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <div class="col-md-12">
            <div class="col-md-3"></div>
            <div class="h3 col-md-6">Type Wise Report</div>
            <div class="col-md-3"></div>
            <div class="col-md-12 row">
                <div class="form-group">
                    <asp:Label ID="lblFromDate" runat="server" Text="From Date"></asp:Label>
                    <asp:TextBox ID="txtFromDate" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFromDate" ErrorMessage="From date is required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

                </div>
                <div class="form-group">
                    <asp:Label ID="lblToDate" runat="server" Text="To Date"></asp:Label>
                    <asp:TextBox ID="txtToDate" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtToDate" ErrorMessage="To date is required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
                <asp:Button ID="btnShowType" CssClass="btn btn-primary pull-Left" runat="server" Text="Show" OnClick="btnShowType_Click" />
                <br />
                <br />
                <div>
                    <asp:Label ID="lblSaveMessage" runat="server" Text=""></asp:Label>
                </div>
                <asp:GridView ID="TypeReportGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                    <Columns>
                        <asp:TemplateField HeaderText="SL">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="typeName" HeaderText=" Type Name" />
                        <asp:BoundField DataField="TotalTest" HeaderText="Total no of test" />
                        <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" />
                    </Columns>
                </asp:GridView>

                <div class="form-group">
                    <span>Total</span>
                    <asp:TextBox ID="txtTypeTotal" CssClass="form-control" runat="server" Width="169px"></asp:TextBox><br />
                    <asp:Button ID="btnPDFShow" CssClass="btn btn-primary pull-Left" runat="server" Text="PDF" Width="67px" CausesValidation="False" OnClick="btnPDFShow_Click" />
                </div>
            </div>

        </div>
    </div>
</asp:Content>
