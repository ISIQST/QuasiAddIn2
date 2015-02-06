Public Class clsTest2
    Inherits Quasi97.clsQSTTestNET

    Public Const ThisTestID$ = "NETSample 3 [Graph]"
    Private mvarDataPoints As Short = 10

    Public Sub New()
        Me.colParameters.Add(New Quasi97.clsTestParam("Data Points", "DataPoints", Me, mvarDataPoints.GetType, True, True, 10, Nothing))
        Me.colResultNames.Add(New Quasi97.ResultName("Resistance (Ohm)"))
    End Sub

    Public Property DataPoints() As Short
        Get
            Return mvarDataPoints
        End Get
        Set(ByVal Value As Short)
            If Value < 10 Or Value > 10000 Then
                Throw New System.ArgumentOutOfRangeException("DataPoints", Value, "Out of range 10..10000 [" & Value & "]")
            Else
                mvarDataPoints = Value
            End If
        End Set
    End Property

    Public Overrides Sub RunTest()
        Dim Rslt As Quasi97.ResultNet
        Dim sWatch As New System.Diagnostics.Stopwatch
        Dim pdBuffer(,,) As Single = Nothing
        Dim fieldbuf#(mvarDataPoints - 1)
        Dim Chan As Short = QST.QSTHardware.MRChannel
        Dim vBuff#() = Nothing

        Try
            sWatch.Restart()
            If QST.OptionsParameters.AutoClearResults Then ClearResults(False) 'the menu is going to refresh anyway when we add new results

            Rslt = New Quasi97.ResultNet
            colResults.Insert(0, Rslt)
            Rslt.Data.Columns.Clear()
            Rslt.Data.Columns.Add("Sample #", GetType(Short))
            Rslt.Data.Columns.Add("Resistance (Ohm)", GetType(Single))
            Rslt.Data.Columns.Add("Random", GetType(Single))

            'measuring
            'set 156KHz sampling rate
            QST.PatGenBoardParameters.DelayCounter = 0
            QST.PatGenBoardParameters.SampleCounter = 0
            'set dc level
            Call QST.QSTHardware.GenerateLevel(fieldbuf, mvarDataPoints, 0, 0)
            'select low gain
            Call QST.QSTHardware.TCSplitSelectInput(False)
            ReDim pdBuffer(1, UBound(fieldbuf), 1)            'number of cycles, number of data points, 2 channels
            Call QST.QSTHardware.TCSplitCaptureWaveform(pdBuffer, 1, 1)
            Call QST.QSTHardware.TCSplitScaleWaveform(pdBuffer, 0, False)
            Call QST.QSTHardware.ExtractPulseByChannel(vBuff, 0, pdBuffer, QST.QSTHardware.MRChannel)

            'storing in the data
            For i = 0 To UBound(vBuff)
                Rslt.Data.Rows.Add(1 + i, vBuff(i), 100 * Rnd(1))
            Next i
            MyBase.RaiseNewDataAvailable(colResults.Count, 1, -1)
            MyBase.RaiseNewDataAvailable(colResults.Count, 2, -1)

            'report results
            Rslt.AddParameters(Me.colParameters)
            Rslt.AddResult("Resistance (Ohm)", 0, 1)            'let next statement calculate statistics
            Rslt.CalcStats("DATA")

            'grade results
            QST.GradingParameters.GradeTestNet(Me, 0)

            'add information about run
            Rslt.AddInfo(Me, sWatch.ElapsedMilliseconds, QST.QuasiParameters.CurInfo)

            'notify the form that new results are available
            MyBase.RaiseNewInfoAvailable()
            MyBase.RaiseNewResultsAvailable(New Integer() {0})

        Catch ex As Exception
            MsgBox(ThisTestID & " RunTest " & ex.Message)
        End Try
    End Sub

    Public Overrides Sub GetSeriesColor(Ridx As Integer, dataColIDX As Integer, ByRef cl As System.Drawing.Color, ByRef LineType As Integer)
        If dataColIDX = 1 Then
            cl = System.Drawing.Color.Blue
        ElseIf dataColIDX = 2 Then
            cl = System.Drawing.Color.Red
        End If
    End Sub

    Public Overrides Sub SetDBase(ByRef NewDBase As String, Optional ByRef voidParam As Object = Nothing)

    End Sub

    Public Overrides Sub StoreParameters()

    End Sub

    Public Overrides ReadOnly Property TestID As String
        Get
            Return thistestid
        End Get
    End Property

    Public Overrides Function CheckRecords(NewDBase As String) As System.Collections.Generic.List(Of Short)
        Dim l As New List(Of Short)
        l.Add(1)
        Return l
    End Function

    Public Overrides Sub ClearResults(Optional doRefreshPlot As Boolean = False)
        colResults.Clear()
        MyBase.RaiseResultsCleared(doRefreshPlot)
    End Sub

    Public Overrides ReadOnly Property ContainsGraph As Short
        Get
            Return True
        End Get
    End Property

    Public Overrides ReadOnly Property ContainsResultPerCycle As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides ReadOnly Property DualChannelCapable As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides ReadOnly Property FeatureVector As UInteger
        Get
            Return 0
        End Get
    End Property

    Public Overrides Sub RemoveRecord()

    End Sub

    Public Overrides Sub RestoreParameters()

    End Sub
End Class
