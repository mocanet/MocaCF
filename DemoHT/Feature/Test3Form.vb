
Imports Moca.Win

Public Class Test3Form

    Private Sub Test3Form_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Startup
        StartFocusControl = ActionButton3
    End Sub

    Private Sub _test(ByVal sender As Object, ByVal e As ProgressWindowEventArgs)
        'e.Progress.Minimum = 0
        'e.Progress.Maximum = 5

        For index As Integer = 0 To 5
            'e.Progress.Value = index
            Threading.Thread.Sleep(1000)
        Next

    End Sub

    Private Sub ActionButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionButton1.Click
        action.ExecuteProgress(AddressOf _test, "テストです")
    End Sub

    Private Sub ActionButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionButton2.Click
        action.ExecuteProgressCanCancel(AddressOf _test, "テストです")
    End Sub

    Private Sub ActionButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionButton3.Click
        action.ExecuteSelectFile(AddressOf _selectedFile, "テストです", New String() {".csv"})
    End Sub

    Private Sub ActionButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionButton4.Click
        action.ExecuteSaveFile(AddressOf _selectedFile, "テストです", ".md")
    End Sub

    Private Sub _selectedFile(ByVal fileName As String)
        MLabel1.Text = fileName
    End Sub

End Class
