<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="Login.aspx.cs" Inherits="RTGS.Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>  
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <meta http-equiv="Cache-Control" content="no-store" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Style CSS -->
    <link href="Content/Site.css" rel="stylesheet" />
    <script type="text/javascript">
    </script>
</head>
<body style="background-image: url(Images/bg_2.png); background-color: rgba(255, 255, 255, 0);">
    <form  id="form1" method="post"  runat="server" defaultbutton="LoginBtn" defaultfocus="UserName">
        <div class="row">
            <div class="col-md-12">
            <div class="login">
                <div class="main-login col-md-5 col-md-offset-4">
                    <div class="loginback">
                        <!-- start: LOGIN BOX -->
                        <div id="Div1" class="box-login" runat="server">
                            <div style="text-align: center">
                                <div>
                                    <img alt="logo" src="images/logo.png " style="max-width:200px" />
                                </div>
                            </div>
                            <br />
                            <fieldset>
                            <div>
                                <div class="row">
                                    <div class="col-md-4" style="width:115px;">
                                        <label for="UserName" class="control-label">User Name:</label>
                                    </div> 
                                    <div class="col-md-4"  style="width:195px;">
                                        <asp:TextBox id="UserName"  placeholder="Login ID"  CssClass="form-control"  runat="server" />
                                    </div>
                                    <div class="col-md-1" style="width:12px;">
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" CssClass="NormalRed" ErrorMessage="*" Display="dynamic" />
                                    </div>
                                </div>
                                <div class="row" style="margin-top:10px;margin-bottom:10px">
                                    <div class="col-md-4" style="width:115px;">
                                        <label for="UserName" class="control-label"> Password :</label>
                                    </div> 
                                    <div class="col-md-4"  style="width:195px;">
                                        <asp:TextBox id="Pass"  CssClass="form-control"  autocomplete="off" placeholder="Password" TextMode="Password" runat="server" />                                
                                    </div>
                                    <div class="col-md-1" style="width:12px;">
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator2"  runat="server" ControlToValidate="Pass"  CssClass="NormalRed" ErrorMessage="*" Display="dynamic" />
                                    </div>
                                    <div class="col-md-3">
                                        <asp:LinkButton ID="LoginBtn" CssClass="btn btn-danger" Runat="server" Text="Sign In " OnClick="Login_Click" ></asp:LinkButton>
                                    </div>
                                </div>
                                <div class="row">
                                        <div class="col-md-4" style="width:115px;"></div>
                                        <div class="col-md-8">
                                            <asp:Label ID="MyMessage" Style="text-align:left" ForeColor="Red" CssClass ="NormalRed" runat="server"></asp:Label> 
                                            <asp:HiddenField ID="Tried" Value="" runat="server" />
                                        </div>
                                </div>
                            </div>
                            </fieldset>
                             </div>          
                    </div>
                        <!-- end: LOGIN BOX -->
                </div>
            </div>
            </div>
        </div>
    </form>
</body>
</html>
