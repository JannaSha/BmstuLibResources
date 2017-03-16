<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Site.Master" AutoEventWireup="true" CodeBehind="Archive.aspx.cs" Inherits="BmstuLibResources.Pages.Archive" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <h2>Архив исключенных ресурсов<%: Title %></h2>
        <p>
            <asp:SqlDataSource ID="SqlDsResvResources" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                SelectCommand="SELECT Res.id, [name], [license_date], [resource_form], [reserve_date], [resource_author], [url], [udc_id], Udc.description as udc, [create_date], [resource_type], (SELECT TOP 1 v.description FROM Validations v WHERE v.resource_id = Res.id ORDER BY v.check_datetime) as error FROM [Resources] Res JOIN [Udc] Udc ON Udc.id = Res.udc_id WHERE (SELECT TOP 1 v.is_valid FROM Validations v WHERE v.resource_id = Res.id ORDER BY v.check_datetime DESC) = 0 AND Res.reserve_date IS NOT NULL">
            </asp:SqlDataSource>
        </p>
        <p>
            <asp:GridView ID="gvResvResources" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDsResvResources">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID ресурса" SortExpression="id" />
                    <asp:BoundField DataField="name" HeaderText="Имя ресурса" SortExpression="name" />
                    <asp:BoundField DataField="resource_author" HeaderText="Автор ресурса" SortExpression="resource_author" />
                    <asp:BoundField DataField="url" HeaderText="URL" SortExpression="url" />
                    <asp:BoundField DataField="udc_id" HeaderText="УДК" SortExpression="udc_id" />
                    <asp:BoundField DataField="create_date" HeaderText="Дата добавления" SortExpression="create_date" />
                    <asp:BoundField DataField="reserve_date" HeaderText="Дата искючения" SortExpression="reserve_date" />
                    <asp:BoundField DataField="resource_type" HeaderText="Тип ресурса" SortExpression="resource_type" />
                    <asp:BoundField DataField="resource_form" HeaderText="Вид ресурса" SortExpression="resource_form" />
                    <asp:BoundField DataField="license_date" HeaderText="Дата получения лицензии" SortExpression="license_date" />  
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
        </p>

</asp:Content>