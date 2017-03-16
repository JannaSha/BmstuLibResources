<%@ Page Title="Ресурсы" Language="C#" MasterPageFile="~/Pages/Master/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BmstuLibResources._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Список ресурсов</h2>

<asp:GridView ID="gvValidResources" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id"  AllowPaging="True" >
    <Columns>
        <asp:BoundField DataField="id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
        <asp:BoundField DataField="name" HeaderText="Имя ресурса" SortExpression="name" />
        <asp:BoundField DataField="resource_author" HeaderText="Оператор ресурса" SortExpression="resource_author" />
        <asp:BoundField DataField="url" HeaderText="URL" SortExpression="url" />
        <asp:BoundField DataField="udc" HeaderText="УДК" SortExpression="udc" />
        <asp:BoundField DataField="create_date" HeaderText="Дата добавления" SortExpression="create_date" />
        <asp:BoundField DataField="amount_resource" HeaderText="Количество экземпляров" SortExpression="amount_resource" />
        <asp:BoundField DataField="resource_form" HeaderText="Вид ресурса" SortExpression="resource_form" />
        <asp:BoundField DataField="license_date" HeaderText="Дата получения лицензии" SortExpression="license_date" />
    </Columns>
    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
    <RowStyle BackColor="White" ForeColor="#003399" />
    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
    <SortedAscendingCellStyle BackColor="#EDF6F6" />
    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
    <SortedDescendingCellStyle BackColor="#D6DFDF" />
    <SortedDescendingHeaderStyle BackColor="#002876" />
</asp:GridView>
    <br />
    <h3>Актуализация</h3>
    <br />
    <asp:Button ID="validateBtn" runat="server" Height="30px" Text="Проверить источники" Width="160px" OnClick="validateBtn_Click" />

    <br />
    <br />
<asp:GridView ID="gvInvalidResources" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" Height="100px">
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
        <asp:BoundField DataField="id" HeaderText="Id" SortExpression="id" />
        <asp:BoundField DataField="name" HeaderText="Имя ресурса" SortExpression="name" />
        <asp:BoundField DataField="resource_author" HeaderText="Автор ресурса" SortExpression="resource_author" />
        <asp:BoundField DataField="url" HeaderText="URL" SortExpression="url" />
        <asp:BoundField DataField="udc" HeaderText="УДК" SortExpression="udc" />
        <asp:BoundField DataField="create_date" HeaderText="Дата добавления" SortExpression="create_date" />
        <asp:BoundField DataField="resource_form" HeaderText="Вид ресурса" SortExpression="resource_form" />
        <asp:BoundField DataField="license_date" HeaderText="Дата получения лицензии" SortExpression="license_date" />
        <asp:BoundField DataField="resource_type" HeaderText="Тип ресурса" SortExpression="resource_type" />
        <asp:BoundField DataField="error" HeaderText="Причина ошибки" SortExpression="error" />

    </Columns>
    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
    <RowStyle BackColor="White" ForeColor="#003399" />
    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
    <SortedAscendingCellStyle BackColor="#EDF6F6" />
    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
    <SortedDescendingCellStyle BackColor="#D6DFDF" />
    <SortedDescendingHeaderStyle BackColor="#002876" />
</asp:GridView>
    <br />
    <asp:Button ID="RemoveResourceBtn" runat="server" Text="Исключить ресурс" Width="200px" OnClick="RemoveResourceBtn_Click" />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="ActualizeResourceBtn" runat="server" Text="Актуализировать ресурс" Width="200px" OnClick="ActualizeResourceBtn_Click" />

</asp:Content>
