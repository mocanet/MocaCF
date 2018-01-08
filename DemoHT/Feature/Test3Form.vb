
Imports Moca.Win

Public Class Test3Form

    Private action As IFormAction

    Private Sub Test3Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StartFocusControl = ActionButton3
        action = New FormAction()
    End Sub

    Private Sub ActionButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionButton2.Click
        action.ExecuteProgress(AddressOf _test, "テストです", Nothing)
    End Sub

    Private Sub _test(ByVal sender As Object, ByVal e As ProgressWindowEventArgs)
        'e.Progress.Minimum = 0
        'e.Progress.Maximum = 5

        For index As Integer = 0 To 5
            'e.Progress.Value = index
            Threading.Thread.Sleep(1000)
        Next

    End Sub

End Class
