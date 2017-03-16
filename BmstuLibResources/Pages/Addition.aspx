<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Site.Master" AutoEventWireup="true" CodeBehind="Addition.aspx.cs" Inherits="BmstuLibResources.Addition" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Добавление ресурса<%: Title %></h2>
<p>Название ресурса:&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtBName" runat="server" Height="26px" Width="154px"></asp:TextBox>
&nbsp;</p>
    <p>Владелец ресурса:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TexBoxOwner" runat="server" Height="25px" Width="153px"></asp:TextBox>
</p>
<p>Ссылка на ресурс:&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtBUrl" runat="server" Height="28px" Width="154px" TextMode="Url"></asp:TextBox>
</p>
<p>Индекс по УДК:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownListUdc" runat="server">
    </asp:DropDownList>
</p>
<p>Вид ресурса:&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="fromResurce" runat="server" Height="25px" Width="405px">
            <asp:ListItem>Журналы</asp:ListItem>
            <asp:ListItem>Газеты</asp:ListItem>
            <asp:ListItem>Книги</asp:ListItem>
            <asp:ListItem>Документы</asp:ListItem>
            <asp:ListItem>Статьи</asp:ListItem>
            <asp:ListItem>Карты</asp:ListItem>
    </asp:DropDownList>
</p>
<p>Дата заключения договора для лицензионных ресурсов:&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="licenseDate" runat="server" Height="28px" Width="154px"></asp:TextBox>
</p>
<p>Тип ресурса:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="listType" runat="server" Height="25px" Width="405px">
            <asp:ListItem>Отдельные публикации в составе платного ресурса</asp:ListItem>
            <asp:ListItem>Коллекции</asp:ListItem>
            <asp:ListItem>Единичные публикации</asp:ListItem>
        </asp:DropDownList>
</p>
    <p>Количество единиц:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxAmount" runat="server" Height="16px" TextMode="Number" Width="44px">1</asp:TextBox>
</p>
    <p>
        <asp:Button ID="btnAdd" runat="server" Height="25px" Text="Добавить" Width="132px" OnClick="btnAdd_Click" />
</p>
</asp:Content>
