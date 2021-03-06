USE [QLTV]
GO
/****** Object:  StoredProcedure [dbo].[ExportExcel_Phat_Doi_CHUNGCHI]    Script Date: 16-Jun-16 1:05:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectCAP_CHUNGCHIsAll]


ALTER PROCEDURE [dbo].[ExportExcel_Phat_Doi_CHUNGCHI]
@CCC_CHCID INT,
@CCC_Status int,
@CCC_SoHieuDoi nvarchar(50)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT CAP_CHUNGCHI.CCC_SoCC, (HOCVIEN.HOV_FirstName + ' '+ HOCVIEN.HOV_LastName ) as FullName, 
 CAP_CHUNGCHI.CCC_NgayCap, CAP_CHUNGCHI.CCC_Status
 --CHUNG_CHI.CHC_Name, LOP.LOP_Khoa

FROM 
	CAP_CHUNGCHI,
	HOCVIEN
	
	
WHERE
	--HOCVIEN.HOV_ID = CAP_CHUNGCHI.CCC_HOVID
	--AND
	--CHUNG_CHI.CHC_ID = CAP_CHUNGCHI.CCC_CHCID
	--AND
	--CHUNG_CHI.CHC_ID = LOP.LOP_CHCID
	--AND 
	--CAP_CHUNGCHI.CCC_CHCID = @CHC_ID
	--AND
	--CAP_CHUNGCHI.CCC_SoHieuDoi = @SoHieuDoi
	--AND
	--CAP_CHUNGCHI.CCC_LOPID = LOP.LOP_ID
	CAP_CHUNGCHI.CCC_CHCID = @CCC_CHCID
	and CAP_CHUNGCHI.CCC_Status = @CCC_Status
	and
	HOCVIEN.HOV_ID = CAP_CHUNGCHI.CCC_HOVID
and 
CAP_CHUNGCHI.CCC_SoHieuDoi = @CCC_SoHieuDoi

--endregion

