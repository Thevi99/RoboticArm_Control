Public Class frmMain

    Dim SP As New IO.Ports.SerialPort
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sData As String() = IO.Ports.SerialPort.GetPortNames
        ComboBox1.Items.AddRange(sData)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If SP.IsOpen Then SP.Close()
        SP.PortName = ComboBox1.SelectedItem
        SP.BaudRate = 38400
        SP.DataBits = 8
        SP.StopBits = 1
        SP.Parity = IO.Ports.Parity.None

        SP.Open()
    End Sub

    Private Function CRC_Checksum(byteData As Byte()) As Byte
        Dim byteSum As Integer = 0
        For i = 0 To byteData.Length - 2
            byteSum += byteData(i)
        Next

        Return (byteSum Mod &H100)
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim byteTX(10) As Byte

        byteTX(0) = &HFA    '####### Header
        byteTX(1) = &H1     '####### Address
        byteTX(2) = &HFD    '####### Function code    (F6=Position mode)
        byteTX(3) = &H1     '####### DIR,Rev,Speed
        byteTX(4) = &H40    '####### Speed
        byteTX(5) = &H2     '####### Acc
        byteTX(6) = &H0     '####### Pluse
        byteTX(7) = &H0     '####### Pluse
        byteTX(8) = &HF    '####### Pluse
        byteTX(9) = &HA     '####### Pluse
        byteTX(10) = CRC_Checksum(byteTX)  '####### CRC Checksum

        If SP.IsOpen Then
            SP.Write(byteTX, 0, byteTX.Length)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim byteTX(10) As Byte

        byteTX(0) = &HFA    '####### Header
        byteTX(1) = &H1     '####### Address
        byteTX(2) = &HFD    '####### Function code    (F6=Position mode)
        byteTX(3) = &H81     '####### DIR,Rev,Speed
        byteTX(4) = &H40    '####### Speed
        byteTX(5) = &H2     '####### Acc
        byteTX(6) = &H0     '####### Pluse
        byteTX(7) = &H0     '####### Pluse
        byteTX(8) = &HE    '####### Pluse
        byteTX(9) = &HD8     '####### Pluse
        byteTX(10) = CRC_Checksum(byteTX)  '####### CRC Checksum

        If SP.IsOpen Then
            SP.Write(byteTX, 0, byteTX.Length)
        End If
    End Sub
End Class
