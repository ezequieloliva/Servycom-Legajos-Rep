<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificarLegajo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnGuardarCambios = New System.Windows.Forms.Button()
        Me.txtEstadoLegaoMod = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPuestoMod = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCbuMod = New System.Windows.Forms.TextBox()
        Me.txtCuentaMod = New System.Windows.Forms.TextBox()
        Me.txtCutMod = New System.Windows.Forms.TextBox()
        Me.txtHijosMod = New System.Windows.Forms.TextBox()
        Me.txtCivilMod = New System.Windows.Forms.TextBox()
        Me.txtEmailMod = New System.Windows.Forms.TextBox()
        Me.txtTelMod = New System.Windows.Forms.TextBox()
        Me.txtDomicilioMod = New System.Windows.Forms.TextBox()
        Me.txtSeguroMod = New System.Windows.Forms.TextBox()
        Me.txtNombreMod = New System.Windows.Forms.ComboBox()
        Me.txtDniMod = New System.Windows.Forms.TextBox()
        Me.txtIngresoMod = New System.Windows.Forms.TextBox()
        Me.txtAptoMod = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtFechaHoy = New System.Windows.Forms.DateTimePicker()
        Me.txtCarnetMod = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.diaMod = New System.Windows.Forms.TextBox()
        Me.mesMod = New System.Windows.Forms.TextBox()
        Me.añoMod = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnGuardarCambios
        '
        Me.btnGuardarCambios.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnGuardarCambios.Enabled = False
        Me.btnGuardarCambios.Location = New System.Drawing.Point(515, 409)
        Me.btnGuardarCambios.Name = "btnGuardarCambios"
        Me.btnGuardarCambios.Size = New System.Drawing.Size(107, 48)
        Me.btnGuardarCambios.TabIndex = 71
        Me.btnGuardarCambios.Text = "Guardar Cambios"
        Me.btnGuardarCambios.UseVisualStyleBackColor = False
        '
        'txtEstadoLegaoMod
        '
        Me.txtEstadoLegaoMod.FormattingEnabled = True
        Me.txtEstadoLegaoMod.Items.AddRange(New Object() {"Alta", "Baja"})
        Me.txtEstadoLegaoMod.Location = New System.Drawing.Point(464, 355)
        Me.txtEstadoLegaoMod.Name = "txtEstadoLegaoMod"
        Me.txtEstadoLegaoMod.Size = New System.Drawing.Size(158, 21)
        Me.txtEstadoLegaoMod.TabIndex = 69
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(358, 361)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(89, 13)
        Me.Label17.TabIndex = 68
        Me.Label17.Text = "Estado de legajo:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(404, 322)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 13)
        Me.Label16.TabIndex = 67
        Me.Label16.Text = "Puesto:"
        '
        'txtPuestoMod
        '
        Me.txtPuestoMod.Location = New System.Drawing.Point(464, 316)
        Me.txtPuestoMod.Name = "txtPuestoMod"
        Me.txtPuestoMod.Size = New System.Drawing.Size(158, 20)
        Me.txtPuestoMod.TabIndex = 66
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(316, 280)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(131, 13)
        Me.Label15.TabIndex = 65
        Me.Label15.Text = "Vencimiento Apto Medico:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(342, 244)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(105, 13)
        Me.Label14.TabIndex = 64
        Me.Label14.Text = "Vencimiento Carnet :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(403, 205)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 13)
        Me.Label13.TabIndex = 63
        Me.Label13.Text = "Seguro:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(415, 166)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 13)
        Me.Label12.TabIndex = 62
        Me.Label12.Text = "CBU:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(388, 127)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 61
        Me.Label11.Text = "N° Cuenta:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(412, 88)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 60
        Me.Label10.Text = "CUIT:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(402, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "Ingreso:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(33, 326)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 13)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "Cantidad de hijos:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(59, 286)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Estado Civil:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(79, 246)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "E-MAIL:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(72, 206)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Telefono:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(72, 166)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Domicilio:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Nombre y Apellido:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(95, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "DNI:"
        '
        'txtCbuMod
        '
        Me.txtCbuMod.Location = New System.Drawing.Point(464, 160)
        Me.txtCbuMod.Name = "txtCbuMod"
        Me.txtCbuMod.Size = New System.Drawing.Size(158, 20)
        Me.txtCbuMod.TabIndex = 48
        '
        'txtCuentaMod
        '
        Me.txtCuentaMod.Location = New System.Drawing.Point(464, 121)
        Me.txtCuentaMod.Name = "txtCuentaMod"
        Me.txtCuentaMod.Size = New System.Drawing.Size(158, 20)
        Me.txtCuentaMod.TabIndex = 47
        '
        'txtCutMod
        '
        Me.txtCutMod.Location = New System.Drawing.Point(464, 82)
        Me.txtCutMod.Name = "txtCutMod"
        Me.txtCutMod.Size = New System.Drawing.Size(158, 20)
        Me.txtCutMod.TabIndex = 46
        '
        'txtHijosMod
        '
        Me.txtHijosMod.Location = New System.Drawing.Point(134, 324)
        Me.txtHijosMod.Name = "txtHijosMod"
        Me.txtHijosMod.Size = New System.Drawing.Size(158, 20)
        Me.txtHijosMod.TabIndex = 45
        '
        'txtCivilMod
        '
        Me.txtCivilMod.Location = New System.Drawing.Point(134, 284)
        Me.txtCivilMod.Name = "txtCivilMod"
        Me.txtCivilMod.Size = New System.Drawing.Size(158, 20)
        Me.txtCivilMod.TabIndex = 44
        '
        'txtEmailMod
        '
        Me.txtEmailMod.Location = New System.Drawing.Point(134, 243)
        Me.txtEmailMod.Name = "txtEmailMod"
        Me.txtEmailMod.Size = New System.Drawing.Size(158, 20)
        Me.txtEmailMod.TabIndex = 43
        '
        'txtTelMod
        '
        Me.txtTelMod.Location = New System.Drawing.Point(134, 200)
        Me.txtTelMod.Name = "txtTelMod"
        Me.txtTelMod.Size = New System.Drawing.Size(158, 20)
        Me.txtTelMod.TabIndex = 42
        '
        'txtDomicilioMod
        '
        Me.txtDomicilioMod.Location = New System.Drawing.Point(134, 163)
        Me.txtDomicilioMod.Name = "txtDomicilioMod"
        Me.txtDomicilioMod.Size = New System.Drawing.Size(158, 20)
        Me.txtDomicilioMod.TabIndex = 41
        '
        'txtSeguroMod
        '
        Me.txtSeguroMod.Location = New System.Drawing.Point(464, 199)
        Me.txtSeguroMod.Name = "txtSeguroMod"
        Me.txtSeguroMod.Size = New System.Drawing.Size(158, 20)
        Me.txtSeguroMod.TabIndex = 40
        '
        'txtNombreMod
        '
        Me.txtNombreMod.FormattingEnabled = True
        Me.txtNombreMod.Location = New System.Drawing.Point(134, 46)
        Me.txtNombreMod.Name = "txtNombreMod"
        Me.txtNombreMod.Size = New System.Drawing.Size(158, 21)
        Me.txtNombreMod.TabIndex = 74
        '
        'txtDniMod
        '
        Me.txtDniMod.Location = New System.Drawing.Point(134, 88)
        Me.txtDniMod.Name = "txtDniMod"
        Me.txtDniMod.Size = New System.Drawing.Size(158, 20)
        Me.txtDniMod.TabIndex = 75
        '
        'txtIngresoMod
        '
        Me.txtIngresoMod.Location = New System.Drawing.Point(464, 47)
        Me.txtIngresoMod.Name = "txtIngresoMod"
        Me.txtIngresoMod.Size = New System.Drawing.Size(158, 20)
        Me.txtIngresoMod.TabIndex = 77
        '
        'txtAptoMod
        '
        Me.txtAptoMod.Location = New System.Drawing.Point(464, 280)
        Me.txtAptoMod.Name = "txtAptoMod"
        Me.txtAptoMod.Size = New System.Drawing.Size(158, 20)
        Me.txtAptoMod.TabIndex = 78
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Button1.Location = New System.Drawing.Point(298, 46)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(58, 23)
        Me.Button1.TabIndex = 79
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtFechaHoy
        '
        Me.txtFechaHoy.Location = New System.Drawing.Point(12, 461)
        Me.txtFechaHoy.Name = "txtFechaHoy"
        Me.txtFechaHoy.Size = New System.Drawing.Size(208, 20)
        Me.txtFechaHoy.TabIndex = 81
        '
        'txtCarnetMod
        '
        Me.txtCarnetMod.Location = New System.Drawing.Point(464, 241)
        Me.txtCarnetMod.Name = "txtCarnetMod"
        Me.txtCarnetMod.Size = New System.Drawing.Size(158, 20)
        Me.txtCarnetMod.TabIndex = 82
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(628, 52)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 13)
        Me.Label19.TabIndex = 83
        Me.Label19.Text = "dd/mm/aaaa"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(628, 283)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(69, 13)
        Me.Label20.TabIndex = 84
        Me.Label20.Text = "dd/mm/aaaa"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(628, 244)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(69, 13)
        Me.Label21.TabIndex = 85
        Me.Label21.Text = "dd/mm/aaaa"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(61, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "Nacimiento:"
        '
        'diaMod
        '
        Me.diaMod.Location = New System.Drawing.Point(134, 124)
        Me.diaMod.Name = "diaMod"
        Me.diaMod.Size = New System.Drawing.Size(37, 20)
        Me.diaMod.TabIndex = 93
        '
        'mesMod
        '
        Me.mesMod.Location = New System.Drawing.Point(177, 124)
        Me.mesMod.Name = "mesMod"
        Me.mesMod.Size = New System.Drawing.Size(33, 20)
        Me.mesMod.TabIndex = 94
        '
        'añoMod
        '
        Me.añoMod.Location = New System.Drawing.Point(216, 124)
        Me.añoMod.Name = "añoMod"
        Me.añoMod.Size = New System.Drawing.Size(76, 20)
        Me.añoMod.TabIndex = 95
        '
        'ModificarLegajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(741, 493)
        Me.Controls.Add(Me.añoMod)
        Me.Controls.Add(Me.mesMod)
        Me.Controls.Add(Me.diaMod)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtCarnetMod)
        Me.Controls.Add(Me.txtFechaHoy)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtAptoMod)
        Me.Controls.Add(Me.txtIngresoMod)
        Me.Controls.Add(Me.txtDniMod)
        Me.Controls.Add(Me.txtNombreMod)
        Me.Controls.Add(Me.btnGuardarCambios)
        Me.Controls.Add(Me.txtEstadoLegaoMod)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtPuestoMod)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCbuMod)
        Me.Controls.Add(Me.txtCuentaMod)
        Me.Controls.Add(Me.txtCutMod)
        Me.Controls.Add(Me.txtHijosMod)
        Me.Controls.Add(Me.txtCivilMod)
        Me.Controls.Add(Me.txtEmailMod)
        Me.Controls.Add(Me.txtTelMod)
        Me.Controls.Add(Me.txtDomicilioMod)
        Me.Controls.Add(Me.txtSeguroMod)
        Me.Name = "ModificarLegajo"
        Me.Text = "Modificar legajo de empleado"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGuardarCambios As Button
    Friend WithEvents txtEstadoLegaoMod As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtPuestoMod As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCbuMod As TextBox
    Friend WithEvents txtCuentaMod As TextBox
    Friend WithEvents txtCutMod As TextBox
    Friend WithEvents txtHijosMod As TextBox
    Friend WithEvents txtCivilMod As TextBox
    Friend WithEvents txtEmailMod As TextBox
    Friend WithEvents txtTelMod As TextBox
    Friend WithEvents txtDomicilioMod As TextBox
    Friend WithEvents txtSeguroMod As TextBox
    Friend WithEvents txtNombreMod As ComboBox
    Friend WithEvents txtDniMod As TextBox
    Friend WithEvents txtIngresoMod As TextBox
    Friend WithEvents txtAptoMod As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents txtFechaHoy As DateTimePicker
    Friend WithEvents txtCarnetMod As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents diaMod As TextBox
    Friend WithEvents mesMod As TextBox
    Friend WithEvents añoMod As TextBox
End Class
