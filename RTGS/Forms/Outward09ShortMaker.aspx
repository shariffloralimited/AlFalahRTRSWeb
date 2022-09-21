<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="Outward09ShortMaker.aspx.cs" Inherits="RTGS.Forms.Outward09ShortMaker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">Financial Institution Credit Transfer</h3>
                </div>
                <div class="panel-body">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <h5 class="panel-title">Sender Information (Financial Institution Credit Transfer)</h5>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-8">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Currency</span>
                                            <div class="col-sm-7">
                                                <asp:DropDownList runat="server" ID="ddlCurrency" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCurrency_SelectedIndexChanged">
                                                    <asp:ListItem Text="BDT" Value="BDT" />
                                                    <asp:ListItem Text="USD" Value="USD" />
                                                    <asp:ListItem Text="CAD" Value="CAD" />
                                                    <asp:ListItem Text="EUR" Value="EUR" />
                                                    <asp:ListItem Text="GBP" Value="GBP" />
                                                    <asp:ListItem Text="JPY" Value="JPY" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Account Number</span>
                                            <div class="col-sm-7">
                                                <asp:TextBox runat="server" ID="txtAccountNo" Enabled="false" placeholder="13 digits" Width="300px" MaxLength="35" CssClass="form-control" />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAccountNo"
                                                    CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Sending Amount</span>
                                            <div class="col-sm-7">
                                                <asp:TextBox runat="server" ID="txtSettlmentAmount" AutoPostBack="true" OnTextChanged="txtSettlmentAmount_txtChanged" placeholder="Max 15 digits with 2 decimal" Width="300px" CssClass="form-control" />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSettlmentAmount"
                                                    CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeCheck1" runat="server" ControlToValidate="txtSettlmentAmount"
                                                    Type="Double" Minimum="100000.00" MaximumValue="10000000000.00" CssClass="normal-red"
                                                    ErrorMessage="Min: One Lac- Max: 1000 Cr" Display="Dynamic" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label"></span>
                                            <span class="col-sm-7 control-label" style="text-align: left">
                                                <asp:Label ID="lblAmount" runat="server" /></span>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-3"></div>
                                            <div class="col-sm-7">
                                                <asp:CheckBox ID="ChkNoCBS" runat="server" CssClass="form-control" Text=" No CBS" />
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h5 class="panel-title">Receiver Information (Financial Institution Credit Transfer)</h5>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-8">
                                <div class="form-horizontal" role="form">
                                    <div class="form-group">
                                        <span class="col-sm-3 control-label">Receiving Bank</span>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddListReceivingBank" CssClass="form-control" runat="server" AutoPostBack="true" DataTextField="BankName" DataValueField="BIC" OnSelectedIndexChanged="ddListReceivingBank_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <span class="col-sm-3 control-label">Receiving Branch</span>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddListBranch" runat="server" CssClass="form-control" DataTextField="BranchName" DataValueField="RoutingNo" AutoPostBack="true" OnSelectedIndexChanged="ddListBranch_SelectedIndexChanged" />
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:TextBox ID="txtRoutingNo" runat="server" MaxLength="9" Enabled="false" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRoutingNo" CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <span class="col-sm-3 control-label">Receiving Bank Account No</span>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtReceiverAccountNo" Enabled="false" MaxLength="34" runat="server" CssClass="form-control" />
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:RequiredFieldValidator ID="ReqTxtReceiverID" CssClass="normal-red" runat="server" ControlToValidate="txtReceiverAccountNo"
                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <span class="col-sm-3 control-label">Instruction Information</span>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtReasonForPayment" Enabled="True" MaxLength="34" runat="server" placeholder="Max 34 characters" CssClass="form-control" />
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:RequiredFieldValidator ID="ReqtxtReasonForPayment" runat="server" ControlToValidate="txtReasonForPayment"
                                                CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    

                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Bill Number(FCY)</span>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="txtInstrInfBillNumber" Enabled="True" MaxLength="35" runat="server" placeholder="Max 35 characters" CssClass="form-control" />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="ReqtxtForBillNumber" runat="server" ControlToValidate="txtInstrInfBillNumber"
                                                    CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">LC Number(FCY)</span>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="txtInstrInfLCNumber" Enabled="True" MaxLength="35" runat="server" placeholder="Max 35 characters" CssClass="form-control" />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="ReqtxtForLCNumber" runat="server" ControlToValidate="txtInstrInfLCNumber"
                                                    CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Party Name(FCY)</span>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="txtInstrInfPartyName" Enabled="True" MaxLength="35" runat="server" placeholder="Max 35 characters" CssClass="form-control" />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="ReqtxtForPartyName" runat="server" ControlToValidate="txtInstrInfPartyName"
                                                    CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Branch ID(FCY)</span>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="txtInstrInfBranchID" Enabled="True" MaxLength="35" runat="server" placeholder="Max 35 characters" CssClass="form-control" />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="ReqtxtForBranchID" runat="server" ControlToValidate="txtInstrInfBranchID"
                                                    CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Others Information(FCY)</span>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="txtInstrInfOthersInformation" Enabled="True" MaxLength="35" runat="server" placeholder="Max 35 characters" CssClass="form-control" />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="ReqtxtForOthersInformation" runat="server" ControlToValidate="txtInstrInfOthersInformation"
                                                    CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                    <div class="col-sm-2"></div>
                                    <div class="col-sm-10">
                                        <asp:Label ID="lblMsg" CssClass="bg-info" runat="server"></asp:Label>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-4">
                                            <div style="margin-left: 200px">
                                                <asp:Button ID="btnSend" Text="Save and Continue" runat="server" OnClick="btnSave_Click" CssClass="btn btn-success" />
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-4">
                                            <div style="margin-left: 10px">
                                                <asp:Button ID="btnCancelTrans" Text="Cancel Transaction" CausesValidation="false" runat="server" CssClass="btn btn-info" OnClick="btnCancelTrans_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
