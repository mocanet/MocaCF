
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
            Me.pnlMenu = New System.Windows.Forms.Panel
            Me.pnlMain.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlMain
            '
            Me.pnlMain.Controls.Add(Me.pnlMenu)
            Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlMain.Location = New System.Drawing.Point(0, 0)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(638, 455)
            '
            'pnlMenu
            '
            Me.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlMenu.Location = New System.Drawing.Point(0, 0)
            Me.pnlMenu.Name = "pnlMenu"
            Me.pnlMenu.Size = New System.Drawing.Size(638, 455)
            '
            'MainForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.ClientSize = New System.Drawing.Size(638, 455)
            Me.Controls.Add(Me.pnlMain)
            Me.Name = "MainForm"
            Me.Text = "MainForm"
            Me.pnlMain.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Protected WithEvents pnlMain As System.Windows.Forms.Panel
        Protected WithEvents pnlMenu As System.Windows.Forms.Panel
    End Class

End Namespace
