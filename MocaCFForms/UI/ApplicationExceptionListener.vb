Imports System.Windows.Forms

Namespace Win

    ''' <summary>
    ''' アプリケーションでキャッチしきれていない例外をキャッチした時に、
    ''' システム固有の処理を行うクラスを作成する為のインタフェース
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ApplicationExceptionListener
        Implements IApplicationExceptionListener

        ''' <summary>
        ''' アプリケーションでキャッチしきれていない例外が発生
        ''' </summary>
        ''' <param name="ex">対象の例外</param>
        ''' <remarks></remarks>
        Public Sub ApplicationException(ByVal ex As System.Exception) Implements IApplicationExceptionListener.ApplicationException
            Dim msg As String
            msg = My.Resources.Messages.E000
            msg &= vbCrLf
            msg &= vbCrLf
            msg &= ex.Message
            UIHelper.ShowErrorMessageBox(Nothing, My.Resources.Messages.E000, New String() {ex.Message})

            ' 強制終了
            Application.Exit()
        End Sub

    End Class

End Namespace
