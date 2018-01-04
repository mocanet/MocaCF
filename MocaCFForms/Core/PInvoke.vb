
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class PInvoke

    Private Const SETSEL = &HB1

    Declare Function SendMessage Lib "coredll.dll" (ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As IntPtr

    Public Sub [Select](ByVal ctrl As Control, ByVal start As Integer, ByVal length As Integer)
        Dim ret As IntPtr
        ret = SendMessage(ctrl.Handle, SETSEL, start, length)
    End Sub

    Private Const BS_MULTILINE = &H2000
    Private Const GWL_STYLE = -16

    <DllImport("coredll.dll", SetLastError:=True)> _
    Private Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
    End Function
    <DllImport("coredll.dll", SetLastError:=True)> _
    Private Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="btn"></param>
    ''' <remarks>
    ''' 共通機能にしたかったが、P/Invoke 定義があるとフォームデザイナーが使えなくなるので仕方なくここでやる
    ''' </remarks>
    Public Sub SetButtonMultiline(ByVal btn As Button)
        Dim hwnd As IntPtr = btn.Handle
        Dim currentStyle As Integer = GetWindowLong(hwnd, GWL_STYLE)
        Dim newStyle As Integer = SetWindowLong(hwnd, GWL_STYLE, currentStyle Or BS_MULTILINE)
    End Sub


    <DllImport("coredll.dll")> _
    Private Shared Function ImmGetContext(ByVal hWnd As IntPtr) As IntPtr
    End Function

    <DllImport("coredll.dll")> _
    Private Shared Function ImmReleaseContext(ByVal hWnd As IntPtr) As Boolean
    End Function

    <DllImport("coredll.dll")> _
    Private Shared Function ImmSetConversionStatus(ByVal hIMC As IntPtr, ByVal fdwConversion As Int32, ByVal fdwSentence As Int32) As Boolean
    End Function

    <DllImport("coredll.dll")> _
    Private Shared Function ImmSetOpenStatus(ByVal hIMC As IntPtr, ByVal fOpen As Int32) As Boolean
    End Function

    <DllImport("coredll.dll")> _
    Private Shared Function ImmAssociateContext(ByVal hWnd As IntPtr, ByVal hIMC As IntPtr) As Int32
    End Function

    Public Enum ImeMode As Integer
        NOCONTROL = 0
        OFF = 1
        [ON] = 2
        DISABLE = 3
        HIRAGANA = 4
        KATAKANA = 5
        KATAKANAHALF = 6
        ALPHAFULL = 7
        ALPHA = 8
    End Enum

    Private Const ALPHANUMERIC = &H0    ' 半角英数
    Private Const NATIVE = &H1          ' 直接入力
    Private Const KATAKANA = &H2       ' カタカナ
    Private Const FULLSHAPE = &H8       ' 全角
    Private Const ROMAN = &H10          ' 

    Public Sub SetImeMode(ByVal ctrl As Control, ByVal mode As ImeMode)
        Dim himc As IntPtr = ImmGetContext(ctrl.Handle)

        Try
            Select Case mode
                Case ImeMode.DISABLE
                    ImmAssociateContext(himc, 0)
                    'ImmAssociateContext(ctrl.Handle, himc)

                Case ImeMode.OFF
                    ImmAssociateContext(himc, 1)
                    ImmSetOpenStatus(himc, 0)

                Case ImeMode.ON
                    ImmAssociateContext(himc, 1)
                    ImmSetOpenStatus(himc, 1)

                Case Else
                    ImmAssociateContext(himc, 1)
                    ImmSetOpenStatus(himc, 1)

                    Dim dwConversion As Int32 = 0

                    Select Case mode
                        Case ImeMode.HIRAGANA
                            dwConversion = NATIVE Or FULLSHAPE Or ROMAN
                        Case ImeMode.KATAKANA
                            dwConversion = NATIVE Or FULLSHAPE Or KATAKANA Or ROMAN
                        Case ImeMode.KATAKANAHALF
                            dwConversion = NATIVE Or KATAKANA Or ROMAN
                        Case ImeMode.ALPHAFULL
                            dwConversion = FULLSHAPE Or ALPHANUMERIC
                        Case ImeMode.ALPHA
                            dwConversion = ALPHANUMERIC
                    End Select
                    ImmSetConversionStatus(himc, dwConversion, 0)
            End Select
        Finally
            ImmReleaseContext(ctrl.Handle)
        End Try
    End Sub

End Class
