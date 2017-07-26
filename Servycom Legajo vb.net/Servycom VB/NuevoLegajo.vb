
Imports System.Data.OleDb
Public Class NuevoLegajo
    Dim CONECTOR As New OleDbConnection(My.Settings.CADENA)
    Dim COMANDO As New OleDbCommand

    Dim TABLA As New DataTable
    Dim ds As DataSet
    ''Boton que guarda datos
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGuardarNuevoLegajo.Click
        guardarDatos()
        Me.Close()
    End Sub
    ''insertar nuevo legajo-empleado
    Sub guardarDatos()

        Dim hoy As Date
        hoy = txtHoy.Value.Date
        CONECTOR.Open()
        Dim comando As New OleDbCommand("insert into empledos values( " & CInt(txtDniNuevo.Text) & ",'" & txtNombreNuevo.Text & "','" & dia.Text & "','" & txtmes.Text & "','" & año.Text & "','" & txtDomicilioNuevo.Text & "','" & txtTelNuevo.Text & "','" & txtEmailNuevo.Text & "','" & txtCivilNuevo.Text & "'," & CInt(txtHijosNuevo.Text) & ",'" & txtIngresoNuevo.Text & "','" & txtCutNuevo.Text & "','" & txtCuentaNueva.Text & "','" & txtCbuNuevo.Text & "','" & txtSeguroNuevo.Text & "','" & txtCarnetNuevo.Text & "','" & txtAptoNuevo.Text & "','" & txtPuestoNuevo.Text & "','" & txtEstadoLegaoNuevo.Text & "')", CONECTOR)
        comando.ExecuteNonQuery()
        CONECTOR.Close()
        ''actualizar grilla

        Dim comandos As New OleDbCommand
        Dim ADAPTADOR As New OleDbDataAdapter(comandos)
        comandos.Connection = CONECTOR
        comandos.CommandType = CommandType.TableDirect
        comandos.CommandText = "empledos"
        ADAPTADOR.Fill(TABLA)
        rrhh.grillaEmpleados.DataSource = TABLA


        rrhh.comboFiltroEmpleados.DisplayMember = "nombre"
        rrhh.comboFiltroEmpleados.ValueMember = "dni"
        rrhh.comboFiltroEmpleados.DataSource = TABLA


        rrhh.comboEmpleadoLlamado.DisplayMember = "nombre"
        rrhh.comboEmpleadoLlamado.ValueMember = "dni"
        rrhh.comboEmpleadoLlamado.DataSource = TABLA


        rrhh.comboCapaEmpleado.DisplayMember = "nombre"
        rrhh.comboCapaEmpleado.ValueMember = "dni"
        rrhh.comboCapaEmpleado.DataSource = TABLA


        rrhh.comboEmpleadoNuevaCapa.DisplayMember = "nombre"
        rrhh.comboEmpleadoNuevaCapa.ValueMember = "dni"
        rrhh.comboEmpleadoNuevaCapa.DataSource = TABLA


        rrhh.comboEmplEntregasFiltro.DisplayMember = "nombre"
        rrhh.comboEmplEntregasFiltro.ValueMember = "dni"
        rrhh.comboEmplEntregasFiltro.DataSource = TABLA


        rrhh.comboEmpleadosEntregas.DisplayMember = "nombre"
        rrhh.comboEmpleadosEntregas.ValueMember = "dni"
        rrhh.comboEmpleadosEntregas.DataSource = TABLA

        rrhh.cmboEmpSueldo.DisplayMember = "nombre"
        rrhh.cmboEmpSueldo.DataSource = TABLA

        rrhh.cmboEmpRecibo.DisplayMember = "nombre"
        rrhh.cmboEmpRecibo.DataSource = TABLA

        rrhh.cmboEmpObs.DisplayMember = "nombre"
        rrhh.cmboEmpObs.DataSource = TABLA

        rrhh.cmboFiltroObs.DisplayMember = "nombre"
        rrhh.cmboFiltroObs.DataSource = TABLA



        ''pintar los dados de baja
        For Each Row As DataGridViewRow In rrhh.grillaEmpleados.Rows
            ''pintar de rojo los empleados dados de baja
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
        ''Ingresar e nuevo legajo al logueo
        Dim objLoginMysql As New loginMYSQL
        objLoginMysql.conectarse()
        objLoginMysql.QuerySql("insert into usuario (dni,nombre)values ('" & txtDniNuevo.Text & "','" & txtNombreNuevo.Text & "')")
        objLoginMysql.desconectarse()
    End Sub
    ''LOAD de form nuevo legajo
    Private Sub NuevoLegajo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For x = 1 To 31
            dia.Items.Add(x)
        Next
        For y = 1 To 12
            txtmes.Items.Add(y)
        Next
        For z = 1900 To 2100
            año.Items.Add(z)
        Next
    End Sub
#Region "Eventos change y keypress"
    Private Sub txtDniNuevo_TextChanged(sender As Object, e As EventArgs) Handles txtDniNuevo.TextChanged
        If txtAptoNuevo.Text <> "" And txtCarnetNuevo.Text <> "" And txtCbuNuevo.Text <> "" And txtCivilNuevo.Text <> "" And txtCuentaNueva.Text <> "" And txtCutNuevo.Text <> "" And txtDniNuevo.Text <> "" And txtDomicilioNuevo.Text <> "" And txtEmailNuevo.Text <> "" And txtEstadoLegaoNuevo.Text <> "" And txtHijosNuevo.Text <> "" And txtHoy.Text <> "" And txtIngresoNuevo.Text <> "" And txtmes.Text <> "" And txtNombreNuevo.Text <> "" And txtPuestoNuevo.Text <> "" And txtSeguroNuevo.Text <> "" And txtTelNuevo.Text <> "" Then
            btnGuardarNuevoLegajo.Enabled = True
        Else
            btnGuardarNuevoLegajo.Enabled = False
        End If
    End Sub

    Private Sub txtNombreNuevo_TextChanged(sender As Object, e As EventArgs) Handles txtNombreNuevo.TextChanged
        If txtAptoNuevo.Text <> "" And txtCarnetNuevo.Text <> "" And txtCbuNuevo.Text <> "" And txtCivilNuevo.Text <> "" And txtCuentaNueva.Text <> "" And txtCutNuevo.Text <> "" And txtDniNuevo.Text <> "" And txtDomicilioNuevo.Text <> "" And txtEmailNuevo.Text <> "" And txtEstadoLegaoNuevo.Text <> "" And txtHijosNuevo.Text <> "" And txtHoy.Text <> "" And txtIngresoNuevo.Text <> "" And txtmes.Text <> "" And txtNombreNuevo.Text <> "" And txtPuestoNuevo.Text <> "" And txtSeguroNuevo.Text <> "" And txtTelNuevo.Text <> "" Then
            btnGuardarNuevoLegajo.Enabled = True
        Else
            btnGuardarNuevoLegajo.Enabled = False
        End If
    End Sub

    Private Sub dia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dia.SelectedIndexChanged
        If txtAptoNuevo.Text <> "" And txtCarnetNuevo.Text <> "" And txtCbuNuevo.Text <> "" And txtCivilNuevo.Text <> "" And txtCuentaNueva.Text <> "" And txtCutNuevo.Text <> "" And txtDniNuevo.Text <> "" And txtDomicilioNuevo.Text <> "" And txtEmailNuevo.Text <> "" And txtEstadoLegaoNuevo.Text <> "" And txtHijosNuevo.Text <> "" And txtHoy.Text <> "" And txtIngresoNuevo.Text <> "" And txtmes.Text <> "" And txtNombreNuevo.Text <> "" And txtPuestoNuevo.Text <> "" And txtSeguroNuevo.Text <> "" And txtTelNuevo.Text <> "" Then
            btnGuardarNuevoLegajo.Enabled = True
        Else
            btnGuardarNuevoLegajo.Enabled = False
        End If
    End Sub

    Private Sub txtmes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtmes.SelectedIndexChanged
        If txtAptoNuevo.Text <> "" And txtCarnetNuevo.Text <> "" And txtCbuNuevo.Text <> "" And txtCivilNuevo.Text <> "" And txtCuentaNueva.Text <> "" And txtCutNuevo.Text <> "" And txtDniNuevo.Text <> "" And txtDomicilioNuevo.Text <> "" And txtEmailNuevo.Text <> "" And txtEstadoLegaoNuevo.Text <> "" And txtHijosNuevo.Text <> "" And txtHoy.Text <> "" And txtIngresoNuevo.Text <> "" And txtmes.Text <> "" And txtNombreNuevo.Text <> "" And txtPuestoNuevo.Text <> "" And txtSeguroNuevo.Text <> "" And txtTelNuevo.Text <> "" Then
            btnGuardarNuevoLegajo.Enabled = True
        Else
            btnGuardarNuevoLegajo.Enabled = False
        End If
    End Sub

    Private Sub año_SelectedIndexChanged(sender As Object, e As EventArgs) Handles año.SelectedIndexChanged
        If txtAptoNuevo.Text <> "" And txtCarnetNuevo.Text <> "" And txtCbuNuevo.Text <> "" And txtCivilNuevo.Text <> "" And txtCuentaNueva.Text <> "" And txtCutNuevo.Text <> "" And txtDniNuevo.Text <> "" And txtDomicilioNuevo.Text <> "" And txtEmailNuevo.Text <> "" And txtEstadoLegaoNuevo.Text <> "" And txtHijosNuevo.Text <> "" And txtHoy.Text <> "" And txtIngresoNuevo.Text <> "" And txtmes.Text <> "" And txtNombreNuevo.Text <> "" And txtPuestoNuevo.Text <> "" And txtSeguroNuevo.Text <> "" And txtTelNuevo.Text <> "" Then
            btnGuardarNuevoLegajo.Enabled = True
        Else
            btnGuardarNuevoLegajo.Enabled = False
        End If
    End Sub

    Private Sub txtDomicilioNuevo_TextChanged(sender As Object, e As EventArgs) Handles txtDomicilioNuevo.TextChanged
        If txtAptoNuevo.Text <> "" And txtCarnetNuevo.Text <> "" And txtCbuNuevo.Text <> "" And txtCivilNuevo.Text <> "" And txtCuentaNueva.Text <> "" And txtCutNuevo.Text <> "" And txtDniNuevo.Text <> "" And txtDomicilioNuevo.Text <> "" And txtEmailNuevo.Text <> "" And txtEstadoLegaoNuevo.Text <> "" And txtHijosNuevo.Text <> "" And txtHoy.Text <> "" And txtIngresoNuevo.Text <> "" And txtmes.Text <> "" And txtNombreNuevo.Text <> "" And txtPuestoNuevo.Text <> "" And txtSeguroNuevo.Text <> "" And txtTelNuevo.Text <> "" Then
            btnGuardarNuevoLegajo.Enabled = True
        Else
            btnGuardarNuevoLegajo.Enabled = False
        End If
    End Sub

    Private Sub txtTelNuevo_TextChanged(sender As Object, e As EventArgs) Handles txtTelNuevo.TextChanged
        If txtAptoNuevo.Text <> "" And txtCarnetNuevo.Text <> "" And txtCbuNuevo.Text <> "" And txtCivilNuevo.Text <> "" And txtCuentaNueva.Text <> "" And txtCutNuevo.Text <> "" And txtDniNuevo.Text <> "" And txtDomicilioNuevo.Text <> "" And txtEmailNuevo.Text <> "" And txtEstadoLegaoNuevo.Text <> "" And txtHijosNuevo.Text <> "" And txtHoy.Text <> "" And txtIngresoNuevo.Text <> "" And txtmes.Text <> "" And txtNombreNuevo.Text <> "" And txtPuestoNuevo.Text <> "" And txtSeguroNuevo.Text <> "" And txtTelNuevo.Text <> "" Then
            btnGuardarNuevoLegajo.Enabled = True
        Else
            btnGuardarNuevoLegajo.Enabled = False
        End If
    End Sub

    Private Sub txtEmailNuevo_TextChanged(sender As Object, e As EventArgs) Handles txtEmailNuevo.TextChanged
        If txtAptoNuevo.Text <> "" And txtCarnetNuevo.Text <> "" And txtCbuNuevo.Text <> "" And txtCivilNuevo.Text <> "" And txtCuentaNueva.Text <> "" And txtCutNuevo.Text <> "" And txtDniNuevo.Text <> "" And txtDomicilioNuevo.Text <> "" And txtEmailNuevo.Text <> "" And txtEstadoLegaoNuevo.Text <> "" And txtHijosNuevo.Text <> "" And txtHoy.Text <> "" And txtIngresoNuevo.Text <> "" And txtmes.Text <> "" And txtNombreNuevo.Text <> "" And txtPuestoNuevo.Text <> "" And txtSeguroNuevo.Text <> "" And txtTelNuevo.Text <> "" Then
            btnGuardarNuevoLegajo.Enabled = True
        Else
            btnGuardarNuevoLegajo.Enabled = False
        End If
    End Sub

    Private Sub txtCivilNuevo_TextChanged(sender As Object, e As EventArgs) Handles txtCivilNuevo.TextChanged
        If txtAptoNuevo.Text <> "" And txtCarnetNuevo.Text <> "" And txtCbuNuevo.Text <> "" And txtCivilNuevo.Text <> "" And txtCuentaNueva.Text <> "" And txtCutNuevo.Text <> "" And txtDniNuevo.Text <> "" And txtDomicilioNuevo.Text <> "" And txtEmailNuevo.Text <> "" And txtEstadoLegaoNuevo.Text <> "" And txtHijosNuevo.Text <> "" And txtHoy.Text <> "" And txtIngresoNuevo.Text <> "" And txtmes.Text <> "" And txtNombreNuevo.Text <> "" And txtPuestoNuevo.Text <> "" And txtSeguroNuevo.Text <> "" And txtTelNuevo.Text <> "" Then
            btnGuardarNuevoLegajo.Enabled = True
        Else
            btnGuardarNuevoLegajo.Enabled = False
        End If
    End Sub

    Private Sub txtHijosNuevo_TextChanged(sender As Object, e As EventArgs) Handles txtHijosNuevo.TextChanged
        If txtAptoNuevo.Text <> "" And txtCarnetNuevo.Text <> "" And txtCbuNuevo.Text <> "" And txtCivilNuevo.Text <> "" And txtCuentaNueva.Text <> "" And txtCutNuevo.Text <> "" And txtDniNuevo.Text <> "" And txtDomicilioNuevo.Text <> "" And txtEmailNuevo.Text <> "" And txtEstadoLegaoNuevo.Text <> "" And txtHijosNuevo.Text <> "" And txtHoy.Text <> "" And txtIngresoNuevo.Text <> "" And txtmes.Text <> "" And txtNombreNuevo.Text <> "" And txtPuestoNuevo.Text <> "" And txtSeguroNuevo.Text <> "" And txtTelNuevo.Text <> "" Then
            btnGuardarNuevoLegajo.Enabled = True
        Else
            btnGuardarNuevoLegajo.Enabled = False
        End If
    End Sub

    Private Sub txtIngresoNuevo_TextChanged(sender As Object, e As EventArgs) Handles txtIngresoNuevo.TextChanged
        If txtAptoNuevo.Text <> "" And txtCarnetNuevo.Text <> "" And txtCbuNuevo.Text <> "" And txtCivilNuevo.Text <> "" And txtCuentaNueva.Text <> "" And txtCutNuevo.Text <> "" And txtDniNuevo.Text <> "" And txtDomicilioNuevo.Text <> "" And txtEmailNuevo.Text <> "" And txtEstadoLegaoNuevo.Text <> "" And txtHijosNuevo.Text <> "" And txtHoy.Text <> "" And txtIngresoNuevo.Text <> "" And txtmes.Text <> "" And txtNombreNuevo.Text <> "" And txtPuestoNuevo.Text <> "" And txtSeguroNuevo.Text <> "" And txtTelNuevo.Text <> "" Then
            btnGuardarNuevoLegajo.Enabled = True
        Else
            btnGuardarNuevoLegajo.Enabled = False
        End If
    End Sub

    Private Sub txtCutNuevo_TextChanged(sender As Object, e As EventArgs) Handles txtCutNuevo.TextChanged
        If txtAptoNuevo.Text <> "" And txtCarnetNuevo.Text <> "" And txtCbuNuevo.Text <> "" And txtCivilNuevo.Text <> "" And txtCuentaNueva.Text <> "" And txtCutNuevo.Text <> "" And txtDniNuevo.Text <> "" And txtDomicilioNuevo.Text <> "" And txtEmailNuevo.Text <> "" And txtEstadoLegaoNuevo.Text <> "" And txtHijosNuevo.Text <> "" And txtHoy.Text <> "" And txtIngresoNuevo.Text <> "" And txtmes.Text <> "" And txtNombreNuevo.Text <> "" And txtPuestoNuevo.Text <> "" And txtSeguroNuevo.Text <> "" And txtTelNuevo.Text <> "" Then
            btnGuardarNuevoLegajo.Enabled = True
        Else
            btnGuardarNuevoLegajo.Enabled = False
        End If
    End Sub

    Private Sub txtCuentaNueva_TextChanged(sender As Object, e As EventArgs) Handles txtCuentaNueva.TextChanged
        If txtAptoNuevo.Text <> "" And txtCarnetNuevo.Text <> "" And txtCbuNuevo.Text <> "" And txtCivilNuevo.Text <> "" And txtCuentaNueva.Text <> "" And txtCutNuevo.Text <> "" And txtDniNuevo.Text <> "" And txtDomicilioNuevo.Text <> "" And txtEmailNuevo.Text <> "" And txtEstadoLegaoNuevo.Text <> "" And txtHijosNuevo.Text <> "" And txtHoy.Text <> "" And txtIngresoNuevo.Text <> "" And txtmes.Text <> "" And txtNombreNuevo.Text <> "" And txtPuestoNuevo.Text <> "" And txtSeguroNuevo.Text <> "" And txtTelNuevo.Text <> "" Then
            btnGuardarNuevoLegajo.Enabled = True
        Else
            btnGuardarNuevoLegajo.Enabled = False
        End If
    End Sub

    Private Sub txtCbuNuevo_TextChanged(sender As Object, e As EventArgs) Handles txtCbuNuevo.TextChanged
        If txtAptoNuevo.Text <> "" And txtCarnetNuevo.Text <> "" And txtCbuNuevo.Text <> "" And txtCivilNuevo.Text <> "" And txtCuentaNueva.Text <> "" And txtCutNuevo.Text <> "" And txtDniNuevo.Text <> "" And txtDomicilioNuevo.Text <> "" And txtEmailNuevo.Text <> "" And txtEstadoLegaoNuevo.Text <> "" And txtHijosNuevo.Text <> "" And txtHoy.Text <> "" And txtIngresoNuevo.Text <> "" And txtmes.Text <> "" And txtNombreNuevo.Text <> "" And txtPuestoNuevo.Text <> "" And txtSeguroNuevo.Text <> "" And txtTelNuevo.Text <> "" Then
            btnGuardarNuevoLegajo.Enabled = True
        Else
            btnGuardarNuevoLegajo.Enabled = False
        End If
    End Sub

    Private Sub txtSeguroNuevo_TextChanged(sender As Object, e As EventArgs) Handles txtSeguroNuevo.TextChanged
        If txtAptoNuevo.Text <> "" And txtCarnetNuevo.Text <> "" And txtCbuNuevo.Text <> "" And txtCivilNuevo.Text <> "" And txtCuentaNueva.Text <> "" And txtCutNuevo.Text <> "" And txtDniNuevo.Text <> "" And txtDomicilioNuevo.Text <> "" And txtEmailNuevo.Text <> "" And txtEstadoLegaoNuevo.Text <> "" And txtHijosNuevo.Text <> "" And txtHoy.Text <> "" And txtIngresoNuevo.Text <> "" And txtmes.Text <> "" And txtNombreNuevo.Text <> "" And txtPuestoNuevo.Text <> "" And txtSeguroNuevo.Text <> "" And txtTelNuevo.Text <> "" Then
            btnGuardarNuevoLegajo.Enabled = True
        Else
            btnGuardarNuevoLegajo.Enabled = False
        End If
    End Sub

    Private Sub txtCarnetNuevo_TextChanged(sender As Object, e As EventArgs) Handles txtCarnetNuevo.TextChanged
        If txtAptoNuevo.Text <> "" And txtCarnetNuevo.Text <> "" And txtCbuNuevo.Text <> "" And txtCivilNuevo.Text <> "" And txtCuentaNueva.Text <> "" And txtCutNuevo.Text <> "" And txtDniNuevo.Text <> "" And txtDomicilioNuevo.Text <> "" And txtEmailNuevo.Text <> "" And txtEstadoLegaoNuevo.Text <> "" And txtHijosNuevo.Text <> "" And txtHoy.Text <> "" And txtIngresoNuevo.Text <> "" And txtmes.Text <> "" And txtNombreNuevo.Text <> "" And txtPuestoNuevo.Text <> "" And txtSeguroNuevo.Text <> "" And txtTelNuevo.Text <> "" Then
            btnGuardarNuevoLegajo.Enabled = True
        Else
            btnGuardarNuevoLegajo.Enabled = False
        End If
    End Sub

    Private Sub txtAptoNuevo_TextChanged(sender As Object, e As EventArgs) Handles txtAptoNuevo.TextChanged
        If txtAptoNuevo.Text <> "" And txtCarnetNuevo.Text <> "" And txtCbuNuevo.Text <> "" And txtCivilNuevo.Text <> "" And txtCuentaNueva.Text <> "" And txtCutNuevo.Text <> "" And txtDniNuevo.Text <> "" And txtDomicilioNuevo.Text <> "" And txtEmailNuevo.Text <> "" And txtEstadoLegaoNuevo.Text <> "" And txtHijosNuevo.Text <> "" And txtHoy.Text <> "" And txtIngresoNuevo.Text <> "" And txtmes.Text <> "" And txtNombreNuevo.Text <> "" And txtPuestoNuevo.Text <> "" And txtSeguroNuevo.Text <> "" And txtTelNuevo.Text <> "" Then
            btnGuardarNuevoLegajo.Enabled = True
        Else
            btnGuardarNuevoLegajo.Enabled = False
        End If
    End Sub

    Private Sub txtPuestoNuevo_TextChanged(sender As Object, e As EventArgs) Handles txtPuestoNuevo.TextChanged
        If txtAptoNuevo.Text <> "" And txtCarnetNuevo.Text <> "" And txtCbuNuevo.Text <> "" And txtCivilNuevo.Text <> "" And txtCuentaNueva.Text <> "" And txtCutNuevo.Text <> "" And txtDniNuevo.Text <> "" And txtDomicilioNuevo.Text <> "" And txtEmailNuevo.Text <> "" And txtEstadoLegaoNuevo.Text <> "" And txtHijosNuevo.Text <> "" And txtHoy.Text <> "" And txtIngresoNuevo.Text <> "" And txtmes.Text <> "" And txtNombreNuevo.Text <> "" And txtPuestoNuevo.Text <> "" And txtSeguroNuevo.Text <> "" And txtTelNuevo.Text <> "" Then
            btnGuardarNuevoLegajo.Enabled = True
        Else
            btnGuardarNuevoLegajo.Enabled = False
        End If
    End Sub

    Private Sub txtEstadoLegaoNuevo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtEstadoLegaoNuevo.SelectedIndexChanged
        If txtAptoNuevo.Text <> "" And txtCarnetNuevo.Text <> "" And txtCbuNuevo.Text <> "" And txtCivilNuevo.Text <> "" And txtCuentaNueva.Text <> "" And txtCutNuevo.Text <> "" And txtDniNuevo.Text <> "" And txtDomicilioNuevo.Text <> "" And txtEmailNuevo.Text <> "" And txtEstadoLegaoNuevo.Text <> "" And txtHijosNuevo.Text <> "" And txtHoy.Text <> "" And txtIngresoNuevo.Text <> "" And txtmes.Text <> "" And txtNombreNuevo.Text <> "" And txtPuestoNuevo.Text <> "" And txtSeguroNuevo.Text <> "" And txtTelNuevo.Text <> "" Then
            btnGuardarNuevoLegajo.Enabled = True
        Else
            btnGuardarNuevoLegajo.Enabled = False
        End If
    End Sub
#End Region
End Class