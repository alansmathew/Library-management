Imports System.Data.OleDb
Imports System.Data

Public Class loginform
    Dim con As New OleDb.OleDbConnection
    Dim command As OleDb.OleDbCommand
    Dim dr As OleDb.OleDbDataReader
    Dim userfound As Boolean = False
    Public userid As Integer


    Private Sub loginform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\vb project files\DATABASE\liberary.mdb"
    End Sub


    Private Sub Username_Click(sender As Object, e As EventArgs) Handles Username.Click
        Username.Clear()
        invalidmessage.Visible = False
        errorpicture.Visible = False

    End Sub

    Private Sub Password_Enter(sender As Object, e As EventArgs) Handles Password.Enter
        Password.Clear()
        Password.PasswordChar = "*"
        invalidmessage.Visible = False
        errorpicture.Visible = False
    End Sub

    Public Sub login_Click(sender As Object, e As EventArgs) Handles login.Click
        con.Open()
        If Username.Text = "" Or Password.Text = "" Then
            invalidmessage.Visible = True
            errorpicture.Visible = True
            'MsgBox("Plz Fill All the info")
            con.Close()
        Else
            command = New OleDb.OleDbCommand("select username from login where username=" & Username.Text & " and password='" & Password.Text & "'", con)

            dr = command.ExecuteReader()

            While dr.Read()
                userfound = True
            End While

            If userfound = True Then
                userid = Username.Text
                '------------------------------------here-------------------------
                command = New OleDb.OleDbCommand("select * from login where username=" & userid & "", con)
                dr = command.ExecuteReader()
                dr.Read()
                If userid < 1000 Then
                    staff.Nme.Text = dr(1)
                Else
                    Student.Nme.Text = dr(1)
                End If
                'staff.Nme.Text = dr(1)
                dr.Close()


                '-----------------------------------------------------------------
                'staff.usrid.Text = Me.userid
                Me.Hide()
                If userid < 1000 Then
                    staff.usrid.Text = Me.userid
                    staff.Show()
                Else
                    Student.usrid.Text = Me.userid
                    Student.Show()
                End If

                userfound = False

            Else
                invalidmessage.Visible = True
                errorpicture.Visible = True
            End If
            con.Close()
        End If
    End Sub

End Class

