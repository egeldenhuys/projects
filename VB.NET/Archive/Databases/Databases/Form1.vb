Imports MySql.Data.MySqlClient
Public Class Form1
    Dim con As MySqlConnection = New MySqlConnection("Data Source=31.170.160.81;Database=a1184946_Test;User ID=a1184946_Test;Password=irapecats2;")
    Dim sql As MySqlCommand = New MySqlCommand("SELECT * FROM Employee", con)
    Dim ds As DataSet = New DataSet()
    Dim DataAdapter1 As MySqlDataAdapter = New MySqlDataAdapter()
    Dim Comb As MySqlCommandBuilder

    'Please add datagridview to your form and name it datagrid1
    'This will display the data to datagrid view 
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        con.Open()
        DataAdapter1.SelectCommand = sql
        DataAdapter1.Fill(ds, "Employee")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Employee"
        con.Close()
    End Sub

    'Update database. Change any data from datagrid then click this button it will save any changes from the grid
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Comb = New MySqlCommandBuilder(DataAdapter1)
        Dim i As Integer = DataAdapter1.Update(ds.Tables("Employee"))
        MessageBox.Show("modify the number " & i.ToString & " rows")
    End Sub

    'Sample insert record to MySQL database
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim MyCommand As New MySqlCommand
        con.Open()
        MyCommand.Connection = con
        MyCommand.CommandText = "INSERT INTO Employee(IDNo,FirstName,LastName,email) VALUES( ‘" & txtID.Text & "‘,’" & txtfirstname.Text & "‘,’" & txtlastname.Text & "‘,’" & txtemail.Text & "‘)"
        MyCommand.ExecuteNonQuery()
        con.Close()
        MsgBox("Record successfully added!")

    End Sub

End Class
