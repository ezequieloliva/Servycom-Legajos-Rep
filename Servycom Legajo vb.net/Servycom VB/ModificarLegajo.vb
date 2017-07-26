
Imports System.Data.OleDb
Public Class ModificarLegajo
    Dim CONECTOR As New OleDbConnection(My.Settings.CADENA)
    Dim COMANDO As New OleDbCommand
    Dim comand As New OleDbCommand
    Dim tablita As New DataTable
    Dim TABLA As New DataTable
    Dim ds As DataSet
    ''actualizar datos de un empleado en tabla empledos
    Private Sub btnGuardarCambios_Click(sender As Object, e As EventArgs) Handles btnGuardarCambios.Click

        ''rrhh.grillaEmpleados.Rows.Clear()
        CONECTOR.Open()
        Dim hoy As String
        hoy = txtFechaHoy.Value.Date

        Dim comando As New OleDbCommand("update empledos set dni=" & txtDniMod.Text & ",nombre='" & txtNombreMod.Text & "',dia='" & diaMod.Text & "',mes='" & mesMod.Text & "',ano='" & añoMod.Text & "',domicilio='" & txtDomicilioMod.Text & "',telefono='" & txtTelMod.Text & "',email='" & txtEmailMod.Text & "',civil='" & txtCivilMod.Text & "',hijos='" & txtHijosMod.Text & "',ingreso='" & txtIngresoMod.Text & "',cuit='" & txtCutMod.Text & "',cuenta='" & txtCuentaMod.Text & "',cbu='" & txtCbuMod.Text & "',seguro='" & txtSeguroMod.Text & "',carnet='" & txtCarnetMod.Text & "',apto='" & txtAptoMod.Text & "',puesto='" & txtPuestoMod.Text & "',estado='" & txtEstadoLegaoMod.Text & "' where nombre='" & txtNombreMod.Text & "'", CONECTOR)
        comando.ExecuteNonQuery()
        CONECTOR.Close()
        ''actualizar grilla
        Dim comandos As New OleDbCommand
        Dim ADAPTADOR As New OleDbDataAdapter(comandos)
        comandos.Connection = CONECTOR
        comandos.CommandType = CommandType.TableDirect
        comandos.CommandText = "empledos"
        ADAPTADOR.Fill(TABLA)
        rrhh.llenar_combo_empleados_premios(rrhh.comboFiltroEmpleados)
        rrhh.llenar_combo_empleados_premios(rrhh.comboEmpleadoLlamado)
        rrhh.llenar_combo_empleados_premios(rrhh.comboCapaEmpleado)
        rrhh.llenar_combo_empleados_premios(rrhh.comboEmpleadoNuevaCapa)
        rrhh.llenar_combo_empleados_premios(rrhh.comboEmplEntregasFiltro)
        rrhh.llenar_combo_empleados_premios(rrhh.comboEmpleadosEntregas)
        rrhh.llenar_combo_empleados_premios(rrhh.cmboEmpSueldo)
        rrhh.llenar_combo_empleados_premios(rrhh.cmboEmpRecibo)
        rrhh.llenar_combo_empleados_premios(rrhh.cmboEmpObs)
        rrhh.llenar_combo_empleados_premios(rrhh.cmboFiltroObs)
        rrhh.grillaEmpleados.DataSource = TABLA
        For Each Row As DataGridViewRow In rrhh.grillaEmpleados.Rows
            ''pintar de rojo los empleados dados de baja
            If Row.Cells("estado").Value = "Baja" Then
                Row.DefaultCellStyle.BackColor = Color.Red
            Else
                ''ver que si o si se llenen los campos
                If CDate(Row.Cells("apto").Value) <= hoy Or CDate(Row.Cells("carnet").Value) <= hoy Then
                    Row.DefaultCellStyle.BackColor = Color.Yellow
                Else
                    Row.DefaultCellStyle.BackColor = Color.Green
                End If
            End If

        Next
        ''cargar cumples del mes
        Dim mes As Integer
        rrhh.cumples.Items.Clear()
        mes = CStr(rrhh.dateHoy.Value.Month)
        Dim dr3 As OleDbDataReader
        Dim comandoo As New OleDbCommand
        comandoo = New OleDbCommand("select * from empledos where mes = '" & mes & "'", CONECTOR)
        CONECTOR.Open()
        dr3 = comandoo.ExecuteReader()
        If dr3.HasRows Then
            While dr3.Read

                rrhh.lblCumple.Visible = True
                rrhh.torta.Visible = True
                rrhh.cumples.Items.Add(dr3("nombre"))
            End While
        End If
        CONECTOR.Close()
        ''Borrar tecnico del logueo si es que se le dio de baja
        If txtEstadoLegaoMod.Text = "Baja" Then
            Dim objLoginMysql As New loginMYSQL
            objLoginMysql.conectarse()
            objLoginMysql.QuerySql("delete from usuario where dni='" & txtDniMod.Text & "'")
            objLoginMysql.desconectarse()
            Me.Close()
        End If

        MsgBox("Datos modificados correctamente")

    End Sub
    ''LOAD
    Private Sub ModificarLegajo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim hoy As String
        hoy = txtFechaHoy.Value.Date
        Dim adap As New OleDbDataAdapter(comand)
        comand.Connection = CONECTOR
        comand.CommandType = CommandType.Text
        comand.CommandText = "select * from empledos order by nombre"
        adap.Fill(tablita)
        txtNombreMod.DataSource = tablita
        txtNombreMod.DisplayMember = "nombre"
        txtNombreMod.ValueMember = "dni"

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '' mostrar las cajas de textos con datos del empleado elegido
        Dim dr As OleDbDataReader
        Dim COMAND As New OleDbCommand
        COMAND = New OleDbCommand("select * from empledos where dni=" & txtNombreMod.SelectedValue, CONECTOR)
        CONECTOR.Open()
        dr = COMAND.ExecuteReader()
        If dr.HasRows Then
            While dr.Read
                '' INGRESAR EN LAS CAJS DE TEXTO
                txtDniMod.Text = dr("dni")
                diaMod.Text = dr("dia")
                mesMod.Text = (dr("mes"))
                añoMod.Text = dr("ano")
                txtDomicilioMod.Text = dr("domicilio")
                txtTelMod.Text = dr("telefono")
                txtEmailMod.Text = dr("email")
                txtCivilMod.Text = dr("civil")
                txtHijosMod.Text = dr("hijos")
                txtIngresoMod.Text = dr("ingreso")
                txtCutMod.Text = dr("cuit")
                txtCuentaMod.Text = dr("cuenta")
                txtCbuMod.Text = dr("cbu")
                txtSeguroMod.Text = dr("seguro")
                txtCarnetMod.Text = dr("carnet")
                txtAptoMod.Text = dr("apto")
                txtPuestoMod.Text = dr("puesto")
                txtEstadoLegaoMod.Text = dr("estado")
            End While
        End If
        CONECTOR.Close()
    End Sub
#Region "Eventos change y key press"
    Private Sub txtDniMod_TextChanged(sender As Object, e As EventArgs) Handles txtDniMod.TextChanged
        If txtAptoMod.Text <> "" And txtCarnetMod.Text <> "" And txtCbuMod.Text <> "" And txtCivilMod.Text <> "" And txtCuentaMod.Text <> "" And txtCutMod.Text <> "" And txtDniMod.Text <> "" And txtDomicilioMod.Text <> "" And txtEmailMod.Text <> "" And txtEstadoLegaoMod.Text <> "" And txtFechaHoy.Text <> "" And txtHijosMod.Text <> "" And txtIngresoMod.Text <> "" And txtPuestoMod.Text <> "" And txtSeguroMod.Text <> "" And txtTelMod.Text <> "" Then
            btnGuardarCambios.Enabled = True
        Else
            btnGuardarCambios.Enabled = False
        End If
    End Sub

    Private Sub diaMod_TextChanged(sender As Object, e As EventArgs) Handles diaMod.TextChanged
        If txtAptoMod.Text <> "" And txtCarnetMod.Text <> "" And txtCbuMod.Text <> "" And txtCivilMod.Text <> "" And txtCuentaMod.Text <> "" And txtCutMod.Text <> "" And txtDniMod.Text <> "" And txtDomicilioMod.Text <> "" And txtEmailMod.Text <> "" And txtEstadoLegaoMod.Text <> "" And txtFechaHoy.Text <> "" And txtHijosMod.Text <> "" And txtIngresoMod.Text <> "" And txtPuestoMod.Text <> "" And txtSeguroMod.Text <> "" And txtTelMod.Text <> "" Then
            btnGuardarCambios.Enabled = True
        Else
            btnGuardarCambios.Enabled = False
        End If
    End Sub

    Private Sub mesMod_TextChanged(sender As Object, e As EventArgs) Handles mesMod.TextChanged
        If txtAptoMod.Text <> "" And txtCarnetMod.Text <> "" And txtCbuMod.Text <> "" And txtCivilMod.Text <> "" And txtCuentaMod.Text <> "" And txtCutMod.Text <> "" And txtDniMod.Text <> "" And txtDomicilioMod.Text <> "" And txtEmailMod.Text <> "" And txtEstadoLegaoMod.Text <> "" And txtFechaHoy.Text <> "" And txtHijosMod.Text <> "" And txtIngresoMod.Text <> "" And txtPuestoMod.Text <> "" And txtSeguroMod.Text <> "" And txtTelMod.Text <> "" Then
            btnGuardarCambios.Enabled = True
        Else
            btnGuardarCambios.Enabled = False
        End If
    End Sub

    Private Sub añoMod_TextChanged(sender As Object, e As EventArgs) Handles añoMod.TextChanged
        If txtAptoMod.Text <> "" And txtCarnetMod.Text <> "" And txtCbuMod.Text <> "" And txtCivilMod.Text <> "" And txtCuentaMod.Text <> "" And txtCutMod.Text <> "" And txtDniMod.Text <> "" And txtDomicilioMod.Text <> "" And txtEmailMod.Text <> "" And txtEstadoLegaoMod.Text <> "" And txtFechaHoy.Text <> "" And txtHijosMod.Text <> "" And txtIngresoMod.Text <> "" And txtPuestoMod.Text <> "" And txtSeguroMod.Text <> "" And txtTelMod.Text <> "" Then
            btnGuardarCambios.Enabled = True
        Else
            btnGuardarCambios.Enabled = False
        End If
    End Sub

    Private Sub txtDomicilioMod_TextChanged(sender As Object, e As EventArgs) Handles txtDomicilioMod.TextChanged
        If txtAptoMod.Text <> "" And txtCarnetMod.Text <> "" And txtCbuMod.Text <> "" And txtCivilMod.Text <> "" And txtCuentaMod.Text <> "" And txtCutMod.Text <> "" And txtDniMod.Text <> "" And txtDomicilioMod.Text <> "" And txtEmailMod.Text <> "" And txtEstadoLegaoMod.Text <> "" And txtFechaHoy.Text <> "" And txtHijosMod.Text <> "" And txtIngresoMod.Text <> "" And txtPuestoMod.Text <> "" And txtSeguroMod.Text <> "" And txtTelMod.Text <> "" Then
            btnGuardarCambios.Enabled = True
        Else
            btnGuardarCambios.Enabled = False
        End If
    End Sub

    Private Sub txtTelMod_TextChanged(sender As Object, e As EventArgs) Handles txtTelMod.TextChanged
        If txtAptoMod.Text <> "" And txtCarnetMod.Text <> "" And txtCbuMod.Text <> "" And txtCivilMod.Text <> "" And txtCuentaMod.Text <> "" And txtCutMod.Text <> "" And txtDniMod.Text <> "" And txtDomicilioMod.Text <> "" And txtEmailMod.Text <> "" And txtEstadoLegaoMod.Text <> "" And txtFechaHoy.Text <> "" And txtHijosMod.Text <> "" And txtIngresoMod.Text <> "" And txtPuestoMod.Text <> "" And txtSeguroMod.Text <> "" And txtTelMod.Text <> "" Then
            btnGuardarCambios.Enabled = True
        Else
            btnGuardarCambios.Enabled = False
        End If
    End Sub

    Private Sub txtEmailMod_TextChanged(sender As Object, e As EventArgs) Handles txtEmailMod.TextChanged
        If txtAptoMod.Text <> "" And txtCarnetMod.Text <> "" And txtCbuMod.Text <> "" And txtCivilMod.Text <> "" And txtCuentaMod.Text <> "" And txtCutMod.Text <> "" And txtDniMod.Text <> "" And txtDomicilioMod.Text <> "" And txtEmailMod.Text <> "" And txtEstadoLegaoMod.Text <> "" And txtFechaHoy.Text <> "" And txtHijosMod.Text <> "" And txtIngresoMod.Text <> "" And txtPuestoMod.Text <> "" And txtSeguroMod.Text <> "" And txtTelMod.Text <> "" Then
            btnGuardarCambios.Enabled = True
        Else
            btnGuardarCambios.Enabled = False
        End If
    End Sub

    Private Sub txtCivilMod_TextChanged(sender As Object, e As EventArgs) Handles txtCivilMod.TextChanged
        If txtAptoMod.Text <> "" And txtCarnetMod.Text <> "" And txtCbuMod.Text <> "" And txtCivilMod.Text <> "" And txtCuentaMod.Text <> "" And txtCutMod.Text <> "" And txtDniMod.Text <> "" And txtDomicilioMod.Text <> "" And txtEmailMod.Text <> "" And txtEstadoLegaoMod.Text <> "" And txtFechaHoy.Text <> "" And txtHijosMod.Text <> "" And txtIngresoMod.Text <> "" And txtPuestoMod.Text <> "" And txtSeguroMod.Text <> "" And txtTelMod.Text <> "" Then
            btnGuardarCambios.Enabled = True
        Else
            btnGuardarCambios.Enabled = False
        End If
    End Sub

    Private Sub txtHijosMod_TextChanged(sender As Object, e As EventArgs) Handles txtHijosMod.TextChanged
        If txtAptoMod.Text <> "" And txtCarnetMod.Text <> "" And txtCbuMod.Text <> "" And txtCivilMod.Text <> "" And txtCuentaMod.Text <> "" And txtCutMod.Text <> "" And txtDniMod.Text <> "" And txtDomicilioMod.Text <> "" And txtEmailMod.Text <> "" And txtEstadoLegaoMod.Text <> "" And txtFechaHoy.Text <> "" And txtHijosMod.Text <> "" And txtIngresoMod.Text <> "" And txtPuestoMod.Text <> "" And txtSeguroMod.Text <> "" And txtTelMod.Text <> "" Then
            btnGuardarCambios.Enabled = True
        Else
            btnGuardarCambios.Enabled = False
        End If
    End Sub

    Private Sub txtIngresoMod_TextChanged(sender As Object, e As EventArgs) Handles txtIngresoMod.TextChanged
        If txtAptoMod.Text <> "" And txtCarnetMod.Text <> "" And txtCbuMod.Text <> "" And txtCivilMod.Text <> "" And txtCuentaMod.Text <> "" And txtCutMod.Text <> "" And txtDniMod.Text <> "" And txtDomicilioMod.Text <> "" And txtEmailMod.Text <> "" And txtEstadoLegaoMod.Text <> "" And txtFechaHoy.Text <> "" And txtHijosMod.Text <> "" And txtIngresoMod.Text <> "" And txtPuestoMod.Text <> "" And txtSeguroMod.Text <> "" And txtTelMod.Text <> "" Then
            btnGuardarCambios.Enabled = True
        Else
            btnGuardarCambios.Enabled = False
        End If
    End Sub

    Private Sub txtCutMod_TextChanged(sender As Object, e As EventArgs) Handles txtCutMod.TextChanged
        If txtAptoMod.Text <> "" And txtCarnetMod.Text <> "" And txtCbuMod.Text <> "" And txtCivilMod.Text <> "" And txtCuentaMod.Text <> "" And txtCutMod.Text <> "" And txtDniMod.Text <> "" And txtDomicilioMod.Text <> "" And txtEmailMod.Text <> "" And txtEstadoLegaoMod.Text <> "" And txtFechaHoy.Text <> "" And txtHijosMod.Text <> "" And txtIngresoMod.Text <> "" And txtPuestoMod.Text <> "" And txtSeguroMod.Text <> "" And txtTelMod.Text <> "" Then
            btnGuardarCambios.Enabled = True
        Else
            btnGuardarCambios.Enabled = False
        End If
    End Sub

    Private Sub txtCuentaMod_TextChanged(sender As Object, e As EventArgs) Handles txtCuentaMod.TextChanged
        If txtAptoMod.Text <> "" And txtCarnetMod.Text <> "" And txtCbuMod.Text <> "" And txtCivilMod.Text <> "" And txtCuentaMod.Text <> "" And txtCutMod.Text <> "" And txtDniMod.Text <> "" And txtDomicilioMod.Text <> "" And txtEmailMod.Text <> "" And txtEstadoLegaoMod.Text <> "" And txtFechaHoy.Text <> "" And txtHijosMod.Text <> "" And txtIngresoMod.Text <> "" And txtPuestoMod.Text <> "" And txtSeguroMod.Text <> "" And txtTelMod.Text <> "" Then
            btnGuardarCambios.Enabled = True
        Else
            btnGuardarCambios.Enabled = False
        End If
    End Sub

    Private Sub txtCbuMod_TextChanged(sender As Object, e As EventArgs) Handles txtCbuMod.TextChanged
        If txtAptoMod.Text <> "" And txtCarnetMod.Text <> "" And txtCbuMod.Text <> "" And txtCivilMod.Text <> "" And txtCuentaMod.Text <> "" And txtCutMod.Text <> "" And txtDniMod.Text <> "" And txtDomicilioMod.Text <> "" And txtEmailMod.Text <> "" And txtEstadoLegaoMod.Text <> "" And txtFechaHoy.Text <> "" And txtHijosMod.Text <> "" And txtIngresoMod.Text <> "" And txtPuestoMod.Text <> "" And txtSeguroMod.Text <> "" And txtTelMod.Text <> "" Then
            btnGuardarCambios.Enabled = True
        Else
            btnGuardarCambios.Enabled = False
        End If
    End Sub

    Private Sub txtSeguroMod_TextChanged(sender As Object, e As EventArgs) Handles txtSeguroMod.TextChanged
        If txtAptoMod.Text <> "" And txtCarnetMod.Text <> "" And txtCbuMod.Text <> "" And txtCivilMod.Text <> "" And txtCuentaMod.Text <> "" And txtCutMod.Text <> "" And txtDniMod.Text <> "" And txtDomicilioMod.Text <> "" And txtEmailMod.Text <> "" And txtEstadoLegaoMod.Text <> "" And txtFechaHoy.Text <> "" And txtHijosMod.Text <> "" And txtIngresoMod.Text <> "" And txtPuestoMod.Text <> "" And txtSeguroMod.Text <> "" And txtTelMod.Text <> "" Then
            btnGuardarCambios.Enabled = True
        Else
            btnGuardarCambios.Enabled = False
        End If
    End Sub

    Private Sub txtCarnetMod_TextChanged(sender As Object, e As EventArgs) Handles txtCarnetMod.TextChanged
        If txtAptoMod.Text <> "" And txtCarnetMod.Text <> "" And txtCbuMod.Text <> "" And txtCivilMod.Text <> "" And txtCuentaMod.Text <> "" And txtCutMod.Text <> "" And txtDniMod.Text <> "" And txtDomicilioMod.Text <> "" And txtEmailMod.Text <> "" And txtEstadoLegaoMod.Text <> "" And txtFechaHoy.Text <> "" And txtHijosMod.Text <> "" And txtIngresoMod.Text <> "" And txtPuestoMod.Text <> "" And txtSeguroMod.Text <> "" And txtTelMod.Text <> "" Then
            btnGuardarCambios.Enabled = True
        Else
            btnGuardarCambios.Enabled = False
        End If
    End Sub

    Private Sub txtAptoMod_TextChanged(sender As Object, e As EventArgs) Handles txtAptoMod.TextChanged
        If txtAptoMod.Text <> "" And txtCarnetMod.Text <> "" And txtCbuMod.Text <> "" And txtCivilMod.Text <> "" And txtCuentaMod.Text <> "" And txtCutMod.Text <> "" And txtDniMod.Text <> "" And txtDomicilioMod.Text <> "" And txtEmailMod.Text <> "" And txtEstadoLegaoMod.Text <> "" And txtFechaHoy.Text <> "" And txtHijosMod.Text <> "" And txtIngresoMod.Text <> "" And txtPuestoMod.Text <> "" And txtSeguroMod.Text <> "" And txtTelMod.Text <> "" Then
            btnGuardarCambios.Enabled = True
        Else
            btnGuardarCambios.Enabled = False
        End If
    End Sub

    Private Sub txtPuestoMod_TextChanged(sender As Object, e As EventArgs) Handles txtPuestoMod.TextChanged
        If txtAptoMod.Text <> "" And txtCarnetMod.Text <> "" And txtCbuMod.Text <> "" And txtCivilMod.Text <> "" And txtCuentaMod.Text <> "" And txtCutMod.Text <> "" And txtDniMod.Text <> "" And txtDomicilioMod.Text <> "" And txtEmailMod.Text <> "" And txtEstadoLegaoMod.Text <> "" And txtFechaHoy.Text <> "" And txtHijosMod.Text <> "" And txtIngresoMod.Text <> "" And txtPuestoMod.Text <> "" And txtSeguroMod.Text <> "" And txtTelMod.Text <> "" Then
            btnGuardarCambios.Enabled = True
        Else
            btnGuardarCambios.Enabled = False
        End If
    End Sub

    Private Sub txtEstadoLegaoMod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtEstadoLegaoMod.SelectedIndexChanged
        If txtAptoMod.Text <> "" And txtCarnetMod.Text <> "" And txtCbuMod.Text <> "" And txtCivilMod.Text <> "" And txtCuentaMod.Text <> "" And txtCutMod.Text <> "" And txtDniMod.Text <> "" And txtDomicilioMod.Text <> "" And txtEmailMod.Text <> "" And txtEstadoLegaoMod.Text <> "" And txtFechaHoy.Text <> "" And txtHijosMod.Text <> "" And txtIngresoMod.Text <> "" And txtPuestoMod.Text <> "" And txtSeguroMod.Text <> "" And txtTelMod.Text <> "" Then
            btnGuardarCambios.Enabled = True
        Else
            btnGuardarCambios.Enabled = False
        End If
    End Sub
#End Region

End Class