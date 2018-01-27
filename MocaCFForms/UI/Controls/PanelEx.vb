
Imports System.Windows.Forms

Namespace Win

    ''' <summary>
    ''' Panel 拡張
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PanelEx
        Inherits Panel

        Private tabstops As IEnumerable(Of Control)

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)

            Dim ctrl As Control
            ctrl = UIHelper.GetFocusedControl(Me)
            If ctrl Is Nothing Then
                Return
            End If
            If Not TypeOf ctrl Is ActionButton Then
                Return
            End If
            Dim btn As ActionButton
            btn = ctrl
            btn.DrawRect(btn, True)
        End Sub

    End Class

End Namespace
