Imports MySql.Data
Imports System.Data.OleDb
Public Class Cambio_de_contraseña
    Dim CONECTOR As New OleDbConnection(My.Settings.CADENA)
    Dim COMANDO As New OleDbCommand
    Dim adaptador As New OleDbDataAdapter(COMANDO)
    Private Sub Cambio_de_contraseña_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'RrhhDataSet.usuarios' Puede moverla o quitarla según sea necesario.
        Me.UsuariosTableAdapter.Fill(Me.RrhhDataSet.usuarios)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If txtContraActual.Text = "" Or txtContraNueva.Text = "" Then
            MsgBox("POR FAVOR LLENE LOS CAMPOS MENCIONADOS".ToString)
        Else
            cambiocontra()
            MsgBox("CONTRASEÑA CAMBIADA".ToString)
            Me.Close()
        End If
    End Sub
    Public Sub cambiocontra()
        CONECTOR.Open()
        Dim sql As String = "UPDATE usuarios SET pass =" & txtContraNueva.Text & " WHERE user= '" & cmbUsuarios.Text & "'"
        Dim comando As New OleDbCommand(sql, CONECTOR)
        comando.ExecuteNonQuery()


        CONECTOR.Close()
    End Sub
    Public Sub validarclave()
        
        Dim dr As OleDb.OleDbDataReader
        Dim COMANDO As New OleDbCommand
        COMANDO.CommandType = CommandType.Text
        COMANDO.Connection = CONECTOR
        COMANDO.CommandText = "select user,pass from usuarios where user= '" & cmbUsuarios.Text & "'"
        CONECTOR.Open()
        dr = COMANDO.ExecuteReader()
        If dr.HasRows Then
            While dr.Read
                If dr("user") = cmbUsuarios.Text Then
                    txtContraActual.Text = dr("pass")

                    Exit While
                End If
            End While
        End If
        CONECTOR.Close()
    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUsuarios.SelectedIndexChanged
        validarclave()
    End Sub
End Class