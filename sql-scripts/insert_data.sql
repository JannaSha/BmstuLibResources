USE Library

INSERT INTO Resources VALUES(N'Органическая химия. Сборник задач.', N'https://e.lanbook.com/', N'https://e.lanbook.com/book/1867#book_name',
							 (SELECT id FROM Udc WHERE id = 43), '', GETDATE(), NULL, NULL,
							   'Книги', 'Единичные публикации', 1, 0);

INSERT INTO Resources VALUES(N'Springer', N'http://www.springerprotocols.com/', N'http://www.springerprotocols.com/',
							 (SELECT id FROM Udc WHERE id = 62), '', GETDATE(), NULL, NULL,
							   'Журналы', 'Коллекции', 1000, 0);

INSERT INTO Resources VALUES(N'Управление научных исследований', N'http://science.spb.ru/', N'http://science.spb.ru/db',
							 (SELECT id FROM Udc WHERE id = 1), '', GETDATE(), NULL, NULL,
							   'Журналы', 'Коллекции', 565, 0);

INSERT INTO Resources VALUES(N'Encyclopedia of Medical Devices and Instrumentation', N'http://onlinelibrary.wiley.com/', N'http://onlinelibrary.wiley.com/book/10.1002/0471732877',
							 (SELECT id FROM Udc WHERE id = 50), '', GETDATE(), NULL, ,
							   'Книги', 'Единичные публикации', 1, 0);

INSERT INTO Resources VALUES(N'SCOPUS', N'https://www.scopus.com/', N'https://www.scopus.com/home.uri',
							 (SELECT id FROM Udc WHERE id = 1), '', GETDATE(), NULL, GETDATE(),
							   'Статьи', 'Отдельные публикации в составе платного ресурса', 1, 0);

INSERT INTO Resources VALUES(N'What is so special about science?', N'http://aapt.scitation.org/', N'http://aapt.scitation.org/doi/abs/10.1119/1.1466542',
							 (SELECT id FROM Udc WHERE id = 1), '', GETDATE(), NULL, NULL,
							   'Статьи', 'Единичные публикации', 1, 0);

INSERT INTO Resources VALUES(N'Taylor & Francis', N'http://www.tandfonline.com/', N'http://www.tandfonline.com/',
							 (SELECT id FROM Udc WHERE id = 8), '', GETDATE(), NULL, NULL,
							   'Журналы', 'Коллекции', 1023, 0);

INSERT INTO Resources VALUES(N'Optical Engineering', N'http://spiedigitallibrary.org/', N'http://opticalengineering.spiedigitallibrary.org/journal.aspx?journalid=92',
							 (SELECT id FROM Udc WHERE id = 42), '', GETDATE(), NULL, NULL,
							   'Журналы', 'Коллекции', 390, 0);

INSERT INTO Resources VALUES(N'Human lymphoid organ dendritic cell identity is predominantly dictated by ontogeny, not tissue microenvironment', N'http://www.sciencemag.org/', N'http://immunology.sciencemag.org/content/1/6/eaai7677',
							 (SELECT id FROM Udc WHERE id = 45), '', GETDATE(), NULL, NULL,
							   'Статьи', 'Единичные публикации', 1, 0);

INSERT INTO Resources VALUES(N'Internet of Things for Smart Cities', N'http://ieeexplore.ieee.org/Xplore/home.jsp', N'http://ieeexplore.ieee.org/document/6740844/',
							 (SELECT id FROM Udc WHERE id = 1), '', GETDATE(), NULL, GETDATE(),
							   'Статьи', 'Отдельные публикации в составе платного ресурса', 1, 0);

