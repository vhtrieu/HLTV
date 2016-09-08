USE [QLTV]
GO

/****** Object:  View [dbo].[vDoiChungChi]    Script Date: 16-Jun-16 12:42:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vDoiChungChi]
AS
SELECT     dbo.DOI_CHUNGCHI.DOI_ID, dbo.DOI_CHUNGCHI.DOI_Code, dbo.DOI_CHUNGCHI.DOI_HOVID, dbo.DOI_CHUNGCHI.DOI_CHCID, dbo.DOI_CHUNGCHI.DOI_SoCC, 
                      dbo.DOI_CHUNGCHI.DOI_NgayCap, dbo.DOI_CHUNGCHI.DOI_Ngay_KG, dbo.DOI_CHUNGCHI.DOI_Ngay_KT, dbo.DOI_CHUNGCHI.DOI_Ngay_QD, 
                      dbo.vHocVienImage.HOV_ID, dbo.vHocVienImage.HOV_Code, dbo.vHocVienImage.HOV_FirstName, dbo.vHocVienImage.HOV_LastName, 
                      dbo.vHocVienImage.HOV_FullName, dbo.vHocVienImage.HOV_BirthDay, dbo.vHocVienImage.HOV_QuocTich, dbo.vHocVienImage.HOV_NoiSinh, 
                      dbo.vHocVienImage.HOV_Phone, dbo.vHocVienImage.HOV_Address, dbo.vHocVienImage.HOV_DonVi, dbo.vHocVienImage.HOV_ChucDanh, 
                      dbo.vHocVienImage.HOV_GhiChu, dbo.vHocVienImage.IMG_ID, dbo.vHocVienImage.IMG_HOVID, dbo.vHocVienImage.IMG_Name, dbo.vHocVienImage.IMG_Image, 
                      dbo.vHocVienImage.TIN_ID, dbo.vHocVienImage.TIN_Code, dbo.vHocVienImage.TIN_Name, dbo.CAP_CHUNGCHI.CCC_ID, dbo.CAP_CHUNGCHI.CCC_Code, 
                      dbo.CAP_CHUNGCHI.CCC_HOVID, dbo.CAP_CHUNGCHI.CCC_LOPID, dbo.CAP_CHUNGCHI.CCC_SoCC, dbo.CAP_CHUNGCHI.CCC_NgayCap, 
                      dbo.CAP_CHUNGCHI.CCC_NgayHetHan, dbo.CAP_CHUNGCHI.CCC_NgayCapLai, dbo.CAP_CHUNGCHI.CCC_CHCID, dbo.CAP_CHUNGCHI.CCC_Status, 
                      dbo.CAP_CHUNGCHI.CCC_SoHieuDoi, dbo.CAP_CHUNGCHI.CCC_DOIID
FROM         dbo.vHocVienImage INNER JOIN
                      dbo.DOI_CHUNGCHI ON dbo.vHocVienImage.HOV_ID = dbo.DOI_CHUNGCHI.DOI_HOVID LEFT OUTER JOIN
                      dbo.CAP_CHUNGCHI ON dbo.DOI_CHUNGCHI.DOI_ID = dbo.CAP_CHUNGCHI.CCC_DOIID
WHERE     (dbo.CAP_CHUNGCHI.CCC_DOIID = dbo.DOI_CHUNGCHI.DOI_ID)

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[32] 4[30] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "vHocVienImage"
            Begin Extent = 
               Top = 16
               Left = 569
               Bottom = 222
               Right = 734
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DOI_CHUNGCHI"
            Begin Extent = 
               Top = 8
               Left = 323
               Bottom = 218
               Right = 483
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CAP_CHUNGCHI"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 178
               Right = 215
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 42
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vDoiChungChi'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vDoiChungChi'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vDoiChungChi'
GO


