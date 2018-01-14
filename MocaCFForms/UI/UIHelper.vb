Imports System.Windows.Forms
Imports System.Threading
Imports System.Drawing

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
        ''' <param name="message"></param>
        ''' <param name="msgargs"></param>
        ''' <param name="buttons"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ShowQuestionMessageBox(ByVal message As String, Optional ByVal msgargs() As String = Nothing, Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.YesNo, Optional ByVal defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button2) As DialogResult
            Dim msg As String = message
            If msgargs IsNot Nothing Then
                msg = String.Format(message, msgargs)
            End If

            'Return MessageBox.Show(msg, CoreSettings.Instance.Title, buttons, MessageBoxIcon.Question, defaultButton)
            Return MessageForm.Show(msg, CoreSettings.Instance.Title, MessageType.Question, buttons, defaultButton)
        End Function

        ''' <summary>
        ''' エラーメッセージボックス表示
        ''' </summary>
        ''' <param name="message"></param>
        ''' <param name="ex"></param>
        ''' <param name="buttons"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ShowErrorMessageBox(ByVal message As String, ByVal ex As Exception, Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.OK) As DialogResult
            Return ShowErrorMessageBox(message, New String() {ex.Message})
        End Function

        ''' <summary>
        ''' エラーメッセージボックス表示
        ''' </summary>
        ''' <param name="message"></param>
        ''' <param name="msgargs"></param>
        ''' <param name="buttons"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ShowErrorMessageBox(ByVal message As String, Optional ByVal msgargs() As String = Nothing, Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.OK) As DialogResult
            Dim msg As String = message
            If msgargs IsNot Nothing Then
                msg = String.Format(message, msgargs)
            End If

            Return MessageForm.Show(msg, My.Resources.Messages.S000, MessageType.Error, buttons, MessageBoxDefaultButton.Button1)
        End Function

        Public Shared Function ShowErrorMessageBox2(ByVal message As String, Optional ByVal msgargs() As String = Nothing, Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.OK) As DialogResult
            Dim msg As String = My.Resources.Messages.S000 & vbCrLf & vbCrLf & message
            If msgargs IsNot Nothing Then
                msg = String.Format(message, msgargs)
            End If

            Return MessageBox.Show(msg, CoreSettings.Instance.Title, buttons, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End Function

        ''' <summary>
        ''' 警告メッセージボックス表示
        ''' </summary>
        ''' <param name="message"></param>
        ''' <param name="msgargs"></param>
        ''' <param name="buttons"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ShowWarningMessageBox(ByVal message As String, Optional ByVal msgargs() As String = Nothing, Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.OK) As DialogResult
            Dim msg As String = message
            If msgargs IsNot Nothing Then
                msg = String.Format(message, msgargs)
            End If

            'Return MessageBox.Show(msg, CoreSettings.Instance.Title, buttons, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Return MessageForm.Show(msg, CoreSettings.Instance.Title, MessageType.Warning, buttons, MessageBoxDefaultButton.Button1)
        End Function

        Public Shared Function ShowInformationMessageBox(ByVal message As String, Optional ByVal msgargs() As String = Nothing, Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.OK) As DialogResult
            Dim msg As String = message
            If msgargs IsNot Nothing Then
                msg = String.Format(message, msgargs)
            End If

            'Return MessageBox.Show(msg, CoreSettings.Instance.Title, buttons, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Return MessageForm.Show(msg, CoreSettings.Instance.Title, MessageType.Information, buttons, MessageBoxDefaultButton.Button1)
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

        Public Shared Function FindForm(ByVal ctrl As Control) As Form
            If TypeOf ctrl Is Form Then
                Return ctrl
            End If

            Dim parent As Control
            parent = ctrl.Parent
            If parent Is Nothing Then
                Return Nothing
            End If
            Return FindForm(parent)
        End Function

        Public Shared Sub DrawString( _
                ByVal text As String, ByVal font As Font, _
                ByVal brush As SolidBrush, ByVal g As Graphics, _
                ByVal rec As Rectangle, ByVal align As TextAlignment)

            Dim strArray() As String
            strArray = text.Split(vbLf)

            Dim lineSize As SizeF = g.MeasureString(strArray(0), font)
            Dim lineRec As New Rectangle
            lineRec = rec
            lineRec.Height = lineSize.Height

            Dim format As New StringFormat
            Dim firstLineTop As Integer
            Select Case align
                Case TextAlignment.TopLeft
                    format.Alignment = StringAlignment.Near
                    firstLineTop = rec.Top

                Case TextAlignment.TopCenter
                    format.Alignment = StringAlignment.Center
                    firstLineTop = rec.Top

                Case TextAlignment.TopRight
                    format.Alignment = StringAlignment.Far
                    firstLineTop = rec.Top


                Case TextAlignment.MiddleLeft
                    format.Alignment = StringAlignment.Near
                    firstLineTop = (rec.Height / 2) - ((lineSize.Height * strArray.Length) / 2) + rec.Top

                Case TextAlignment.MiddleCenter
                    format.Alignment = StringAlignment.Center
                    firstLineTop = (rec.Height / 2) - ((lineSize.Height * strArray.Length) / 2) + rec.Top

                Case TextAlignment.MiddleRight
                    format.Alignment = StringAlignment.Far
                    firstLineTop = (rec.Height / 2) - ((lineSize.Height * strArray.Length) / 2) + rec.Top


                Case TextAlignment.BottomLeft
                    format.Alignment = StringAlignment.Near
                    firstLineTop = (rec.Height) - (lineSize.Height * (strArray.Length)) + rec.Top

                Case TextAlignment.BottomCenter
                    format.Alignment = StringAlignment.Center
                    firstLineTop = (rec.Height) - (lineSize.Height * (strArray.Length)) + rec.Top

                Case TextAlignment.BottomRight
                    format.Alignment = StringAlignment.Far
                    firstLineTop = (rec.Height) - (lineSize.Height * (strArray.Length)) + rec.Top

            End Select

            'format.LineAlignment = StringAlignment.Near
            format.LineAlignment = StringAlignment.Far

            For ii As Integer = 0 To strArray.Length - 1
                'lineRec.Location = New Point(lineRec.Left, (lineSize.Height * ii) + firstLineTop)
                lineRec.Y = firstLineTop
                'lineRec.Height = (lineSize.Height * ii) + firstLineTop
                lineRec.Height = lineSize.Height * (ii + 1)
                Debug.WriteLine(String.Format("{0},{1},{2},{3},{4},{5}", lineRec.X, lineRec.Y, lineRec.Width, lineRec.Height, lineRec.Right, lineRec.Bottom))
                g.DrawString(strArray(ii).Replace(vbCr, ""), font, brush, lineRec, format)
            Next
        End Sub

        Public Shared Sub DrawRectangle(ByVal g As Graphics, _
                                        ByVal borderWidth As Integer, _
                                        ByVal borderColor As Color, _
                                        ByVal clientRectangle As Rectangle)
            If borderWidth.Equals(0) Then
                Return
            End If

            Dim pen As New Pen(borderColor, borderWidth)

            g.DrawRectangle(pen, _
                             clientRectangle.X + borderWidth, _
                             clientRectangle.Y + borderWidth, _
                             clientRectangle.Width - borderWidth * 2, _
                             clientRectangle.Height - borderWidth * 2)
        End Sub

    End Class

End Namespace
