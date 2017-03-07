<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteView.Master" AutoEventWireup="true" CodeBehind="TestSetup.aspx.cs" Inherits="DiagonisticCenterBilllManagement.UI.Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function Hide() {
            document.getElementById('<%= Label1.ClientID %>').style.display = 'none';

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div class="col-md-12">
        <div class="col-md-4"></div>
        <div class="h3 col-md-5">Test Set</div>
        <div class="col-md-3"></div>
        <div class="col-md-12 row">
            <div class="form-group">
                <asp:Label ID="lblTestName" runat="server" Text="Test Name"></asp:Label>
                <asp:TextBox ID="txtTestName" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Visible="false" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTestName" ErrorMessage="Please Enter Test Name." ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Fee"></asp:Label>
                <asp:TextBox ID="txtTestFee" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="lblNumberMsg" runat="server" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTestFee" ErrorMessage="Please Enter Test Fee." ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Select Type Name"></asp:Label>
                <asp:DropDownList ID="ddlTestType" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlTestType" Display="Dynamic" ErrorMessage="Select a type name" ForeColor="Red" InitialValue="Select One"></asp:RequiredFieldValidator>
            </div>
            <asp:Button ID="btnTestSave" OnClientClick="Hide()" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnTestSave_Click" />
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            <div>
            <br/>
            <asp:GridView ID="GridViewTest" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" Style="width: 100% ">
                <Columns>
                    <asp:TemplateField HeaderText="SL">
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Test" HeaderText="Name" />
                    <asp:BoundField DataField="Fee" HeaderText="Fee" />
                    <asp:BoundField DataField="Type" HeaderText="Type" />
                </Columns>
            </asp:GridView>
                </div>
        </div>

    </div>
</asp:Content>
