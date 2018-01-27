Public Class TestForm

#Region " log4net "
    ''' <summary>log4net logger</summary>
    Private ReadOnly _mylog As log4net.ILog = log4net.LogManager.GetLogger(String.Empty)
#End Region

    Private Sub TestForm_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Startup
        _mylog.Error("TestForm Load")

        Dim lst As New List(Of String)
        lst.Add("test 1")
        lst.Add("test 2")
        lst.Add("test 3")

        ComboBoxEx1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxEx1.DataSource = lst

        StartFocusControl = ActionButton1
    End Sub

    Private Sub ActionButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionButton1.Click
        Throw New Exception("例外発生の" & vbCrLf & "テストです。")
    End Sub

    Private Sub ActionButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionButton2.Click
        ShowChildForm(GetType(ProcessListForm))
    End Sub

End Class
