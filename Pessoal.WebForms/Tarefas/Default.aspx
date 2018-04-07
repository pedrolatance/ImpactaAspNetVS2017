<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Tarefas_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Tarefas</h1>
    <hr />
    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="Create">Nova Tarefa</asp:LinkButton>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="Black" GridLines="Horizontal" Width="100%">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
        <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
        <asp:BoundField DataField="Prioridade" HeaderText="Prioridade" SortExpression="Prioridade" />
        <asp:CheckBoxField DataField="Concluida" HeaderText="Concluida" SortExpression="Concluida" />
        <asp:BoundField DataField="Observacao" HeaderText="Observacao" SortExpression="Observacao" />
    </Columns>
    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F7F7F7" />
    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
    <SortedDescendingCellStyle BackColor="#E5E5E5" />
    <SortedDescendingHeaderStyle BackColor="#242121" />
</asp:GridView>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Selecionar" TypeName="Pessoal.Repositorios.SqlServer.TarefaRepositorio"></asp:ObjectDataSource>


</asp:Content>

