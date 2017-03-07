<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteView.Master" AutoEventWireup="true" CodeBehind="PatientRequestEntry.aspx.cs" Inherits="DiagonisticCenterBilllManagement.UI.Patient" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div class="col-md-12">
        <div class="col-md-3"></div>
        <div class="h3 col-md-7">Patient Request Entry</div>
        <div class="col-md-2"></div>
        <div class="col-md-12 row">
            <div class="form-group">
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:Label ID="lblTxtName" runat="server" Text="Patient Name"></asp:Label>
                <asp:TextBox ID="txtPatientName" runat="server" placeholder="Enter patient name" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPatientName" Display="Dynamic" ErrorMessage="Please Enter Patient Name" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="lblTxtMobile" runat="server" Text="Mobile No"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtMobileNo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Please Enter Mobile Number" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Contact no must be number" ForeColor="Red" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtDateOfBirth" runat="server" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDateOfBirth" Display="Dynamic" ErrorMessage="Please Set Date of Birth" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="lblTestName" runat="server" Text="Select Test Name"></asp:Label>
                <asp:DropDownList CssClass="form-control" ID="ddlTestName" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlTestName_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlTestName" Display="Dynamic" ErrorMessage="Select a test name" ForeColor="Red" InitialValue="Select One" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="lblTestFee" runat="server" Text="Test Fee"></asp:Label>
                <asp:TextBox CssClass="form-control" ReadOnly="True" ID="txtFeeOfTest" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnTestAdd" runat="server" Text="Add" OnClick="btnTestAdd_Click" CssClass="btn btn-primary" />
            <div>
                <br />
                <asp:GridView ID="GridOfTestRequest" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="table table-striped" Style="width: 100% !important">
                    <Columns>
                        <asp:TemplateField HeaderText="SL">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="5%"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="tName" HeaderText="Test" />
                        <asp:BoundField DataField="testFee" HeaderText="Fee" />
                    </Columns>
                </asp:GridView>
                <span>Total</span>
                <asp:TextBox ID="txtTotalTestAmount" runat="server" CssClass="form-control pull-right"></asp:TextBox>
                <br />
                <br />
                <br />
                <asp:Button ID="btnTestRequst" runat="server" Text="Save" OnClick="btnTestRequst_Click" CssClass="btn btn-primary" />
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

