
Public Class frmEventosTemporales

#Region "Eventos del formulario"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Hide()
        Me.BackgroundWorker1.RunWorkerAsync()
    End Sub
#End Region
#Region "Metodos de instancia"
    Private Sub moverCarpetas()
        Dim capaNegocio As New BL
        capaNegocio.moverCarpetas()
    End Sub
#End Region
#Region "Background worker"
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        moverCarpetas()
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Me.Close()
    End Sub
#End Region

End Class
