<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarPrograma.aspx.cs" Inherits="MicroondasBenner.Webforms.BuscarPrograma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-bottom:15px">
            Nome do alimento:
            <asp:TextBox ID="TextBox1" runat="server" Width="543px"></asp:TextBox>
            <asp:Button ID="ButtonBuscar" runat="server" OnClick="ButtonBuscar_Click" Text="Buscar" Width="120px" Height="25"/>
        </div>
        <div>
            <asp:Table id="Table1" runat="server"
        CellPadding="10" 
        GridLines="Both" style="margin-bottom: 15px;margin-left: 0px; display: inline-block" Width="797px" Font-Bold="True" Font-Italic="False">
        <asp:TableHeaderRow id="Table1HeaderRow" 
            BackColor="LightBlue"
            runat="server"
            Width="100%">
            <asp:TableHeaderCell 
                Scope="Column" 
                Text="Nome"
                Width="20%"/>
            <asp:TableHeaderCell  
                Scope="Column" 
                Text="Instruções"
                Width="50%"/>
            <asp:TableHeaderCell 
                Scope="Column" 
                Text="Tempo" 
                Width="10%"/>
            <asp:TableHeaderCell 
                Scope="Column" 
                Text="Potencia"
                Width="10%"/>
            <asp:TableHeaderCell 
                Scope="Column" 
                Text="Caractere"
                Width="10%"/>
        </asp:TableHeaderRow>   
    </asp:Table>
        </div>
        <div>
            <asp:Button ID="ButtonVoltar" runat="server" Text="Voltar" Width="120px" Height="44px" OnClick="ButtonVoltar_Click"/>
        </div>
    </form>
</body>
</html>
