Public Class DemoHTForm

    Private _menuForm As MenuForm = New MenuForm

    Private Sub DemoHTForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AlertMessage31.FullClickClose = True
        AlertMessage31.AutoCloseSecond = 4
        AlertMessage31.Warn("テスト！")
    End Sub

    Private Sub ActionButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AlertMessage31.Success("テスト！")
    End Sub

    Protected Overrides ReadOnly Property DefaultChildForm() As Moca.Win.ChildForm
        Get
            Return _menuForm
        End Get
    End Property

End Class
