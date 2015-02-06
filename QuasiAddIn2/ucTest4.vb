Public Class ucTest4
    Implements Quasi97.iQSTUserControl

    Private WithEvents OwnerTest As clsTest4
    Public Property OwnerTestKey As String = "" Implements Quasi97.iQSTUserControl.OwnerTestKey

    Public Function GetChart(SizeXmm As Integer, SizeYmm As Integer) As System.Drawing.Image Implements Quasi97.iQSTUserControl.GetChart
        '        Return Nothing
        Dim imstream As New System.IO.MemoryStream
        Chart1.SaveImage(imstream, System.Drawing.Imaging.ImageFormat.Png)
        GetChart = System.Drawing.Image.FromStream(imstream)
        imstream.Close()
    End Function

    Public ReadOnly Property LongLabel As String Implements Quasi97.iQSTUserControl.LongLabel
        Get
            Return OwnerTest.TestIDandSetup
        End Get
    End Property

    Public ReadOnly Property ShortLabel As String Implements Quasi97.iQSTUserControl.ShortLabel
        Get
            Return OwnerTest.TestIDandSetup
        End Get
    End Property

    Public ReadOnly Property MenuPTR As System.Windows.Forms.UserControl Implements Quasi97.iQSTUserControl.MenuPTR
        Get
            Return Me
        End Get
    End Property

    Public Sub PickResult(rsidx As Short) Implements Quasi97.iQSTUserControl.PickResult

    End Sub

    Public Sub RunTimeInit(ByRef lOwnerTest As Quasi97.clsQSTTestNET) Implements Quasi97.iQSTUserControl.RunTimeInit
        OwnerTest = lOwnerTest
        OwnerTestKey = lOwnerTest.Key

        txtDataPoints.Text = OwnerTest.DataPoints
    End Sub

    Private Sub txtDataPoints_LostFocus(sender As Object, e As System.EventArgs) Handles txtDataPoints.LostFocus
        OwnerTest.DataPoints = Val(txtDataPoints.Text)
    End Sub

    Private Sub OwnerTest_NewResultsAvailable(rsList() As Integer) Handles OwnerTest.NewResultsAvailable
        Try
            txtRes.Text = OwnerTest.colResults(rsList(0)).GetResult("Resistance (Ohm)")
            Chart1.DataSource = OwnerTest.colResults(rsList(0)).Data
            Chart1.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub OwnerTest_RestoreParams() Handles OwnerTest.RestoreParams
        txtDataPoints.Text = OwnerTest.DataPoints
    End Sub

    Private Sub OwnerTest_ResultsCleared(DoRefreshMenu As Boolean) Handles OwnerTest.ResultsCleared
        txtRes.Text = ""
    End Sub

    Public Property Activate As System.Windows.Forms.MethodInvoker Implements Quasi97.iQSTUserControl.Activate
        
End Class
