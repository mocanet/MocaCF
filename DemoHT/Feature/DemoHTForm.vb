Public Class DemoHTForm

    Private _menuForm As MenuForm = New MenuForm

#Region " log4net "
    ''' <summary>log4net logger</summary>
    Private ReadOnly _mylog As log4net.ILog = log4net.LogManager.GetLogger(GetType(DemoHTForm))
#End Region

    Private Sub DemoHTForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _mylog.Info("start !!")

        AlertMessage1.Warn("テスト！")
    End Sub

    Private Sub ActionButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AlertMessage1.Success("テスト！")
    End Sub

    Protected Overrides ReadOnly Property DefaultChildForm() As Moca.Win.ChildForm
        Get
            Return _menuForm
        End Get
    End Property

End Class
