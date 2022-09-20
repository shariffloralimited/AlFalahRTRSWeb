<%--<%@ Page Title="Bank Settings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DailyOperations.aspx.cs" Inherits="RTGS.DailyOperations" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading"><h3 class="panel-title"><b>Daily BOD EOD ILF Operations</b></h3></div>
                <div class="panel-body">   
                    <!------------------>
                    <table class="table table-striped table-hover">
                        <tr>
                            <td class="form-control-small">Transaction Type</td>
                            <td>
                                <asp:DropDownList ID="ddlType" style="width:120px" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="BOD" Value="BOD" />
                                    <asp:ListItem Text="EOD" Value="EOD" />
                                    <asp:ListItem Text="ILF Injection"  Value="ILFINJ"/>
                                    <asp:ListItem Text="ILF Return"  Value="ILFRTN" />
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td class="form-control-small">Currency</td>
                            <td><asp:DropDownList ID="ddlCurrency" style="width:120px" runat="server" CssClass="form-control" DataTextField="CCY"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="form-control-small">Account No</td>
                            <td><asp:TextBox ID="txtAccountNo" MaxLength="34" CssClass="form-control"  Width="200px" runat="server" /></td>
                        </tr>
                         <tr>
                            <td class="form-control-small">Amount</td>
                            <td><asp:TextBox ID="txtAmount" MaxLength="20" CssClass="form-control"  Width="200px" runat="server" /></td>
                        </tr>
                          <tr>
                            <td class="form-control-small">Narration</td>
                            <td><asp:TextBox ID="txtEntryDesc" MaxLength="35" CssClass="form-control"  Width="200px" runat="server" /></td>
                        </tr>                         
                        <tr>
                            <td></td>
                            <td><asp:Button ID="BtnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="BtnSave_Click" /></td>
                        </tr>
                    </table>
                    <asp:Label ID="Msg" runat="server" CssClass="NormalRed"></asp:Label>
                    <!------------------>
                </div>
            </div>
        </div>

</asp:Content>--%>

<%@ Page Title="Bank Settings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DailyOperations.aspx.cs" Inherits="RTGS.DailyOperations" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading"><h3 class="panel-title"><b>Daily BOD EOD ILF Operations</b></h3></div>
                <div class="panel-body">   
                    <!------------------>
                    <table class="table table-striped table-hover">
                        <tr>
                            <td class="form-control-small">Transaction Type</td>
                            <td>
                                <asp:DropDownList ID="ddlType" style="width:120px" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="BOD" Value="BOD" />
                                    <asp:ListItem Text="EOD" Value="EOD" />
                                    <asp:ListItem Text="ILF Injection"  Value="ILFINJ"/>
                                    <asp:ListItem Text="ILF Return"  Value="ILFRTN" />
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td class="form-control-small">Currency</td>
                            <td><asp:DropDownList ID="ddlCurrency" style="width:120px" runat="server" CssClass="form-control" DataTextField="CCY"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="form-control-small">Account No</td>
                            <td><asp:TextBox ID="txtAccountNo" MaxLength="34" CssClass="form-control"  Width="200px" runat="server" /></td>
                        </tr>
                         <tr>
                            <td class="form-control-small">Amount</td>
                            <td><asp:TextBox ID="txtAmount" MaxLength="20" CssClass="form-control"  Width="200px" runat="server" /></td>
                        </tr>
                          <tr>
                            <td class="form-control-small">Narration</td>
                            <td><asp:TextBox ID="txtEntryDesc" MaxLength="35" CssClass="form-control"  Width="200px" runat="server" /></td>
                        </tr>                         
                        <tr>
                            <td></td>
                            <td><asp:Button ID="BtnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="BtnSave_Click" /></td>
                        </tr>
                    </table>
                    <asp:Label ID="Msg" runat="server" CssClass="NormalRed"></asp:Label>
                    <!------------------>
                </div>
            </div>
        </div>

</asp:Content>