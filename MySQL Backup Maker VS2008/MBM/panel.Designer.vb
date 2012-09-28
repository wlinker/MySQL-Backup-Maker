<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class panel
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(panel))
        Me.Lista_BD = New System.Windows.Forms.ListBox()
        Me.panel_tabs = New System.Windows.Forms.TabControl()
        Me.server = New System.Windows.Forms.TabPage()
        Me.lb_eventos = New System.Windows.Forms.Label()
        Me.logs = New System.Windows.Forms.TextBox()
        Me.conection = New System.Windows.Forms.TabPage()
        Me.finalizar = New System.Windows.Forms.CheckBox()
        Me.autocrear = New System.Windows.Forms.CheckBox()
        Me.regenerar = New System.Windows.Forms.Button()
        Me.examinar = New System.Windows.Forms.Button()
        Me.boton_guardar = New System.Windows.Forms.Button()
        Me.lb_servidor = New System.Windows.Forms.Label()
        Me.raiz_respaldo = New System.Windows.Forms.TextBox()
        Me.lb_raiz = New System.Windows.Forms.Label()
        Me.servidor = New System.Windows.Forms.TextBox()
        Me.lb_password = New System.Windows.Forms.Label()
        Me.clave = New System.Windows.Forms.TextBox()
        Me.lb_usuario = New System.Windows.Forms.Label()
        Me.usuario = New System.Windows.Forms.TextBox()
        Me.timer_inicial = New System.Windows.Forms.Timer(Me.components)
        Me.panel_tabs.SuspendLayout()
        Me.server.SuspendLayout()
        Me.conection.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lista_BD
        '
        Me.Lista_BD.FormattingEnabled = True
        Me.Lista_BD.Location = New System.Drawing.Point(6, 6)
        Me.Lista_BD.Name = "Lista_BD"
        Me.Lista_BD.Size = New System.Drawing.Size(230, 121)
        Me.Lista_BD.TabIndex = 0
        '
        'panel_tabs
        '
        Me.panel_tabs.Controls.Add(Me.server)
        Me.panel_tabs.Controls.Add(Me.conection)
        Me.panel_tabs.Location = New System.Drawing.Point(12, 12)
        Me.panel_tabs.Name = "panel_tabs"
        Me.panel_tabs.SelectedIndex = 0
        Me.panel_tabs.Size = New System.Drawing.Size(250, 243)
        Me.panel_tabs.TabIndex = 1
        '
        'server
        '
        Me.server.Controls.Add(Me.lb_eventos)
        Me.server.Controls.Add(Me.logs)
        Me.server.Controls.Add(Me.Lista_BD)
        Me.server.Location = New System.Drawing.Point(4, 22)
        Me.server.Name = "server"
        Me.server.Padding = New System.Windows.Forms.Padding(3)
        Me.server.Size = New System.Drawing.Size(242, 217)
        Me.server.TabIndex = 0
        Me.server.Text = "Listado de bases de datos"
        Me.server.UseVisualStyleBackColor = True
        '
        'lb_eventos
        '
        Me.lb_eventos.AutoSize = True
        Me.lb_eventos.Location = New System.Drawing.Point(2, 136)
        Me.lb_eventos.Name = "lb_eventos"
        Me.lb_eventos.Size = New System.Drawing.Size(124, 13)
        Me.lb_eventos.TabIndex = 2
        Me.lb_eventos.Text = "Visor de ultimos eventos:"
        '
        'logs
        '
        Me.logs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.logs.Location = New System.Drawing.Point(4, 152)
        Me.logs.Multiline = True
        Me.logs.Name = "logs"
        Me.logs.ReadOnly = True
        Me.logs.Size = New System.Drawing.Size(232, 45)
        Me.logs.TabIndex = 1
        '
        'conection
        '
        Me.conection.Controls.Add(Me.finalizar)
        Me.conection.Controls.Add(Me.autocrear)
        Me.conection.Controls.Add(Me.regenerar)
        Me.conection.Controls.Add(Me.examinar)
        Me.conection.Controls.Add(Me.boton_guardar)
        Me.conection.Controls.Add(Me.lb_servidor)
        Me.conection.Controls.Add(Me.raiz_respaldo)
        Me.conection.Controls.Add(Me.lb_raiz)
        Me.conection.Controls.Add(Me.servidor)
        Me.conection.Controls.Add(Me.lb_password)
        Me.conection.Controls.Add(Me.clave)
        Me.conection.Controls.Add(Me.lb_usuario)
        Me.conection.Controls.Add(Me.usuario)
        Me.conection.Location = New System.Drawing.Point(4, 22)
        Me.conection.Name = "conection"
        Me.conection.Padding = New System.Windows.Forms.Padding(3)
        Me.conection.Size = New System.Drawing.Size(249, 217)
        Me.conection.TabIndex = 1
        Me.conection.Text = "Configurar aplicación"
        Me.conection.UseVisualStyleBackColor = True
        '
        'finalizar
        '
        Me.finalizar.AutoSize = True
        Me.finalizar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.finalizar.Location = New System.Drawing.Point(7, 164)
        Me.finalizar.Name = "finalizar"
        Me.finalizar.Size = New System.Drawing.Size(146, 17)
        Me.finalizar.TabIndex = 6
        Me.finalizar.Text = "Cerrar al finalizar respaldo"
        Me.finalizar.UseVisualStyleBackColor = True
        '
        'autocrear
        '
        Me.autocrear.AutoSize = True
        Me.autocrear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.autocrear.Location = New System.Drawing.Point(7, 141)
        Me.autocrear.Name = "autocrear"
        Me.autocrear.Size = New System.Drawing.Size(222, 17)
        Me.autocrear.TabIndex = 5
        Me.autocrear.Text = "Crear respaldo automaticamente al cargar"
        Me.autocrear.UseVisualStyleBackColor = True
        '
        'regenerar
        '
        Me.regenerar.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.regenerar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.regenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.regenerar.ForeColor = System.Drawing.Color.White
        Me.regenerar.Location = New System.Drawing.Point(129, 188)
        Me.regenerar.Name = "regenerar"
        Me.regenerar.Size = New System.Drawing.Size(107, 23)
        Me.regenerar.TabIndex = 8
        Me.regenerar.Text = "Regenerar"
        Me.regenerar.UseVisualStyleBackColor = False
        '
        'examinar
        '
        Me.examinar.Location = New System.Drawing.Point(162, 110)
        Me.examinar.Name = "examinar"
        Me.examinar.Size = New System.Drawing.Size(75, 23)
        Me.examinar.TabIndex = 4
        Me.examinar.Text = "Examinar..."
        Me.examinar.UseVisualStyleBackColor = True
        '
        'boton_guardar
        '
        Me.boton_guardar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.boton_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.boton_guardar.Location = New System.Drawing.Point(7, 187)
        Me.boton_guardar.Name = "boton_guardar"
        Me.boton_guardar.Size = New System.Drawing.Size(113, 24)
        Me.boton_guardar.TabIndex = 7
        Me.boton_guardar.Text = "Guardar cambios"
        Me.boton_guardar.UseVisualStyleBackColor = True
        '
        'lb_servidor
        '
        Me.lb_servidor.AutoSize = True
        Me.lb_servidor.Location = New System.Drawing.Point(3, 7)
        Me.lb_servidor.Name = "lb_servidor"
        Me.lb_servidor.Size = New System.Drawing.Size(49, 13)
        Me.lb_servidor.TabIndex = 5
        Me.lb_servidor.Text = "Servidor:"
        '
        'raiz_respaldo
        '
        Me.raiz_respaldo.Location = New System.Drawing.Point(3, 112)
        Me.raiz_respaldo.Name = "raiz_respaldo"
        Me.raiz_respaldo.ReadOnly = True
        Me.raiz_respaldo.Size = New System.Drawing.Size(153, 20)
        Me.raiz_respaldo.TabIndex = 100
        '
        'lb_raiz
        '
        Me.lb_raiz.AutoSize = True
        Me.lb_raiz.Location = New System.Drawing.Point(2, 96)
        Me.lb_raiz.Name = "lb_raiz"
        Me.lb_raiz.Size = New System.Drawing.Size(112, 13)
        Me.lb_raiz.TabIndex = 0
        Me.lb_raiz.Text = "Raíz de los respaldos:"
        '
        'servidor
        '
        Me.servidor.Location = New System.Drawing.Point(2, 24)
        Me.servidor.Name = "servidor"
        Me.servidor.Size = New System.Drawing.Size(234, 20)
        Me.servidor.TabIndex = 1
        '
        'lb_password
        '
        Me.lb_password.AutoSize = True
        Me.lb_password.Location = New System.Drawing.Point(124, 49)
        Me.lb_password.Name = "lb_password"
        Me.lb_password.Size = New System.Drawing.Size(56, 13)
        Me.lb_password.TabIndex = 3
        Me.lb_password.Text = "Password:"
        '
        'clave
        '
        Me.clave.Location = New System.Drawing.Point(125, 66)
        Me.clave.Name = "clave"
        Me.clave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.clave.Size = New System.Drawing.Size(111, 20)
        Me.clave.TabIndex = 3
        '
        'lb_usuario
        '
        Me.lb_usuario.AutoSize = True
        Me.lb_usuario.Location = New System.Drawing.Point(1, 49)
        Me.lb_usuario.Name = "lb_usuario"
        Me.lb_usuario.Size = New System.Drawing.Size(46, 13)
        Me.lb_usuario.TabIndex = 1
        Me.lb_usuario.Text = "Usuario:"
        '
        'usuario
        '
        Me.usuario.Location = New System.Drawing.Point(2, 66)
        Me.usuario.Name = "usuario"
        Me.usuario.Size = New System.Drawing.Size(112, 20)
        Me.usuario.TabIndex = 2
        '
        'timer_inicial
        '
        Me.timer_inicial.Interval = 3500
        '
        'panel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 267)
        Me.Controls.Add(Me.panel_tabs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "panel"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MySQL Backup Maker"
        Me.panel_tabs.ResumeLayout(False)
        Me.server.ResumeLayout(False)
        Me.server.PerformLayout()
        Me.conection.ResumeLayout(False)
        Me.conection.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lista_BD As System.Windows.Forms.ListBox
    Friend WithEvents panel_tabs As System.Windows.Forms.TabControl
    Friend WithEvents server As System.Windows.Forms.TabPage
    Friend WithEvents conection As System.Windows.Forms.TabPage
    Friend WithEvents boton_guardar As System.Windows.Forms.Button
    Friend WithEvents lb_servidor As System.Windows.Forms.Label
    Friend WithEvents servidor As System.Windows.Forms.TextBox
    Friend WithEvents lb_password As System.Windows.Forms.Label
    Friend WithEvents clave As System.Windows.Forms.TextBox
    Friend WithEvents lb_usuario As System.Windows.Forms.Label
    Friend WithEvents usuario As System.Windows.Forms.TextBox
    Friend WithEvents lb_raiz As System.Windows.Forms.Label
    Friend WithEvents raiz_respaldo As System.Windows.Forms.TextBox
    Friend WithEvents examinar As System.Windows.Forms.Button
    Friend WithEvents lb_eventos As System.Windows.Forms.Label
    Friend WithEvents logs As System.Windows.Forms.TextBox
    Friend WithEvents regenerar As System.Windows.Forms.Button
    Friend WithEvents autocrear As System.Windows.Forms.CheckBox
    Friend WithEvents timer_inicial As System.Windows.Forms.Timer
    Friend WithEvents finalizar As System.Windows.Forms.CheckBox
End Class
