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
                                                <asp:DropDownList runat="server" ID="ddlCtgyPurpPrtry" DataTextField="TTCType"  AutoPostBack="true" DataValueField="TTCCode" CssClass="form-control" OnSelectedIndexChanged="ddlCtgyPurpPrtry_SelectedIndexChanged" >
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


                                        <div class="form-group" id="CheckSLNoSignatureDiv" runat="server" visible="false">
                                            <span class="col-sm-3 control-label">Check Serial Number</span>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtCheckSLNo" CssClass="form-control" MaxLength="34"  placeholder="Sender's Check SLNo" />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:Button Text="Get Signature" ID="btnSignature" CssClass="btn btn-danger" runat="server" CausesValidation="false" OnClick="btnGetSignature_Click" />
                                            </div>
                                            
                                        </div>

                                        <div class="form-group" id="ActNameDiv" runat="server" visible="true">
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
                                            <div class="col-md-6">
                                            <asp:Label ID="lblMsg" CssClass="normal-red" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4" id="CBSAccSigInfoDiv" runat="server" visible="false">
                                    
                                    <div>
                                        <table border="1"  style="color:gray">
                                            <tr>
                                                <td>Account No</td>
                                                <td>
                                                    <asp:Label ID="accountNoField" runat="server"></asp:Label>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Working Balance</td>
                                                <td>
                                                    <asp:Label ID="workingBalanceField" runat="server"></asp:Label>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Currency</td>
                                                <td>
                                                    <asp:Label ID="currencyField" runat="server"></asp:Label>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Branch Code</td>
                                                <td>
                                                    <asp:Label ID="branchCodeField" runat="server"></asp:Label>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Account Title</td>
                                                <td>
                                                    <asp:Label ID="accountTitleField" runat="server"></asp:Label>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Active InActive</td>
                                                <td>
                                                    <asp:Label ID="activeInactiveField" runat="server"></asp:Label>

                                                </td>
                                            </tr>                                         
                                            <tr>
                                                <td>Account Posting Restrict</td>
                                                <td>
                                                    <asp:Label ID="accountPostingRestrictField" runat="server"></asp:Label>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Customer Posting Restrict</td>
                                                <td>
                                                    <asp:Label ID="customerPostingRestrictField" runat="server"></asp:Label>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Error Message</td>
                                                <td>
                                                    <asp:Label ID="errorMsgField" runat="server"></asp:Label>

                                                </td>
                                            </tr>
                                            
                                        </table>
                                        <asp:Label runat="server" ID="lblCurrentBalance"   Visible="false"  />
                                        <asp:Label runat="server" ID="lblCCY"              Visible="false" />
                                    </div>
                                    
                                    <div>
                                       <%-- <asp:Image ID="Image1" runat="server" />--%>
                                         <img id="SignatureImage"  runat="server" style="width: 408px; height: 250px" />
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
                                                 <asp:TextBox ID="txtReceiverName" MaxLength="35" runat="server" placeholder="Receiver's Name"  CssClass="form-control" />
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
                                        <!--------------------------------------------------------------------------->
                                        <asp:Panel ID="CustomDutyPanel" runat="server">
                                        
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Custom Office Code</span>
                                             <div class="col-sm-7">
                                                 <asp:TextBox ID="txtCustomOfficeCD" MaxLength="3" runat="server" Width="300px" CssClass="form-control" placeholder ="3 Digit"/>
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtCustomOfficeCD" runat="server" ErrorMessage="Only Numbers allowed" ForeColor="Red"  ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                             </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="normal-red" runat="server" ControlToValidate="txtCustomOfficeCD" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Registration Year</span>
                                             <div class="col-sm-7">
                                                 <asp:TextBox ID="txtRegYr" MaxLength="4" runat="server"  Width="300px" CssClass="form-control" placeholder ="4 Digit"/>
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtRegYr" runat="server" ErrorMessage="Only Numbers allowed" ForeColor="Red"  ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                             </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="normal-red" runat="server" ControlToValidate="txtRegYr" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Registration Number</span>
                                             <div class="col-sm-7">
                                                 <asp:TextBox ID="txRegNumber" MaxLength="12" runat="server"  Width="300px" CssClass="form-control" />
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txRegNumber" runat="server" ErrorMessage="Only Numbers allowed" ForeColor="Red" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                             </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="normal-red" runat="server" ControlToValidate="txRegNumber" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Declarant Code</span>
                                             <div class="col-sm-7">
                                                 <asp:TextBox ID="txtDeclarantCD" MaxLength="18" runat="server" Width="300px" CssClass="form-control"/>
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtDeclarantCD" runat="server" ErrorMessage="Only Numbers allowed" ForeColor="Red"  ValidationExpression="\d+"></asp:RegularExpressionValidator>

                                             </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="normal-red" runat="server" ControlToValidate="txtDeclarantCD" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Customer Mobile Number</span>
                                             <div class="col-sm-7">
                                                 <asp:TextBox ID="txtCustomerMobile" MaxLength="11" runat="server"  Width="300px" CssClass="form-control" placeholder ="11 Digit" />
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtCustomerMobile" runat="server" ErrorMessage="Only Numbers allowed" ForeColor="Red"  ValidationExpression="\d+"></asp:RegularExpressionValidator>

                                             </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="normal-red" runat="server" ControlToValidate="txtCustomerMobile" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                      </asp:Panel>
                                        <!--------------------------------------------------------------------------->
                                         <div class="form-group" runat="server" id="UnstructDiv">
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
