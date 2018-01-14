
Namespace Win

    ''' <summary>
    ''' アクション処理の検証イベント引数
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ActionValidatingEventArgs
        Inherits EventArgs

        Private _IsValid As Boolean

        ''' <summary>
        ''' デフォルトコンストラクタ
        ''' </summary>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' 検証結果
        ''' </summary>
        ''' <returns></returns>
        Public Property IsValid() As Boolean
            Get
                Return _IsValid
            End Get
            Set(ByVal value As Boolean)
                _IsValid = value
            End Set
        End Property

    End Class

End Namespace
