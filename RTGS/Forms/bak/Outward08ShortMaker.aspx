<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="Outward08ShortMaker.aspx.cs" Inherits="RTGS.Forms.Outward08ShortMaker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <section class="panel">
            <div class="panel panel-primary">
                <header class="panel-heading"><h3 class="panel-title"><b>FI To FI Customer Credit Transfer</b></h3></header>
                <div class="panel-body">
                    <div class="panel panel-info">
                        <div class="panel-heading"><h5 class="panel-title">Senders Information</h5></div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-8">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Transaction Type</span>
                                            <div class="col-sm-4">
                                                <asp:DropDownList runat="server" ID="ddlCtgyPurpPrtry" DataTextField="TTCType" DataValueField="TTCCode" CssClass="form-control" >
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Branch</span>
                                            <div class="col-sm-4">
                                                <asp:DropDownList runat="server" ID="ddlSendBranch" CssClass="form-control" DataTextField="BranchName" DataValueField="RoutingNo" ></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Account Number</span>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtAccountNo" CssClass="form-control" MaxLength="34"  placeholder="Sender's Account Number" />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ControlToValidate="txtAccountNo" 
                                                    CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="normal-red"  ErrorMessage="Invalid Characters found" Display="Dynamic" ControlToValidate="txtAccountNo" ValidationExpression="^[0-9a-zA-Z'.\s-]{1,40}$" />
                                                <asp:Button Text="Get A/C Info" ID="btnGetInfo" CssClass="btn btn-success" runat="server" CausesValidation="false" OnClick="btnGetInfo_Click" />
                                            </div>
                                        </div>
                                        <div class="form-group" id="ActNameDiv" runat="server" visible="false">
                                            <span class="col-sm-3 control-label">Account Name</span>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtAccountName" CssClass="form-control" MaxLength="35"  placeholder="Sender's Name" />
                                            </div>
                                            <div class="col-sm-2">
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAccountName" 
                                                 CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                             <asp:RegularExpressionValidator ID="RegExAccountName" runat="server" CssClass="normal-red"  ErrorMessage="Invalid Characters found" Display="Dynamic" ControlToValidate="txtAccountName" ValidationExpression="^[0-9a-zA-Z'.\s-]{1,40}$" />
                                           </div>
                                        </div>
                                        <div class="form-group">
                                        <span class="col-sm-3 control-label">Currency</span>
                                        <div class="col-sm-4">
                                            <asp:DropDownList runat="server" ID="ddlCurrency" CssClass="form-control">
                                                <asp:ListItem Text="BDT" Value="BDT" />
                                                <asp:ListItem Text="USD" Value="USD" />
                                                <asp:ListItem Text="CAD" Value="CAD" />
                                                <asp:ListItem Text="EUR" Value="EUR" />
                                                <asp:ListItem Text="GBP" Value="GBP" />
                                                <asp:ListItem Text="YEN" Value="YEN" />
                                            </asp:DropDownList>
                                        </div>
                                        </div>
                                        <div class="form-group">
                                        <span class="col-sm-3 control-label">Sending Amount</span>
                                        <div class="col-sm-4"><asp:TextBox runat="server" ID="txtSettlmentAmount" AutoPostBack="true" OnTextChanged="txtSettlmentAmount_txtChanged" placeholder="Min: 1 Lac Max:1000 Cr" CssClass="form-control"  Display="Dynamic" /></div>
                                        <div class="col-sm-2">
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSettlmentAmount" 
                                                 CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                             <asp:RangeValidator id="RangeCheck1" runat="server" ControlToValidate="txtSettlmentAmount"
                                                Type="Double" Minimum="100000.00" MaximumValue="10000000000.00" CssClass="normal-red" 
                                                 ErrorMessage="Min: One Lac- Max: 1000 Cr" Display="Dynamic" />
                                        </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-7 control-label" style="text-align:right">
                                            <asp:Label ID="lblAmount" runat="server" /></span>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-3"></div>
                                            <div class="col-sm-4">
                                                <asp:CheckBox ID="ChkChargeWaived" runat="server" CssClass="form-control" Text=" Charges Waived" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-3">
                                            </div>
                                            <div class="col-md-3">
                                            <asp:Label ID="lblMsg" CssClass="normal-red" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                     <div>
                                         <asp:DataGrid ID="AccountInfoGrid" runat="server" CssClass="table table-striped table-hover" BorderWidth="1" AutoGenerateColumns="false" ShowHeader="false" ShowFooter="false">
                                             <Columns>
                                                 <asp:BoundColumn DataField="Title" />
                                                 <asp:BoundColumn DataField="Value" />
                                             </Columns>
                                         </asp:DataGrid>
                                         
                                         <asp:Label runat="server" ID="lblAccountNo"        Visible="false"  />
                                         <asp:Label runat="server" ID="lblAccountName"      Visible="false"  />
                                         <asp:Label runat="server" ID="lblCurrentBalance"   Visible="false"  />
                                         <asp:Label runat="server" ID="lblCCY"              Visible="false" />
                                         <asp:Label runat="server" ID="lblSuccess"          Visible="false"  />
                                         <asp:Label runat="server" ID="lblBlocked"          Visible="false"  />
                                         <asp:Label runat="server" ID="lblDormant"          Visible="false"  />
                                         <asp:Label runat="server" ID="lblClosed"           Visible="false" />
                                         <asp:Label runat="server" ID="lblDeceased"         Visible="false" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-info">
                        <div class="panel-heading"><h5 class="panel-title">Receivers Information</h5></div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-10">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Receiving Bank</span>
                                             <div class="col-sm-4">
                                                 <asp:DropDownList ID="ddListReceivingBank" CssClass="form-control" runat="server" DataTextField="BankName" DataValueField="BIC" OnSelectedIndexChanged="ddListReceivingBank_SelectedIndexChanged" AutoPostBack="true" />
                                             </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Receiving Branch</span>
                                             <div class="col-sm-4">
                                                 <asp:DropDownList ID="ddListBranch" runat="server" CssClass="form-control"  DataTextField="BranchName" DataValueField="RoutingNo" AutoPostBack="true" OnSelectedIndexChanged="ddListBranch_SelectedIndexChanged" />
                                             </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="txtRoutingNo" runat="server" Enabled="false" Width="100px" MaxLength="9" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRoutingNo"  CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Receiver's Name</span>
                                             <div class="col-sm-4">
                                                 <asp:TextBox ID="txtReceiverName" MaxLength="35" runat="server" placeholder="Receiver's Name" CssClass="form-control" />
                                             </div>
                                            <div class="col-sm-3">
                                                <asp:RequiredFieldValidator ID="ReqtxtReceiverName" runat="server" ControlToValidate="txtReceiverName"  CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                             <asp:RegularExpressionValidator ID="RegExReceiverName" runat="server" CssClass="normal-red"  ErrorMessage="Invalid Characters found" Display="Dynamic" ControlToValidate="txtReceiverName" ValidationExpression="^[0-9a-zA-Z'.\s-]{1,40}$" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Receiver's Account No</span>
                                             <div class="col-sm-4">
                                                 <asp:TextBox ID="txtReceiverAccountNo" MaxLength="34" runat="server" placeholder="Receiver's Account No" CssClass="form-control" />
                                             </div>
                                            <div class="col-sm-3">
                                                <asp:RequiredFieldValidator ID="ReqTxtReceiverID" CssClass="normal-red" runat="server" ControlToValidate="txtReceiverAccountNo" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Unstructured Information</span>
                                            <div class="col-sm-4">
                                                 <asp:TextBox ID="txtReasonForPayment" MaxLength="140" runat="server" placeholder="Max 140 characters" CssClass="form-control"/>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:RequiredFieldValidator ID="ReqtxtReasonForPayment" runat="server" ControlToValidate="txtReasonForPayment"  CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                             </div>
                                        </div>
                                        <div class="form-group">
                                             <span class="col-sm-3 control-label">Charge Bearer</span>
                                             <div class="col-sm-4">
                                                 <asp:RadioButtonList runat="server" ID="radioChargeBearer1">
                                                    <asp:ListItem Text="Borne By Debtor [DEBT]" Value="DEBT" />
                                                    <asp:ListItem Text="Borne By Creditor [CRED]" Value="CRED" />
                                                    <asp:ListItem Text="Shared [SHAR]" Value="SHAR" Selected="True" />
                                                    
                                                </asp:RadioButtonList>
                                             </div>
                                        </div>

                                        <div class="form-group">
                                             <div class="col-sm-5">
                                                 <asp:Button ID="btnSend" Text="Save and Continue" runat="server" OnClick="btnSave_Click" CssClass="btn btn-success" />
                                             </div>
                                             <div class="col-sm-5">
                                                 <asp:Button ID="btnCancelTrans" Text="Cancel Transaction" runat="server" CssClass="btn btn-info" CausesValidation="false" OnClick="btnCancelTrans_Click" />
                                             </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
               </div>
            </section>
        </div>
    </div>
</asp:Content>
