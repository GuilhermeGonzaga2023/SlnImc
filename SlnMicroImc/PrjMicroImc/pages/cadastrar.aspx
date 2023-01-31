<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastrar.aspx.cs" Inherits="PrjMicroImc.cadastrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../css/estilo.css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cadastro">
            <h2>Cadastro de Usuário</h2>

            <p>
                <asp:Label ID="Label1" runat="server" Text="nome: "></asp:Label>
                <asp:TextBox ID="txtNome" runat="server" placeholder="nome"></asp:TextBox>
            </p>
            <p> 
                <asp:Label ID="Label2" runat="server" Text="Login: "></asp:Label>
                <asp:TextBox ID="txtLogin" runat="server" placeholder="login"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label3" runat="server" Text="Senha: "></asp:Label>
                <asp:TextBox ID="txtSenha" runat="server" placeholder="senha" TextMode="Password"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label4" runat="server" Text="data de nascimento: "></asp:Label>
                <asp:TextBox ID="txtData" runat="server" placeholder="data de nascimento" TextMode="Datetime"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label5" runat="server" Text="telefone: "></asp:Label>
                <asp:TextBox ID="txtTelefone" runat="server" placeholder="telefone"></asp:TextBox>
            </p>

            <div class="btnCadastro">
                <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
            </div>
            <p>
                <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
            </p>
        </div>
    </form>
</body>
</html>
