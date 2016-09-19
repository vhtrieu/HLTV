USE [QLTV]
GO
/****** Object:  StoredProcedure [dbo].[getPrintGCN]    Script Date: 06/01/2016 00:25:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[getPrintGCN]
@CCC_LOPID int,
@DIE_LanThi int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT vHocVienImage.HOV_ID as HvID, vHocVienImage.HOV_FirstName as HvFirstName, vHocVienImage.HOV_LastName as HvLastName, vHocVienImage.HOV_BirthDay as HvBirthDay, vHocVienImage.HOV_NoiSinh as HvNoiSinh,
		vHocVienImage.HOV_QuocTich, vHocVienImage.HOV_NoiSinh,vHocVienImage.TIN_Name, vHocVienImage.IMG_Image,
		LOP.LOP_ShortName, LOP.LOP_Ngay_KG, LOP.LOP_Ngay_KT, LOP.LOP_Ngay_QD, 
		CAP_CHUNGCHI.CCC_SoCC as HvSoCc, CAP_CHUNGCHI.CCC_NgayCap as HvNgayCapSoCc,CAP_CHUNGCHI.CCC_NgayHetHan as HvNgayHetHan,
		CHUNG_CHI.CHC_Name,CHUNG_CHI.CHC_Content1,CHC_Content2,CHC_Content3,CHC_Content4, CHC_ModleCode
		,CHC_QuyDinh,CHC_QuyDinhEngl, CHC_QuyTac,CHC_Static, CHC_ID
		,CHUNG_CHI.CHC_FontSize1,CHUNG_CHI.CHC_FontSize2,CHUNG_CHI.CHC_FontSize3,CHUNG_CHI.CHC_FontSize4
		
FROM 
	CAP_CHUNGCHI,
	LOP,
	CHUNG_CHI,
	vHocVienImage
WHERE 
	
	CAP_CHUNGCHI.CCC_LOPID = @CCC_LOPID	
	and
	CAP_CHUNGCHI.CCC_LOPID = LOP.LOP_ID
	and 
	CHUNG_CHI.CHC_ID = CAP_CHUNGCHI.CCC_CHCID
	AND
    CAP_CHUNGCHI.CCC_SoCC <>''
   AND
   vHocVienImage.HOV_ID = CAP_CHUNGCHI.CCC_HOVID
	
	order by CAP_CHUNGCHI.CCC_SoCC 

