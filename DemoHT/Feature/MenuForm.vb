Public Class MenuForm

    Private Sub MenuForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StartFocusControl = ActionButton2
    End Sub

    Private Sub ActionButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionButton1.Click
        ShowChildForm(GetType(TestForm))
    End Sub

    Private Sub ActionButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionButton2.Click
        ShowChildForm(GetType(Test2Form))
    End Sub

    Private Sub ActionButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionButton3.Click
        ShowChildForm(GetType(Test3Form))
    End Sub

End Class
