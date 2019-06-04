Imports System.Data.OleDb
Imports System.Data
Public Class staff
    Dim con As New OleDb.OleDbConnection
    Dim command As OleDb.OleDbCommand
    Dim dr As OleDb.OleDbDataReader
    Dim userid As Integer
    Dim usrname As String

    '--------------------------------------------Database functions Starts--------------------------------------

    '--------------------------------------------Database functions Ends!!--------------------------------------


    Private Sub Logout_Click(sender As Object, e As EventArgs) Handles Logout.Click
        Me.Hide()
        loginform.Show()
    End Sub

    Private Sub staff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chgepass.Visible = False
        mylibrary.Visible = False
        dash.Visible = True
        serch.Visible = False
        tran.Visible = False
        userbox.Visible = False




        usrname = Nme.Text
        userid = usrid.Text


        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\vb project files\DATABASE\liberary.mdb"
        con.Open()
        'command = New OleDb.OleDbCommand("select * from login where username=" & Nme.Text & "", con)
        'dr = command.ExecuteReader()
        'dr.Read()
        'Nme.Text = dr(1)
        'dr.Close()
        'con.Close()
        '------------------------------------defalt dashboard----------
        Dim count As Integer = 0
        command = New OleDbCommand("select count(*) from login", con)
        count = command.ExecuteScalar()
        Label6.Text = count
        command = New OleDbCommand("select count(*) from Book_Details", con)
        count = command.ExecuteScalar()
        Label5.Text = count
        command = New OleDbCommand("select count(*) from Book_Details where [issueone] is not null or [issuetwo] is not null", con)
        count = command.ExecuteScalar()
        Label7.Text = count
        stuadd.Visible = False
        addookss.Visible = False
        '-------------------------------------------------------------------
    End Sub

    '----------------------------------------- menu items------------------------------------------

    Private Sub mylib_Click(sender As Object, e As EventArgs) Handles mylib.Click
        mylibrary.Visible = True
        chgepass.Visible = False
        dash.Visible = False
        serch.Visible = False
        tran.Visible = False
        datagridshow()
        userbox.Visible = False



    End Sub

    Private Sub Dashboard_Click(sender As Object, e As EventArgs) Handles Dashboard.Click
        dash.Visible = True
        mylibrary.Visible = False
        chgepass.Visible = False
        serch.Visible = False
        tran.Visible = False
        userbox.Visible = False
        '---------------
        stuadd.Visible = False
        addookss.Visible = False
        Dim count As Integer = 0
        command = New OleDbCommand("select count(*) from login", con)
        count = command.ExecuteScalar()
        Label6.Text = count
        command = New OleDbCommand("select count(*) from Book_Details", con)
        count = command.ExecuteScalar()
        Label5.Text = count
        command = New OleDbCommand("select count(*) from Book_Details where [issueone] is not null or [issuetwo] is not null", con)
        count = command.ExecuteScalar()
        Label7.Text = count
        '-------------------

    End Sub

    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click
        serch.Visible = True
        chgepass.Visible = False
        mylibrary.Visible = False
        dash.Visible = False
        tran.Visible = False
        userbox.Visible = False
        datagridshow1()
    End Sub


    Private Sub Passwordchange_Click(sender As Object, e As EventArgs) Handles Passwordchange.Click
        chgepass.Visible = True
        mylibrary.Visible = False
        dash.Visible = False
        serch.Visible = False
        userbox.Visible = False
        tran.Visible = False
    End Sub
    Private Sub Transaction_Click(sender As Object, e As EventArgs) Handles Transaction.Click
        tran.Visible = True
        chgepass.Visible = False
        mylibrary.Visible = False
        dash.Visible = False
        serch.Visible = False
        userbox.Visible = False
        datagridshowtr()
    End Sub
    Private Sub News_Click(sender As Object, e As EventArgs) Handles News.Click
        userbox.Visible = True
        chgepass.Visible = False
        mylibrary.Visible = False
        dash.Visible = False
        serch.Visible = False
        tran.Visible = False
        datagridshowuser()
    End Sub

    '---------------------------------------------------end-----------------------------------------------------------------


    '-----------------------------------------------data grids-----------------------------------------------


   
    Private Sub datagridshow()
        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)
        Dim da As OleDbDataAdapter
        da = New OleDbDataAdapter("Select * from Book_Details", con)
        da.Fill(dt)
        DataGridView2.DataSource = dt.DefaultView
        ' con.Close()

    End Sub

    Private Sub datagridshow1()
        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)
        Dim da As OleDbDataAdapter
        da = New OleDbDataAdapter("Select [ID],[Book],[Author],[Quantity] from Book_Details", con)
        da.Fill(dt)
        DataGridView.DataSource = dt.DefaultView

    End Sub


    Private Sub datagridshowtr()
        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)
        Dim da As OleDbDataAdapter
        da = New OleDbDataAdapter("select [ID],[Book],[Issueone],[dateone],[issuetwo],[datetwo],[quantity]  from Book_Details where [issueone] is not null or [issuetwo] is not null", con)
        da.Fill(dt)
        DataGridViewtran.DataSource = dt.DefaultView
    End Sub

    Private Sub datagridshowuser()
        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)
        Dim da As OleDbDataAdapter
        da = New OleDbDataAdapter("select * from login ", con)
        da.Fill(dt)
        usergrid.DataSource = dt.DefaultView
    End Sub

    '---------------------------------------------------end-----------------------------------------------------------------



    '--------------------------------------------- button events ----------------------------------------------------------
    Private Sub bookadd_Click(sender As Object, e As EventArgs) Handles bookadd.Click
        addookss.Visible = True
        stuadd.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox4.Text <> "" Or TextBox5.Text <> "" Then
            command = New OleDbCommand("insert into Book_Details (Book, Author, Quantity, issueone, issuetwo) values('" & TextBox4.Text & "', '" & TextBox5.Text & "', 2, null, null)", con)
            command.ExecuteNonQuery()
            MsgBox("sucess")
        Else
            MsgBox("These fields must be filled !!")
        End If
        
    End Sub

    Private Sub memberadd_Click(sender As Object, e As EventArgs) Handles memberadd.Click
        stuadd.Visible = True
        addookss.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If textboxid.Text = "" Or TextBox7.Text = "" Or TextBox6.Text = "" Then
            MsgBox("These fields should be filled !!")
            textboxid.Focus()
        Else
            command = New OleDbCommand("INSERT INTO login ([username], [Name], [password] ) VALUES(" & textboxid.Text & ",'" & TextBox7.Text & "', '" & TextBox6.Text & "')", con)

            Try
                command.ExecuteNonQuery()
                MsgBox("sucess")

            Catch
                MsgBox("userid should be unique !!")
            End Try
        End If
       
    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If TextBox13.Text <> "" Then
            command = New OleDbCommand("select [ID],[Book],[Author],[Quantity] from Book_Details where [ID]=" & TextBox13.Text & "", con)
            dr = command.ExecuteReader()
            dr.Read()
            TextBox12.Text = dr(1)
            TextBox11.Text = dr(2)
            dr.Close()
        ElseIf TextBox12.Text <> "" Then
            command = New OleDbCommand("select [ID],[Book],[Author],[Quantity] from Book_Details where [Book]='" & TextBox12.Text & "'", con)
            dr = command.ExecuteReader()
            dr.Read()
            TextBox13.Text = dr(0)
            TextBox12.Text = dr(1)
            TextBox11.Text = dr(2)
            dr.Close()
        ElseIf TextBox11.Text <> "" Then
            Dim dds As New DataSet
            Dim ddt As New DataTable
            dds.Tables.Add(ddt)
            Dim dda As OleDbDataAdapter
            dda = New OleDbDataAdapter("Select [ID],[Book],[Author],[Quantity] from Book_Details where [Author]='" & TextBox11.Text & "'", con)
            dda.Fill(ddt)
            DataGridView.DataSource = ddt.DefaultView

        Else
            MsgBox("There must me a value for search !!")
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        datagridshow()
    End Sub

    '---------------------------------------------------end-----------------------------------------------------------------

End Class