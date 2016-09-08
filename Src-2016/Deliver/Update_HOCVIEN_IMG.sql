USE [QLTV]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Update_HOCVIEN_IMG]
	@IMG_ID int,
	@IMG_Name nvarchar(100),
	@IMG_Image image
	 
AS

SET NOCOUNT ON

UPDATE [dbo].[HOCVIEN_IMG] SET
	[IMG_Name]= @IMG_Name,
	[IMG_Image] = @IMG_Image
	
WHERE
	[IMG_ID] = @IMG_ID



