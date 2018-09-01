Sub COQC宏()
'
' COQC宏 宏
' coqc Excel格式处理
'

'
    For Each wk In Workbooks
        If Left(wk.Name, 5) = "COQC_" Then
            For Each sh In wk.Sheets
            '操作sheet
                '去除保护
                sh.Unprotect
                '分页重置
                sh.ResetAllPageBreaks
                '每隔70rows分页
                For i = 71 To sh.UsedRange.Rows.Count Step 70 ' [Step 60]的意思就是70行就执行一次分页
                    sh.HPageBreaks.Add Before:=Cells(i, 1)
                Next
                '设置页眉
                sh.PageSetup.LeftHeader = "Page &P of &N"
                sh.PageSetup.RightHeader = "&D"
                '设置页边距
                sh.PageSetup.LeftMargin = Application.InchesToPoints(0.708661417322835)
                sh.PageSetup.RightMargin = Application.InchesToPoints(0.708661417322835)
                sh.PageSetup.TopMargin = Application.InchesToPoints(0.748031496062992)
                sh.PageSetup.BottomMargin = Application.InchesToPoints(0.748031496062992)
                sh.PageSetup.HeaderMargin = Application.InchesToPoints(0.31496062992126)
                sh.PageSetup.FooterMargin = Application.InchesToPoints(0.31496062992126)
                '打印设置
                'sh.PageSetup.AlignMarginsHeaderFooter = False
                '打印区域设置
                'sh.PageSetup.PrintArea = "$A$1:$I$sh.UsedRange.Rows.Count"
                '去除网格线
                sh.PageSetup.PrintHeadings = False
                sh.PageSetup.PrintGridlines = False
                sh.PageSetup.PrintComments = xlPrintNoComments
                sh.PageSetup.CenterHorizontally = False
                sh.PageSetup.CenterVertically = False
                sh.PageSetup.Orientation = xlPortrait
                sh.PageSetup.Draft = False
                sh.PageSetup.PaperSize = xlPaperA4
                sh.PageSetup.FirstPageNumber = xlAutomatic
                sh.PageSetup.BlackAndWhite = False
                sh.PageSetup.Zoom = 90
                sh.PageSetup.PrintErrors = xlPrintErrorsDisplayed
                sh.PageSetup.OddAndEvenPagesHeaderFooter = False
                sh.PageSetup.DifferentFirstPageHeaderFooter = False
                sh.PageSetup.ScaleWithDocHeaderFooter = True
                sh.PageSetup.AlignMarginsHeaderFooter = True
                sh.PageSetup.PrintQuality = 600
            Next
            MsgBox (wk.Name + "  reformat successfully !")
        End If
    Next
    
End Sub
