Imports Mysql.Data.MysqlClient
Module Module1
    Dim con As New MySqlConnection
    Dim reader As MySqlDataReader
    Dim mysqlcmd As New MySqlCommand
    Dim host, uname, pwd, dbname As String
    Dim query As String
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
        uid = Form1.txtuid.text
        query = "SELECT * FROM student where studID = @uid"
        mysqlcmd = New MySqlCommand(query, con)
        mysqlcmd.Parameters.AddWithValue("@uid", uid)
        Try
            reader = mysqlcmd.ExecuteReader()
            If reader.Read Then
                Form1.txtFirst.Text = reader("studFName").ToString
                Form1.txtLast.Text = reader("studLName").ToString
                Form1.txtstudcourse.Text = reader("course").ToString
            Else
                MsgBox("Not Found!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            reader.Close()
        End Try

    End Sub
End Module
