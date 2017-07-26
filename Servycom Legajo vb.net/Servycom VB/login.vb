Imports System.Data.OleDb
Public Class login
    Dim CONECTOR As New OleDbConnection(My.Settings.CADENA)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dr As OleDb.OleDbDataReader
        Dim COMANDO As New OleDbCommand
        COMANDO.CommandType = CommandType.Text
        COMANDO.Connection = CONECTOR
        COMANDO.CommandText = "select user,pass from usuarios where user= '" & txtUusario.Text & "'"
        CONECTOR.Open()
        dr = COMANDO.ExecuteReader()
        If dr.HasRows Then
            While dr.Read
                If dr("pass") = txtClave.Text Then
                    ''entrar a la app
                    rrhh.Show()
                Else
                    '' no entrar y quedarse aqui
                    MsgBox("Clave incorrecta")
                End If
            End While
        Else
            MsgBox("Usuario incorrecto")
        End If
        CONECTOR.Close()
    End Sub
    Private Sub checkClave_CheckedChanged_1(sender As Object, e As EventArgs) Handles checkClave.CheckedChanged
        If checkClave.Checked Then
            txtClave.UseSystemPasswordChar = False
        Else
            txtClave.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUusario.Select()
    End Sub
End Class