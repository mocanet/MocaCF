<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DemoHTForm
    Inherits Moca.Win.MainForm

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
        Me.AlertMessage31 = New Moca.Win.AlertMessage
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.Size = New System.Drawing.Size(238, 295)
        '
        'AlertMessage31
        '
        Me.AlertMessage31.AutoCloseSecond = 0
        Me.AlertMessage31.DefaultMessageBackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.AlertMessage31.DefaultMessageForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.AlertMessage31.DirectionType = Moca.Win.AnimateWindow.DirectionType.Top
        Me.AlertMessage31.Dock = System.Windows.Forms.DockStyle.Top
        Me.AlertMessage31.ErrorBackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.AlertMessage31.ErrorForeColor = System.Drawing.Color.White
        Me.AlertMessage31.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.AlertMessage31.FullClickClose = False
        Me.AlertMessage31.Location = New System.Drawing.Point(0, 0)
        Me.AlertMessage31.Name = "AlertMessage31"
        Me.AlertMessage31.Size = New System.Drawing.Size(238, 57)
        Me.AlertMessage31.SuccessBackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.AlertMessage31.SuccessForeColor = System.Drawing.Color.White
        Me.AlertMessage31.TabIndex = 4
        Me.AlertMessage31.Text = "AlertMessage31"
        Me.AlertMessage31.WarnBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.AlertMessage31.WarnForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'DemoHTForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(238, 295)
        Me.Name = "DemoHTForm"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AlertMessage31 As Moca.Win.AlertMessage

End Class
