
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Namespace Win

    ''' <summary>
    ''' ComboBox コントロール拡張
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ComboBoxEx
        Inherits ComboBox

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
        End Sub


        Private Const CB_SHOWDROPDOWN As UInteger = 335

        Private Const [TRUE] As Integer = 1
        Private Const [FALSE] As Integer = 0

        <DllImport("Coredll.dll", EntryPoint:="SendMessage", SetLastError:=True)> _
        Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As UInteger, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
        End Function


#End Region

        Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
            MyBase.OnGotFocus(e)

            SendMessage(Me.Handle, CB_SHOWDROPDOWN, [TRUE], 0)
        End Sub

    End Class

End Namespace
