<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="T24AccountInfo.aspx.cs" Inherits="RTGS.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <header class="panel-heading">
                    T24 Account Information
                </header>
                <div class="row">
                    <div class="col-md-7">

                        <div class="form-group">
                            <span class="col-sm-3 control-label">Account Number</span>
                            <div class="col-sm-4">
                                <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" />
                            </div>
                            <div class="col-sm-2">

                                <asp:Button Text="Get A/C Info" ID="btnGetInfo" CssClass="btn btn-success" runat="server" CausesValidation="false" OnClick="btnGetInfo_Click" />
                            </div>

                            <div class="col-sm-2">

                                <asp:Button Text="Get Signature" ID="btnSignature" CssClass="btn btn-danger" runat="server" CausesValidation="false" OnClick="btnGetSignature_Click" />
                            </div>

                        </div>       
                    </div>
                    <div class="col-md-5" runat="server">


                        <div>
                            <table border="1" style="color: gray">
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
                            <asp:Label runat="server" ID="lblCurrentBalance" Visible="false" />
                            <asp:Label runat="server" ID="lblCCY" Visible="false" />
                        </div>

                        <div>
                            <%-- <asp:Image ID="Image1" runat="server" />--%>
                            <img id="SignatureImage" runat="server" style="width: 408px; height: 250px" />
                        </div>
                    </div>
                </div>

            </section>
        </div>
    </div>
</asp:Content>

