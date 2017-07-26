<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cambio_de_contraseña
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
        Me.components = New System.ComponentModel.Container()
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox()
        Me.UsuariosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RrhhDataSet = New Servycom_VB.rrhhDataSet()
        Me.txtContraActual = New System.Windows.Forms.TextBox()
        Me.txtContraNueva = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.UsuariosTableAdapter = New Servycom_VB.rrhhDataSetTableAdapters.usuariosTableAdapter()
        CType(Me.UsuariosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RrhhDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.DataSource = Me.UsuariosBindingSource
        Me.cmbUsuarios.DisplayMember = "user"
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(195, 34)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(184, 21)
        Me.cmbUsuarios.TabIndex = 0
        Me.cmbUsuarios.ValueMember = "user"
        '
        'UsuariosBindingSource
        '
        Me.UsuariosBindingSource.DataMember = "usuarios"
        Me.UsuariosBindingSource.DataSource = Me.RrhhDataSet
        '
        'RrhhDataSet
        '
        Me.RrhhDataSet.DataSetName = "rrhhDataSet"
        Me.RrhhDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtContraActual
        '
        Me.txtContraActual.Enabled = False
        Me.txtContraActual.Location = New System.Drawing.Point(195, 95)
        Me.txtContraActual.Name = "txtContraActual"
        Me.txtContraActual.Size = New System.Drawing.Size(184, 20)
        Me.txtContraActual.TabIndex = 1
        '
        'txtContraNueva
        '
        Me.txtContraNueva.Location = New System.Drawing.Point(195, 161)
        Me.txtContraNueva.Name = "txtContraNueva"
        Me.txtContraNueva.Size = New System.Drawing.Size(184, 20)
        Me.txtContraNueva.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(82, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Usuarios Registrados"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(95, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Contraseña Actual"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(93, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Contraseña Nueva"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(184, 221)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(130, 45)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Confirmar Cambio"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'UsuariosTableAdapter
        '
        Me.UsuariosTableAdapter.ClearBeforeFill = True
        '
        'Cambio_de_contraseña
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(485, 285)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtContraNueva)
        Me.Controls.Add(Me.txtContraActual)
        Me.Controls.Add(Me.cmbUsuarios)
        Me.Name = "Cambio_de_contraseña"
        Me.Text = "Cambio_de_contraseña"
        CType(Me.UsuariosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RrhhDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents txtContraActual As System.Windows.Forms.TextBox
    Friend WithEvents txtContraNueva As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents RrhhDataSet As Servycom_VB.rrhhDataSet
    Friend WithEvents UsuariosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UsuariosTableAdapter As Servycom_VB.rrhhDataSetTableAdapters.usuariosTableAdapter
End Class
