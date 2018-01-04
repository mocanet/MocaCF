
Imports System.Windows.Forms

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

#End Region

    End Class

End Namespace
