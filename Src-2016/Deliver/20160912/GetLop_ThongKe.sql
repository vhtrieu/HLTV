USE [QLTV]
GO
/****** Object:  StoredProcedure [dbo].[GetLop_ThongKe]    Script Date: 9/19/2016 8:21:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectCAP_CHUNGCHI]


ALTER PROCEDURE [dbo].[GetLop_ThongKe]
	@CHC_ID int,
	@LOP_Ngay_KG date,
	@LOP_Ngay_KT date

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;



--SET NOCOUNT ON
--SET TRANSACTION ISOLATION LEVEL READ COMMITTED


select LOP.LOP_ID,LOP.LOP_Name, LOP.LOP_Khoa,LOP.LOP_ShortName
from LOP	
where lop.LOP_CHCID = @CHC_ID
		and
		LOP.LOP_Ngay_KG>= @LOP_Ngay_KG
		and 	
		LOP.LOP_Ngay_KT <= @LOP_Ngay_KT	
		
END
--endregion

