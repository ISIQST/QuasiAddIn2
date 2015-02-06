Public Class Class1
    Implements IDisposable

    Public Property ModuleDescr$ = "Quasi AddIn 2"        'Module's description
    Public Property ModuleID$ = "QuasiAddIn2"                'module's name

    Public ReadOnly Property QuasiAddIn() As Boolean
        'property signaling to Quasi97 that this is valid Quasi97 add-in, should return true
        Get
            Return True
        End Get
    End Property

    Public Sub Initialize2(ByRef QSTPtr As Object)
        'entry point, the function Quasi97 calls after instantiating this class
        Try
            QST = QSTPtr
            QST.QstStatus.Message = "Hello QST!"

            QST.QuasiParameters.RegisterTestClassNET(clsTest1.ThisTestID, "QuasiAddIn2", "QuasiAddIn2.clsTest1", "", "Quasi97.ucGenericNoGraph")
            QST.QuasiParameters.RegisterTestClassNET(clsTest2.ThisTestID, "QuasiAddIn2", "QuasiAddIn2.clsTest2", "", "Quasi97.ucGenericTestForm")
            QST.QuasiParameters.RegisterTestClassNET(clsTest4.ThisTestID, "QuasiAddIn2", "QuasiAddIn2.clsTest4", "", "QuasiAddIn2.ucTest4")
            QST.QuasiParameters.RegisterTestClassNET(clstest5.ThisTestID, "QuasiAddIn2", "QuasiAddIn2.clsTest5", "", "QuasiAddIn2.ucTest5")
        Catch ex As Exception
            Call MsgBox("Error occured: " & ex.Message)
        End Try
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                If Not QST Is Nothing Then
                    QST.QuasiParameters.UnregisterTestClass(clsTest1.ThisTestID)
                    QST.QuasiParameters.UnregisterTestClass(clsTest2.ThisTestID)
                    QST.QuasiParameters.UnregisterTestClass(clsTest4.ThisTestID)
                    QST = Nothing
                End If
            End If
        End If
        Me.disposedValue = True
    End Sub

    Protected Overrides Sub Finalize()
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(False)
        MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class

