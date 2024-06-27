<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.tb_InputPulese = New System.Windows.Forms.TextBox()
        Me.bt_SendMotor1 = New System.Windows.Forms.Button()
        Me.bt_CalMotor = New System.Windows.Forms.Button()
        Me.Timer_SerialPort = New System.Windows.Forms.Timer(Me.components)
        Me.bt_StopMotor = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_InputSpeedGear = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tb_InputPulese
        '
        Me.tb_InputPulese.Location = New System.Drawing.Point(125, 89)
        Me.tb_InputPulese.Name = "tb_InputPulese"
        Me.tb_InputPulese.Size = New System.Drawing.Size(108, 26)
        Me.tb_InputPulese.TabIndex = 0
        '
        'bt_SendMotor1
        '
        Me.bt_SendMotor1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_SendMotor1.Location = New System.Drawing.Point(36, 92)
        Me.bt_SendMotor1.Name = "bt_SendMotor1"
        Me.bt_SendMotor1.Size = New System.Drawing.Size(75, 23)
        Me.bt_SendMotor1.TabIndex = 1
        Me.bt_SendMotor1.Text = "Pulses"
        Me.bt_SendMotor1.UseVisualStyleBackColor = True
        '
        'bt_CalMotor
        '
        Me.bt_CalMotor.Location = New System.Drawing.Point(23, 26)
        Me.bt_CalMotor.Name = "bt_CalMotor"
        Me.bt_CalMotor.Size = New System.Drawing.Size(75, 23)
        Me.bt_CalMotor.TabIndex = 2
        Me.bt_CalMotor.Text = "Cal"
        Me.bt_CalMotor.UseVisualStyleBackColor = True
        '
        'Timer_SerialPort
        '
        '
        'bt_StopMotor
        '
        Me.bt_StopMotor.Location = New System.Drawing.Point(137, 26)
        Me.bt_StopMotor.Name = "bt_StopMotor"
        Me.bt_StopMotor.Size = New System.Drawing.Size(75, 23)
        Me.bt_StopMotor.TabIndex = 3
        Me.bt_StopMotor.Text = "Stop"
        Me.bt_StopMotor.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tb_InputSpeedGear)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tb_InputPulese)
        Me.GroupBox1.Controls.Add(Me.bt_SendMotor1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 123)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(439, 315)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control Motor with Pulses"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Speed Gear :"
        '
        'tb_InputSpeedGear
        '
        Me.tb_InputSpeedGear.Location = New System.Drawing.Point(125, 44)
        Me.tb_InputSpeedGear.Name = "tb_InputSpeedGear"
        Me.tb_InputSpeedGear.Size = New System.Drawing.Size(108, 26)
        Me.tb_InputSpeedGear.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.bt_StopMotor)
        Me.Controls.Add(Me.bt_CalMotor)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents tb_InputPulese As TextBox
    Friend WithEvents bt_SendMotor1 As Button
    Friend WithEvents bt_CalMotor As Button
    Friend WithEvents Timer_SerialPort As Timer
    Friend WithEvents bt_StopMotor As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tb_InputSpeedGear As TextBox
End Class
