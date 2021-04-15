Create DataBase DotStarkContactUsAssignment
use DotStarkContactUsAssignment
Create Table ContactUs(
RowId bigint identity(1,1) primary key,
Name NVarchar(128),
Email NVARCHAR(200),
Phone Decimal(12,0),
Purpose Nvarchar(128),
Matter Nvarchar(500)
)
CREATE PROCEDURE SP_Contact(
@Name NVARCHAR(128)=null,
@Email NVARCHAR(200)=null,
@Phone DECIMAL(12,0)=null,
@Purpose NVARCHAR(128)=null,
@Matter NVARCHAR(500)=null
)
AS BEGIN
INSERT INTO ContactUs(Name,Email,Phone,Purpose,Matter)VALUES(
@Name ,
@Email,
@Phone,
@Purpose,
@Matter 
)
END
