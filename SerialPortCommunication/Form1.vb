Imports System.IO.Ports

Public Class Form1
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ComboBox1.DataSource = My.Computer.Ports.SerialPortNames
        ComboBox2.DataSource = My.Computer.Ports.SerialPortNames
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
            Label1.Text = $"{SerialPort1.PortName} is Closed"
            Button1.Text = "Open"
        Else
            SerialPort1.PortName = ComboBox1.SelectedItem
            If SerialPort1.PortName = SerialPort2.PortName AndAlso SerialPort2.IsOpen Then
                Label1.Text = "Port 1 cannot be the same as Port 2!"
            Else
                SerialPort1.Open()
                Label1.Text = $"{SerialPort1.PortName} is Opened"
                Button1.Text = "Close"
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If SerialPort2.IsOpen Then
            SerialPort2.Close()
            Label2.Text = $"{SerialPort2.PortName} is Closed"
            Button2.Text = "Open"
        Else
            SerialPort2.PortName = ComboBox2.SelectedItem
            If SerialPort2.PortName = SerialPort1.PortName AndAlso SerialPort1.IsOpen Then
                Label2.Text = "Port 2 cannot be the same as Port 1!"
            Else
                SerialPort2.Open()
                Label2.Text = $"{SerialPort2.PortName} is Opened"
                Button2.Text = "Close"
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If SerialPort1.IsOpen Then
            SerialPort1.WriteTimeout = 5000
            Try
                Label1.Text = Nothing
                SerialPort1.Write(TextBox1.Text)
            Catch ex As Exception
                Label1.Text = ex.Message
            End Try
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If SerialPort2.IsOpen Then
            SerialPort2.WriteTimeout = 5000
            Try
                Label2.Text = Nothing
                SerialPort2.Write(TextBox3.Text)
            Catch ex As Exception
                Label2.Text = ex.Message
            End Try
        End If
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        TextBox2.Invoke(Sub() TextBox2.AppendText(SerialPort1.ReadExisting))
    End Sub

    Private Sub SerialPort2_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort2.DataReceived
        TextBox4.Invoke(Sub() TextBox4.AppendText(SerialPort2.ReadExisting))
    End Sub
End Class
