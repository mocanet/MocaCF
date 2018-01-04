Public Class MenuForm

    Private Sub ActionButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionButton1.Click
        ShowChildForm(GetType(TestForm))
    End Sub

End Class
