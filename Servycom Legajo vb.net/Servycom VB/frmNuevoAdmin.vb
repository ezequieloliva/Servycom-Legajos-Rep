Imports System.Data.OleDb
Public Class frmNuevoAdmin
    Private Sub btnGuardarAdmin_Click(sender As Object, e As EventArgs) Handles btnGuardarAdmin.Click
        Dim conector As New OleDbConnection(My.Settings.CADENA)
        conector.Open()
        Dim comando As New OleDbCommand("INSERT INTO usuarios VALUES ('" & txtUsuarioAdminNuevo.Text & "','" & txtClaveNuevoAdmin.Text & "')", conector)
        comando.ExecuteNonQuery()
        conector.Close()
        txtClaveNuevoAdmin.Text = ""
        txtUsuarioAdminNuevo.Text = ""
    End Sub
End Class