USE [QLTV]
GO
/****** Object:  StoredProcedure [dbo].[Search_HovVien_bySoCC]    Script Date: 15-Jun-16 7:01:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[Search_HovVien_bySoCC]
@textSearch nvarchar(50)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT *
FROM	
CAP_CHUNGCHI left outer join vHocVienImage on CAP_CHUNGCHI.CCC_HOVID = vHocVienImage.HOV_ID
Where 
CAP_CHUNGCHI.CCC_SoCC =@textSearch
  
--HOCVIEN.HOV_Phone like  '%'+@textSearch+'%' OR HOCVIEN.HOV_Phone LIKE @textSearch+'%'

--endregion

