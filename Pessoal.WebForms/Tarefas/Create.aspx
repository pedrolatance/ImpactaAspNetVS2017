<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Create.aspx.cs" Inherits="Tarefas_Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Nova Tarefa</h1>
    <hr />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />
    <table style="width: 100%;">
        <tr>
            <td style="width: 147px">Nome:</td>
            <td>
                <asp:TextBox ID="nomeTextBox" runat="server" Width="280px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nomeTextBox" CssClass="text-danger" ErrorMessage="O Nome é obrigatório!!" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 147px">Prioridade:</td>
            <td>
                <asp:DropDownList ID="prioridadeDropDownList" runat="server" AppendDataBoundItems="true" Width="280px" DataSourceID="ObjectDataSource1">
                    <asp:ListItem Text="Selecione..." Value="0"/>
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ObterPrioridades" TypeName="Pessoal.WebForms.Helper"></asp:ObjectDataSource>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="prioridadeDropDownList" CssClass="text-danger" ErrorMessage="A seleção de Prioridade é obrigatória!!" InitialValue="0" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 147px">Concluída:</td>
            <td>
                <asp:CheckBox ID="concluidaCheckBox" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 147px">Observação:</td>
            <td>
                <asp:TextBox ID="observacaoTextBox" runat="server" Rows="5" TextMode="MultiLine" Width="280px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 147px">
                <asp:Button ID="gravarButton" runat="server" Text="Gravar" OnClick="gravarButton_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

