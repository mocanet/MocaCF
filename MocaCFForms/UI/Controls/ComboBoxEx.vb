
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Namespace Win

    ''' <summary>
    ''' ComboBox コントロール拡張
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ComboBoxEx
        Inherits ComboBox

#Region " Declare "

        Private Const CB_SHOWDROPDOWN As UInteger = 335

        Private Const [TRUE] As Integer = 1
        Private Const [FALSE] As Integer = 0

        <DllImport("Coredll.dll", EntryPoint:="SendMessage", SetLastError:=True)> _
        Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As UInteger, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
        End Function

        ''' <summary>フォームの処理にて実行する処理を変わりに実行する</summary>
        Private _action As IFormAction

#End Region

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

#End Region

#Region " Property "

        ''' <summary>
        ''' フォームの処理にて実行する処理を変わりに実行する
        ''' </summary>
        ''' <returns></returns>
        Protected ReadOnly Property Action() As IFormAction
            Get
                If _action Is Nothing Then
                    Dim frm As CoreForm = TryCast(UIHelper.FindForm(Me), CoreForm)
                    _action = frm.action
                End If
                Return _action
            End Get
        End Property

        ''' <summary>
        ''' フォームの処理にて実行する処理を変わりに実行するオブジェクト有無
        ''' </summary>
        ''' <returns></returns>
        Protected ReadOnly Property haveAction() As Boolean
            Get
                Return Not (Action Is Nothing)
            End Get
        End Property

#End Region

#Region " Overrides "

        ''' <summary>
        ''' キー押下
        ''' </summary>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or _
                e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
                SendMessage(Me.Handle, CB_SHOWDROPDOWN, [TRUE], 0)
            End If

            MyBase.OnKeyDown(e)
        End Sub

        Protected Overrides Sub OnSelectedValueChanged(ByVal e As System.EventArgs)
            If haveAction Then
                Action.ExecuteNoCursor(AddressOf MyBase.OnSelectedValueChanged, e)
            Else
                MyBase.OnSelectedValueChanged(e)
            End If
        End Sub

#End Region

    End Class

End Namespace
