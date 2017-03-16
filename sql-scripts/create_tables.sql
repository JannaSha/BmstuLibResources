USE master;
GO

IF EXISTS(SELECT * from sys.databases WHERE name='Library')
BEGIN
    DROP DATABASE Library;
END

CREATE DATABASE Library;

USE Library
GO

CREATE TABLE [Resources] (
	id int IDENTITY(1,1),
	name varchar(255) NOT NULL,
	resource_author varchar(255),
	url varchar(max) NOT NULL,
	udc_id integer NOT NULL,
	html_code text NOT NULL,
	create_date date NOT NULL,
	reserve_date date DEFAULT NULL,
	license_date date DEFAULT NULL,
	resource_type varchar(100) NOT NULL,
	resource_form varchar(50) DEFAULT NULL,
	amount_resource int DEFAULT 0,
	is_editing bit DEFAULT 0
  CONSTRAINT [PK_RESOURCES] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
)

GO
CREATE TABLE [Validations] (
	id int IDENTITY(1,1),
	resource_id integer NOT NULL,
	check_datetime datetime NOT NULL,
	is_valid bit NOT NULL,
	description text,
  CONSTRAINT [PK_VALIDATIONS] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
)

GO
CREATE TABLE [Stats] (
	id int IDENTITY(1,1),
	resource_id integer NOT NULL,
	start_period_datetime datetime NOT NULL,
	finish_period_datetime datetime NOT NULL,
	visitors_count integer NOT NULL DEFAULT 0,
  CONSTRAINT [PK_STATS] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
)

GO
CREATE TABLE [Udc] (
	id int IDENTITY(1,1),
	udc_index varchar(255),
	description text NOT NULL,
  CONSTRAINT [PK_UDC] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
)

GO
ALTER TABLE [Resources] WITH CHECK ADD CONSTRAINT [Resources_fk0] FOREIGN KEY ([udc_id]) REFERENCES [Udc]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Resources] CHECK CONSTRAINT [Resources_fk0]
GO


ALTER TABLE [Validations] WITH CHECK ADD CONSTRAINT [Validations_fk0] FOREIGN KEY ([resource_id]) REFERENCES [Resources]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Validations] CHECK CONSTRAINT [Validations_fk0]
GO

ALTER TABLE [Stats] WITH CHECK ADD CONSTRAINT [Stats_fk0] FOREIGN KEY ([resource_id]) REFERENCES [Resources]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Stats] CHECK CONSTRAINT [Stats_fk0]
GO


