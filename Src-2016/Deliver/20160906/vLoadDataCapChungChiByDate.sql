USE [QLTV]
GO
/****** Object:  StoredProcedure [dbo].[vLoadDataCapChungChiByDate]    Script Date: 9/6/2016 6:57:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[vLoadDataCapChungChiByDate]

@DateFrom nvarchar(20),
@DateTo nvarchar(20)

AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

Select *
from vCapChungChi a
where 

a.CCC_NgayCap >= @DateFrom
AND
a.CCC_NgayCap <= @DateTo


--endregion

