<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PrjMicroImc.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/estilo.css" />
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <div class="login">
        <h1>Sena<span class="backtxt">fit</span></h1>
            <asp:DropDownList ID="ddlPerfil" runat="server">
                <asp:ListItem>Perfil</asp:ListItem>
                <asp:ListItem Value="medico">médico</asp:ListItem>
                <asp:ListItem Value="paciente">paciente</asp:ListItem>
            </asp:DropDownList>
<%--            <div class="txts">--%>
                <asp:TextBox ID="txtLogin" runat="server" placeholder="login"></asp:TextBox>
                <asp:TextBox ID="txtSenha" runat="server" placeholder="senha" TextMode="Password"></asp:TextBox>
<%--            </div>--%>
            
            <div class="btns">
                <asp:Button ID="btnLogar" runat="server" Text="Logar" OnClick="btnLogar_Click" />
                <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
            </div>
            
            <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>

        </div>
    </form>
</body>
</html>
