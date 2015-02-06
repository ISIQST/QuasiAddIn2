Public Class uctest5
    Implements Quasi97.iQSTUserControl

    Private WithEvents OwnerTest As clsTest5
    Public Property OwnerTestKey As String = "" Implements Quasi97.iQSTUserControl.OwnerTestKey
    Public Property Activate As System.Windows.Forms.MethodInvoker Implements Quasi97.iQSTUserControl.Activate
    Public Function GetChart(SizeXmm As Integer, SizeYmm As Integer) As System.Drawing.Image Implements Quasi97.iQSTUserControl.GetChart
        Return Nothing
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

        txtAverages.Text = OwnerTest.Average
        cmdStress.ForeColor = IIf(OwnerTest.Stress.HasEnabledStressItems, Drawing.Color.Blue, Drawing.Color.Black)
    End Sub

    Private Sub txtDataPoints_LostFocus(sender As Object, e As System.EventArgs) Handles txtAverages.LostFocus
        OwnerTest.Average = Val(txtAverages.Text)
    End Sub

    Private Sub OwnerTest_NewResultsAvailable(rsList() As Integer) Handles OwnerTest.NewResultsAvailable
        Try
            txtRes.Text = OwnerTest.colResults(rsList(0)).GetResult("Resistance (Ohm)")
            
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub OwnerTest_RestoreParams() Handles OwnerTest.RestoreParams
        txtAverages.Text = OwnerTest.Average
    End Sub

    Private Sub OwnerTest_ResultsCleared(DoRefreshMenu As Boolean) Handles OwnerTest.ResultsCleared
        txtRes.Text = ""
    End Sub

    Private Sub cmdStress_Click(sender As System.Object, e As System.EventArgs) Handles cmdStress.Click
        OwnerTest.Stress.ShowForm()
        cmdStress.ForeColor = IIf(OwnerTest.Stress.HasEnabledStressItems, Drawing.Color.Blue, Drawing.Color.Black)
    End Sub
End Class
