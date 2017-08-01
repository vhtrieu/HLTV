USE [QLTV]
GO
/****** Object:  StoredProcedure [dbo].[CAPCHUNGCHI_ThongKeByIDAndDate]    Script Date: 9/8/2016 10:20:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[CAPCHUNGCHI_ThongKeByIDAndDate]
@CHC_ID int,
@DateFrom nvarchar(20),
@DateTo nvarchar(20)

AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

Select *
from vCapChungChi a
where 
a.CCC_CHCID =@CHC_ID
and 
a.CCC_NgayCap >= @DateFrom
AND
a.CCC_NgayCap <= @DateTo


--endregion

