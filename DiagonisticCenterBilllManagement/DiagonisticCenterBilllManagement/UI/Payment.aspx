<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteView.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="DiagonisticCenterBilllManagement.UI.Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function Hide1() {
            document.getElementById('<%= Label1.ClientID %>').style.display = 'none';
        }
        function Hide2() {
            document.getElementById('<%= lblPaymentMsg.ClientID %>').style.display = 'none';

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div class="col-md-12">
        <div class="col-md-3"></div>
        <div class="h3 col-md-7">Patient Request Entry</div>
        <div class="col-md-2"></div>
        <div class="col-md-12 row">
            <div class="form-group">
                <asp:Label ID="lblBillNoSearch" runat="server" Text="Bill No"></asp:Label>
                <asp:TextBox ID="txtBillNoSearch" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBillNoSearch" ErrorMessage="Please Enter Bill Number" ForeColor="Red" ValidationGroup="BillNo"></asp:RequiredFieldValidator>
            </div>
            <asp:Button ID="btnSearch" OnClientClick="Hide1()" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnSearch_Click" ValidationGroup="BillNo" />
            <div>
                <br />
                <asp:GridView ID="PaymentGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                    <Columns>
                        <asp:TemplateField HeaderText="SL">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="tName" HeaderText="Test" />
                        <asp:BoundField DataField="testFee" HeaderText="Fee" />
                    </Columns>
                </asp:GridView>
            </div>
            <asp:HiddenField ID="HiddenFieldBillNo" runat="server" />
            <div>
                <table class="table">
                    <tr>
                        <th>
                            <asp:Label ID="lblBillDateMsg" runat="server" Text="Bill Date"></asp:Label></th>
                        <td>
                            <asp:Label ID="lblBillDate" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="lblTotalFeeMsg" runat="server" Text="Total Fee"></asp:Label></th>
                        <td>
                            <asp:Label ID="lblTotalFee" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="lblPaidMsg" runat="server" Text="Paid Amount"></asp:Label></th>
                        <td>
                            <asp:Label ID="lblPaid" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="lblDueMsg" runat="server" Text="Due Amount"></asp:Label></th>
                        <td>
                            <asp:Label ID="lblDue" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:Label ID="lblAmount" runat="server" Text="Amount"></asp:Label>
                <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="lblPaymentMsg" runat="server" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAmount" ErrorMessage="Please Enter Amount" ForeColor="Red" ValidationGroup="Amount"></asp:RequiredFieldValidator>
            </div>
            <asp:Button ID="paySave" runat="server" OnClientClick="Hide2()" Text="Pay" CssClass="btn btn-primary" OnClick="paySave_Click" Width="116px" ValidationGroup="Amount" />
        </div>
    </div>
</asp:Content>
