<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dieta.aspx.cs" Inherits="PrjMicroImc.pages.dieta" %>

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
            <div class="quadradoDieta">

                <h2>Dieta</h2>
                    <p>
                        <asp:Label ID="Label1" runat="server" Text="Dieta para o paciente:"></asp:Label>
                        <asp:Label ID="lblNome" runat="server" Text=""></asp:Label>
                    </p>
                     <p>
                        <asp:TextBox ID="txtPesquisar" runat="server" placeholder="nome do paciente"></asp:TextBox>
                        <asp:Button ID="btnListar" runat="server" Text="Listar" OnClick="btnListar_Click" />
                     </p>

                    <p>
                        <asp:Label ID="lblNomeDieta" runat="server" Text="dieta: "></asp:Label>
                        <asp:TextBox ID="txtNomeDieta" runat="server" placeholder="Dieta" TextMode="MultiLine" Rows="4" style="resize: none"></asp:TextBox>
<%--                        <textarea id="txtNomeDieta" name="txtNomeDieta" cols="20" rows="5"></textarea>--%>
                    </p>
                    <p>
                        <asp:Label ID="lblRestricoes" runat="server" Text="Restrições: "></asp:Label>
                        <asp:TextBox ID="txtRestricoes" runat="server" placeholder="restrições" TextMode="MultiLine" Rows="4" style="resize: none"></asp:TextBox>
<%--                        <textarea id="txtRestricoes" cols="20" rows="5"></textarea>--%>
                    </p>

                    <p>
                        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar dieta" OnClick="btnCadastrar_Click" />
                    </p>
                    <p>
                        <asp:Label ID="msgErro" runat="server" Text=""></asp:Label>
                    </p>
                        <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
                        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
            </div>
     
               <div class="quadrado2" style="overflow-y:auto">
                     <h2>Selecione a avaliação aqui: </h2>
                      <asp:GridView ID="GridAvaliacao" runat="server" AutoGenerateSelectButton="true" OnSelectedIndexChanged="GridAvaliacao_SelectedIndexChanged" BorderColor="#47793B" BorderStyle="Solid" BorderWidth="3px" CellPadding="5" CellSpacing="1" GridLines="None" EnableTheming="True">
                        <HeaderStyle BackColor="#47793B" />
                      </asp:GridView>                 
               </div>
        </div>
    </form>
</body>
</html>
