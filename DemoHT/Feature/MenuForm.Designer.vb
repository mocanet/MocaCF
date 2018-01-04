<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuForm
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
        Me.ActionButton1 = New Moca.Win.ActionButton
        Me.pnlContents.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContents
        '
        Me.pnlContents.Controls.Add(Me.ActionButton1)
        Me.pnlContents.Size = New System.Drawing.Size(238, 295)
        '
        'ActionButton1
        '
        Me.ActionButton1.Location = New System.Drawing.Point(29, 80)
        Me.ActionButton1.Name = "ActionButton1"
        Me.ActionButton1.Size = New System.Drawing.Size(180, 38)
        Me.ActionButton1.TabIndex = 0
        Me.ActionButton1.Text = "ActionButton1"
        '
        'MenuForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(238, 295)
        Me.Name = "MenuForm"
        Me.pnlContents.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ActionButton1 As Moca.Win.ActionButton

End Class
