
Imports System.Windows.Forms
Imports System.ComponentModel

Namespace Win

    ''' <summary>
    ''' NumericUpDown コントロール拡張版
    ''' </summary>
    ''' <remarks></remarks>
    Public Class NumericUpDownEx
        Inherits NumericUpDown
        Implements ISupportInitialize

#Region " Implements ISupportInitialize "

        Public Sub BeginInit() Implements System.ComponentModel.ISupportInitialize.BeginInit
        End Sub

        Public Sub EndInit() Implements System.ComponentModel.ISupportInitialize.EndInit
        End Sub

#End Region

#Region " コンストラクタ "

        ''' <summary>
        ''' デフォルトコンストラクタ
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.New()

            ImeMode = PInvoke.ImeMode.OFF

            If UIHelper.DesignMode(Me) Then
                Return
            End If

        End Sub

#End Region

#Region " Property "

        Protected Property ImeMode() As PInvoke.ImeMode
            Get
                Return _ImeMode
            End Get
            Set(ByVal value As PInvoke.ImeMode)
                _ImeMode = value
            End Set
        End Property
        Private _ImeMode As PInvoke.ImeMode

#End Region

#Region " Overrides "

        Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
            Dim pinvoke As New PInvoke
            pinvoke.SetImeMode(Me, _ImeMode)
            pinvoke.Select(Me, 0, Me.Text.Length)

            MyBase.OnGotFocus(e)
        End Sub

#End Region

    End Class

End Namespace
