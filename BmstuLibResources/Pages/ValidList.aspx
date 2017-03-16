<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidList.aspx.cs" Inherits="BmstuLibResources.Pages.ValidList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=yes">
    
    <title><%: Page.Title %> Ресурсы библиотеки МГТУ им. Н.Э. Баумана</title>
    <style type="text/css">
        A {
            color: #000000; /* Цвет ссылок */
        }
        A:visited {
            color: #000000; /* Цвет посещенных ссылок */
        }
        A:hover {
            color: #D2691E; /* Цвет ссылки при наведении на нее курсора мыши */  
        }
    </style>
</head>
<body style="background: #FFDBA4; font-family: Arial; font-size: 14px; padding:0; margin:0;">
    <form id="form1" runat="server">
    <div style="width: 100%">
        <div id="LeftSide" style="width: 25%; float: left;">
            <div id="Logo">
                <img src="/images/pic_logo.jpg" width="270" height="270" border="0" usemap="#logomap" alt="Библиотека МГТУ им. Н.Э.Баумана"  />
                <map id="logomap" name="logomap">
                <area shape="rect" coords="95,243,116,263" href="/Feedback/FeedbackForm.aspx" alt="Обратная связь" title="Обратная связь" />
                <area shape="rect" coords="121,243,142,263" href="/" alt="Главная страница" title="Главная страница" /> 
                </map>
            </div>
            <div class="BoxHeader" style="margin: 10px; width: 238px; background-color: #DEB887; float: none; border:1px #b2b0b0 ridge; padding: 5px 0 5px 15px"> <B>Информационные ресурсы библиотеки</B> </div>
            <div class="ContentBox" style="margin: 10px; width: 238px; float: none; border:1px #b2b0b0  ridge; padding: 5px 0 5px 15px">
                <span id="NavigationPlaceHolder_NavigationContentBox">
                    <a href="/Feedback/BibRequestForm.aspx">Виртуальная справка</a><br><br>
	                <B>Электронные 
                      каталоги библиотеки МГТУ им. Н.Э. Баумана</B><BR><A 
                      href="http://library.bmstu.ru/BooksSearcher.aspx?BooksCatalog=1">Полный 
                      электронный каталог</A> <BR><A 
                      href="http://library.bmstu.ru/BooksSearcher.aspx?SubjectCatalog=1">Предметный 
                      каталог</A> <BR><A 
                      href="http://library.bmstu.ru/Periodicals/PeriodicalsTitles.aspx">Электронный 
                      каталог периодики</A><BR><A 
                      href="http://library.bmstu.ru/BooksSearcher.aspx?SearchFx=1">Каталог 
                      полнотекстовых документов</A><BR><A 
                      href="http://library.bmstu.ru/BooksSearcher.aspx?mode=a&amp;src=c&amp;order=0&amp;fn=17">Каталог фонда редких книг</A><BR><A 
                      href="http://atoz.ebsco.com/Titles/MGTUB471?lang=ru&lang.menu=ru&lang.subject=ru" target"=_blank">Каталог зарубежных ресурсов МГТУ: 
                      периодики и книг (с переходом на полный текст с IP МГТУ)</A><BR>

                    <BR><A 
                    href="http://library.bmstu.ru/static/InformationalResources/GOST.aspx"><B>ГОСТ</B>ы</A> 
                    <BR>

                    <br><b>Электронные библиотечные системы (ЭБС)</b>
                    <br>
                    <br> <a href="http://ebooks.bmstu.ru" target="_blank"><b> МГТУ им. Н.Э.Баумана </b></a>
                    <br> <a href="http://e.lanbook.com" target="_blank"><b>Лань</b></a>
                    <br> <a href="http://biblio-online.ru" target="_blank"><b>ЮРАЙТ</b></a>
                    <br>     
                    
                    <BR><B>Полнотекстовые научные издания</B><BR>
                    <p style="margin-top: 2px; margin-bottom: 7px">
                    <img src="images/explain.gif">
                    <A 
                          href="http://library.bmstu.ru/static/InformationalResources/FullTextResources.aspx">Доступ к ресурсам</A> <BR>
                    <A 
                          href="https://webvpn.bmstu.ru/">Войти в ВЕБ ВПН</A> <BR>
                    </p>
                    <A 
                          href="http://library.bmstu.ru/static/InformationalResources/IEEE.aspx"><B>IEEE/IET </B>Electronic Library (IEL) 
                          (журналы,конференции, стандарты)</A> <BR>
                          <!-- <A href="http://library.bmstu.ru/static/InformationalResources/ACM.aspx"><B>ACM</B> 
                          (журналы,конференции)</A> <BR> -->
	                    <A 
                          href="http://library.bmstu.ru/static/InformationalResources/SPIE.aspx"><B>SPIE</B> 
                          (журналы,конференции)</A> <BR><A 
                          href="http://library.bmstu.ru/static/InformationalResources/OSA.aspx"><B>OSA</B> 
                          Optical Society of America (журналы,конференции)</A> <BR><A 
                          href="http://library.bmstu.ru/static/InformationalResources/ElsevierCS.aspx"><B>ScienceDirect(Elsevier)</B> 
                          (журналы, книги)</A> <BR><A 
                          href="http://library.bmstu.ru/static/InformationalResources/Oxford.aspx"><B>OUP</B> 
                          Oxford University Press (журналы)</A> <BR>
                          <A       href="http://library.bmstu.ru/static/InformationalResources/AIP.aspx"><B>AIP</B> 
                          American Institute of Physics (журналы)</A> <BR>
	                    <A 
                          href="http://library.bmstu.ru/static/InformationalResources/Science.aspx"><B>Science</B> 
                          (журнал)</A> <BR> 
                     <A 
                          href="http://library.bmstu.ru/static/InformationalResources/Sage.aspx"><B>Sage Publications</B> 
                          (журналы)</A>
                     <!-- <A href="http://library.bmstu.ru/static/InformationalResources/Nature.aspx"><B>Nature</B> 
                          (журналы)</A> --> 
	                    <BR><A      href="http://library.bmstu.ru/static/InformationalResources/TF.aspx"><B>Taylor 
                          &amp; Francis</B> (журналы)</A>
                     <br> <A href="http://library.bmstu.ru/static/InformationalResources/Springer.aspx"><B>Springer</B> 
                          (журналы,книги)
                     <BR>
	                    <A href="http://library.bmstu.ru/static/InformationalResources/Wiley.aspx"><B>Wiley</B> 
                          (журналы)</A> 
                     <BR> 
                          <A href="http://library.bmstu.ru/static/InformationalResources/APS.aspx"><B>APS</B> American Physical Sosiety</A>
                    <br> <a href="http://archive.neicon.ru"><b>Архив научных журналов</b></a>
     
	                    <!-- A 
                          href="http://library.bmstu.ru/static/InformationalResources/ECS.aspx"><B>Electrochemical 
                          Society</B> (журналы)</A> <BR> -->
	                    <!--A  href="http://library.bmstu.ru/static/InformationalResources/AR.aspx"><B>Annual 
                          Reveiws</B> (журналы)</A> <BR> --> 
	                    <!-- <A  href="http://library.bmstu.ru/static/InformationalResources/S_of_S.aspx"><B>Science 
                          of Synthesis</B> (справочно-информационный)</A> <BR> -->
	                    <!--- <A href="http://library.bmstu.ru/static/InformationalResources/CrCpress.aspx"><B>CRCpress</B> 
                          (книги)</A> <BR> -->
                    <br><a href="http://library.bmstu.ru/static/InformationalResources/ProQuest.aspx"><b>PROQUEST DISSERTATIONS & THESES GLOBAL</b></a>
                    <br><a href="http://library.bmstu.ru/static/InformationalResources/EBSCO.aspx"><b>Computers & Applied Science</b></a>
	                    <BR><A href="http://library.bmstu.ru/static/InformationalResources/ELibrary.aspx"><B>Н</B>аучная 
                          <B>Э</B>лектронная <B>Б</B>иблиотека</A> 
                    <!-- <a href="http://www.ebiblioteka.ru"><b>Издания по естественным и техническим наукам</b></A> -->	

                     <br><A href="http://library.bmstu.ru/static/InformationalResources/Questel.aspx"><B>Questel QPAT</B> (Patent)</A> 
                    <BR><!--a href="static/InformationalResources/dis.aspx">Диссертации РГБ</a> <br /-->
                    <A 
                          href="http://library.bmstu.ru/static/InformationalResources/Garant.aspx"><B>"Консультант"</B> 
                          (правовая БД)</A> 
                    <a href="http://library.bmstu.ru/static/InformationalResources/TotalMateria.aspx"><b>TotalMateria </b> Справочная БД по материалам </a>

                    <!-- <BR><A href="http://library.bmstu.ru/static/InformationalResources/kodex.aspx"><B>"КОДЕКС"</B> (правовая БД)</A> -->
                    <BR><!-- <a href="static/InformationalResources/Snips.aspx">СНиПы и СаНиПы</a> <br /> -->
                    
                    <BR><B>Энциклопедии,       словари, справочники</B><BR>
                    <BR>
                    <A 
                          href="http://www3.interscience.wiley.com/cgi-bin/mrwhome/112102158/HOME"><B>Encyclopedia 
                          of Medical Devices and Instrumentation</B></A>
                    <!-- <A 
                          href="http://www.sciencedirect.com/science/referenceworks/9780080429939"><B>Comprehensive 
                          Composite Materials</B></A> -->
                    <BR><BR><B>Реферативные БД, индексы цитирования</B>
                    <BR><A   href="http://library.bmstu.ru/static/InformationalResources/Viniti.aspx">Реферативный 
                          журнал <B>ВИНИТИ</B></A>
 

                    <br> <A  href="http://library.bmstu.ru/static/InformationalResources/scopus.aspx"><b>SCOPUS</b> </A>

                    <br> <A  href="http://library.bmstu.ru/static/InformationalResources/wos.aspx"><b>Web of Science</b> </A>

                    <br> <A  href="http://elibrary.ru/project_risc.asp" target="_blank"><b>РИНЦ</b> </A>

                    <br> <a href="http://library.bmstu.ru/static/InformationalResources/EBSCO.aspx"><b>INSPEC</b></a>

                    <!-- <br> <a href="http://www.ams.org/mathscinet" target="_blank"><b>MathsciNet</b></a>(БД авторов по математике) -->
                    <br> 
                    <!-- <BR><A  href="http://library.bmstu.ru/static/InformationalResources/EBSCO.aspx"><B>Inspec 
                          (IEE)</B></A> <BR> -->
	                    <!-- <A href="http://library.bmstu.ru/static/InformationalResources/Thomson.aspx"><B>Knowledge 
                          Dashboard</B></A> -->
	                    <!-- <A href="http://library.bmstu.ru/static/InformationalResources/CSA.aspx"><B>CSA</B> 
                          (Cambridge Scientific Abstracts)</A> -->
                     <!-- <BR> <A href="http://www.scirus.com/"><B>Scirus</B> (от Elsevier)</A> -->
 
                    <br> <A href="http://library.bmstu.ru/static/InformationalResources/polpred.aspx"><b>POLPRED.com Обзор СМИ</b></A> 
 

                     <BR><!-- <a href="static/InformationalResources/google.aspx">GooglScholar (специальный проект)</a> <br /> -->
 
				                    <BR><!--b>Тестовые доступы</b><br />
				                    <a href="http://elsevier.ru/products/demo-access/scopus">Scopus (Elsevier)</a> <br /> 
				                    <a href="http://elsevier.ru/products/electronic/physico-mathematical/EngineeringVillage2">Engineering Village 2 (Inspec, Compendex)</a> <br />
				                    <br /--><B>Ресурсы университета</B><BR><A 
                          href="http://msdnaa.lib.bmstu.ru/default.aspx">Лицензионное ПО - программа DreamSpark (MSDN AA)</A> 
                          <BR>
                </span>
            </div>
            <p style="margin: 10px;"><a href="http://www.bmstu.ru" target="_blank">
                <span style="white-space:nowrap">&copy; МГТУ им. Н.Э. Баумана, 2003-<%: DateTime.Now.Year %></span>
               </a> 
            </p>

        </div>
        <div id="RightSide" style="width: 75%; float: left">
           <!-- <div id="MenuBarContainer">
                <span id="XmlMenu1"><div id="menu">
	            <ul>
		            <li><h2>
			            <nobr>О библиотеке</nobr>
		            </h2><ul style="width:200px;">
			            <li style="width:200px;"><a href="default.aspx">Новости</a></li><li style="width:200px;"><a href="Information/LibraryTimetable.aspx">График работы</a></li><li style="width:200px;"><a href="static/Information/LibraryHistory.aspx">История библиотеки</a></li><li style="width:200px;"><a href="static/Information/LibraryPlan.aspx">Расположение отделов</a></li><li style="width:200px;"><a href="static/Information/LibraryRules.aspx">Правила пользования библиотекой</a></li><li style="width:200px;"><a href="static/Information/Contacts.aspx">Наши контакты</a></li><li style="width:200px;"><a href="Feedback/BibRequestForm.aspx">Виртуальная справка</a></li><li style="width:200px;"><a href="Information/DatabaseInformation.aspx">О базе данных</a></li>
		            </ul></li>
	            </ul><ul>
		            <li><h2>
			            <nobr>Каталоги</nobr>
		            </h2><ul style="width:200px;">
			            <li style="width:200px;"><a href="BooksSearcher.aspx?SearchMode=Advanced">Каталог книг</a></li><li style="width:200px;"><a href="BooksSearcher.aspx?SubjectCatalog=1">Предметный каталог</a></li><li style="width:200px;"><a href="Periodicals/PeriodicalsTitles.aspx">Каталог периодики</a></li><li style="width:200px;"><a href="BooksSearcher.aspx?SearchFx=1">Каталог полнотекстовых документов</a></li><li style="width:200px;"><a href="BooksSearcher.aspx?mode=a&amp;src=c&amp;order=0&amp;fn=17">Каталог фонда редких книг</a></li><li style="width:200px;"><a href="Bibliography/Authors.aspx">Труды учёных МГТУ им. Баумана</a></li><li style="width:200px;"><a href="BooksSearcher.aspx?AutoRefs=1">Каталог авторефератов</a></li><li style="width:200px;"><a href="BooksSearcher.aspx?NewIncomings=1">Каталог новых поступлений</a></li><li style="width:200px;"><a href="static/Recommendations/default.aspx">Списки рекомендованной литературы</a></li>
		            </ul></li>
	            </ul><ul>
		            <li><h2>
			            <nobr>Картотека публикаций</nobr>
		            </h2><ul style="width:200px;">
			            <li style="width:200px;"><a href="Publications/">Публикации авторов МГТУ</a></li><li style="width:200px;"><a href="Bibliography/Authors.aspx">Публикации авторов в фонде библиотеки</a></li><li style="width:200px;"><a href="static/Science/CitationIndexes.aspx">Индексы цитирования</a></li>
		            </ul></li>
	            </ul><ul>
		            <li><h2>
			            <nobr>Выставки</nobr>
		            </h2><ul style="width:150px;">
			            <li style="width:150px;"><a href="static/Presentations/WW1/default.aspx">ИМТУ в годы Первой мировой войны</a></li><li style="width:150px;"><a href="static/Presentations/BattleForMoscow/default.aspx">Битва за Москву</a></li><li style="width:150px;"><a href="static/Presentations/VDay70/default.aspx">К 70-летию Победы</a></li><li style="width:150px;"><a href="static/Presentations/Geometry/default.aspx">Начертательная геометрия - прошлое и настоящее</a></li><li style="width:150px;"><a href="static/Presentations/SNTR/default.aspx">Об опыте организации студенческой научно-исследовательской работы</a></li>
		            </ul></li>
	            </ul><ul>
		            <li><h2>
			            <nobr>Персональный центр</nobr>
		            </h2><ul style="width:200px;">
			            <li style="width:200px;"><a href="static/PersonalCenter/welcome.aspx">Вход/Активация</a></li><li style="width:200px;"><a href="PersonalCenter/PersonalCenter.aspx?Mode=Orders">Мои заказы</a></li><li style="width:200px;"><a href="PersonalCenter/PersonalCenter.aspx?Mode=Books">Мои книги</a></li><li style="width:200px;"><a href="PersonalCenter/PersonalCenter.aspx?Mode=PersonalInfo">Мои личные данные</a></li><li style="width:200px;"><a href="static/InformationalResources/FullTextResources.aspx">Доступ к ресурсам</a></li><li style="width:200px;"><a href="http://msdnaa.lib.bmstu.ru/default.aspx">Доступ к лицензионному ПО</a></li><li style="width:200px;"><a href="Feedback/FeedbackForm.aspx">Обратная связь</a></li><li style="width:200px;"><a href="default.aspx?logout=1">Выйти</a></li>
		            </ul></li>
	            </ul>
                </div></span>
            </div> -->
            <div id="SearchBar">
                <div id="UDC" style="margin: 10px; padding: 30px; border: 1px ridge #b2b0b0;">
                    <!-- <asp:Label ID="LabelHead" runat="server" Text="Label"></asp:Label>
                    <br /> -->
                    <asp:Label ID="LabelInput" runat="server" Text="Выберите УДК:"></asp:Label>
                    <asp:DropDownList ID="DropDownListUdc" runat="server" BackColor="#CFD1E2" onselectedindexchanged="Index_Changed" AutoPostBack="True" ForeColor="Black" Width="500px"/>
                    </asp:DropDownList>
                </div>
            </div>
            <div id="Search" style="margin: 10px; padding: 30px; border:1px #b2b0b0  ridge;">
                <asp:Label ID="label2" runat="server" Text="Поиск в каталоге"></asp:Label>
                <asp:TextBox ID="TextBoxSearch" runat="server" Height="20px" Width="159px" TextMode="Search"></asp:TextBox>
                <asp:Button ID="ButtonSearch" runat="server" BackColor="#CFD1E2" Height="26px" OnClick="ButtonSearch_Click" style="margin-right: 0px" Text="Найти" Width="105px" />
                <p>
                    <asp:Label ID="LabelMessage" runat="server" Text="Label"></asp:Label>
                    <asp:PlaceHolder ID="PlaceHolder" runat="server"></asp:PlaceHolder>
                </p>
            </div>
        </div>
    </div>
    </form>
</body>
</html>