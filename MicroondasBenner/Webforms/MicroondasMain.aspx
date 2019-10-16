<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MicroondasMain.aspx.cs" Inherits="MicroondasBenner.Webforms.MicroondasMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 1174px">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div style="display: inline-block; height: 81px; margin-top: 0px;">
                Informe o alimento<br />
                <asp:TextBox ID="TextBox1" runat="server" Width="790px" Height="44px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox>
            </div>
            

            <div style="display: inline-block; width: 122px;">
                &nbsp;&nbsp;&nbsp;
                Tempo:<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ViewStateMode="Enabled">
                    <ContentTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Height="25px" MaxLength="4" ReadOnly="True" Style="margin-left: 24px" Width="90px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
            </div>
            <div style="display:inline-block"> 
                <asp:Button ID="ButtonLimparCancelar" runat="server" Height="31px" OnClick="LimparCancelar_Click" Text="Limpar/Cancelar" Width="180px" /><br />
                <asp:Button ID="ButtonPausarRetomar" runat="server" Height="31px" Width="180px" OnClick="ButtonPausarRetomar_Click" Text="Pausar/Retomar" style="margin-top:10px" />
            </div>
                        
            <div style="float: right; width: 353px; margin-top: 10px; height: 255px;">
                <asp:Button ID="Button1" runat="server" Text="1" Height="44px" OnClick="Button1_Click" Width="90" UseSubmitBehavior="False" />
                <asp:Button ID="Button2" runat="server" Text="2" Height="44px" OnClick="Button2_Click" Width="90" />
                <asp:Button ID="Button3" runat="server" Text="3" Height="44px" OnClick="Button3_Click" Width="90" />
                <br />
                <asp:Button ID="Button4" runat="server" Text="4" Height="44px" Style="margin-top: 10px;" OnClick="Button4_Click" Width="90" />
                <asp:Button ID="Button5" runat="server" Text="5" Height="44px" OnClick="Button5_Click" Width="90" />
                <asp:Button ID="Button6" runat="server" Text="6" Height="44px" OnClick="Button6_Click" Width="90" />
                <br />
                <asp:Button ID="Button7" runat="server" Text="7" Height="44px" Style="margin-top: 10px;" OnClick="Button7_Click" Width="90" />
                <asp:Button ID="Button8" runat="server" Text="8" Height="44px" OnClick="Button8_Click" Width="90" />
                <asp:Button ID="Button9" runat="server" Text="9" Height="44px" OnClick="Button9_Click" Width="90" />
                <br />
                <asp:Button ID="ButtonAquecerRapido" runat="server" Text="Início Rápido" Style="margin-top: 10px;" Height="44px" OnClick="ButtonAquecerRapido_Click" Width="90" />
                <asp:Button ID="Button0" runat="server" Text="0" Height="44px" OnClick="Button0_Click" Width="90" />
                <asp:Button ID="ButtonAquecer" runat="server" Text="Iniciar" Height="44px" OnClick="ButtonAquecer_Click" Width="90" />

            </div>

            <br />
            <br />
            Saída<br />
            <asp:TextBox ID="TextBox3" runat="server" Width="790px" Height="60px" ReadOnly="True" TextMode="MultiLine" Style="resize: none;"></asp:TextBox>

            <br />
            <br />
            Potência:<br />
            <asp:DropDownList ID="DropDownList2" runat="server" Height="25px" Width="233px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem Selected="True">10</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Programas:<br />
            <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="233px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Table ID="Table1" runat="server"
                CellPadding="10"
                GridLines="Both" Style="margin-left: 0px; display: inline-block" Width="797px" Font-Bold="True" Font-Italic="False">
                <asp:TableHeaderRow ID="Table1HeaderRow"
                    BackColor="LightBlue"
                    runat="server"
                    Width="100%">
                    <asp:TableHeaderCell
                        Scope="Column"
                        Text="Nome"
                        Width="20%" />
                    <asp:TableHeaderCell
                        Scope="Column"
                        Text="Instruções"
                        Width="50%" />
                    <asp:TableHeaderCell
                        Scope="Column"
                        Text="Tempo"
                        Width="10%" />
                    <asp:TableHeaderCell
                        Scope="Column"
                        Text="Potencia"
                        Width="10%" />
                    <asp:TableHeaderCell
                        Scope="Column"
                        Text="Caractere"
                        Width="10%" />
                </asp:TableHeaderRow>
            </asp:Table>
            <br />
            <br />
            <asp:Button ID="ButtonNovoPrograma" runat="server" Text="Novo Programa" Height="44" OnClick="ButtonNovoPrograma_Click" Width="120" />
            <asp:Button ID="ButtonBuscarPrograma" runat="server" Text="Buscar Programa" Height="44" OnClick="ButtonBuscarPrograma_Click" Width="120" Style="margin-left: 15px" />
            <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="1000" OnTick="Timer1_Tick" ValidateRequestMode="Disabled">
            </asp:Timer>
        </div>

    </form>
</body>
</html>
