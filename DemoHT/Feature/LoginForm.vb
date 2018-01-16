Public Class LoginForm

    Private _isAuth As Boolean

    Private Sub ActionButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionButton1.Click
        _isAuth = True
        Close()
    End Sub

    Private Sub LoginForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If _isAuth Then
            Return
        End If

        Application.Exit()
    End Sub

    Public Sub New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        _isAuth = False
    End Sub
End Class
