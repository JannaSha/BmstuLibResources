<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Site.Master" AutoEventWireup="true" CodeBehind="Editing.aspx.cs" Inherits="BmstuLibResources.Edditing" %>
<asp:Content ID="Head" ContentPlaceHolderID="HeadHolder" runat="server">
    <script language="javascript" type="text/javascript">
        function unloadMess() {
            msg = "Изменения не были сохранены. Вы можете потерять измененные данные!";
            return msg;
        }

        function setBunload(on) {
            window.onbeforeunload = (on) ? unloadMess : null;
        }

        setBunload(true);
    </script>
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="BodyHolder" runat="server">
    <h1> Редактирование ресурса</h1>
    <div id="base" style="margin-bottom: 10px;">
        <p>Название:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtName" runat="server" Height="20px" Width="300px"></asp:TextBox>
        &nbsp;</p>
        <p>Владелец:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAuthor" runat="server" Height="20px" Width="300px"></asp:TextBox>
        &nbsp;</p>
        <p>Ссылка:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUrl" runat="server" Height="20px" Width="300px" TextMode="Url"></asp:TextBox>
        &nbsp;</p>
        <p>Индекс по УДК:&nbsp;&nbsp;
            <asp:DropDownList ID="listUdc" runat="server" Height="25px" Width="300px"></asp:DropDownList>
        </p>
        <hr />
        <p>Вид ресурса:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="listForm" runat="server" Height="25px" Width="300px">
                <asp:ListItem>Журнал</asp:ListItem>
                <asp:ListItem>Газета</asp:ListItem>
                <asp:ListItem>Книга</asp:ListItem>
                <asp:ListItem>Документ</asp:ListItem>
                <asp:ListItem>Статья</asp:ListItem>
                <asp:ListItem>Карта</asp:ListItem>
                <asp:ListItem>База данных</asp:ListItem>
                <asp:ListItem>Универсальный</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>Тип ресурса:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="listType" runat="server" Height="25px" Width="300px" OnClientSelectedIndexChanged="setBunload(false)" OnSelectedIndexChanged="listType_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>Единичная публикация</asp:ListItem>
                <asp:ListItem>Коллекция</asp:ListItem>
                <asp:ListItem>Публикация в лицензионном ресурсе</asp:ListItem>
                <asp:ListItem>Коллекция в лицензионном ресурсе</asp:ListItem>
            </asp:DropDownList>
            <br /> <br /><asp:Label ID="lblAmount" runat="server" Text="Количество экземпляров: "></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtAmount" runat="server" Height="20px" Width="90px" Text="1" Enabled="False"></asp:TextBox>
        </p>
        <hr />
        <p>
            <asp:Label ID="lblLicStart" runat="server" Text="Дата начала лицензии: "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtLicStart" runat="server" Height="20px" Width="90px" Text="01.01.17" Enabled="False"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblLicEnd" runat="server"   Text="Дата окончания лицензии: "></asp:Label>
            <asp:TextBox ID="txtLicEnd" runat="server" Height="20px" Width="90px" Text="01.01.17" Enabled="False"></asp:TextBox>
        </p>
        <asp:Button ID="btnEdt" runat="server" Text="Изменить" Height="40px" Width="120px" OnClick="btnUpd_Click" OnClientClick="setBunload(false)"/>
    </div>
</asp:Content>
