USE [QLTV]
GO

/****** Object:  View [dbo].[vHocVienImage]    Script Date: 16-Jun-16 12:41:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vHocVienImage]
AS
SELECT     dbo.HOCVIEN.*, dbo.HOCVIEN_IMG.*, dbo.TINH.*
FROM         dbo.TINH RIGHT OUTER JOIN
                      dbo.HOCVIEN ON dbo.TINH.TIN_ID = dbo.HOCVIEN.HOV_NoiSinh LEFT OUTER JOIN
                      dbo.HOCVIEN_IMG ON dbo.HOCVIEN.HOV_ID = dbo.HOCVIEN_IMG.IMG_HOVID LEFT OUTER JOIN
                      dbo.DONVI ON dbo.HOCVIEN.HOV_DonVi = dbo.DONVI.DON_ID

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[62] 4[9] 2[10] 3) )"
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
         Begin Table = "HOCVIEN_IMG"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 179
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "HOCVIEN"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 208
               Right = 401
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "DONVI"
            Begin Extent = 
               Top = 132
               Left = 513
               Bottom = 295
               Right = 669
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TINH"
            Begin Extent = 
               Top = 17
               Left = 499
               Bottom = 121
               Right = 659
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
      Begin ColumnWidths = 20
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
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 11' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vHocVienImage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'70
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vHocVienImage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vHocVienImage'
GO


