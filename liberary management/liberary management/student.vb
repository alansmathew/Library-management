Imports System.Data.OleDb
Imports System.Data

Public Class Student
    Dim con As New OleDb.OleDbConnection
    Dim command As OleDb.OleDbCommand
    Dim dr As OleDb.OleDbDataReader
    Dim userid As Integer
    Dim usrname As String


    Private Sub datagridshow()
        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)
        Dim da As OleDbDataAdapter
        da = New OleDbDataAdapter("Select [ID],[Book],[Author],[Quantity] from Book_Details", con)
        da.Fill(dt)
        DataGridView.DataSource = dt.DefaultView
        ' con.Close()

    End Sub

    Private Sub datagridshow1()
        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)
        Dim da As OleDbDataAdapter
        da = New OleDbDataAdapter("Select [ID],[Book],[Author],[Quantity] from Book_Details", con)
        da.Fill(dt)
        DataGridView2.DataSource = dt.DefaultView
        ' con.Close()

    End Sub

    Private Sub datagridshowtr()
        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)
        Dim da As OleDbDataAdapter
        da = New OleDbDataAdapter("Select [ID],[Book],[Author] from Book_Details where [issueone] = " & userid & " or [issuetwo] = " & userid & "", con)
        da.Fill(dt)
        DataGridViewtran.DataSource = dt.DefaultView
        ' con.Close()

    End Sub

    Private Sub Student_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        usrname = Nme.Text
        userid = usrid.Text



        mylibrary.Visible = True
        mylibgr.Visible = False
        mylibrary.Visible = False
        chgepass.Visible = False
        tran.Visible = False
        mylibgr.Visible = False
        chgepass.Visible = False
        tran.Visible = False

        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\vb project files\DATABASE\liberary.mdb"
        con.Open()

        datagridshow1()

    End Sub

    Private Sub mylib_Click(sender As Object, e As EventArgs) Handles mylib.Click
        mylibgr.Visible = True
        mylibrary.Visible = False
        chgepass.Visible = False
        tran.Visible = False
        datagridshow1()

    End Sub

    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click
        mylibrary.Visible = True
        mylibgr.Visible = False
        chgepass.Visible = False
        tran.Visible = False
        datagridshow()
    End Sub

    Private Sub Passwordchange_Click(sender As Object, e As EventArgs) Handles Passwordchange.Click
        mylibrary.Visible = False
        mylibgr.Visible = False
        chgepass.Visible = True
        tran.Visible = False
    End Sub
    Private Sub Transaction_Click(sender As Object, e As EventArgs) Handles Transaction.Click
        tran.Visible = True
        mylibrary.Visible = False
        mylibgr.Visible = False
        chgepass.Visible = False
        datagridshowtr()

        '238, 60
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" Then
            command = New OleDbCommand("select [ID],[Book],[Author],[Quantity] from Book_Details where [ID]=" & TextBox1.Text & "", con)
            dr = command.ExecuteReader()
            dr.Read()
            TextBox2.Text = dr(1)
            TextBox3.Text = dr(2)
            dr.Close()
        ElseIf TextBox2.Text <> "" Then
            command = New OleDbCommand("select [ID],[Book],[Author],[Quantity] from Book_Details where [Book]='" & TextBox2.Text & "'", con)
            dr = command.ExecuteReader()
            dr.Read()
            TextBox1.Text = dr(0)
            TextBox2.Text = dr(1)
            TextBox3.Text = dr(2)
            dr.Close()
        ElseIf TextBox3.Text <> "" Then
            Dim dds As New DataSet
            Dim ddt As New DataTable
            dds.Tables.Add(ddt)
            Dim dda As OleDbDataAdapter
            dda = New OleDbDataAdapter("Select [ID],[Book],[Author],[Quantity] from Book_Details where [Author]='" & TextBox3.Text & "'", con)
            dda.Fill(ddt)
            DataGridView.DataSource = ddt.DefaultView

        Else
            MsgBox("There must me a value for search !!")
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        datagridshow()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim quantity As Integer = 0
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("There must me be a book to issue")
        Else
            command = New OleDbCommand("select [Quantity] from Book_Details where [ID]=" & TextBox1.Text & "", con)
            dr = command.ExecuteReader()
            dr.Read()
            quantity = dr(0)
            dr.Close()
            If quantity > 0 Then
                quantity -= 1
                command = New OleDbCommand("update Book_Details set [Quantity] =" & quantity & " where [ID] = " & TextBox1.Text & "", con)
                command.ExecuteNonQuery()

                Dim today As Date = Date.Now().ToString("MM\/dd\/yyyy")
                'Dim today As String = regdate.ToString("MM\/dd\/yyyy")

                If quantity = 1 Then
                    command = New OleDbCommand("update Book_Details set [dateone]='" & today & "'  where [ID] = " & TextBox1.Text & "", con)
                    command.ExecuteNonQuery()
                    command = New OleDbCommand("update Book_Details set [issueone]=" & userid & "  where [ID] = " & TextBox1.Text & "", con)
                    command.ExecuteNonQuery()
                ElseIf quantity = 0 Then
                    command = New OleDbCommand("update Book_Details set [issuetwo]=" & userid & "  where [ID] = " & TextBox1.Text & "", con)
                    command.ExecuteNonQuery()
                    command = New OleDbCommand("update Book_Details set [datetwo]='" & today & "'  where [ID] = " & TextBox1.Text & "", con)
                    command.ExecuteNonQuery()
                Else
                    MsgBox("somthing went wrong !! ;(")
                End If

            Else
                MsgBox("Out of stock !!")
            End If

        End If
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        datagridshow()
    End Sub

    Private Sub passclear_Click(sender As Object, e As EventArgs) Handles passclear.Click
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox6.Focus()
    End Sub

    Private Sub passsubmit_Click(sender As Object, e As EventArgs) Handles passsubmit.Click
        Dim status As Boolean = False
        Dim pass As String = ""
        'con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\vb project files\DATABASE\liberary.mdb"
        'con.Open()
        command = New OleDb.OleDbCommand("select * from login where username=" & userid & "", con)
        dr = command.ExecuteReader()
        dr.Read()
        pass = dr(2)
        dr.Close()

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("these fields cannot be empty ")
            status = False
        ElseIf pass <> TextBox1.Text Then
            MsgBox("passsword is incorrect")
            status = False
        ElseIf TextBox2.Text <> TextBox3.Text Then
            MsgBox("no match found !")
            TextBox2.Focus()
            status = False
        Else
            status = True
        End If
        If status = True Then
            command = New OleDbCommand("update login set [password] ='" & TextBox3.Text & "' where [username] = " & userid & "", con)
            command.ExecuteNonQuery()
            MsgBox("password changed scucessfully !")

            status = False
        End If
    End Sub


    Private Sub Logout_Click(sender As Object, e As EventArgs) Handles Logout.Click
        Me.Hide()
        loginform.Show()
    End Sub
End Class
