Imports System.Windows.Forms

Namespace Win

    ''' <summary>
    ''' アプリケーションでキャッチしきれていない例外をキャッチした時に、
    ''' システム固有の処理を行うクラスを作成する為のインタフェース
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ApplicationExceptionListener
        Implements IApplicationExceptionListener

#Region " log4net "
        ''' <summary>log4net logger</summary>
        Private ReadOnly _mylog As Global.log4net.ILog = Global.log4net.LogManager.GetLogger(GetType(ApplicationExceptionListener))
#End Region

        ''' <summary>
        ''' アプリケーションでキャッチしきれていない例外が発生
        ''' </summary>
        ''' <param name="ex">対象の例外</param>
        ''' <remarks></remarks>
        Public Sub ApplicationException(ByVal ex As System.Exception) Implements IApplicationExceptionListener.ApplicationException
            UIHelper.ShowErrorMessageBox(My.Resources.Messages.E000, New String() {ex.Message})

            _mylog.Error(ex)

            ' 強制終了
            Application.Exit()
        End Sub

    End Class

End Namespace
