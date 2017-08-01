USE [QLTV]
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectCC_MONHOC_BycCID]    Script Date: 9/27/2016 9:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[getChungChiByNhomChungChi]
	@CHC_Static int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	CHC_ID, CHC_Name
FROM
	[dbo].[CHUNG_CHI]
WHERE
	[CHC_Static] = @CHC_Static

--endregion
