<%@ Page Title="Вывод отчетов" Language="C#" MasterPageFile="~/Pages/Master/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="BmstuLibResources.Reports" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>&nbsp;</h2>
    <h3>
        <asp:Label ID="YearLabel" runat="server" Text="Год:   "></asp:Label>
        <asp:DropDownList ID="YearDropDownList" runat="server" Height="30px" OnDataBound="YearDropDownList_DataBound" OnSelectedIndexChanged="YearDropDownList_SelectedIndexChanged">
        </asp:DropDownList>
    </h3>
    <h3>Получить отчет&nbsp;
        <asp:DropDownList ID="ddlReportsType" runat="server" Height="30px" Width="200px">
            <asp:ListItem Selected="True">Поступление</asp:ListItem>
            <asp:ListItem>Выбытие</asp:ListItem>
            <asp:ListItem>Движение</asp:ListItem>
        </asp:DropDownList>
    &nbsp;:</h3>
 

    <asp:Button ID="btnGetReports" runat="server" Height="30px" Text="Получить отчет" Width="160px" OnClick="btnGetReports_Click" />
    <br />
    <h3>Получить статистику по ресурсам за:</h3>
    <p>
        <asp:DropDownList ID="MonthDropDownList" runat="server" Height="30px">
            <asp:ListItem>Январь</asp:ListItem>
            <asp:ListItem>Февраль</asp:ListItem>
            <asp:ListItem>Март</asp:ListItem>
            <asp:ListItem>Апрель</asp:ListItem>
            <asp:ListItem>Май</asp:ListItem>
            <asp:ListItem>Июнь</asp:ListItem>
            <asp:ListItem>Июль</asp:ListItem>
            <asp:ListItem>Август</asp:ListItem>
            <asp:ListItem>Сентябрь</asp:ListItem>
            <asp:ListItem>Октябрь</asp:ListItem>
            <asp:ListItem>Ноябрь</asp:ListItem>
            <asp:ListItem>Декабрь</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p> 
        <asp:Button ID="btnGetStats" runat="server" Height="30px" Text="Получить статистику" Width="160px" OnClick="btnGetStats_Click" />
    </p>
</asp:Content>
