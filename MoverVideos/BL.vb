Imports System.IO

Public Class BL
#Region "VARIABLES DE INSTANCIA"
    Dim fechaDesde As Date = Today.AddDays(-30)
    Dim directorioOrigen As New IO.DirectoryInfo("D:\VIDEOS ENUTV\" & Now.Year.ToString())
    Dim directorioBackUp As New DirectoryInfo("D:\BACKUP VIDEOS\" & Now.Year.ToString() & "-" & Now.Month.ToString() & "-" & Now.Day.ToString() & "\")
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

        Try
            For Each directorioMes As DirectoryInfo In directorioOrigen.GetDirectories()
                directorioMes.Refresh()
                For Each directorioDia As DirectoryInfo In directorioMes.GetDirectories()
                    If directorioDia.CreationTime.Date <= fechaDesde Then
                        'esta linea de prueba la dejo para futuras pruebas, ya que nos indica el formato de salida de una estructura de directorio.
                        'en un futuro, optar por configurar la estructura desde archivo configurable

                        'My.Computer.FileSystem.WriteAllText("e:\prueba.txt", directorioDia.FullName & vbCrLf & vbCrLf, True)
                        My.Computer.FileSystem.CopyDirectory(directorioDia.FullName, directorioBackUp.FullName & "\" & directorioMes.Name & directorioDia.Name, True)
                    End If
                Next
            Next

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("c:\errorlogFileMover.txt", vbCrLf & " fecha =  " & Date.Today.ToString() & vbCrLf & ex.Message & vbCrLf, True)
            Exit Sub
        End Try
    End Sub


#End Region
End Class
