USE [QLTV]
GO
/****** Object:  StoredProcedure [dbo].[GetChungChi_ThongKe]    Script Date: 9/19/2016 7:58:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectCAP_CHUNGCHI]


alter PROCEDURE [dbo].[GetChungChi_ThongKeWithLoaiCc]
	@LOP_Ngay_KG date,
	@LOP_Ngay_KT date,
	@iLoaiCc int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;



--SET NOCOUNT ON
--SET TRANSACTION ISOLATION LEVEL READ COMMITTED

--@DIE_LOPIDs = @DIE_LOPID 
SELECT CHUNG_CHI.CHC_ID,CHUNG_CHI.CHC_Name 
FROM LOP,CHUNG_CHI 
WHERE	LOP.LOP_Ngay_KG>= @LOP_Ngay_KG
		and 	
		LOP.LOP_Ngay_KT <= @LOP_Ngay_KT	
		and LOP_CHCID = CHUNG_CHI.CHC_ID 
		and CHC_Static = @iLoaiCc
group by CHUNG_CHI.CHC_Name,CHUNG_CHI.CHC_ID
END
--endregion

