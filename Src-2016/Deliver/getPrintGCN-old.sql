USE [QLTV]
GO
/****** Object:  StoredProcedure [dbo].[getPrintGCN]    Script Date: 06/01/2016 00:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectCAP_CHUNGCHIsAll]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Trieu using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectCAP_CHUNGCHIsAll]
-- Date Generated: Thursday, March 29, 2012
------------------------------------------------------------------------------------------------------------------------

ALTER PROCEDURE [dbo].[getPrintGCN]
@CCC_LOPID int,
@DIE_LanThi int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT HOCVIEN.HOV_ID as HvID, HOCVIEN.HOV_FirstName as HvFirstName, HOCVIEN.HOV_LastName as HvLastName, HOCVIEN.HOV_BirthDay as HvBirthDay, HOCVIEN.HOV_NoiSinh as HvNoiSinh,
		HOCVIEN.HOV_QuocTich, HOCVIEN.HOV_NoiSinh,TINH.TIN_Name,
		LOP.LOP_ShortName, LOP.LOP_Ngay_KG, LOP.LOP_Ngay_KT, LOP.LOP_Ngay_QD, 
		CAP_CHUNGCHI.CCC_SoCC as HvSoCc, CAP_CHUNGCHI.CCC_NgayCap as HvNgayCapSoCc,CAP_CHUNGCHI.CCC_NgayHetHan as HvNgayHetHan,
		CHUNG_CHI.CHC_Name,CHUNG_CHI.CHC_Content1,CHC_Content2,CHC_Content3,CHC_Content4, CHC_ModleCode
		,CHC_QuyDinh,CHC_QuyDinhEngl, CHC_QuyTac,CHC_Static, CHC_ID
		,CHUNG_CHI.CHC_FontSize1,CHUNG_CHI.CHC_FontSize2,CHUNG_CHI.CHC_FontSize3,CHUNG_CHI.CHC_FontSize4
		--,DIEM.DIE_LanThi
FROM 
	CAP_CHUNGCHI,
	HOCVIEN,
	LOP,
	--DIEM,
	CHUNG_CHI,TINH
WHERE 
	CAP_CHUNGCHI.CCC_HOVID = HOCVIEN.HOV_ID
	AND 
	CAP_CHUNGCHI.CCC_LOPID = @CCC_LOPID	
	and
	CAP_CHUNGCHI.CCC_LOPID = LOP.LOP_ID
	and 
	CHUNG_CHI.CHC_ID = CAP_CHUNGCHI.CCC_CHCID
	AND
    CAP_CHUNGCHI.CCC_SoCC <>''
    AND
    TINH.TIN_ID = HOCVIEN.HOV_NoiSinh
    --AND
    --DIEM.DIE_HOVID = CAP_CHUNGCHI.CCC_HOVID
    --AND
    --DIEM.DIE_LOPID = CAP_CHUNGCHI.CCC_LOPID
    --AND
    --DIEM.DIE_LanThi =@DIE_LanThi
	
	order by CAP_CHUNGCHI.CCC_SoCC 

--endregion

