Imports System.IO

Public Class BL
#Region "VARIABLES DE INSTANCIA"
    Dim fechaDesde As Date = Today.AddDays(-30)
    Dim directorioOrigen As New IO.DirectoryInfo("d:\usb\")
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
        Dim subDir As DirectoryInfo
        Try
            For Each subDir In directorioOrigen.GetDirectories()
                If subDir.CreationTime.Date = fechaDesde Then
                    Dim subDirectorioDestino As New DirectoryInfo(directorioBackUp.ToString() & subDir.ToString())
                    My.Computer.FileSystem.MoveDirectory(subDir.FullName, subDirectorioDestino.FullName, True)
                End If

            Next
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub


#End Region
End Class
