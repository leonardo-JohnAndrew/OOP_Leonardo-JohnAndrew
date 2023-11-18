Imports MySql.Data.MySqlClient
Module Module1
    Dim con As New MySqlConnection
    Dim reader As MySqlDataReader
    Dim mysqlcmd As New MySqlCommand
    Dim host, uname, pwd, dbname As String
    Dim query As String
    Dim dtTable As New DataTable
    Dim adapter As New MySqlDataAdapter
    Public Sub Connect()
        host = "127.0.0.1"
        dbname = "it2boop"
        uname = "root"
        pwd = "password"
        'check connection if open 
        If Not con Is Nothing Then
            con.Close() ' connection close 
            'connection signature
            con.ConnectionString = "server =" & host & ";userid=" & uname & ";password=" & pwd & ";database =" & dbname & ""
            Try
                con.Open() 'connection is open
                MessageBox.Show("Connected!")

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
    Public Sub SaveRecord()
        Dim fname, lname, course As String
        fname = Form1.txtFname.Text ' get vcalue from text box
        lname = Form1.txtLname.Text
        course = Form1.txtCourse.Text

        'pass the query and connection to command
        query = "INSERT INTO student(studFName,studLName,course) values(@fname,@lname, @course )"
        mysqlcmd = New MySqlCommand(query, con)
        'add the parameter value
        mysqlcmd.Parameters.AddWithValue("@fname", fname)
        mysqlcmd.Parameters.AddWithValue("@lname", lname)
        mysqlcmd.Parameters.AddWithValue("@course", course)
        Try
            'execute query command
            mysqlcmd.ExecuteNonQuery()
            MsgBox("Record save  successfully!")
        Catch ex As Exception
            MessageBox.Show("Error" & ex.Message)
        End Try
        txtClear()
    End Sub

    Public Sub txtClear()
        Form1.txtCourse.Clear()
        Form1.txtFname.Clear()
        Form1.txtLname.Clear()
    End Sub
    Public Sub Search()
        Dim uid As String
        uid = Form1.txtuid.Text
        query = "SELECT * FROM student where studID = @uid"
        mysqlcmd = New MySqlCommand(query, con)
        mysqlcmd.Parameters.AddWithValue("@uid", uid)
        Try
            reader = mysqlcmd.ExecuteReader()
            If reader.Read Then
                Form1.txtFirst.Text = reader("studFName").ToString
                Form1.txtLast.Text = reader("studLName").ToString
                Form1.txtstudcourse.Text = reader("course").ToString
                Form1.btndelete.Enabled = True
                Form1.btnupdate.Enabled = True
                Form1.txtFirst.Enabled = True
                Form1.txtLast.Enabled = True
                Form1.txtstudcourse.Enabled = True
            Else
                MsgBox("Not Found!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            reader.Close()
        End Try

    End Sub
    Public Sub LoadAllData()
        query = "Select * From Student"
        adapter = New MySqlDataAdapter(query, con) 'dISPLAY ALL Data in data grid
        Try
            dtTable = New DataTable
            adapter.Fill(dtTable) ' pass the record from mysql to table
            With Form2.dgvData
                .DataSource = dtTable 'set the source of datagridview
                .AutoResizeColumns()
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()

        End Try
    End Sub
    Public Sub LoadCourse()
        query = "SELECT Distinct course From student"
        Try
            mysqlcmd = New MySqlCommand(query, con)
            reader = mysqlcmd.ExecuteReader
            While reader.Read
                Form2.cboCourse.Items.Add(reader("course").ToString)

            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub DisplayData(kurso As String)
        query = "Select * From Student where course = @kurso"
        adapter = New MySqlDataAdapter(query, con) 'dISPLAY ALL Data in data grid
        adapter.SelectCommand.Parameters.AddWithValue("@kurso", kurso)

        Try
            dtTable = New DataTable
            adapter.Fill(dtTable) ' pass the record from mysql to table
            With Form2.dgvData
                .DataSource = dtTable 'set the source of datagridview
                .AutoResizeColumns()
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()

        End Try
    End Sub

    Public Sub UpdateRecords(studID As String, Fname As String, lname As String, course As String)
        query = "Update student set studFName = @fname , studLName = @lname, course = @course where studID  = @studID "
        Try
            Using CMD As New MySqlCommand(query, con)
                CMD.Parameters.AddWithValue("@fname", Fname)
                CMD.Parameters.AddWithValue("@lname", lname)
                CMD.Parameters.AddWithValue("@course", course)
                CMD.Parameters.AddWithValue("@studID", studID)
                CMD.ExecuteNonQuery()

            End Using
            MsgBox("Update Successfull!", vbInformation, "UPDATE MESSAGE")
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbInformation, "ERROR MESSAGE")
        Finally
            Form1.txtFirst.Clear()
            Form1.txtLast.Clear()
            Form1.txtstudcourse.Clear()
            Form1.txtuid.Clear()
        End Try
    End Sub
    Public Sub DELETE(stuid As String)
        query = "DELETE student  studFName  , studLName , course  where studID  = @studID "
        Try
            Using CMD As New MySqlCommand(query, con)
                CMD.Parameters.AddWithValue("@studID", stuid)
                CMD.ExecuteNonQuery()

            End Using
            MsgBox("DELETION Successfull!", vbInformation, "DELETE MESSAGE")
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbInformation, "ERROR MESSAGE")
        Finally
            Form1.txtFirst.Clear()
            Form1.txtLast.Clear()
            Form1.txtstudcourse.Clear()
            Form1.txtuid.Clear()
        End Try

    End Sub
End Module
