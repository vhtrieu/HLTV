USE [QLTV]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[vLoadDataCapChungChiByChungChiIDWithStatus]
@CCC_Status int,
@CHC_ID int,
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
a.CHC_ID = @CHC_ID
and 
a.CCC_Status = @CCC_Status
--endregion

