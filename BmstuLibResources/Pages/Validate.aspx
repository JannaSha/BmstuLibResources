<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Site.Master" AutoEventWireup="true" CodeBehind="Validate.aspx.cs" Inherits="BmstuLibResources.Validate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadHolder" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="BodyHolder" runat="server">
    <h1>Работа с ресурсами</h1>
    <div id="info">
        <p>
            <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
        </p>
    </div>
    <div id="table">
        <asp:GridView ID="gvResources" runat="server" DataSourceID="dsResources" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="5" DataKeyNames="id">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="name" HeaderText="Имя ресурса" SortExpression="name" />
                <asp:BoundField DataField="url" HeaderText="Ссылка" SortExpression="url" />
                <asp:BoundField DataField="udc" HeaderText="Индекс УДК" SortExpression="udc" />
                <asp:BoundField DataField="create_date" HeaderText="Дата создания" SortExpression="create_date" />
                <asp:BoundField DataField="license" HeaderText="Дата лицензирования" SortExpression="license" />
                <asp:BoundField DataField="type_res" HeaderText="Тип" SortExpression="type_res" />
                <asp:BoundField DataField="form" HeaderText="ВИд" SortExpression="form" />
                <asp:BoundField DataField="amount" HeaderText="Кол-во" SortExpression="amount" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#E9967A" Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#E9967A" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#E9967A" />
        </asp:GridView>
        <asp:SqlDataSource ID="dsResources" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Res.id, [name], [url], Udc.description as udc, [create_date], [license], [type_res], [form], [amount]
                    FROM [Resources] Res JOIN [Udc] Udc ON Udc.id = Res.udc_id
                    WHERE ( SELECT TOP 1 v.is_valid FROM Validations v WHERE v.id_resource = Res.id ORDER BY v.check_date DESC ) = 1 OR NOT EXISTS ( SELECT v.id FROM Validations v WHERE v.id_resource = Res.id )"></asp:SqlDataSource>
        <!--"SELECT Res.id, [name], [url], Udc.description as udc, [create_date], [license], [type_res], [form], [amount]
                       FROM [Resources] Res JOIN [Udc] Udc ON Udc.id = Res.udc_id
                       WHERE (( SELECT TOP 1 v.is_valid FROM Validations v WHERE v.id_resource = Res.id ORDER BY v.check_date DESC ) = 1 OR NOT EXISTS ( SELECT v.id FROM Validations v WHERE v.id_resource = Res.id )) AND (Res.is_editing = 0)"-->    
    </div>
    <div id="button">
        <p>
            <asp:Button ID="btnActualize" runat="server" Text="Проверить ресурсы" Height="40px" Width="160px" OnClick="btnActualize_Click"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDelete" runat="server" Text="Удалить" Height="40px" Width="120px" OnClick="btnDelete_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="btnEdit" runat="server" Text="Редактировать" Height="40px" Width="120px" OnClick="btnEdit_Click"/>
        </p>
    </div>
</asp:Content>

