USE [QLTV]
GO
/****** Object:  StoredProcedure [dbo].[ExportExcel_Phat_CHUNGCHI]    Script Date: 15-Jun-16 9:19:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[ExportExcel_Phat_CHUNGCHI]
@CHC_ID INT,
@Lop_ID int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT 
 CAP_CHUNGCHI.CCC_SoCC, 
 (HOCVIEN.HOV_FirstName + ' '+ HOCVIEN.HOV_LastName ) as FullName, 
 CAP_CHUNGCHI.CCC_NgayCap, 
 CAP_CHUNGCHI.CCC_Status,
 CHUNG_CHI.CHC_Name, 
 LOP.LOP_Khoa

FROM 
	CAP_CHUNGCHI,
	HOCVIEN,
	CHUNG_CHI,
	LOP
WHERE
	HOCVIEN.HOV_ID = CAP_CHUNGCHI.CCC_HOVID
	AND
	CHUNG_CHI.CHC_ID = CAP_CHUNGCHI.CCC_CHCID
	AND
	CHUNG_CHI.CHC_ID = LOP.LOP_CHCID
	AND 
	CHUNG_CHI.CHC_ID = @CHC_ID
	AND 
	LOP.LOP_ID = @Lop_ID
	AND
	CAP_CHUNGCHI.CCC_LOPID = LOP.LOP_ID
	AND
	CAP_CHUNGCHI.CCC_SoCC <>''
	order by CAP_CHUNGCHI.CCC_SoCC
--endregion

