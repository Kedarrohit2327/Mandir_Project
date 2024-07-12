<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Jain_Mandir_Pro.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" crossorigin="anonymous">

    <link href="Content/LoginStyle.css" rel="stylesheet" />
    
</head>
<body>
    <div id="form1" runat="server">
        <div>

            
    <section class="">
        <div class="login-container">

            <div class="card">
                <div class="card-header" style="text-align: center; font-family: 'Calisto MT'; font-size: 30px;">
                    Login 
                </div>
                <div class="card-body">
                    <%--<img src="logo.png" alt="Logo" class="logo">--%>
                    <form id="loginForm" runat="server">
                        <div class="form-group">
                            <label class="txt-clr text-center"><b>Username</b></label>
                            <input type="text" class="form-control" id="username" name="username" placeholder="Username" />
                        </div>
                        <div class="form-group">
                            <label class="txt-clr text-center"><b>Password</b></label>
                            <input type="password" class="form-control" id="password" name="password" placeholder="Password" />
                        </div>
                        <asp:Label ID="error_msg" runat="server" Text="Label"></asp:Label><br />
                        <div class="txt-clear1">
                        <asp:Button ID="submit" runat="server" CssClass="btn btn-success" Text="Submit" OnClick="submit_Click" />
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </section>
        </div>
    </div>
</body>
</html>
