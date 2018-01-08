<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Test2Form
    Inherits Moca.Win.ChildForm

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBoxEx1 = New Moca.Win.TextBoxEx
        Me.TextBoxEx2 = New Moca.Win.TextBoxEx
        Me.TextBoxEx3 = New Moca.Win.TextBoxEx
        Me.pnlContents.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContents
        '
        Me.pnlContents.Controls.Add(Me.TextBoxEx3)
        Me.pnlContents.Controls.Add(Me.TextBoxEx2)
        Me.pnlContents.Controls.Add(Me.TextBoxEx1)
        Me.pnlContents.Size = New System.Drawing.Size(238, 295)
        '
        'TextBoxEx1
        '
        Me.TextBoxEx1.BottomBorderColor = System.Drawing.Color.Empty
        Me.TextBoxEx1.Location = New System.Drawing.Point(64, 65)
        Me.TextBoxEx1.Name = "TextBoxEx1"
        Me.TextBoxEx1.Size = New System.Drawing.Size(100, 23)
        Me.TextBoxEx1.TabIndex = 0
        Me.TextBoxEx1.TextChangedCompleteDelay = 0
        '
        'TextBoxEx2
        '
        Me.TextBoxEx2.BottomBorderColor = System.Drawing.Color.Empty
        Me.TextBoxEx2.Location = New System.Drawing.Point(64, 94)
        Me.TextBoxEx2.Name = "TextBoxEx2"
        Me.TextBoxEx2.Size = New System.Drawing.Size(100, 23)
        Me.TextBoxEx2.TabIndex = 1
        Me.TextBoxEx2.TextChangedCompleteDelay = 0
        '
        'TextBoxEx3
        '
        Me.TextBoxEx3.BottomBorderColor = System.Drawing.Color.Empty
        Me.TextBoxEx3.Location = New System.Drawing.Point(64, 123)
        Me.TextBoxEx3.Name = "TextBoxEx3"
        Me.TextBoxEx3.Size = New System.Drawing.Size(100, 23)
        Me.TextBoxEx3.TabIndex = 2
        Me.TextBoxEx3.TextChangedCompleteDelay = 0
        '
        'Test2Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(238, 295)
        Me.Name = "Test2Form"
        Me.pnlContents.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextBoxEx1 As Moca.Win.TextBoxEx
    Friend WithEvents TextBoxEx3 As Moca.Win.TextBoxEx
    Friend WithEvents TextBoxEx2 As Moca.Win.TextBoxEx

End Class
