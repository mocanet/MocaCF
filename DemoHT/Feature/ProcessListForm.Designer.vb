<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcessListForm
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
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.btnRefresh = New Moca.Win.ActionButton
        Me.btnKill = New Moca.Win.ActionButton
        Me.pnlContents.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContents
        '
        Me.pnlContents.Controls.Add(Me.btnKill)
        Me.pnlContents.Controls.Add(Me.btnRefresh)
        Me.pnlContents.Controls.Add(Me.ListBox1)
        Me.pnlContents.Size = New System.Drawing.Size(238, 295)
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(13, 14)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(213, 178)
        Me.ListBox1.TabIndex = 0
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(13, 247)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(91, 31)
        Me.btnRefresh.TabIndex = 1
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UpdateCheck = False
        Me.btnRefresh.UpdateCheckCaption = Nothing
        '
        'btnKill
        '
        Me.btnKill.Location = New System.Drawing.Point(135, 247)
        Me.btnKill.Name = "btnKill"
        Me.btnKill.Size = New System.Drawing.Size(91, 31)
        Me.btnKill.TabIndex = 2
        Me.btnKill.Text = "Kill"
        Me.btnKill.UpdateCheck = False
        Me.btnKill.UpdateCheckCaption = Nothing
        '
        'ProcessListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(238, 295)
        Me.Name = "ProcessListForm"
        Me.Text = "Process List"
        Me.pnlContents.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents btnKill As Moca.Win.ActionButton
    Friend WithEvents btnRefresh As Moca.Win.ActionButton

End Class
