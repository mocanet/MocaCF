
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing


Namespace Win

    ''' <summary>
    ''' ボタンの拡張コントロール
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ActionButton
        Inherits Button

        Private _flg As Boolean

#Region " コンストラクタ "

        ''' <summary>
        ''' デフォルトコンストラクタ
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.New()

            If UIHelper.DesignMode(Me) Then
                Return
            End If

            MultiLine()
        End Sub

#End Region

        ''' <summary>
        ''' Visible=false でも Click イベントを実行します。
        ''' </summary>
        Public Sub DoClick()
            Focus()
            OnClick(New EventArgs)
        End Sub

        Public Sub MultiLine()
            Dim pinvoke As New PInvoke
            pinvoke.SetButtonMultiline(Me)
        End Sub

        Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
            MyBase.OnGotFocus(e)
            _drawRect(Me, True)
        End Sub

        Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
            MyBase.OnLostFocus(e)
            _drawRect(Me, False)
        End Sub

        Private Sub _drawRect(ByVal control As Control, ByVal drawmode As Boolean)
            Dim graph As Graphics = Nothing
            Dim bkcolor As New Color()
            Dim parent As Control = control.Parent

            graph = parent.CreateGraphics()
            bkcolor = parent.BackColor

            Dim pen As Pen = Nothing
            If drawmode = True Then
                pen = New Pen(Color.FromArgb(0, 0, 255), 3)
                Dim rect As New Rectangle()
                If True Then
                    rect = New Rectangle(control.Location.X, control.Location.Y, control.Size.Width, Math.Min(control.Size.Height, (control.ClientSize.Height + 1)))
                End If
                graph.DrawRectangle(pen, rect)
                pen.Dispose()
            Else
                graph.Clear(bkcolor)
            End If
            graph.Dispose()
        End Sub

    End Class

End Namespace
