USE [QLTV]
GO
/****** Object:  StoredProcedure [dbo].[vLoadDataCapChungChiByDate]    Script Date: 9/6/2016 9:40:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[vLoadDataCapChungChiByDateWithStatus]
@CCC_Status int,
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

and
a.CCC_Status = @CCC_Status
--endregion

