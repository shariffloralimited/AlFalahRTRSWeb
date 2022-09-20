<%@ Page Title="Add Message" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditMessage998.aspx.cs" Inherits="RTGS.EditMessage998" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
       <div class="row">
        <div class="col-md-12">
            <section class="panel">
                    <header class="panel-heading">
                       Send to 998 Message
                    </header>
                    <table>
                        <tr>
                            <td width="80"></td>
                            <td class="NormalBold">Message Text</td>
                            <td><asp:TextBox ID="MessageText" runat="server" TextMode="MultiLine" Width="800px" Height="150px" MaxLength="1000" CssClass="inputlt" /></td>
                            <td><asp:RequiredFieldValidator ID="ValidatorMessageText" ControlToValidate="MessageText"  runat="server" Display="Dynamic" ErrorMessage="**" CssClass="NormalRed"></asp:RequiredFieldValidator></td>
                       </tr>
                        <tr>
                            <td></td>
                            <td align="right"><asp:LinkButton ID="SaveBtn" Text="Save" runat="server" CssClass="CommandButton" OnClick="SaveBtn_Click"></asp:LinkButton></td>
                            <td align="Center"><asp:LinkButton ID="CancelBtn" Text="Cancel" runat="server" CssClass="CommandButton" CausesValidation="false" OnClick="CancelBtn_Click"></asp:LinkButton></td>
                        </tr>
                    </table>
            </section>
        </div>
        </div>
</asp:Content>