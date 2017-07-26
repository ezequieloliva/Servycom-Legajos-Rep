Imports MySql.Data.MySqlClient
Public Class conexion
    Friend conexion As MySqlConnection
    Public Sub conectarse()
        conexion = New MySqlConnection()
        conexion.ConnectionString = "server=db4free.net ; database= rrhhservycom; user id= eoliva ; password= clave123;"
        conexion.Open()

    End Sub
End Class
