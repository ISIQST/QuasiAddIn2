<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uctest5
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.txtRes = New System.Windows.Forms.TextBox()
        Me.txtAverages = New System.Windows.Forms.TextBox()
        Me.lblDataPts = New System.Windows.Forms.Label()
        Me.cmdStress = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblResult
        '
        Me.lblResult.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblResult.AutoSize = True
        Me.lblResult.Location = New System.Drawing.Point(44, 90)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(93, 13)
        Me.lblResult.TabIndex = 8
        Me.lblResult.Text = "Result Resistance"
        '
        'txtRes
        '
        Me.txtRes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRes.Location = New System.Drawing.Point(143, 87)
        Me.txtRes.Name = "txtRes"
        Me.txtRes.Size = New System.Drawing.Size(34, 20)
        Me.txtRes.TabIndex = 7
        '
        'txtAverages
        '
        Me.txtAverages.Location = New System.Drawing.Point(77, 12)
        Me.txtAverages.Name = "txtAverages"
        Me.txtAverages.Size = New System.Drawing.Size(100, 20)
        Me.txtAverages.TabIndex = 6
        '
        'lblDataPts
        '
        Me.lblDataPts.AutoSize = True
        Me.lblDataPts.Location = New System.Drawing.Point(9, 15)
        Me.lblDataPts.Name = "lblDataPts"
        Me.lblDataPts.Size = New System.Drawing.Size(52, 13)
        Me.lblDataPts.TabIndex = 5
        Me.lblDataPts.Text = "Averages"
        '
        'cmdStress
        '
        Me.cmdStress.Location = New System.Drawing.Point(238, 28)
        Me.cmdStress.Name = "cmdStress"
        Me.cmdStress.Size = New System.Drawing.Size(209, 50)
        Me.cmdStress.TabIndex = 9
        Me.cmdStress.Text = "Stress Options"
        Me.cmdStress.UseVisualStyleBackColor = True
        '
        'uctest5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdStress)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.txtRes)
        Me.Controls.Add(Me.txtAverages)
        Me.Controls.Add(Me.lblDataPts)
        Me.Name = "uctest5"
        Me.Size = New System.Drawing.Size(489, 125)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents txtRes As System.Windows.Forms.TextBox
    Friend WithEvents txtAverages As System.Windows.Forms.TextBox
    Friend WithEvents lblDataPts As System.Windows.Forms.Label
    Friend WithEvents cmdStress As System.Windows.Forms.Button

End Class
