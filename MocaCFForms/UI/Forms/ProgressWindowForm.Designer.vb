
Namespace Win

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProgressWindowForm
        Inherits Win.CoreForm

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
            Me.lblMessage = New Moca.Win.LabelEx
            Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
            Me.pnlMain = New System.Windows.Forms.Panel
            Me.Timer1 = New System.Windows.Forms.Timer
            Me.pnlMain.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblMessage
            '
            Me.lblMessage.BottomBorderColor = System.Drawing.Color.Empty
            Me.lblMessage.Location = New System.Drawing.Point(11, 15)
            Me.lblMessage.Name = "lblMessage"
            Me.lblMessage.Size = New System.Drawing.Size(206, 33)
            Me.lblMessage.Text = "処理中 ..."
            '
            'ProgressBar1
            '
            Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ProgressBar1.Location = New System.Drawing.Point(11, 51)
            Me.ProgressBar1.Name = "ProgressBar1"
            Me.ProgressBar1.Size = New System.Drawing.Size(206, 20)
            '
            'pnlMain
            '
            Me.pnlMain.Controls.Add(Me.ProgressBar1)
            Me.pnlMain.Controls.Add(Me.lblMessage)
            Me.pnlMain.Location = New System.Drawing.Point(1, 1)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(225, 99)
            '
            'Timer1
            '
            Me.Timer1.Enabled = True
            Me.Timer1.Interval = 300
            '
            'ProgressWindowForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.ClientSize = New System.Drawing.Size(227, 101)
            Me.ControlBox = False
            Me.Controls.Add(Me.pnlMain)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "ProgressWindowForm"
            Me.Text = ""
            Me.pnlMain.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents lblMessage As Moca.Win.LabelEx
        Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
        Friend WithEvents pnlMain As System.Windows.Forms.Panel
        Friend WithEvents Timer1 As System.Windows.Forms.Timer

    End Class

End Namespace
