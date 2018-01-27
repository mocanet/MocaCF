Imports Moca.Win

Public Class ProcessListForm

    Public Sub New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        If UIHelper.DesignMode(Me) Then
            Return
        End If

        ListBox1.DataSource = Moca.Process.GetProcesses()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        ListBox1.DataSource = Moca.Process.GetProcesses()
    End Sub

    Private Sub btnKill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKill.Click
        Dim proc As Moca.Process = CType(ListBox1.SelectedItem, Moca.Process)
        proc.Kill()
        ListBox1.DataSource = Nothing
        ListBox1.DataSource = Moca.Process.GetProcesses()
    End Sub

End Class
