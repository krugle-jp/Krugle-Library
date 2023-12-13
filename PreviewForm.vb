' Copyright 2020 FUJITSU Limited 
' ****************************************************************************************************
' システム名     ：  [新ＭＪＰＣリビルド]
' プログラムID   ：  [QC301R01]
' プログラム名   ：  [見積書_鑑_物販]
' 新規作成       ：  [BFS)李振]
' 新規作成日     ：  [2020/08/06]
' ****************************************************************************************************
' 改版履歴
' ****************************************************************************************************
' バージョン             名前                    日付
' (変更内容)
' (1)V1.0.0              BFS)李振                2020/08/06
' 新規作成
' ****************************************************************************************************

Imports Jp.Co.OtsukaShokai.MJPC.Common.Base.Util

Namespace Client.Base.Estimate
    ''' <summary>
    ''' 帳票プレビュー画面
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PreviewForm

        ''' <summary>
        ''' プレビューロード
        ''' プレビューから保存する際のﾃﾞﾌｫﾙﾄﾊﾟｽをデスクトップパスに設定
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub frmPreview_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            ClientLogUtil.Logger.DebugAP("PreviewForm:frmPreview_Load start")

            '(2)Nullでない場合、保存するファイル名を設定
            If Me.ViewerControl1.SaveFileName = vbNullString Then
                Me.ViewerControl1.SaveFileName = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) & "\"
            End If

            ' (3)Windowを最大化する
            Me.WindowState = FormWindowState.Maximized
            Me.ViewerControl1.ViewZoom = 97

            Me.BringToFront()
            '▼#12706 のプレビュー対応 ADD ST
            Me.TopMost = True
            Me.TopMost = False
            '▲#12706 のプレビュー対応 ADD ED

            ClientLogUtil.Logger.DebugAP("PreviewForm:frmPreview_Load end")
        End Sub

        ''' <summary>
        ''' 画面閉じるボタン押下時処理　
        ''' ※Escキー押下時にも実行されます。ボタン自体は見えないようになってます。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub CmdExit_Click(sender As Object, e As System.EventArgs) Handles CmdExit.Click
            Me.Close()
        End Sub

        ''' <summary>
        ''' キー入力処理
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub ViewerControl1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown, ViewerControl1.KeyDown

            '(1)System.Windows.Forms.KeyEventArgsで補足できないものなら空をリターンする
            If Not e.Control Then Return

            '(2)入力値がPageDownまたは、PageUPの場合処理を行う
            Select Case e.KeyCode

            '(2-1)入力値がPageDownの場合
                Case Keys.PageDown
                    ViewNext()

            '(2-2)入力値がPageUpの場合
                Case Keys.PageUp
                    ViewBack()
            End Select
        End Sub

        ''' <summary>
        ''' 次へ処理
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ViewNext()
            '現在の頁よりも頁数のほうが大きい場合、頁数を1つ進める
            If Me.ViewerControl1.ViewPage < Me.ViewerControl1.PageCount Then
                Me.ViewerControl1.ViewPage += 1
            End If

        End Sub

        ''' <summary>
        ''' 次へ処理
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ViewBack()
            '頁数が1より大きい場合、頁数を1つ戻す
            If Me.ViewerControl1.ViewPage > 1 Then
                Me.ViewerControl1.ViewPage -= 1
            End If
        End Sub

    End Class
End Namespace
