<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="BmstuLibResources.Reports" %>

<asp:Content ID="head" ContentPlaceHolderID="HeadHolder" runat="server">
</asp:Content>

<asp:Content ID="body" ContentPlaceHolderID="BodyHolder" runat="server">
    <div id="reports" style="margin-bottom: 10px;">
        <h1>Отчеты</h1>
        <h3>Выберите период отчета:</h3>
        <p>Год: &nbsp;&nbsp;
            <asp:DropDownList ID="listYear1" runat="server" Height="25px" Width="200px">
            </asp:DropDownList>
        </p>
        <h3>Выберите тип отчета:</h3>
        <p>Тип: &nbsp;&nbsp;
            <asp:DropDownList ID="listType" runat="server" Height="25px" Width="200px">
                <asp:ListItem Selected="True">Поступление</asp:ListItem>
                <asp:ListItem>Выбытие</asp:ListItem>
                <asp:ListItem>Движение</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Button ID="btnGetReport" runat="server" Text="Получить" Height="40px" Width="120px" OnClick="btnGetReport_Click"/>
        </p>
        <hr />
        <h1>Статистика</h1>
        <h3>Выберите период отчета:</h3>
        <p>Год: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="listYear2" runat="server" Height="25px" Width="200px">
            </asp:DropDownList>
        </p>
        <p>Месяц: &nbsp;&nbsp;
            <asp:DropDownList ID="listMonth" runat="server" Height="25px" Width="200px">
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
            <asp:Button ID="btnGetStats" runat="server" Text="Получить" Height="40px" Width="120px" OnClick="btnGetStats_Click"/>
        </p>
    </div>
</asp:Content>
