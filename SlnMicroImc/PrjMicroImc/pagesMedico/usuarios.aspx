<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="PrjMicroImc.pages.usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link rel="stylesheet" href="../css/estilo.css"/>
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
        <div class="GRID">
            <div class="quadrado1">

                <h2>Usuarios</h2>
                <asp:TextBox ID="txtPesquisarUsuario" runat="server" placeholder="nome do usuario"></asp:TextBox>
                <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" />
                <asp:Button ID="btnListar" runat="server" Text="listar" OnClick="btnListar_Click" />

                <p>
                    <asp:Label ID="Label6" runat="server" Text="nome do paciente que foi selecionado: " ></asp:Label>
                    <asp:Label ID="lblNome" runat="server" Text=""></asp:Label>
                </p>

                
                    <asp:TextBox ID="txtIdUsuario" runat="server" placeholder="id do usuario" Enabled="False" Visible="false"></asp:TextBox>
                <p>
                    <asp:Label ID="Label1" runat="server" Text="Nome: "></asp:Label>
                    <asp:TextBox ID="txtNomeUsu" runat="server" placeholder="nome do usuario"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label2" runat="server" Text="Login: "></asp:Label>
                    <asp:TextBox ID="txtLoginUsu" runat="server" placeholder="login"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label3" runat="server" Text="Senha: "></asp:Label>
                    <asp:TextBox ID="txtSenhaUsu" runat="server" placeholder="senha" Enabled="false"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label4" runat="server" Text="data de nascimento: "></asp:Label>
                    <asp:TextBox ID="txtDataNascimentoUsu" runat="server" placeholder="data de nascimento"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label5" runat="server" Text="telefone: "></asp:Label>
                    <asp:TextBox ID="txtTelefoneUsu" runat="server" placeholder="telefone"></asp:TextBox>
                </p>
                

                <p>
                    <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
                </p>
                <div class="btnUsuarios">
                    <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" OnClick="btnAtuaizar_Click" />
                    <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
                </div>
                <p>
                    <asp:Label ID="msgErro" runat="server" Text=""></asp:Label>
                </p>
            </div>
             <div class="quadrado2" style="overflow-y:auto">
                 <h2>Selecione o usuário aqui: </h2>
                <asp:GridView ID="GridUsuarios" runat="server" AutoGenerateSelectButton="true" OnSelectedIndexChanged="GridUsuarios_SelectedIndexChanged" BorderColor="#47793B" BorderStyle="Solid" BorderWidth="3px" CellPadding="5" CellSpacing="1" GridLines="None" EnableTheming="True" HorizontalAlign="Center" PagerStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center"></asp:GridView>
                  <HeaderStyle BackColor="#47793B" />

             </div>
        </div>
    </form>
</body>
</html>
