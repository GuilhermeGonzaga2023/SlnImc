<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="suaAvaliacao.aspx.cs" Inherits="PrjMicroImc.pagesUsuario.suaAvaliacao" %>

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
                <asp:LinkButton ID="lbkAvaliacaoUsu" runat="server" OnClick="lbkAvaliacaoUsu_Click">Ver Sua avaliação</asp:LinkButton>
                <asp:LinkButton ID="lbkSair" runat="server" OnClick="lbkSair_Click">Sair</asp:LinkButton>
            </nav>
        </header>

        <div class="GRID">

            <div class="AvaPaciente">
                <h2>Consulte sua avaliação: </h2>
                <p>
                    <asp:Label ID="Label8" runat="server" Text="Avaliação do dia:"></asp:Label>
                    <asp:Label ID="lblData" runat="server" Text=""></asp:Label>
                </p>
                <p>        
                    <asp:Label ID="Label1" runat="server" Text="Nome Do Paciente: "></asp:Label>
                    <asp:TextBox ID="txtNomeUsu" runat="server" ReadOnly="True" Visible="false"></asp:TextBox>
                </p>

                <p>
                    <asp:Label ID="Label2" runat="server" Text="Nome do Médico: "></asp:Label>
                    <asp:TextBox ID="txtNomeMedico" runat="server" ReadOnly="True" Visible="false"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label3" runat="server" Text="Peso do Paciente: "></asp:Label>
                    <asp:TextBox ID="txtPeso" runat="server" ReadOnly="True" Visible="false"></asp:TextBox>
                </p>

                <p>
                    <asp:Label ID="Label4" runat="server" Text="altura do Paciente: "></asp:Label>
                    <asp:TextBox ID="txtAltura" runat="server" ReadOnly="True" Visible="false"></asp:TextBox>
                </p>

                <p>
                    <asp:Label ID="Label5" runat="server" Text="dieta do paciente: "></asp:Label>
                    <asp:TextBox ID="txtDieta" runat="server" ReadOnly="True" Visible="false" TextMode="MultiLine" Rows="4" style="resize: none"></asp:TextBox>
                </p>

                <p>
                    <asp:Label ID="Label6" runat="server" Text="Restrições alimentares: "></asp:Label>
                    <asp:TextBox ID="txtRestricoesDieta" runat="server" ReadOnly="True" Visible="false" TextMode="MultiLine" Rows="4" style="resize: none"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label7" runat="server" Text="Data da avaliação: "></asp:Label>
                    <asp:TextBox ID="txtDataAva" runat="server" ReadOnly="true" Visible="false"></asp:TextBox>
                </p>
            
                    <asp:Button ID="btnCalcular" runat="server" Text="Calcular Imc" OnClick="btnCalcular_Click" />
                    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
            
                <p class="lblAva">
                    <asp:Label ID="lblIMC" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
                </p>            
                <asp:Label ID="msgErro" runat="server" Text=""></asp:Label>
            </div>
            <div class="quadrado2" style="overflow-y:auto; height:200px">
                <h2>Selecione sua avaliação aqui: </h2>
                <asp:GridView ID="GridAvaPac" runat="server" AutoGenerateSelectButton="true" BorderColor="#47793B" BorderStyle="Solid" BorderWidth="3px" CellPadding="5" CellSpacing="1" GridLines="None" EnableTheming="True" OnSelectedIndexChanged="GridAvaPac_SelectedIndexChanged">
                    <HeaderStyle BackColor="#47793B" />
                </asp:GridView>

            </div>
        </div>
    </form>
</body>
</html>
