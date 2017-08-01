USE [QLTV]
GO

/****** Object:  View [dbo].[vHocVienDaCapGCN]    Script Date: 9/12/2016 11:06:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vHocVienDaCapGCN]
AS
SELECT        dbo.CHUNG_CHI.CHC_ID, dbo.CHUNG_CHI.CHC_Name, dbo.CHUNG_CHI.CHC_Static, dbo.LOP.LOP_ID, dbo.LOP.LOP_Khoa, dbo.LOP.LOP_ShortName, dbo.CAP_CHUNGCHI.CCC_ID, 
                         dbo.CAP_CHUNGCHI.CCC_HOVID, dbo.CAP_CHUNGCHI.CCC_SoCC, dbo.CAP_CHUNGCHI.CCC_Status, dbo.CAP_CHUNGCHI.CCC_NgayCap
FROM            dbo.CAP_CHUNGCHI LEFT OUTER JOIN
                         dbo.LOP ON dbo.CAP_CHUNGCHI.CCC_LOPID = dbo.LOP.LOP_ID LEFT OUTER JOIN
                         dbo.CHUNG_CHI ON dbo.CAP_CHUNGCHI.CCC_CHCID = dbo.CHUNG_CHI.CHC_ID

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Begin Table = "CAP_CHUNGCHI"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 225
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LOP"
            Begin Extent = 
               Top = 6
               Left = 263
               Bottom = 136
               Right = 439
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CHUNG_CHI"
            Begin Extent = 
               Top = 145
               Left = 407
               Bottom = 275
               Right = 596
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
      Begin ColumnWidths = 12
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vHocVienDaCapGCN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vHocVienDaCapGCN'
GO

