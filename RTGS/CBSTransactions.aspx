<%@ Page Title="Inward Transactions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CBSTransactions.aspx.cs" Inherits="RTGS.CBSTransactions" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">            
   <div class="row">
        <div class="col-md-12">
            <section class="panel">
                    <header class="panel-heading">
                       Todays CBS Transactions
                    </header>
                    <div class="row">
                         <div class="col-md-3">
                              <div style="float:left; margin-left:20px">
                                  <asp:DropDownList ID="BranchList" runat="server"  CssClass="form-control" DataTextField="BranchName" DataValueField="RoutingNo" AutoPostBack="true"></asp:DropDownList>
                              </div>
                        </div>
                        <div class="col-md-2">
                              <div style="float:left; margin-left:3px">
                                <asp:DropDownList ID="ddlClearingType" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="1">Outward</asp:ListItem>
                                    <asp:ListItem Value="2">Inward</asp:ListItem>                                                    
                                </asp:DropDownList>
                              </div>
                        </div>   
                        <div class="col-md-2">
                              <div style="float:left; margin-left:3px">
                                  <asp:DropDownList ID="FormList" runat="server"  CssClass="form-control" AutoPostBack="true">
                                      <asp:ListItem Text="All"></asp:ListItem>
                                      <asp:ListItem Text="pacs.008"></asp:ListItem>
                                      <asp:ListItem Text="pacs.009"></asp:ListItem>
                                      <asp:ListItem Text="pacs.004"></asp:ListItem>
                                  </asp:DropDownList>
                              </div>
                         </div>                                                              
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div style="width:100%; overflow-x:auto">
                                <asp:GridView Id="MyDataGrid" DataKeyNames="TransID" CssClass="table  table-bordered table-striped table-hover" 
                                    runat="server" autogeneratecolumns="true" RowStyle-Wrap="false">
            	                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkActive" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
               	                </Columns>
    	                        </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Button ID="ReverseBtn" runat="server" CssClass="btn btn-success" Text="Reverse Selected" OnClick="ReverseBtn_Click"  />
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="Msg" runat="server" />
                        </div>
                    </div>
                </section>
            </div>
        </div>
</asp:Content>
