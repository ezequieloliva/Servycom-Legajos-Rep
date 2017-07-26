
Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Public Class rrhh
    Dim CONECTOR As New OleDbConnection(My.Settings.CADENA)
    Dim COMANDO As New OleDbCommand
    Dim adaptador As New OleDbDataAdapter(COMANDO)
    Dim TABLA As New DataTable
    Dim hoy As String
    Dim inicioMes As String
    Public desde_controlAcceso As DateTime
    Public hasta_controlAcceso As DateTime
    Dim ds As DataSet

    ''Eevento LOAD
    Private Sub rrhh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        hoy = dateHoy.Value.Date.ToString("dd/MM/yyyy")
        inicioMes = dateHoy.Value.Date.ToString("01/MM/yyyy")
        dateControlAccesoDesde.Value = Today
        cmboNovedadesMes.SelectedIndex = dateHoy.Value.Month - 1
        cargar_grilla_empleados() '' --> aca se llenan los combos tmb
        cargarGrillaLogueoDiario()
        cargarFrillaLogueoMensual()

        Dim mes As Integer
        cumples.Items.Clear()
        mes = CStr(dateHoy.Value.Month)

        Dim dr3 As OleDbDataReader
        Dim comandoo As New OleDbCommand
        comandoo = New OleDbCommand("select nombre from empledos where mes = '" & mes & "'", CONECTOR)
        CONECTOR.Open()
        dr3 = comandoo.ExecuteReader()
        If dr3.HasRows Then
            While dr3.Read

                lblCumple.Visible = True
                torta.Visible = True
                cumples.Items.Add(dr3("nombre"))
            End While
        End If
        CONECTOR.Close()
        radioSi.Checked = True
        For i = 2017 To 2027
            cmboNovedadesAñoFiltro.Items.Add(i.ToString)
        Next
        ''cargarNovedadesAñoActual()

    End Sub
    ''Cargar grilla con logueos con filtro por rango
    Sub cargarGrillaLogueoDeEmpleado(empleado As String, desdeDia As Integer, hastaDia As Integer, desdeMes As Integer, hastaMes As Integer, desdeAño As Integer, hastaAño As Integer)
        Dim objConexionMysql As New loginMYSQL
        objConexionMysql.conectarse()

        objConexionMysql.SelectSQL("select  dni as 'DNI', nombre as 'Nombre', fecha as 'Fecha de Logueo', latitud as 'Latitud', longitud as 'Longitud', cellid as 'Se logueo desde...' from login where dni='" & empleado & "' and año>= " & desdeAño & " and año <= " & hastaAño & " and mes>= " & desdeMes & " and mes<= " & hastaMes & " and (dia>= " & desdeDia & " or dia<= " & hastaDia & " )", grillaLogueoEmpleadoDiario)
        'objConexionMysql.SelectSQL("select * from login where dni='" & empleado & "' and dia>= " & dia_desde & " and mes>=" & mes_desde & " and año= " & año_desde & " and dia<= " & dia_hasta & " and mes<=" & mes_hasta & " and año= " & año_hasta & " order by fecha ", grillaLogueoEmpleadoDiario)
        objConexionMysql.desconectarse()
    End Sub
    ''cargar grilla conlogueos diarios
    Sub cargarGrillaLogueoDiario()
        Dim objConexionMysql As New loginMYSQL
        objConexionMysql.conectarse()

        objConexionMysql.SelectSQL("select dni as 'DNI', nombre as 'Nombre', fecha as 'Fecha de Logueo', latitud as 'Latitud', longitud as 'Longitud', cellid as 'Se logueo desde...' from login where fecha like'" & hoy & "%'", grillaLogueoDiario)
        objConexionMysql.desconectarse()
    End Sub
    ''cargar grilla con logueo mensual
    Sub cargarFrillaLogueoMensual()
        Dim objConexionMysql As New loginMYSQL
        objConexionMysql.conectarse()

        Dim mes As String = dateHoy.Value.Month.ToString()
        objConexionMysql.SelectSQL("select  dni as 'DNI', nombre as 'Nombre', fecha as 'Fecha de Logueo', latitud as 'Latitud', longitud as 'Longitud', cellid as 'Se logueo desde...' from login where mes= '" & mes & "'", grillaLogeuoMensual)
        objConexionMysql.desconectarse()
    End Sub
    ''procedimiento q carga la grilla con la nomina de empleados y pinta de rojo los legajos dados de baja
    Sub cargar_grilla_empleados()
        Dim hoy As Date
        hoy = txtFechaLlamado.Value.Date

        Dim ADAPTADOR As New OleDbDataAdapter(COMANDO)
        COMANDO.Connection = CONECTOR
        COMANDO.CommandType = CommandType.Text
        COMANDO.CommandText = "select * from empledos order by nombre asc"
        ADAPTADOR.Fill(TABLA)
        ''esto agregue
        llenar_combo_empleados_premios(comboFiltroEmpleados)
        llenar_combo_empleados_premios(comboEmpleadoLlamado)
        llenar_combo_empleados_premios(comboCapaEmpleado)
        llenar_combo_empleados_premios(comboEmpleadoNuevaCapa)
        llenar_combo_empleados_premios(comboEmplEntregasFiltro)
        llenar_combo_empleados_premios(comboEmpleadosEntregas)
        llenar_combo_empleados_premios(cmboEmpSueldo)
        llenar_combo_empleados_premios(cmboEmpRecibo)
        llenar_combo_empleados_premios(cmboEmpObs)
        llenar_combo_empleados_premios(cmboFiltroObs)
        llenar_combo_empleados_premios(cmboLogueosDeEmpleado)
        grillaEmpleados.DataSource = TABLA

        comboFiltroEmpleados.DisplayMember = "nombre"
        comboFiltroEmpleados.ValueMember = "dni"
        comboFiltroEmpleados.DataSource = TABLA
        llenar_combo_capacitaciones()
        For Each Row As DataGridViewRow In grillaEmpleados.Rows
            If Row.Cells("estado").Value = "Baja" Then
                Row.DefaultCellStyle.BackColor = Color.Red
            Else
                If CDate(Row.Cells("apto").Value) <= hoy Or CDate(Row.Cells("carnet").Value) <= hoy Then
                    Row.DefaultCellStyle.BackColor = Color.Yellow
                Else
                    Row.DefaultCellStyle.BackColor = Color.Green
                End If
            End If
        Next
    End Sub
    ''llenar combos con nombres de empleados dados de alta
    Public Sub llenar_combo_empleados_premios(combo As ComboBox)
        Dim tabl As New DataTable
        Dim ad As OleDbDataAdapter
        ad = New OleDbDataAdapter("select dni, nombre from empledos where estado='Alta'  order by nombre ", CONECTOR)
        ad.Fill(tabl)
        combo.DisplayMember = "nombre"
        combo.ValueMember = "dni"
        combo.DataSource = tabl
    End Sub
    ''procedimiento q llena el combo por titulo de capacitacion
    Sub llenar_combo_capacitaciones()

        Dim tabli As New DataTable
        Dim ADAPTADOR As New OleDbDataAdapter(COMANDO)
        COMANDO.Connection = CONECTOR
        COMANDO.CommandType = CommandType.TableDirect
        COMANDO.CommandText = "capacitaciones"
        ADAPTADOR.Fill(tabli)
        ''grillaCapa.DataSource = tabli
        comboCapacitaciones.DataSource = tabli
        comboCapacitaciones.DisplayMember = "titulo"

    End Sub
    ''Boton para insertar llamdos de atencion
    Private Sub btnInsertarLlamado_Click(sender As Object, e As EventArgs) Handles btnInsertarLlamado.Click
        insertarDatos()
    End Sub
    ''insertar llamados de atencion en tabla llamado
    Sub insertarDatos()

        Dim empleado As Integer
        Dim descripcion As String
        Dim fecha As String
        Dim tipo As String

        empleado = comboEmpleadoLlamado.SelectedValue

        descripcion = txtDetalleLlamado.Text
        fecha = txtFechaLlamado.Value.Date
        tipo = comboTipoLlamado.Text
        CONECTOR.Open()
        Dim comando As New OleDbCommand("insert into llamado values( " & empleado & ",'" & tipo & "','" & fecha & "','" & descripcion & "')", CONECTOR)
        comando.ExecuteNonQuery()
        CONECTOR.Close()
        txtDetalleLlamado.Text = ""
    End Sub
    '' llenar grilla con llamados de atencion de empleado filtrado en combo
    Private Sub btnBuscarEmpleadoLlamado_Click(sender As Object, e As EventArgs) Handles btnBuscarEmpleadoLlamado.Click
        grillaLlamado.Rows.Clear()
        Dim empleado As Integer
        Dim dr As OleDbDataReader
        empleado = comboFiltroEmpleados.SelectedValue

        COMANDO = New OleDbCommand("select dni,tipo,fecha,detalle from llamado where dni=" & empleado, CONECTOR)
        CONECTOR.Open()
        dr = COMANDO.ExecuteReader()

        If dr.HasRows Then
            While dr.Read
                grillaLlamado.Rows.Add(dr("dni"), dr("tipo"), dr("fecha"), dr("detalle"))
            End While
        Else
            MsgBox("No hay registros para " & comboFiltroEmpleados.Text.ToString)
        End If
        dr.Close()
        CONECTOR.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        NuevoLegajo.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ModificarLegajo.Show()
    End Sub

    ''cargar grilla con capcitaciones segun empleado elegido en combo
    Private Sub btnFiltrarXempleado_Click(sender As Object, e As EventArgs) Handles btnFiltrarXempleado.Click
        Dim empleado As Integer
        Dim dr As OleDbDataReader
        empleado = comboCapaEmpleado.SelectedValue
        COMANDO = New OleDbCommand("select * from capacitaciones where dni=" & empleado, CONECTOR)
        CONECTOR.Open()
        dr = COMANDO.ExecuteReader()
        If dr.HasRows Then
            While dr.Read
                grillaCapa.Rows.Add(comboCapaEmpleado.Text, dr("titulo"), dr("certificado"), dr("vencimiento"))
            End While
        End If
        CONECTOR.Close()

    End Sub
    ''cargar grilla con capacitaciones segun capa elegida en combo
    Private Sub btnFiltrarXcapacitacion_Click(sender As Object, e As EventArgs) Handles btnFiltrarXcapacitacion.Click

        Dim capacitacion As String
        Dim dr As OleDbDataReader
        capacitacion = comboCapacitaciones.Text
        COMANDO = New OleDbCommand("select * from capacitaciones where titulo='" & capacitacion & "'", CONECTOR)
        CONECTOR.Open()
        dr = COMANDO.ExecuteReader()
        If dr.HasRows Then
            While dr.Read
                grillaCapa.Rows.Add(dr("dni"), dr("titulo"), dr("certificado"), dr("vencimiento"))
            End While
        End If
        CONECTOR.Close()
    End Sub
    ''insertar capacitacion nueva
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        grillaCapa.Rows.Clear()
        Dim certificacion As String
        If radioSi.Checked Then
            certificacion = "SI"
        Else
            certificacion = "NO"
        End If
        CONECTOR.Open()
        Dim comando As New OleDbCommand("insert into capacitaciones values( " & comboEmpleadoNuevaCapa.SelectedValue & ",'" & comboEmpleadoNuevaCapa.Text & "','" & txtTituloNuevaCapa.Text & "','" & certificacion & "','" & txtVnecimientoCapaNeva.Text & "')", CONECTOR)
        comando.ExecuteNonQuery()

        ''actualizar grilla
        Dim dr As OleDbDataReader
        Dim COMAND = New OleDbCommand("select * from capacitaciones ", CONECTOR)

        dr = COMAND.ExecuteReader()
        If dr.HasRows Then
            While dr.Read
                grillaCapa.Rows.Add(dr("nombre"), dr("titulo"), dr("certificado"), dr("vencimiento"))
            End While
        End If
        CONECTOR.Close()
        txtTituloNuevaCapa.Text = ""
        txtVnecimientoCapaNeva.Text = ""
        llenar_combo_capacitaciones()
    End Sub
    ''Insertar los elementos entregados en tabla entregas
    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click

        Dim remera As String
        Dim pantalon As String
        Dim camisa As String
        Dim campera As String
        Dim buzo As String
        Dim zapatos As String
        If radioBuzo.Checked Then
            buzo = "SI"
        Else
            buzo = "NO"
        End If

        If radioCamisa.Checked Then
            camisa = "SI"
        Else
            camisa = "NO"
        End If

        If radioCampera.Checked Then
            campera = "SI"
        Else
            campera = "NO"
        End If

        If radioPantalon.Checked Then
            pantalon = "SI"
        Else
            pantalon = "NO"
        End If

        If radioRemera.Checked Then
            remera = "SI"
        Else
            remera = "NO"
        End If

        If radioZapatos.Checked Then
            zapatos = "SI"
        Else
            zapatos = "NO"
        End If
        CONECTOR.Open()
        Dim comando As New OleDbCommand("insert into entregas values( " & comboEmpleadosEntregas.SelectedValue & ",'" & comboEmpleadosEntregas.Text & "','" & txtFechaEntregas.Value.Date & "','" & remera & "','" & pantalon & "','" & camisa & "','" & campera & "','" & buzo & "','" & zapatos & "')", CONECTOR)
        comando.ExecuteNonQuery()

        ''actualizar grilla
        Dim dr As OleDbDataReader
        Dim COMAND = New OleDbCommand("select * from entregas ", CONECTOR)

        dr = COMAND.ExecuteReader()
        If dr.HasRows Then
            While dr.Read
                grillaEntregas.Rows.Add(dr("nombre"), dr("remera"), dr("pantalon"), dr("camisa"), dr("campera"), dr("buzo"), dr("zapatos"), dr("fecha"))
            End While
        End If
        CONECTOR.Close()
    End Sub
    ''cargar grilla con entregas de elementos de seguridad segun capa elegida en combo
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        grillaEntregas.Rows.Clear()

        Dim empleado As String
        Dim dr As OleDbDataReader
        empleado = comboEmplEntregasFiltro.Text
        COMANDO = New OleDbCommand("select * from entregas where nombre='" & empleado & "'", CONECTOR)
        CONECTOR.Open()
        dr = COMANDO.ExecuteReader()
        If dr.HasRows Then
            While dr.Read
                grillaEntregas.Rows.Add(dr("nombre"), dr("remera"), dr("pantalon"), dr("camisa"), dr("campera"), dr("buzo"), dr("zapatos"), dr("fecha"))
            End While
        End If
        CONECTOR.Close()
    End Sub
    ''ingresar recibo de sueldo
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        grillaSueldo.Rows.Clear()
        Dim entregado As String
        If chEntregado.Checked Then
            entregado = "SI"
        Else
            entregado = "NO"
        End If
        CONECTOR.Open()
        Dim comando As New OleDbCommand("insert into recibos values( '" & cmboEmpSueldo.Text & "','" & cmboMes.Text & "','" & entregado & "','" & txtFechaEntregadoRecibo.Value.Date & "')", CONECTOR)
        comando.ExecuteNonQuery()

        ''actualizar grilla
        Dim dr As OleDbDataReader
        Dim COMAND = New OleDbCommand("select * from recibos ", CONECTOR)

        dr = COMAND.ExecuteReader()
        If dr.HasRows Then
            While dr.Read
                grillaSueldo.Rows.Add(dr("empleado"), dr("mes"), dr("entregado"), dr("fecha"))
            End While
        End If
        CONECTOR.Close()


    End Sub
    ''filtrar y mostrar recibos de empleado
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        grillaSueldo.Rows.Clear()

        Dim empleado As String
        Dim dr As OleDbDataReader
        empleado = cmboEmpSueldo.Text
        COMANDO = New OleDbCommand("select * from recibos where empleado='" & empleado & "'", CONECTOR)
        CONECTOR.Open()
        dr = COMANDO.ExecuteReader()
        If dr.HasRows Then
            While dr.Read
                grillaSueldo.Rows.Add(dr("empleado"), dr("mes"), dr("entregado"), dr("fecha"))
            End While
        Else
            MsgBox("No hay registros ingresados para " & empleado)
        End If
        CONECTOR.Close()

    End Sub
    ''Insertar obwrvaciones
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

        grillaObs.Rows.Clear()

        CONECTOR.Open()
        Dim comando As New OleDbCommand("insert into observaciones values( '" & cmboEmpObs.Text & "','" & txtfechaObs.Value.Date & "','" & txtDetalleObs.Text & "')", CONECTOR)
        comando.ExecuteNonQuery()


        Dim dr As OleDbDataReader
        Dim COMAND = New OleDbCommand("select * from observaciones ", CONECTOR)

        dr = COMAND.ExecuteReader()
        If dr.HasRows Then
            While dr.Read
                grillaObs.Rows.Add(dr("nombre"), dr("fecha"), dr("detalle"))
            End While
        End If
        CONECTOR.Close()
        txtDetalleObs.Text = ""
    End Sub
    ''filtrar y mostrar recibos de empleado
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        grillaObs.Rows.Clear()

        Dim empleado As String
        Dim dr As OleDbDataReader
        empleado = cmboFiltroObs.Text
        COMANDO = New OleDbCommand("select * from observaciones where nombre='" & empleado & "'", CONECTOR)
        CONECTOR.Open()
        dr = COMANDO.ExecuteReader()
        If dr.HasRows Then
            While dr.Read
                grillaObs.Rows.Add(dr("nombre"), dr("fecha"), dr("detalle"))
            End While
        Else
            MsgBox("No hay registros ingresados para " & empleado)
        End If
        CONECTOR.Close()

    End Sub

    ''evento click del boton Cargar grilla de empleados
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        'grillaLogueoEmpleadoDiario.Rows.Clear()
        Dim desde_dia As Integer = dateControlAccesoDesde.Value.Day
        Dim desde_mes As Integer = dateControlAccesoDesde.Value.Month
        Dim desde_año As Integer = dateControlAccesoDesde.Value.Year
        Dim hasta_dia As Integer = dateControlAccesoHasta.Value.Day
        Dim hasta_mes As Integer = dateControlAccesoHasta.Value.Month
        Dim hasta_año As Integer = dateControlAccesoHasta.Value.Year


        cargarGrillaLogueoDeEmpleado(cmboLogueosDeEmpleado.SelectedValue, desde_dia, hasta_dia, desde_mes, hasta_mes, desde_año, hasta_año)
    End Sub
    ''Boton para exportar a excel logueo de empleado filtro desde-hasta
    Private Sub btnExportarExc_Click(sender As Object, e As EventArgs) Handles btnExportarExc.Click
        exportarExcel(grillaLogueoEmpleadoDiario)
    End Sub
    ''Sub exportar a excel
    Public Sub exportarExcel(grilla As DataGridView)
        Dim fichero As New SaveFileDialog()
        fichero.Filter = "Excel (*.xls)|*.xls"
        If fichero.ShowDialog() = DialogResult.OK Then
            Dim aplicacion As Microsoft.Office.Interop.Excel.Application
            Dim libros_trabajo As Microsoft.Office.Interop.Excel.Workbook
            Dim hoja_trabajo As Microsoft.Office.Interop.Excel.Worksheet
            aplicacion = New Microsoft.Office.Interop.Excel.Application()
            libros_trabajo = aplicacion.Workbooks.Add()
            hoja_trabajo = DirectCast(libros_trabajo.Worksheets.Item(1), Microsoft.Office.Interop.Excel.Worksheet)
            'Recorremos el DataGridView rellenando la hoja de trabajo
            Dim columnsCount As Integer = grilla.Columns.Count
            For i As Integer = 0 To grilla.Rows.Count - 2
                For j As Integer = 0 To grilla.Columns.Count - 1
                    If i = 0 Then 'pintamos cabecera
                        hoja_trabajo.Cells(i + 1, j + 1) = grilla.Columns(j).HeaderText
                    Else 'pintamos datos
                        hoja_trabajo.Cells(i + 1, j + 1) = grilla.Rows(i).Cells(j).Value.ToString()
                    End If
                Next
            Next
            libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
            libros_trabajo.Close(True)
            aplicacion.Quit()
        End If
    End Sub

    Private Sub btnControlAccesoExportarLogueoMensual_Click(sender As Object, e As EventArgs) Handles btnControlAccesoExportarLogueoMensual.Click
        exportarExcel(grillaLogeuoMensual)
    End Sub

    Private Sub btnControlAccesoExportarLogueoDiario_Click(sender As Object, e As EventArgs) Handles btnControlAccesoExportarLogueoDiario.Click
        exportarExcel(grillaLogueoDiario)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        cargarGrillaLogueoDiario()
        cargarFrillaLogueoMensual()
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.F8
                frmNuevoAdmin.Show()
            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)

        End Select

        Return True
    End Function

    Private Sub cmboNovedadesAñoFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboNovedadesAñoFiltro.SelectedIndexChanged
        cargarNovedades()
    End Sub
    ''' <summary>
    ''' Metodo privado que crga las novedades
    ''' </summary>
    Private Sub cargarNovedades()
        Dim objLoginMysql As New loginMYSQL
        objLoginMysql.conectarse()
        If cmboNovedadesMes.SelectedIndex = 0 Then
            objLoginMysql.Novedades(grillaNovedadesEnero, 1, Val(cmboNovedadesAñoFiltro.Text))
        ElseIf cmboNovedadesMes.SelectedIndex = 1 Then
            objLoginMysql.Novedades(grillaNovedadesFebrero, 2, Val(cmboNovedadesAñoFiltro.Text))
        ElseIf cmboNovedadesMes.SelectedIndex = 2 Then
            objLoginMysql.Novedades(grillaNovedadesMarzo, 3, Val(cmboNovedadesAñoFiltro.Text))
        ElseIf cmboNovedadesMes.SelectedIndex = 3 Then
            objLoginMysql.Novedades(grillaNovedadesAbril, 4, Val(cmboNovedadesAñoFiltro.Text))
        ElseIf cmboNovedadesMes.SelectedIndex = 4 Then
            objLoginMysql.Novedades(grillaNovedadesMayo, 5, Val(cmboNovedadesAñoFiltro.Text))
        ElseIf cmboNovedadesMes.SelectedIndex = 5 Then
            objLoginMysql.Novedades(grillaNovedadesJunio, 6, Val(cmboNovedadesAñoFiltro.Text))
        ElseIf cmboNovedadesMes.SelectedIndex = 6 Then
            objLoginMysql.Novedades(grillaNovedadesJulio, 7, Val(cmboNovedadesAñoFiltro.Text))
        ElseIf cmboNovedadesMes.SelectedIndex = 7 Then
            objLoginMysql.Novedades(grillaNovedadesAgosto, 8, Val(cmboNovedadesAñoFiltro.Text))
        ElseIf cmboNovedadesMes.SelectedIndex = 8 Then
            objLoginMysql.Novedades(grillaNovedadesSeptiembre, 9, Val(cmboNovedadesAñoFiltro.Text))
        ElseIf cmboNovedadesMes.SelectedIndex = 9 Then
            objLoginMysql.Novedades(grillaNovedadesOctubre, 10, Val(cmboNovedadesAñoFiltro.Text))
        ElseIf cmboNovedadesMes.SelectedIndex = 10 Then
            objLoginMysql.Novedades(grillaNovedadesNoviembe, 11, Val(cmboNovedadesAñoFiltro.Text))
        Else
            objLoginMysql.Novedades(grillaNovedadesDiciembre, 12, Val(cmboNovedadesAñoFiltro.Text))
        End If
        objLoginMysql.desconectarse()
    End Sub
    Private Sub cargarNovedadesAñoActual()
        Dim objLoginMysql As New loginMYSQL
        Dim año As Integer = dateHoy.Value.Year()
        Dim mes As Integer = dateHoy.Value.Month()
        objLoginMysql.conectarse()
        objLoginMysql.Novedades(grillaNovedadesEnero, 1, año)
        objLoginMysql.Novedades(grillaNovedadesFebrero, 2, año)
        objLoginMysql.Novedades(grillaNovedadesMarzo, 3, año)
        objLoginMysql.Novedades(grillaNovedadesAbril, 4, año)
        objLoginMysql.Novedades(grillaNovedadesMayo, 5, año)
        objLoginMysql.Novedades(grillaNovedadesJunio, 6, año)
        objLoginMysql.Novedades(grillaNovedadesJulio, 7, año)
        objLoginMysql.Novedades(grillaNovedadesAgosto, 8, año)
        objLoginMysql.Novedades(grillaNovedadesSeptiembre, 9, año)
        objLoginMysql.Novedades(grillaNovedadesOctubre, 10, año)
        objLoginMysql.Novedades(grillaNovedadesNoviembe, 11, año)
        objLoginMysql.Novedades(grillaNovedadesDiciembre, 12, año)
        objLoginMysql.desconectarse()
    End Sub
    ''Evento change del combo novedades por mes
    Private Sub cmboNovedadesMes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboNovedadesMes.SelectedIndexChanged
        cargarNovedades()
    End Sub
#Region "Expotar Novedades"
    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        exportarExcel(grillaNovedadesDiciembre)
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        exportarExcel(grillaNovedadesNoviembe)
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        exportarExcel(grillaNovedadesOctubre)
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        exportarExcel(grillaNovedadesSeptiembre)
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        exportarExcel(grillaNovedadesAgosto)
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        exportarExcel(grillaNovedadesJulio)
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        exportarExcel(grillaNovedadesJunio)
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        exportarExcel(grillaNovedadesMayo)
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        exportarExcel(grillaNovedadesAbril)
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        exportarExcel(grillaNovedadesMarzo)
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        exportarExcel(grillaNovedadesFebrero)
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        exportarExcel(grillaNovedadesEnero)
    End Sub
#End Region

    Private Sub TabPage24_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Cambio_de_contraseña.Show()
    End Sub

    Private Sub comboFiltroEmpleados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboFiltroEmpleados.SelectedIndexChanged

    End Sub
End Class