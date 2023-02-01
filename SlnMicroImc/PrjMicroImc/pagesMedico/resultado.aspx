<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resultado.aspx.cs" Inherits="PrjMicroImc.resultado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../css/estilo.css" />
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
    <header class="cabecalho">
            <nav>
                <asp:LinkButton ID="lbkIMC" runat="server" OnClick="lbkIMC_Click">Avaliação</asp:LinkButton>
                <asp:LinkButton ID="lbkDieta" runat="server" OnClick="lbkDieta_Click">Gerenciar Dietas</asp:LinkButton>
                <asp:LinkButton ID="lbkMedico" runat="server" OnClick="lbkMedico_Click">Medicos</asp:LinkButton>
                <asp:LinkButton ID="lbkUsuario" runat="server" OnClick="lbkUsuario_Click">Usuarios</asp:LinkButton>
                <asp:LinkButton ID="lbkSair" runat="server" OnClick="lbkSair_Click">Sair</asp:LinkButton>
            </nav>
    </header>
        <div class="quadradoResultado">
        <h2>Resultado IMC:</h2>

            <p>
                <asp:Label ID="lblNome" runat="server" Text=""></asp:Label>

            </p>
            <p>
                <asp:Label ID="lblPeso" runat="server" Text=""></asp:Label>

            </p>
            <p>
                <asp:Label ID="lblAltura" runat="server" Text=""></asp:Label>

            </p>
            <p>
                <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>

            </p>
            <p>
                <asp:Label ID="lblMsg" runat="server" Text="A Dieta precisa ser criada para concluir a avaliação"></asp:Label>
                <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>

            </p>
            <p>
                <asp:Button ID="btnCriarDieta" runat="server" Text="Criar Dieta" OnClick="btnCriarDieta_Click" />

            </p>
<%--            <p>
                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />

            </p>
--%>
        </div>
    </form>
</body>
</html>
