<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevoAdmin
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
        Me.btnGuardarAdmin = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUsuarioAdminNuevo = New System.Windows.Forms.TextBox()
        Me.txtClaveNuevoAdmin = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnGuardarAdmin
        '
        Me.btnGuardarAdmin.Location = New System.Drawing.Point(222, 51)
        Me.btnGuardarAdmin.Name = "btnGuardarAdmin"
        Me.btnGuardarAdmin.Size = New System.Drawing.Size(78, 31)
        Me.btnGuardarAdmin.TabIndex = 0
        Me.btnGuardarAdmin.Text = "Guardar"
        Me.btnGuardarAdmin.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Usuario:"
        '
        'txtUsuarioAdminNuevo
        '
        Me.txtUsuarioAdminNuevo.Location = New System.Drawing.Point(84, 23)
        Me.txtUsuarioAdminNuevo.Name = "txtUsuarioAdminNuevo"
        Me.txtUsuarioAdminNuevo.Size = New System.Drawing.Size(100, 20)
        Me.txtUsuarioAdminNuevo.TabIndex = 2
        '
        'txtClaveNuevoAdmin
        '
        Me.txtClaveNuevoAdmin.Location = New System.Drawing.Point(84, 57)
        Me.txtClaveNuevoAdmin.Name = "txtClaveNuevoAdmin"
        Me.txtClaveNuevoAdmin.Size = New System.Drawing.Size(100, 20)
        Me.txtClaveNuevoAdmin.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Clave:"
        '
        'frmNuevoAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(320, 89)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtClaveNuevoAdmin)
        Me.Controls.Add(Me.txtUsuarioAdminNuevo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnGuardarAdmin)
        Me.Name = "frmNuevoAdmin"
        Me.Text = "frmNuevoAdmin"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnGuardarAdmin As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtUsuarioAdminNuevo As TextBox
    Friend WithEvents txtClaveNuevoAdmin As TextBox
    Friend WithEvents Label2 As Label
End Class
