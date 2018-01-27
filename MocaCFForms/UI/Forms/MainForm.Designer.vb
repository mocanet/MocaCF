
Namespace Win

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class MainForm
        Inherits CoreForm

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
            Me.pnlMain = New System.Windows.Forms.Panel
            Me.AlertMessage1 = New Moca.Win.AlertMessage
            Me.SuspendLayout()
            '
            'pnlMain
            '
            Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlMain.Location = New System.Drawing.Point(0, 0)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(638, 410)
            '
            'AlertMessage1
            '
            Me.AlertMessage1.AutoCloseSecond = 4
            Me.AlertMessage1.DefaultMessageBackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(242, Byte), Integer))
            Me.AlertMessage1.DefaultMessageForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
            Me.AlertMessage1.DirectionType = Moca.Win.AnimateWindow.DirectionType.Bottom
            Me.AlertMessage1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.AlertMessage1.ErrorBackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.AlertMessage1.ErrorForeColor = System.Drawing.Color.White
            Me.AlertMessage1.FullClickClose = True
            Me.AlertMessage1.Location = New System.Drawing.Point(0, 410)
            Me.AlertMessage1.Name = "AlertMessage1"
            Me.AlertMessage1.Size = New System.Drawing.Size(638, 45)
            Me.AlertMessage1.SuccessBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.AlertMessage1.SuccessForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
            Me.AlertMessage1.TabIndex = 1
            Me.AlertMessage1.TabStop = False
            Me.AlertMessage1.Text = "AlertMessage1"
            Me.AlertMessage1.WarnBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(92, Byte), Integer))
            Me.AlertMessage1.WarnForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
            '
            'MainForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.ClientSize = New System.Drawing.Size(638, 455)
            Me.Controls.Add(Me.pnlMain)
            Me.Controls.Add(Me.AlertMessage1)
            Me.Name = "MainForm"
            Me.Text = "MainForm"
            Me.ResumeLayout(False)

        End Sub
        Protected WithEvents pnlMain As System.Windows.Forms.Panel
        Public WithEvents AlertMessage1 As Moca.Win.AlertMessage
    End Class

End Namespace
