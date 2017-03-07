<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteView.Master" AutoEventWireup="true" CodeBehind="TestTypes.aspx.cs" Inherits="DiagonisticCenterBilllManagement.UI.TestTypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div class="col-md-12">
        <div class="col-md-4"></div>
        <div class="h3 col-md-5" >Test Type Set</div>
        <div class="col-md-3"></div>

        <div class="col-md-12 row">
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Test Type Name"></asp:Label>
                <asp:TextBox ID="txtTypeName" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblMessage" runat="server" Visible="false" Text=""></asp:Label>
                <asp:Button ID="btnTypeSave" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnTypeSave_Click" />

            </div>
            <br />
            <br />
            <div>
                <asp:Label ID="lblSaveMessage" runat="server" Text=""></asp:Label>
            </div>
            <asp:GridView ID="testTypeGridView" runat="server" CssClass="table table-striped" Style="width: 100% " AutoGenerateColumns="False" Width="254px">
                <Columns>
                    <asp:TemplateField HeaderText="SL" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Left" Width="5%"></HeaderStyle>

                    </asp:TemplateField>

                    <asp:BoundField DataField="typeName" HeaderText="Type" />
                </Columns>
            </asp:GridView>
        </div>






    </div>
</asp:Content>
