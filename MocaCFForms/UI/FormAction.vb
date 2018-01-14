Imports System.Windows.Forms

Namespace Win

    ''' <summary>
    ''' フォームの処理にて実行する処理を変わりに実行する
    ''' </summary>
    ''' <remarks></remarks>
    Public Class FormAction
        Implements IFormAction

#Region " Declare "

        Private _frm As CoreForm

#Region " Logging For Log4net "
        ''' <summary>Logging For Log4net</summary>
        Private Shared ReadOnly _mylog As Global.log4net.ILog = Global.log4net.LogManager.GetLogger(String.Empty)
#End Region
#End Region

#Region " Implements "

#Region " Property "

        Public Property Frm() As CoreForm Implements IFormAction.Frm
            Get
                Return _frm
            End Get
            Set(ByVal value As CoreForm)
                _frm = value
            End Set
        End Property

        Public ReadOnly Property OwnerForm() As CoreForm
            Get
                If TypeOf Frm Is ChildForm Then
                    Return DirectCast(Frm, ChildForm).OwnerForm
                End If
                'If Frm.ParentForm IsNot Nothing Then
                '    Return Frm.ParentForm
                'End If
                Return Frm
            End Get
        End Property

#End Region

#Region " Method "

#Region " カーソル変更あり "

        ''' <summary>
        ''' 引数無しのメソッド実行時
        ''' </summary>
        ''' <param name="cmd"></param>
        Private Sub Execute(ByVal cmd As FormActionExecuteCallback) Implements IFormAction.Execute
            Execute(cmd, False)
        End Sub

        ''' <summary>
        ''' 引数無しのメソッド実行時
        ''' </summary>
        ''' <param name="cmd"></param>
        ''' <param name="updateCheck"></param>
        Private Sub Execute(ByVal cmd As FormActionExecuteCallback, ByVal updateCheck As Boolean) Implements IFormAction.Execute
            Execute(cmd, updateCheck, Nothing)
        End Sub

        ''' <summary>
        ''' 引数無しのメソッド実行時
        ''' </summary>
        ''' <param name="cmd"></param>
        ''' <param name="updateCheck"></param>
        ''' <param name="caption"></param>
        ''' <remarks></remarks>
        Private Sub Execute(ByVal cmd As FormActionExecuteCallback, ByVal updateCheck As Boolean, ByVal caption As String) Implements IFormAction.Execute
            Try
                If updateCheck Then
                    ' 編集あり？
                    If Frm.IsUpdate Then
                        ' 確認
                        caption = IIf(String.IsNullOrEmpty(caption), "検索", caption)
                        If UIHelper.ShowQuestionMessageBox(My.Resources.Messages.Q003, New String() {caption}) = DialogResult.No Then
                            Return
                        End If
                    End If
                End If

                Cursor.Current = Cursors.WaitCursor
                SuspendLayout()

                cmd()
            Catch ex As Exception
                UIHelper.ShowErrorMessageBox(My.Resources.Messages.E000, ex)
                _mylog.Error(ex)
            Finally
                ResumeLayout()
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        ''' <summary>
        ''' 通常のイベントの引数を使用したメソッド実行
        ''' </summary>
        ''' <param name="cmd"></param>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub Execute(ByVal cmd As FormActionEventCallback, ByVal sender As Object, ByVal e As EventArgs) Implements IFormAction.Execute
            Try
                Cursor.Current = Cursors.WaitCursor
                SuspendLayout()

                cmd(sender, e)
            Catch ex As Exception
                UIHelper.ShowErrorMessageBox(My.Resources.Messages.E000, ex)
                _mylog.Error(ex)
            Finally
                ResumeLayout()
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub Execute(ByVal cmd As FormActionEventCallback, ByVal sender As Object, ByVal e As EventArgs, ByVal updateCheck As Boolean) Implements IFormAction.Execute
            Execute(cmd, sender, e, updateCheck, Nothing)
        End Sub

        Private Sub Execute(ByVal cmd As FormActionEventCallback, ByVal sender As Object, ByVal e As EventArgs, ByVal updateCheck As Boolean, ByVal caption As String) Implements IFormAction.Execute
            Try
                If updateCheck Then
                    ' 編集あり？
                    If Frm.IsUpdate Then
                        ' 確認
                        caption = IIf(String.IsNullOrEmpty(caption), "検索", caption)
                        If UIHelper.ShowQuestionMessageBox(My.Resources.Messages.Q003, New String() {caption}) = DialogResult.No Then
                            Return
                        End If
                    End If
                End If

                Cursor.Current = Cursors.WaitCursor
                SuspendLayout()

                cmd(sender, e)
            Catch ex As Exception
                UIHelper.ShowErrorMessageBox(My.Resources.Messages.E000, ex)
                _mylog.Error(ex)
            Finally
                ResumeLayout()
                Cursor.Current = Cursors.Default
            End Try
        End Sub

#End Region
#Region " カーソル変更なし "

        ''' <summary>
        ''' 通常のイベントの引数を使用したメソッド実行
        ''' </summary>
        ''' <param name="cmd"></param>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Sub ExecuteNoCursor(ByVal cmd As FormActionEventCallback, ByVal sender As Object, ByVal e As System.EventArgs) Implements IFormAction.ExecuteNoCursor
            Try
                SuspendLayout()

                cmd(sender, e)
            Catch ex As Exception
                UIHelper.ShowErrorMessageBox(My.Resources.Messages.E000, ex)
                _mylog.Error(ex)
            Finally
                ResumeLayout()
            End Try
        End Sub

        ''' <summary>
        ''' 引数無しのメソッド実行時
        ''' </summary>
        ''' <param name="cmd"></param>
        ''' <remarks></remarks>
        Public Sub ExecuteNoCursor(ByVal cmd As FormActionExecuteCallback) Implements IFormAction.ExecuteNoCursor
            Try
                SuspendLayout()

                cmd()
            Catch ex As Exception
                UIHelper.ShowErrorMessageBox(My.Resources.Messages.E000, ex)
                _mylog.Error(ex)
            Finally
                ResumeLayout()
            End Try
        End Sub

#End Region
#Region " 進捗状況画面表示 "

        ''' <summary>
        ''' 進捗状況画面表示
        ''' </summary>
        ''' <param name="handler"></param>
        ''' <param name="message"></param>
        ''' <param name="args"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function ExecuteProgress(ByVal handler As System.EventHandler(Of ProgressWindowEventArgs), ByVal message As String, ByVal ParamArray args() As Object) As Object Implements IFormAction.ExecuteProgress
            Dim rc As Object = Nothing
            Try
                ResumeLayout()

                Cursor.Current = Cursors.WaitCursor
                rc = ProgressWindow.Show(_frm, handler, message, False, args)
            Catch ex As Exception
                UIHelper.ShowErrorMessageBox(My.Resources.Messages.E000, ex)
                _mylog.Error(ex)
            Finally
                Cursor.Current = Cursors.Default
            End Try
            Return rc
        End Function

        '''<summary>
        '''進捗状況画面表示（コールバックあり）
        '''</summary>
        '''<param name="handler">処理のメソッド</param>
        '''<param name="message">処理中に表示するメッセージ</param>
        '''<param name="condition"></param>
        '''<param name="successCallback"></param>
        '''<param name="errorCallback"></param>
        '''<param name="args">処理のメソッドへ引数として渡したい値</param>
        '''<returns></returns>
        Public Overloads Function ExecuteProgress(ByVal handler As EventHandler(Of ProgressWindowEventArgs), ByVal message As String, ByVal condition As Func(Of Object(), Boolean), ByVal successCallback As ProgressWindow.OwnerMethodInvoker, ByVal errorCallback As ProgressWindow.OwnerMethodInvoker, ByVal ParamArray args() As Object) As Object Implements IFormAction.ExecuteProgress
            Dim rc As Object = Nothing
            Try
                If condition Is Nothing Then
                    Throw New ArgumentNullException("condition パラメーターは必ず指定してください")
                End If
                If successCallback Is Nothing Then
                    Throw New ArgumentNullException("successCallback パラメーターは必ず指定してください")
                End If
                If errorCallback Is Nothing Then
                    Throw New ArgumentNullException("errorCallback パラメーターは必ず指定してください")
                End If

                ResumeLayout()

                Cursor.Current = Cursors.WaitCursor
                rc = ProgressWindow.Show(_frm, handler, message, False, condition, successCallback, errorCallback, args)
            Catch ex As Exception
                UIHelper.ShowErrorMessageBox(My.Resources.Messages.E000, ex)
                _mylog.Error(ex)
            Finally
                Cursor.Current = Cursors.Default
            End Try
            Return rc
        End Function

        Public Function ExecuteProgressCanCancel(ByVal handler As EventHandler(Of ProgressWindowEventArgs), ByVal message As String, ByVal ParamArray args() As Object) As Object Implements IFormAction.ExecuteProgressCanCancel
            Dim rc As Object = Nothing
            Try
                ResumeLayout()

                Cursor.Current = Cursors.WaitCursor
                rc = ProgressWindow.Show(_frm, handler, message, True, args)
            Catch ex As Exception
                UIHelper.ShowErrorMessageBox(My.Resources.Messages.E000, ex)
                _mylog.Error(ex)
            Finally
                Cursor.Current = Cursors.Default
            End Try
            Return rc
        End Function

        Public Function ExecuteProgressCanCancel(ByVal handler As EventHandler(Of ProgressWindowEventArgs), ByVal message As String, ByVal condition As Func(Of Object(), Boolean), ByVal successCallback As ProgressWindow.OwnerMethodInvoker, ByVal errorCallback As ProgressWindow.OwnerMethodInvoker, ByVal ParamArray args() As Object) As Object Implements IFormAction.ExecuteProgressCanCancel
            Throw New NotImplementedException()
        End Function

#End Region
#Region " ファイル選択画面表示 "

        ''' <summary>
        ''' 引数無しのメソッド実行時(ファイル選択あり)
        ''' </summary>
        ''' <param name="cmd"></param>
        Public Sub ExecuteSelectFile(ByVal cmd As FormActionFileSelectExecuteCallback, ByVal applicationName As String, ByVal extension() As String) Implements IFormAction.ExecuteSelectFile
            Try
                Cursor.Current = Cursors.Default
                ResumeLayout()

                Dim filename As String
                ' ファイル選択
                filename = _importFileSelect(applicationName, extension)
                If String.IsNullOrEmpty(filename) Then
                    Return
                End If

                Cursor.Current = Cursors.WaitCursor
                SuspendLayout()

                cmd(filename)
            Catch ex As Exception
                UIHelper.ShowErrorMessageBox(My.Resources.Messages.E000, ex)
                _mylog.Error(ex)
            Finally
                ResumeLayout()
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        ''' <summary>
        ''' 引数無しのメソッド実行時(ファイル選択あり)
        ''' </summary>
        ''' <param name="cmd"></param>
        ''' <param name="applicationName"></param>
        ''' <param name="extension"></param>
        Private Sub ExecuteSaveFile(ByVal cmd As FormActionFileSelectExecuteCallback, ByVal applicationName As String, ByVal extension As String) Implements IFormAction.ExecuteSaveFile
            ExecuteSaveFile(cmd, applicationName, extension, Nothing)
        End Sub

        ''' <summary>
        ''' 引数無しのメソッド実行時(ファイル選択あり)
        ''' </summary>
        ''' <param name="cmd"></param>
        ''' <param name="applicationName"></param>
        ''' <param name="extension"></param>
        ''' <param name="defaultFileName"></param>
        Private Sub ExecuteSaveFile(ByVal cmd As FormActionFileSelectExecuteCallback, ByVal applicationName As String, ByVal extension As String, ByVal defaultFileName As String) Implements IFormAction.ExecuteSaveFile
            Try
                Cursor.Current = Cursors.Default
                ResumeLayout()

                Dim filename As String
                ' ファイル選択
                filename = _saveFileSelect(defaultFileName, applicationName, extension)
                If String.IsNullOrEmpty(filename) Then
                    Return
                End If

                Cursor.Current = Cursors.WaitCursor
                SuspendLayout()

                cmd(filename)
            Catch ex As Exception
                UIHelper.ShowErrorMessageBox(My.Resources.Messages.E000, ex)
                _mylog.Error(ex)
            Finally
                ResumeLayout()
                Cursor.Current = Cursors.Default
            End Try
        End Sub

#End Region
#Region " Etc "

        Public Sub SuspendLayout() Implements IFormAction.SuspendLayout
        End Sub

        Public Sub ResumeLayout() Implements IFormAction.ResumeLayout
        End Sub

#End Region

#End Region

#End Region

#Region " Method "

        ''' <summary>
        ''' インポートファイル選択
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function _importFileSelect(ByVal applicationName As String, ByVal extension() As String) As String
            Using dlg As New OpenFileDialog()
                dlg.FileName = String.Empty
                dlg.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                If String.IsNullOrEmpty(applicationName) AndAlso _
                    (extension Is Nothing OrElse extension.Count.Equals(0)) Then
                    dlg.Filter = "All File(*.*)|*.*"
                Else
                    Dim nm1 As String = String.Join(", *.", extension)
                    Dim nm2 As String = String.Join(";*.", extension)
                    dlg.Filter = String.Format("{0} ファイル(*.{1})|*.{2}|All File(*.*)|*.*", applicationName, nm1, nm2)
                End If
                dlg.FilterIndex = 1

                'ダイアログを表示する
                If dlg.ShowDialog() <> DialogResult.OK Then
                    Return Nothing
                End If
                Return dlg.FileName
            End Using
        End Function

        ''' <summary>
        ''' 保存先ファイル名指定
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function _saveFileSelect(ByVal defaultFilename As String, ByVal applicationName As String, ByVal extension As String) As String
            Using dlg As New SaveFileDialog()
                If String.IsNullOrEmpty(extension) Then
                    dlg.FileName = String.Format("{0}", defaultFilename)
                    extension = "*"
                Else
                    dlg.FileName = String.Format("{0}.{1}", defaultFilename, extension)
                End If
                dlg.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                dlg.Filter = String.Format("{0} ファイル(*.{1})|*.{1}", applicationName, extension)
                dlg.FilterIndex = 1

                'ダイアログを表示する
                If dlg.ShowDialog() <> DialogResult.OK Then
                    Return Nothing
                End If
                Return dlg.FileName
            End Using
        End Function

#End Region

    End Class

End Namespace
