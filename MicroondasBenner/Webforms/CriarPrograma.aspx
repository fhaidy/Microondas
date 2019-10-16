<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CriarPrograma.aspx.cs" Inherits="MicroondasBenner.Webforms.CriarPrograma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #textNomeProg, #textTempoProg, #textCaractereProg {
            width: 250px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            Nome do Programa:<br />
            <input id="textNomeProg" runat="server" type="text" /><br />
            <br />
            Instruções:
            <br />
            <asp:TextBox ID="textInstrucoesProg" runat="server" Height="125px" Width="250px"  TextMode="MultiLine" style="resize:none;"></asp:TextBox>

            <br />
            <br />
            Tempo:<br />
            <asp:TextBox id="textTempoProg" runat="server" type="text" TextMode="Time" /><br />
            <br />
            Potência:<br />
            <asp:DropDownList ID="DropDownPotencia" runat="server" Height="16px" Width="250px">
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
            Caractere de aquecimento:<br />
            <input id="textCaractereProg" runat="server" type="text" maxlength="1"  size="1" />
            <br />
            <br />
            <asp:Button ID="ButtonCriar" runat="server" Text="Criar Programa" style="margin-right:15px;" OnClick="ButtonCriar_Click" Width="120px" Height="44px"/>
            <asp:Button ID="ButtonCancelar" runat="server" OnClick="ButtonCancelar_Click" Text="Cancelar"  Width="120px" Height="44px"/>
        </div>
    </form>
</body>
</html>
