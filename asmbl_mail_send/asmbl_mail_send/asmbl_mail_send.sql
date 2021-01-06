/*
ALTER DATABASE SQLCreateFile SET TRUSTWORTHY ON
go

use comp_tmp
go
exec sp_changedbowner 'sa'
go

sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO
*/
/*
DROP FUNCTION [dbo].[SqlCreateFile]
DROP ASSEMBLY asmbl_mail_send

*/
/*

CREATE ASSEMBLY asmbl_mail_send FROM 'd:\Project\C#\Assemmble_MSSQL\asmbl_mail_send\asmbl_mail_send\bin\Debug\asmbl_mail_send.dll'   WITH PERMISSION_SET=UNSAFE 

*/


/*
CREATE FUNCTION [dbo].[asml_mail_send](@MailAddress nvarchar(200), @Comment nvarchar(200), @SMTP nvarchar(200), @Port smallint, @Login nvarchar(200), @Password nvarchar(200), @Subject nvarchar(200), @Body nvarchar(max), @EnableSsl bit)
RETURNS nvarchar(max) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [asmbl_mail_send].[asmbl_mail_send].[Is_Mail_send]
GO
*/


declare @MailAddress nvarchar(200)	= 'alexykos@mail.ru'
		, @Comment nvarchar(200)	= ''
		, @SMTP nvarchar(200)		= 'smtp.mail.ru'
		, @Port smallint			= 5871
		, @Login nvarchar(200)		= 'alextestsendmail@mail.ru'
		, @Password nvarchar(200)	= 'U654321u'
		, @Subject nvarchar(200)	= 'aaa'
		, @Body nvarchar(max)		= ''
		, @EnableSsl bit			= 1

SELECT [dbo].[asml_mail_send](@MailAddress, @Comment , @SMTP , @Port , @Login , @Password , @Subject , @Body , @EnableSsl )
GO


