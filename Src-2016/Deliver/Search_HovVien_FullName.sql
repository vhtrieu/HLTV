USE [QLTV]
GO
/****** Object:  StoredProcedure [dbo].[Search_HovVien_FullName]    Script Date: 06/07/2016 19:46:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[Search_HovVien_FullName]
@FullName nvarchar(50)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
SELECT 
vHocVienImage.*
--HOCVIEN.*,DONVI.DON_Name,TINH.TIN_Name
	
FROM
	--HOCVIEN, DONVI, TINH
	vHocVienImage
 
 WHERE
  
vHocVienImage.HOV_FullName like   '%'+@FullName+'%' 
--AND
--HOCVIEN.HOV_DonVi = DONVI.DON_ID
--AND
--HOCVIEN.HOV_NoiSinh = TINH.TIN_ID

--endregion

