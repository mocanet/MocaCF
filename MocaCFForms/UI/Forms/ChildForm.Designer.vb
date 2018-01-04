
Namespace Win

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class ChildForm
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
            Me.pnlContents = New System.Windows.Forms.Panel
            Me.SuspendLayout()
            '
            'pnlContents
            '
            Me.pnlContents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlContents.Location = New System.Drawing.Point(0, 0)
            Me.pnlContents.Name = "pnlContents"
            Me.pnlContents.Size = New System.Drawing.Size(238, 295)
            '
            'ChildForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.ClientSize = New System.Drawing.Size(238, 295)
            Me.ControlBox = False
            Me.Controls.Add(Me.pnlContents)
            Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "ChildForm"
            Me.Text = "ChildForm"
            Me.ResumeLayout(False)

        End Sub
        Protected Friend WithEvents pnlContents As System.Windows.Forms.Panel
    End Class

End Namespace
