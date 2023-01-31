<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menuPaciente.aspx.cs" Inherits="PrjMicroImc.pages.menuCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../css/estilo.css"/>
    <title></title>
</head>
<body>
    <form id="menu" runat="server">
            <header class="cabecalho">
            <nav>
                <asp:LinkButton ID="lbkAvaliacaoUsu" runat="server" OnClick="lbkAvaliacaoUsu_Click">Ver Sua avaliação</asp:LinkButton>
                <asp:LinkButton ID="lbkSair" runat="server" OnClick="lbkSair_Click">Sair</asp:LinkButton>
            </nav>
    </header>
        <div class="menu">
            <nav>
            </nav>
<%--            <asp:Button ID="btnVoltar" runat="server" Text="voltar" OnClick="btnVoltar_Click" />--%>
        </div>
    </form>
</body>
</html>
