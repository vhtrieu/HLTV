USE [QLTV]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[SelectHOCVIEN]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	--[HOV_ID],
	--[HOV_Code],
	--[HOV_FirstName],
	--[HOV_LastName],
	--[HOV_BirthDay],
	--[HOV_NoiSinh],
	--[HOV_QuocTich],
	--[HOV_Phone],
	--[HOV_Address],
	--[HOV_DonVi],
	--[HOV_ChucDanh],
	--[HOV_GhiChu],
	--TINH.TIN_Name,
	--DONVI.DON_Name,
	*
	
FROM
	--[dbo].[HOCVIEN],DONVI,TINH,vHocVienImage
	vHocVienImage
--WHERE
 --HOCVIEN.HOV_DonVi = DONVI.DON_ID
 --AND
 --HOCVIEN.HOV_NoiSinh = TINH.TIN_ID
 --AND
 --HOCVIEN.HOV_ID = HOCVIEN_IMG.IMG_HOVID
 

--endregion

