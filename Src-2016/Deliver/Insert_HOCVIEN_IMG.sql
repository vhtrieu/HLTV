USE [QLTV]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

alter PROCEDURE [dbo].[Insert_HOCVIEN_IMG]
	@IMG_HOVID int,
	@IMG_Name nvarchar(100),
	@IMG_Image image,
	@IMG_ID int OUTPUT
AS

SET NOCOUNT ON

INSERT INTO [dbo].[HOCVIEN_IMG] (
	[IMG_HOVID],
	[IMG_Name],
	[IMG_Image]
	
) VALUES (
	@IMG_HOVID ,
	@IMG_Name ,
	@IMG_Image 
)

SET @IMG_ID = SCOPE_IDENTITY()

--endregion

