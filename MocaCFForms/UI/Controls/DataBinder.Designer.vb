
Namespace Win

    Partial Public Class DataBinder
        Inherits System.ComponentModel.Component

        <System.Diagnostics.DebuggerNonUserCode()> _
        Public Sub New(ByVal Container As System.ComponentModel.IContainer)
            MyClass.New()

            'Windows.Forms クラス作成デザイナのサポートに必要です。
            Container.Add(Me)

        End Sub

        <System.Diagnostics.DebuggerNonUserCode()> _
        Public Sub New()
            MyBase.New()

            'この呼び出しは、コンポーネント デザイナで必要です。
            InitializeComponent()

        End Sub

        'Component は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()

                _bindSrc.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'コンポーネント デザイナで必要です。
        Private components As System.ComponentModel.IContainer

        'メモ: 以下のプロシージャはコンポーネント デザイナで必要です。
        'コンポーネント デザイナを使って変更できます。
        'コード エディタを使って変更しないでください。
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()
        End Sub

    End Class

End Namespace
