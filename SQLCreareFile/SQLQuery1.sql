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
DROP ASSEMBLY SQLCreateFile

*/

/*

CREATE ASSEMBLY SQLCreateFile FROM 'd:\Project\C#\Assemmble_MSSQL\SQLCreareFile\SQLCopyFile\bin\Debug\SQLCreateFile.dll'   WITH PERMISSION_SET=UNSAFE 

*/

/*

CREATE FUNCTION [dbo].[SqlCreateFile](@path [nvarchar](max), @text [nvarchar](max))
RETURNS [bit] WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [SQLCreateFile].[AssemmbleCreateFile].[IsCopyFile]
GO

*/

/*
CREATE FUNCTION [dbo].[SqlCreateFile](@path [nvarchar](max), @text [nvarchar](max))
RETURNS nvarchar(max) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [SQLCreateFile].[AssemmbleCreateFile].[IsCopyFile]
GO
*/

/*
SELECT [dbo].[SqlCreateFile] (
   'c:\bcg.tmp\11_SQLCreateFile.txt'
  ,'bbbbbb')
GO



*/