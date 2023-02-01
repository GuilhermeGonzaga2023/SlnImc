<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="avaliacao.aspx.cs" Inherits="PrjMicroImc.imc" %>

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
        <div class="GRID">
            <div class="quadradoAva">
                <h2> Criar Avaliação</h2>

                <p>
                    <asp:Label ID="Label1" runat="server" Text="médico que está logado: " ></asp:Label>
                    <asp:Label ID="lblNome" runat="server" Text=""></asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="txtPesquisar" runat="server" placeholder="nome do paciente"></asp:TextBox>               
                    <asp:Button ID="btnListar" runat="server" Text="Listar pacientes" OnClick="btnListar_Click" />
                </p>
                <p>
                    <asp:Label ID="Label6" runat="server" Text="nome do paciente que foi selecionado: " ></asp:Label>
                    <asp:Label ID="lblNomePaciente" runat="server" Text=""></asp:Label>
                </p>
                <p>
                    <asp:Label ID="Label2" runat="server" Text="data da avaliação: "></asp:Label>
                    <asp:TextBox ID="txtDataAvaliacao" runat="server" placeholder="data" TextMode="Date"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label3" runat="server" Text="peso do paciente: "></asp:Label>
                    <asp:TextBox ID="txtPeso" runat="server" placeholder="Peso"></asp:TextBox>
                </p>
                <p>   
                    <asp:Label ID="Label4" runat="server" Text="altura do paciente: "></asp:Label>
                    <asp:TextBox ID="txtAltura" runat="server" placeholder="Altura"></asp:TextBox>
                </p>
                <p>
                    <asp:Button ID="btnCriarAva" runat="server" Text="Criar Avaliação" OnClick="btnCriarAva_Click" />
                </p>
                
                    <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
                    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />        
                                           
                <p>
                    <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
                </p>
            </div>
            <div class="quadrado2" style="overflow-y:auto">
               <h2>Selecione o usuário aqui: </h2>
                    <asp:GridView ID="GridUsuarios" runat="server" AutoGenerateSelectButton="true" OnSelectedIndexChanged="GridUsuarios_SelectedIndexChanged" BorderColor="#47793B" BorderStyle="Solid" BorderWidth="3px" CellPadding="5" CellSpacing="1" GridLines="None" EnableTheming="True">
                        <HeaderStyle BackColor="#47793B" />
                    </asp:GridView>                 
            </div>
        
         </div>
    </form>
</body>
</html>
