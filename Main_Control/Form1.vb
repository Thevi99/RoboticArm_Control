Imports System.IO.Ports
Imports System

Public Class Form1

    Private byte_data As Byte() = New Byte() {&H0, &H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &HA, &HB, &HC, &HD, &HE, &HF, &H10}
    Private Addr As Byte
    Private Buffer As Byte() 'เก็บข้อมูลที่ต้องการส่ง
    Private DataSended As Integer
    Private PulseByte As Byte()
    Private SpeedGear As Byte()

    ' Function Byte Motor
    Dim FWD As Byte = &H80
    Dim RWD As Byte = &H0
    Dim [STOP] As Byte = &HF7
    Dim EN_ON As Byte = &H1
    Dim EN_OFF As Byte = &H0
    Dim Save_Speed As Byte = &HC8
    Dim Clear_Speed As Byte = &HCA

    ' Data
    Private Start_ACC = {&H10}, Stop_AXX = {&H10}








    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SerialPort1.PortName = "COM9"
        SerialPort1.BaudRate = 38400
        SerialPort1.Parity = Parity.None
        SerialPort1.DataBits = 8
        SerialPort1.StopBits = StopBits.One

        SerialPort1.Open()

        Dim x As Integer = 600
        Dim intBytes() As Byte = BitConverter.GetBytes(x)
        For Each i In intBytes
            MsgBox(i)
        Next



    End Sub

    Private Sub bt_MoveMotor_Click(sender As Object, e As EventArgs) Handles bt_CalMotor.Click
        DataSended = &H80  ' กำหนดค่า : 128 ใน ฐาน 10 เป็น ฐาน 16 (Hex)
        SendRelevantData(DataSended)
    End Sub


    Private Sub bt_SendMotor1_Click(sender As Object, e As EventArgs) Handles bt_SendMotor1.Click
        DataSended = &HFD ' 253 ใน ฐาน 10 -> ฐาน 16
        SendRelevantData(DataSended)
    End Sub
    Private Sub bt_StopMotor_Click(sender As Object, e As EventArgs) Handles bt_StopMotor.Click

    End Sub



    Private Sub SendRelevantData(data As Integer)
        Dim PulseText As UInteger 'อยู่ในช่วง 0 - 4,294,967,295 และเป็น 4 byte
        Dim SpeedGearText As UShort 'เก็บจำนวนเต็มไม่ติดลบ ช่วง 0 - 65,535



        Try
            Addr = Convert.ToByte("01", 16)  ' แปลง 01 ใน ฐาน 16 
            'Dim hexString As String = "01"
            'Dim decimalValue As Byte = Convert.ToByte(hexString, 16) ' แปลงจากฐาน 16 เป็นฐาน 10
            'MessageBox.Show("Decimal Value: " & decimalValue)
        Catch
            MessageBox.Show("Invalid UART Address", "Error")
            Return
        End Try

        If Addr <= &HFF AndAlso Addr >= &H0 Then
            If data = 128 Then  ' การสอบเทียบ
                ' ใช้ Mod 256 เข้ามาช่วย เพราะ ปกติ byte รับได้ถึงแค่ 0-255 ถ้ามากว่านั้นจะ overflow
                Dim tCHK As Byte = CByte((&HFA + Addr + data + byte_data(0)) Mod 256)
                Buffer = New Byte() {&HFA, Addr, CByte(data), byte_data(0), tCHK}
                ' Debug tCHK , Buffer (HEX)
                Console.WriteLine("tCHK: {0:X2}", tCHK)
                Console.Write("Buffer: ")
                For Each b As Byte In Buffer
                    Console.Write("{0:X2} ", b)
                Next
                Console.WriteLine()

                WriteByteToSerialPort(Buffer, 0, 5)
            ElseIf data = 253 Then
                ' ---- Speed Gear
                SpeedGearText = Convert.ToUInt16(tb_InputSpeedGear.Text)
                SpeedGear = BitConverter.GetBytes(SpeedGearText)

                ' ---- Pulse 
                PulseText = Convert.ToUInt32(tb_InputPulese.Text, 10)
                PulseByte = BitConverter.GetBytes(PulseText)
                'Console.Write("Bytes: ")
                'For Each b As Byte In PulseByte
                '    Console.Write("{0:X2} ", b)
                'Next
                'Console.WriteLine()

                If (SpeedGearText <= 3000 AndAlso SpeedGearText >= 1) Then
                    If (PulseText <= 4294967295 AndAlso PulseText >= 1) Then
                        SpeedGear(1) = SpeedGear(1) Or FWD

                        Dim tCHK As Byte = CByte((&HFA + Addr + data + SpeedGear(1) + SpeedGear(0) + Start_ACC(0) + PulseByte(3) + PulseByte(2) + PulseByte(1) + PulseByte(0)) Mod 256)
                        Buffer = New Byte() {&HFA, Addr, CByte(data), SpeedGear(1), SpeedGear(0), Start_ACC(0), PulseByte(3), PulseByte(2), PulseByte(1), PulseByte(0), CByte(tCHK)}
                        WriteByteToSerialPort(Buffer, 0, 11)
                    End If
                Else
                    MessageBox.Show("Invalid UART Address", "Error")

                End If
            End If
        End If
    End Sub

    Private Sub WriteByteToSerialPort(data As Byte(), start As Byte, length As Byte)
        If SerialPort1.IsOpen Then
            Try
                SerialPort1.Write(data, start, length)
                'txDisplay()
            Catch
                MessageBox.Show("Serial Port Error", "Error")
            End Try
        Else
            MessageBox.Show("Serial Port Error", "Error")
        End If
    End Sub

    'Private Sub txDisplay()
    '    Console.Write("TX: ")
    '    For Each b As Byte In Buffer
    '        Console.Write("{0:X2} ", b)
    '    Next
    '    Console.WriteLine("Length: {0}", Buffer.Length)
    'End Sub

    Private Sub Timer_SerialPort_Tick(sender As Object, e As EventArgs) Handles Timer_SerialPort.Tick
        Timer_SerialPort.Stop()
        Timer_SerialPort.Start()
    End Sub


End Class
