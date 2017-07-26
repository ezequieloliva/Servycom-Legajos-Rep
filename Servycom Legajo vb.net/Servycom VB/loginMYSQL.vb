Imports MySql.Data.MySqlClient
''Esta clase aadministra la conexion a la base de datos LOgin que esta en MYSQL
Public Class loginMYSQL
#Region "VARIABLES GLOBALES"
    Dim conn As New MySqlConnection
    Dim comando As New MySqlCommand
    Dim tabla As DataTable
    Dim adaptador As MySqlDataAdapter
    Dim ds As New DataSet()
#End Region
#Region "PropiedadesDeClase"
    Private _diasObra As Integer
    Private _diasDeposito As Integer
    Private _sabados As Integer
    Private _domingos As Integer
    Private _diasTotal As Integer
    Private _dni As String
    Private _nombre As String

#End Region
    Public Sub loginMysql()

    End Sub
    Public Sub conectarse()
        conn.ConnectionString = cadenaConexion
        comando.CommandType = CommandType.Text
        comando.Connection = conn
        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("Sin conexion a Internet")
        End Try
    End Sub
    Public Sub desconectarse()
        conn.Close()

    End Sub
    ''' <summary>
    ''' Metodo que ejecuta una consulta
    ''' </summary>
    ''' <param name="consulta">Sentencia SQL Select</param>
    ''' <param name="grilla">Nombre de Data grid view que rellenera</param>
    Public Sub SelectSQL(consulta As String, grilla As DataGridView)
        tabla = New DataTable
        adaptador = New MySqlDataAdapter(consulta, conn)
        adaptador.Fill(tabla)
        grilla.DataSource = tabla
    End Sub
    ''' <summary>
    ''' Metodo que ejecuta un executeNonQuery(insert, delete o update)
    ''' </summary>
    ''' <param name="consulta">Sentenci SQL que debe realizar</param>
    Public Sub QuerySql(consulta As String)
        comando.CommandText = consulta
        comando.ExecuteNonQuery()

    End Sub

    ''' <summary>
    ''' Metodo que llena tabla con cada usuario y por cada usuario llama el metodo listarNovedades
    ''' </summary>
    Public Sub Novedades(grilla As DataGridView, mes As Integer, año As Integer)
        grilla.Rows.Clear()
        comando.CommandText = "select dni, nombre from usuario"
        Dim adaptador = New MySqlDataAdapter(comando.CommandText, conn)
        Dim tabla As New DataTable()
        adaptador.Fill(tabla)
        For Each fila As DataRow In tabla.Rows
            listarNovedades(grilla, fila("nombre").ToString, fila("dni").ToString, mes, año)
        Next
    End Sub
    ''Este metodo es llamado desde Sub Novedades
    Public Sub listarNovedades(grilla As DataGridView, nombre As String, dni As String, mes As Integer, año As Integer)
        Dim contadorObra As Integer = 0
        Dim contadorOficina As Integer = 0
        Dim contadorDeposito As Integer = 0
        Dim dia As Integer = 0
        _diasDeposito = 0
        _diasObra = 0
        _diasTotal = 0
        _sabados = 0
        _domingos = 0
        comando.CommandText = "select cellid,dia,diaSemana, hora from login where dni='" & dni & "' and mes=" & mes & " and año=" & año & " order by dia"
        Dim tablaConEmpleado As New DataTable()
        tablaConEmpleado.Load(comando.ExecuteReader)
        For Each fila As DataRow In tablaConEmpleado.Rows

            If fila("dia") = dia Then
                If fila("cellid") = "Obra" Then
                    contadorObra += 1
                End If
                If fila("cellid") = "Deposito" Then
                    contadorDeposito += 1
                End If
                If fila("cellid") = "Oficina" Then
                    contadorOficina += 1
                End If
                If fila("diaSemana") = 6 And fila("hora") >= 13 Then ''Sabado
                    _sabados += 1
                End If
                If fila("diaSemana") = 0 Then
                    _domingos += 1
                End If
            Else
                ''hacer calculo->que le guardo?
                calcularDiaTrabajado(contadorObra, contadorDeposito, contadorOficina)
                dia = Val(fila("dia"))
                contadorObra = 0
                contadorOficina = 0
                contadorDeposito = 0
                If fila("cellid") = "Obra" Then
                    contadorObra += 1
                End If
                If fila("cellid") = "Deposito" Then
                    contadorDeposito += 1
                End If
                If fila("cellid") = "Oficina" Then
                    contadorOficina += 1
                End If
                If fila("diaSemana") = 6 And fila("hora") >= 13 Then ''Sabado
                    _sabados += 1
                End If
                If fila("diaSemana") = 0 Then
                    _domingos += 1
                End If
            End If
        Next
        _diasTotal = _diasDeposito + _diasObra + _sabados + _domingos
        grilla.Rows.Add(nombre, _diasObra, _diasDeposito, _sabados, _domingos, "0", "0", _diasTotal, "0")
    End Sub
    ''' <summary>
    ''' Metodo que calcula si se le computa dia de oficina u obra al tecnico
    ''' </summary>
    ''' <param name="logueosObra"></param>
    ''' <param name="logueosDeposito"></param>
    ''' <param name="logueosOficina"></param>
    Sub calcularDiaTrabajado(logueosObra As Integer, logueosDeposito As Integer, logueosOficina As Integer)
        'If logueosOficina = 2 Or logueosDeposito = 2 Or (logueosOficina = 1 And logueosDeposito = 1) Then
        '    _diasDeposito += 1
        'End If
        If logueosObra <> 0 Then
            _diasObra += 1
        Else
            _diasDeposito += 1
        End If
    End Sub
End Class
