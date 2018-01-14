
Namespace Win

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MessageForm
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
            Me.pnlMain = New System.Windows.Forms.Panel
            Me.pnlBody = New System.Windows.Forms.Panel
            Me.lblMessage = New Moca.Win.MLabel
            Me.pnlHeader = New System.Windows.Forms.Panel
            Me.lblHeader = New Moca.Win.MLabel
            Me.pnlFooter = New System.Windows.Forms.Panel
            Me.btnOK = New System.Windows.Forms.Button
            Me.btnCancel = New System.Windows.Forms.Button
            Me.pnlMain.SuspendLayout()
            Me.pnlBody.SuspendLayout()
            Me.pnlHeader.SuspendLayout()
            Me.pnlFooter.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlMain
            '
            Me.pnlMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnlMain.Controls.Add(Me.pnlBody)
            Me.pnlMain.Controls.Add(Me.pnlHeader)
            Me.pnlMain.Controls.Add(Me.pnlFooter)
            Me.pnlMain.Location = New System.Drawing.Point(1, 1)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(225, 198)
            '
            'pnlBody
            '
            Me.pnlBody.Controls.Add(Me.lblMessage)
            Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlBody.Location = New System.Drawing.Point(0, 54)
            Me.pnlBody.Name = "pnlBody"
            Me.pnlBody.Size = New System.Drawing.Size(225, 109)
            '
            'lblMessage
            '
            Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
            Me.lblMessage.BorderColor = System.Drawing.Color.Empty
            Me.lblMessage.BorderWidth = 1
            Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblMessage.Location = New System.Drawing.Point(0, 0)
            Me.lblMessage.Name = "lblMessage"
            Me.lblMessage.Size = New System.Drawing.Size(225, 109)
            Me.lblMessage.TabIndex = 0
            Me.lblMessage.Text = "内容"
            Me.lblMessage.TextAlign = Moca.TextAlignment.MiddleCenter
            '
            'pnlHeader
            '
            Me.pnlHeader.Controls.Add(Me.lblHeader)
            Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Size = New System.Drawing.Size(225, 54)
            '
            'lblHeader
            '
            Me.lblHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
            Me.lblHeader.BorderColor = System.Drawing.Color.Empty
            Me.lblHeader.BorderWidth = 1
            Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblHeader.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblHeader.Location = New System.Drawing.Point(0, 0)
            Me.lblHeader.Name = "lblHeader"
            Me.lblHeader.Size = New System.Drawing.Size(225, 54)
            Me.lblHeader.TabIndex = 0
            Me.lblHeader.Text = "タイトル"
            Me.lblHeader.TextAlign = Moca.TextAlignment.MiddleCenter
            '
            'pnlFooter
            '
            Me.pnlFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
            Me.pnlFooter.Controls.Add(Me.btnOK)
            Me.pnlFooter.Controls.Add(Me.btnCancel)
            Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlFooter.Location = New System.Drawing.Point(0, 163)
            Me.pnlFooter.Name = "pnlFooter"
            Me.pnlFooter.Size = New System.Drawing.Size(225, 35)
            '
            'btnOK
            '
            Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.btnOK.Dock = System.Windows.Forms.DockStyle.Left
            Me.btnOK.Location = New System.Drawing.Point(0, 0)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(100, 35)
            Me.btnOK.TabIndex = 2
            Me.btnOK.Text = "はい(&Y)"
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
            Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
            Me.btnCancel.Location = New System.Drawing.Point(125, 0)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(100, 35)
            Me.btnCancel.TabIndex = 3
            Me.btnCancel.Text = "いいえ(&N)"
            '
            'MessageForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(227, 200)
            Me.ControlBox = False
            Me.Controls.Add(Me.pnlMain)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "MessageForm"
            Me.Text = "MessageBox"
            Me.TopMost = True
            Me.pnlMain.ResumeLayout(False)
            Me.pnlBody.ResumeLayout(False)
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlFooter.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents pnlMain As System.Windows.Forms.Panel
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents pnlFooter As System.Windows.Forms.Panel
        Friend WithEvents pnlBody As System.Windows.Forms.Panel
        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblMessage As Moca.Win.MLabel
        Friend WithEvents lblHeader As Moca.Win.MLabel

    End Class

End Namespace
