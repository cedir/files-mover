Imports System.IO

Public Class BL
#Region "VARIABLES DE INSTANCIA"
    Dim fechaDesde As Date = Today.AddDays(35)
    Dim directorioOrigen As New IO.DirectoryInfo("d:\videos endoscopio\" & Now.Year.ToString())
    Dim directorioBackUp As New DirectoryInfo("d:\backup\" & Now.Year.ToString() & "-" & Now.Month.ToString() & "-" & Now.Day.ToString() & "\")
#End Region
#Region "METODOS PUBLICOS"
    Public Sub moverCarpetas()
        crearDirectorioBack()
        copiarArchivos()
    End Sub

#End Region
#Region "METODOS PRIVADOS"
    Private Sub crearDirectorioBack()
        'creating a DirectoryInfo object
        If Not Directory.Exists(directorioBackUp.ToString()) Then
            Directory.CreateDirectory(directorioBackUp.ToString())
        End If
    End Sub
    Private Sub copiarArchivos()
        Dim subDirectorio As DirectoryInfo
        Try
            For Each subDirectorio In directorioOrigen.GetDirectories()
                If subDirectorio.CreationTime.Date < fechaDesde Then
                    subDirectorio.Refresh()
                    Dim subDirectorioDestino As New DirectoryInfo(directorioBackUp.ToString() & subDirectorio.ToString())
                    My.Computer.FileSystem.MoveDirectory(subDirectorio.FullName, subDirectorioDestino.FullName, True)
                End If
            Next
        Catch ex As Exception
            Exit Sub
        Finally
            subDirectorio = Nothing
        End Try
    End Sub


#End Region
End Class
