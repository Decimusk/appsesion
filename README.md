El código está desarrollado en Visual Studio.NET 2019. Usando la tecnología del Web Form, una Base de Datos SQL Server Express (MDF) o 
local. Para el funcionamiento se recomienda ejecutar el siguiente Script.



Create database ASPNET
USE ASPNET

CREATE TABLE [dbo].[tblUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL
)
-------------------

create proc [dbo].[sp_login]
(
@UserId varchar(50), @Password nvarchar(50)
)
as
begin
Select * from tblUsers where UserId=@UserId and password=@Password
end;
GO

-----------------------------
Insert into tblUsers (UserId, Password) values ('admin','admin');
Insert into tblUsers (UserId, Password) values ('perezg74','123')
