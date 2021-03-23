SET NOCOUNT ON
GO

USE master

GO
if exists (select * from sysdatabases where name='WebNotepadDB')
        drop database WebNotepadDB
GO

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE WebNotepadDB
  ON PRIMARY (NAME = N''WebNotepadDB'', FILENAME = N''' + @device_directory + N'WebNotepadDB.mdf'')
  LOG ON (NAME = N''WebNotepadDB_log'',  FILENAME = N''' + @device_directory + N'WebNotepadDB.ldf'')')

GO 

set quoted_identifier on
GO

SET DATEFORMAT mdy
GO

use "WebNotepadDB"
GO

drop table if exists ActiveNote
drop table if exists ArchiveNote

GO
CREATE TABLE CurrentNote (
	id int IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	title varchar(128) NOT NULL,
	content varchar(512) NOT NULL,
	created datetime,
	modified datetime,
	is_active bit NOT NULL,
)
GO

CREATE TABLE ArchiveNote (
	note_id int NOT NULL,
	title varchar(128) NOT NULL,
	content varchar(512) NOT NULL,
	created datetime,
	modified datetime,
	is_active bit NOT NULL,
	[version] int IDENTITY (1, 1) NOT NULL PRIMARY KEY,
)
GO
--! Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=WebNotepadDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
