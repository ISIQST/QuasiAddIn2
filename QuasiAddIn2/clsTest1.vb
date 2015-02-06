Public Class clsTest1
    Inherits Quasi97.clsQSTTestNET

    Public Const ThisTestID$ = "NETSample 2"
    Private objNativeRes As New NativeRes
    Private mvarAverages As Short = 1

    Private DBPtr As OleDb.OleDbConnection

    Public Overrides Sub SetDBase(ByRef NewDBase As String, Optional ByRef voidParam As Object = Nothing)
        'all setups should have one item, if user wants to add one item by default.
        'will only remember the name
        Try
            Dim cnBuilder As New OleDb.OleDbConnectionStringBuilder
            If NewDBase = "" Then
                DBPtr = Nothing
            Else
                DBPtr = New OleDb.OleDbConnection
                cnBuilder.Provider = "Microsoft.Jet.OLEDB.4.0"
                cnBuilder.DataSource = NewDBase
                DBPtr.ConnectionString = cnBuilder.ConnectionString
            End If
            UpdateTableDefs(dbptr)

        Catch ex As Exception
            MsgBox("SetDBase " & ex.Message)
        End Try
    End Sub

    Private Class NativeRes
        Public bv$ = "Bias Voltage"
        Public res$ = "Resistance (Ohm)"
    End Class

    Public Property Average() As Short
        Get
            Return mvarAverages
        End Get
        Set(ByVal Value As Short)
            If Value < 1 Or Value > 100 Then
                Throw New System.ArgumentOutOfRangeException("Average", Value, "Out of range 1..100 [" & Value & "]")
            Else
                mvarAverages = Value
            End If
        End Set
    End Property

    Public Overrides Sub RunTest()
        Dim Rslt As Quasi97.ResultNet
        Dim MeasuredVal! = 0
        Dim ib! = 0

        Try
            If QST.OptionsParameters.AutoClearResults Then ClearResults(False) 'the menu is going to refresh anyway when we add new results
            'measuring
            For i = 1 To mvarAverages
                MeasuredVal += QST.QSTHardware.HReadRes(QST.QSTHardware.MRChannel, 10)
                ib += QST.QSTHardware.GetReadBias(QST.QSTHardware.MRChannel)
            Next i
            ib /= mvarAverages
            MeasuredVal /= mvarAverages

            'report results
            Rslt = New Quasi97.ResultNet
            Rslt.AddParameters(Me.colParameters)
            colResults.Insert(0, Rslt)
            Rslt.AddResult(objNativeRes.res, MeasuredVal.ToString("F2"), 1)
            Rslt.AddResult(objNativeRes.bv, (ib * MeasuredVal).ToString("F2"), 1)
            Rslt.CalcStats("RESULT")

            'grade results
            QST.GradingParameters.GradeTestNet(Me, 0)

            'add information about run
            Rslt.AddInfo(Me, 0, QST.QuasiParameters.CurInfo)

            'notify the form that new results are available
            MyBase.RaiseNewInfoAvailable()
            MyBase.RaiseNewResultsAvailable(New Integer() {0})

        Catch ex As Exception
            MsgBox("clsTest1:RunTest " & ex.Message)
        End Try
    End Sub

    Sub UpdateTableDefs(db As OleDb.OleDbConnection)
        If db Is Nothing Then Return

        Try
            Dim SQLCom As New OleDb.OleDbCommand("CREATE TABLE QuasiAddIn2_NETSample2 (Setup Integer, Averages Integer)", db)
            Call SQLCom.ExecuteNonQuery()
        Catch ex As Exception
            'table already exists
            'MsgBox("UpdateTableDefs " & ex.Message)
        End Try
    End Sub

    Public Overrides ReadOnly Property TestID As String
        Get
            Return ThisTestID
        End Get
    End Property

    Public Overrides Function CheckRecords(NewDBase As String) As System.Collections.Generic.List(Of Short)
        'this really should be a shared function, but since there is no way to ver
        'all setups should have one item, if user wants to add one item by default.
        'will only remember the name
        Dim db As OleDb.OleDbConnection
        Dim cnBuilder As New OleDb.OleDbConnectionStringBuilder
        Dim dbCom As New OleDb.OleDbCommand
        Dim records As OleDb.OleDbDataReader
        Dim AllSetups As New List(Of Short)

        If Not NewDBase = "" Then
            Try
                db = New OleDb.OleDbConnection
                cnBuilder.Provider = "Microsoft.Jet.OLEDB.4.0"
                cnBuilder.DataSource = NewDBase
                db.ConnectionString = cnBuilder.ConnectionString
                db.Open()

                dbCom.CommandText = "SELECT Setup FROM QuasiAddIn2_NetSample2 ORDER BY Setup"
                dbCom.Connection = db
                Try
                    records = dbCom.ExecuteReader
                Catch ex As Exception
                    UpdateTableDefs(db)
                    records = dbCom.ExecuteReader
                End Try

                Do While records.Read
                    AllSetups.Add(CShort(records("Setup")))
                Loop

                If db.State <> ConnectionState.Closed Then db.Close()
            Catch e As Exception
                MsgBox("CheckRecords " & e.Message)
            End Try
        End If

        Return AllSetups
    End Function

    Public Overrides Sub ClearResults(Optional doRefreshPlot As Boolean = False)
        colResults.Clear()
        MyBase.RaiseResultsCleared(doRefreshPlot)
    End Sub

    Public Overrides Sub RemoveRecord()
        If DBPtr Is Nothing Then Exit Sub
        Dim sqlcom As New OleDb.OleDbCommand("DELETE * FROM QuasiAddIn2_NetSample2 WHERE Setup=" & Setup, DBPtr)
        Try
            DBPtr.Open()
            sqlcom.ExecuteNonQuery()
        Catch e As Exception
            MsgBox("RemoveRecord " & e.Message)
        Finally
            DBPtr.Close()
        End Try
        DBPtr = Nothing
    End Sub

    Public Overrides Sub RestoreParameters()
        'testsetup was left for compatibility only; is not used otherwise
        Dim rsParameters As OleDb.OleDbDataReader

        Try
            If DBPtr Is Nothing Then Return
            DBPtr.Open()
            Dim sqlCOM As New OleDb.OleDbCommand("SELECT * FROM QuasiAddIn2_NetSample2 WHERE Setup=" & Setup) With {.Connection = DBPtr}

            sqlCOM.ExecuteScalar()
            rsParameters = sqlCOM.ExecuteReader
            If Not rsParameters.Read Then
                'no records
                rsParameters.Close()
                Dim sqlWRCom As New OleDb.OleDbCommand("INSERT INTO QuasiAddIn2_NetSample2 (Setup) VALUES (" & Setup & ")", DBPtr)
                sqlWRCom.ExecuteNonQuery()
                Call sqlCOM.ExecuteNonQuery()
                rsParameters = sqlCOM.ExecuteReader
                Call rsParameters.Read()
            End If

            If Not rsParameters Is Nothing Then
                mvarAverages = CShort(rsParameters("Averages"))
            End If
            MyBase.RaiseRestoreParams()

        Catch ex As Exception
            MsgBox("RestoreParameters " & ex.Message)
        Finally
            If DBPtr.State = ConnectionState.Open Then DBPtr.Close()
        End Try
    End Sub

    Public Overrides Sub StoreParameters()
        If DBPtr Is Nothing Then Return

        Try
            Dim SQLCom As New OleDb.OleDbCommand("DELETE * FROM QuasiAddIn2_NETSample2 WHERE Setup=" & Setup.ToString, DBPtr)
            DBPtr.Open()
            Call SQLCom.ExecuteNonQuery()
            SQLCom.CommandText = "INSERT INTO QuasiAddIn2_NETSample2 (Setup, Averages) VALUES (" & _
                Setup.ToString & "," & _
                mvarAverages.ToString & ")"

            SQLCom.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("StoreParameters " & ex.Message)

        Finally
            If DBPtr.State <> ConnectionState.Closed Then DBPtr.Close()

        End Try
    End Sub

    Public Overrides ReadOnly Property ContainsGraph As Short
        Get
            Return False
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

    Public Sub New()
        MyBase.RegisterResults(objNativeRes)
        MyBase.colParameters.Add( _
            New Quasi97.clsTestParam("Average", "Average", Me, mvarAverages.GetType, True, True))

    End Sub
End Class

