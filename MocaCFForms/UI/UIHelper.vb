Imports System.Windows.Forms
Imports System.Threading

Namespace Win

    ''' <summary>
    ''' ウィンドウ操作系メソッド集
    ''' </summary>
    ''' <remarks></remarks>
    Public Class UIHelper

#Region " MessageBox "

        ''' <summary>
        ''' 質問メッセージボックス表示
        ''' </summary>
        ''' <param name="owner"></param>
        ''' <param name="message"></param>
        ''' <param name="msgargs"></param>
        ''' <param name="buttons"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ShowQuestionMessageBox(ByVal owner As Form, ByVal message As String, Optional ByVal msgargs() As String = Nothing, Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.YesNo, Optional ByVal defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button2) As DialogResult
            Dim msg As String = message
            If msgargs IsNot Nothing Then
                msg = String.Format(message, msgargs)
            End If

            Return MessageBox.Show(msg, CoreSettings.Instance.Title, buttons, MessageBoxIcon.Question, defaultButton)
        End Function

        Public Shared Function ShowErrorMessageBox(ByVal owner As Form, ByVal message As String, ByVal ex As Exception) As DialogResult
            Return ShowErrorMessageBox(owner, message, New String() {ex.Message})
        End Function

        ''' <summary>
        ''' エラーメッセージボックス表示
        ''' </summary>
        ''' <param name="owner"></param>
        ''' <param name="message"></param>
        ''' <param name="msgargs"></param>
        ''' <param name="buttons"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ShowErrorMessageBox(ByVal owner As Form, ByVal message As String, Optional ByVal msgargs() As String = Nothing, Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.OK) As DialogResult
            Dim msg As String = message
            If msgargs IsNot Nothing Then
                msg = String.Format(message, msgargs)
            End If

            Return MessageBox.Show(msg, CoreSettings.Instance.Title, buttons, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End Function

        ''' <summary>
        ''' 警告メッセージボックス表示
        ''' </summary>
        ''' <param name="owner"></param>
        ''' <param name="message"></param>
        ''' <param name="msgargs"></param>
        ''' <param name="buttons"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ShowWarningMessageBox(ByVal owner As Form, ByVal message As String, Optional ByVal msgargs() As String = Nothing, Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.OK) As DialogResult
            Dim msg As String = message
            If msgargs IsNot Nothing Then
                msg = String.Format(message, msgargs)
            End If

            Return MessageBox.Show(msg, CoreSettings.Instance.Title, buttons, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End Function

#End Region
#Region " ExceptionListener "

        ''' <summary>アプリケーションでキャッチしきれていない例外をキャッチした時のリスナー</summary>
        Protected Shared appExceptionListener As IApplicationExceptionListener

        Public Shared Sub ApplicationExceptionHandler(ByVal listener As IApplicationExceptionListener)
            appExceptionListener = listener

            '' ThreadExceptionイベント・ハンドラを登録する
            'AddHandler Application.ThreadException, AddressOf Application_ThreadException
            ' UnhandledExceptionイベント・ハンドラを登録する
            AddHandler Thread.GetDomain().UnhandledException, AddressOf Application_UnhandledException
        End Sub

        'Protected Shared Sub Application_ThreadException(ByVal sender As Object, ByVal e As ThreadExceptionEventArgs)
        '    appExceptionListener.ApplicationException(e.Exception)
        'End Sub

        Protected Shared Sub Application_UnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
            Dim ex As Exception = CType(e.ExceptionObject, Exception)
            If ex Is Nothing Then
                Exit Sub
            End If

            appExceptionListener.ApplicationException(ex)
        End Sub

#End Region
#Region " DesignMode "

        ''' <summary>
        ''' コントロールがデザインモード中かどうか
        ''' </summary>
        ''' <param name="ctrl"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function DesignMode(ByVal ctrl As Control) As Boolean
            If ctrl.Site IsNot Nothing AndAlso ctrl.Site.DesignMode Then
                Return True
            End If
            Return AppDomain.CurrentDomain.FriendlyName.Contains("DefaultDomain")
        End Function

#End Region
#Region " SetComboBox "

        ''' <summary>
        ''' コンボボックスを構築する
        ''' </summary>
        ''' <param name="cbo">対象のコンボボックス</param>
        ''' <param name="dataSource">データソース</param>
        ''' <param name="displayMember">リストに表示する列名</param>
        ''' <param name="valueMember">値にする列名</param>
        ''' <param name="selectedIndex">デフォルトのSelectedIndex</param>
        ''' <remarks>
        ''' </remarks>
        Public Shared Sub SetComboBox(ByVal cbo As ComboBox, ByVal dataSource As Object, ByVal displayMember As String, ByVal valueMember As String, Optional ByVal selectedIndex As Integer = -1)
            cbo.BeginUpdate()
            cbo.DisplayMember = displayMember
            cbo.ValueMember = valueMember
            cbo.DataSource = dataSource
            If cbo.DropDownStyle <> ComboBoxStyle.DropDownList Then
                cbo.SelectedIndex = selectedIndex
            End If
            cbo.EndUpdate()
        End Sub

#End Region

    End Class

End Namespace
