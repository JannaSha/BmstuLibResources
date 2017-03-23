<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Site.Master" AutoEventWireup="true" CodeBehind="Irrelevant.aspx.cs" Inherits="BmstuLibResources.Irrelevant" %>
<asp:Content ID="Head" ContentPlaceHolderID="HeadHolder" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="BodyHolder" runat="server">
    <h1>Неактуальные ресурсы</h1>
        <p>
            <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
        </p>
        <asp:GridView ID="gvIResources" runat="server" DataSourceID="dsIResources" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="5" DataKeyNames="id">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="name" HeaderText="Имя ресурса" SortExpression="name" />
            <asp:BoundField DataField="url" HeaderText="Ссылка" SortExpression="url" />
            <asp:BoundField DataField="udc" HeaderText="УДК" SortExpression="udc" />
            <asp:BoundField DataField="create_date" HeaderText="Дата создания" SortExpression="create_date" />
            <asp:BoundField DataField="license" HeaderText="Дата лицензирования" SortExpression="license" />
            <asp:BoundField DataField="form" HeaderText="Вид" SortExpression="form" />
            <asp:BoundField DataField="type_res" HeaderText="Тип" SortExpression="type_res" />
            <asp:BoundField DataField="error" HeaderText="Причина ошибки" ReadOnly="True" SortExpression="error" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#E9967A" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#E9967A" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#E9967A" />
        </asp:GridView>
        <asp:SqlDataSource ID="dsIResources" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Res.id, [name], [license], [form], [author], [url], Udc.description as udc, [create_date], [type_res], 
					   (SELECT TOP 1 v.description FROM Validations v
					    WHERE v.id_resource= Res.id
					    ORDER BY v.check_date) as error
                       FROM [Resources] Res JOIN [Udc] Udc ON Udc.id = Res.udc_id
					   WHERE 
					   (
							SELECT TOP 1 v.is_valid FROM Validations v
							WHERE v.id_resource = Res.id
							ORDER BY v.check_date DESC
					   ) = 0 AND Res.reserve_date IS NULL">
        </asp:SqlDataSource>
        <p>
            <asp:Button ID="btnReserve" runat="server" Text="Исключить" Height="40px" Width="160px" OnClick="btnReserve_Click"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnHandActualize" runat="server" Text="Актуализировать" Height="40px" Width="160px" OnClick="btnHandActualize_Click"/>
        </p>
</asp:Content>
