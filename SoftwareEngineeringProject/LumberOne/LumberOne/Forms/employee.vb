Imports System.Data.OleDb
Imports System.Text

Public Class employee

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToScreen()
        Dim DateNow = Date.Now
        Label8.Text = "Welcome " + Form1.txtUsername.Text + ", You are logged on as of " + DateNow
        Form1.txtUsername.Text = ""
        Form1.txtPassword.Text = ""
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub searchLoc_Click(sender As Object, e As EventArgs) Handles searchLoc.Click
        Try
            Dim street As String = String.Empty
            Dim city As String = String.Empty
            Dim state As String = String.Empty
            Dim zip As String = String.Empty
            Dim queryAddress As New StringBuilder
            queryAddress.Append("http://maps.google.com/maps?q=")

            If txtStreet.Text <> String.Empty Then
                street = txtStreet.Text.Replace(" ", "+")
                queryAddress.Append(street + "," & "+")
            End If

            If txtCity.Text <> String.Empty Then
                city = txtCity.Text.Replace(" ", "+")
                queryAddress.Append(city + "," & "+")
            End If

            If txtState.Text <> String.Empty Then
                state = txtState.Text.Replace(" ", "+")
                queryAddress.Append(state + "," & "+")
            End If

            If txtZip.Text <> String.Empty Then
                zip = txtZip.Text.Replace(" ", "+")
                queryAddress.Append(zip + "," & "+")
            End If

            WebBrowser1.Navigate(queryAddress.ToString())

        Catch ex As Exception
            MessageBox.Show("Unable to retrieve data!")
        End Try

    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox1.Items.Add(ComboBox1.SelectedItem)
        ListBox1.Items.Add(ComboBox2.SelectedItem)
        ListBox1.Items.Add(ComboBox3.SelectedItem)
        MessageBox.Show("Warning! Your report has errors and may not have been generated correctly. Please try again.")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Process.Start("C:\ProgramData\Microsoft\Windows\Start Menu\Programs\jGRASP\jGRASP.lnk")
    End Sub
End Class