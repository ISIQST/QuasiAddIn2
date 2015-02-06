<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucTest4
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.lblDataPts = New System.Windows.Forms.Label()
        Me.txtDataPoints = New System.Windows.Forms.TextBox()
        Me.txtRes = New System.Windows.Forms.TextBox()
        Me.lblResult = New System.Windows.Forms.Label()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(0, 51)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Series1.XValueMember = "Sample #"
        Series1.YValueMembers = "Resistance (Ohm)"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series2.Legend = "Legend1"
        Series2.Name = "Series2"
        Series2.XValueMember = "Sample #"
        Series2.YValueMembers = "Random"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(348, 258)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'lblDataPts
        '
        Me.lblDataPts.AutoSize = True
        Me.lblDataPts.Location = New System.Drawing.Point(16, 16)
        Me.lblDataPts.Name = "lblDataPts"
        Me.lblDataPts.Size = New System.Drawing.Size(62, 13)
        Me.lblDataPts.TabIndex = 1
        Me.lblDataPts.Text = "Data Points"
        '
        'txtDataPoints
        '
        Me.txtDataPoints.Location = New System.Drawing.Point(84, 13)
        Me.txtDataPoints.Name = "txtDataPoints"
        Me.txtDataPoints.Size = New System.Drawing.Size(100, 20)
        Me.txtDataPoints.TabIndex = 2
        '
        'txtRes
        '
        Me.txtRes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRes.Location = New System.Drawing.Point(453, 54)
        Me.txtRes.Name = "txtRes"
        Me.txtRes.Size = New System.Drawing.Size(34, 20)
        Me.txtRes.TabIndex = 3
        '
        'lblResult
        '
        Me.lblResult.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblResult.AutoSize = True
        Me.lblResult.Location = New System.Drawing.Point(354, 57)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(93, 13)
        Me.lblResult.TabIndex = 4
        Me.lblResult.Text = "Result Resistance"
        '
        'ucTest4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.txtRes)
        Me.Controls.Add(Me.txtDataPoints)
        Me.Controls.Add(Me.lblDataPts)
        Me.Controls.Add(Me.Chart1)
        Me.Name = "ucTest4"
        Me.Size = New System.Drawing.Size(490, 309)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents lblDataPts As System.Windows.Forms.Label
    Friend WithEvents txtDataPoints As System.Windows.Forms.TextBox
    Friend WithEvents txtRes As System.Windows.Forms.TextBox
    Friend WithEvents lblResult As System.Windows.Forms.Label

    Private Sub ucTest4_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        If Not OwnerTest Is Nothing Then
            OwnerTest = Nothing
        End If
    End Sub
End Class
