
Imports System.Drawing

Namespace Win

    ''' <summary>
    ''' モデルとコントロールのバインダーインタフェース
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface IControlBinder

        ''' <summary>
        ''' 必須項目時の背景色
        ''' </summary>
        ''' <returns></returns>
        Property RequiredBackColor() As Color

    End Interface

End Namespace
