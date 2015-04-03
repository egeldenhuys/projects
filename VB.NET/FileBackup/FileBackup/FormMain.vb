Imports System.IO

Public Class FormMain

#Region "TODO"
    ' Replace 1 demensional arrays with 4 dimmensional array ( 1 for each data type)
    ' Add: Run Task Function
    ' Add: Help -> About (Instructions)
    ' Add: Help -> check for updates (function)
    ' Add: File -> Exit (function)
    ' Add: Help -> About -> Version
    ' Save the Task to file and update array function for Save button
    ' Function to determine if the old config file is compatible with the latest version, if it is copy it over. 
    '       If it is not tell the user. If they choose to convert them display a form to make the Tasks compatible
    ' (?) Import config file from old version folder - old files will require conversion and user input
    ' (?) Move project folder to dropbox folder - could allow for faster update releases
#End Region

    Dim TaskNameArray(0) As String
    Dim TaskSourceArray(0) As String
    Dim TaskDestinationArray(0) As String
    Dim TaskFolderArray(0) As String

    Dim AppData As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
    Dim ConfigFile As String = AppData & "\Config.txt"

    Dim FormSizeCounter As Integer = 0
    Dim FormMaxWidth As Integer = 722
    Dim FormMinWidth As Integer = 262

    Private Sub FormMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Width = FormMinWidth
        grpNewTask.Visible = False

        LoadTasks()
        DisplayTaskNames()

        Console.WriteLine("Load Complete ------")

        MsgBox(My.Application.Info.Version.ToString)
        My.Application.Info.
    End Sub

#Region "Buttons"

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click

        ' Remove the selected task by using it's index. Will only work if the list is not sorted.
        RemoveTask(lstTask.SelectedIndex)
        ReloadArrays()
        SaveArraysToFile()
        DisplayTaskNames()

    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        btnSave.Visible = False
        btnAddTask.Visible = True

        ShowNewTaskPanel()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        HideNewTaskPanel()

    End Sub

    Private Sub btnAddTask_Click(sender As System.Object, e As System.EventArgs) Handles btnAddTask.Click
        Dim folder As String

        If chkFolder.Checked = True Then
            folder = "T"
        Else
            folder = "F"
        End If

        If txtSource.Text <> Nothing Then
            If txtDestination.Text <> Nothing Then
                If txtTaskName.Text <> Nothing Then

                    ' Add to array and save to file
                    SaveTask(txtTaskName.Text, txtSource.Text, txtDestination.Text, folder)
                    DisplayTaskNames()

                End If
            End If
        End If
    End Sub

    Private Sub btnSetSource_Click(sender As System.Object, e As System.EventArgs) Handles btnSetSource.Click
        If chkFolder.Checked = True Then
            FolderBrowserDialog1.ShowDialog()
            txtSource.Text = FolderBrowserDialog1.SelectedPath
        Else
            OpenFileDialog1.ShowDialog()
            txtSource.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnSetDestination_Click(sender As System.Object, e As System.EventArgs) Handles btnSetDestination.Click
        If chkFolder.Checked = True Then
            FolderBrowserDialog1.ShowDialog()
            txtDestination.Text = FolderBrowserDialog1.SelectedPath
        Else
            SaveFileDialog1.ShowDialog()
            txtDestination.Text = OpenFileDialog1.FileName
        End If

    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        txtTaskName.Clear()
        txtSource.Clear()
        txtDestination.Clear()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        btnSave.Visible = True
        btnAddTask.Visible = False

        ShowNewTaskPanel()

        ' Check if a task has been selected
        If lstTask.SelectedIndex <> -1 Then
            Dim i As Integer = lstTask.SelectedIndex

            ' Populate text boxes with the selected array's Data
            txtTaskName.Text = TaskNameArray(i)
            txtSource.Text = TaskSourceArray(i)
            txtDestination.Text = TaskDestinationArray(i)
        End If
    End Sub

    Private Sub btnRun_Click(sender As System.Object, e As System.EventArgs) Handles btnRun.Click
        Dim taskIndex As Integer = lstTask.SelectedIndex

        If lstTask.SelectedIndex <> -1 Then
            My.Computer.FileSystem.CopyDirectory(TaskSourceArray(taskIndex), TaskDestinationArray(taskIndex), False)

        End If
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        HideNewTaskPanel()

    End Sub

#End Region

#Region "Functions"

    Private Sub SaveTask(ByVal Taskname As String, ByVal TaskSource As String, ByVal TaskDestination As String, ByVal TaskFolder As String)
        Console.WriteLine("SaveTask")

        ' Add the task to the arrays
        AddToTaskArray(Taskname, TaskSource, TaskDestination, TaskFolder)

        Console.WriteLine("AddToTaskArray(" & Taskname & ", " & TaskSource & ", " & TaskDestination & ", " & TaskFolder & ")")

        ' Save the task to the file
        Try
            Dim Writer As New StreamWriter(ConfigFile, True)

            Writer.WriteLine(Taskname & "=" & TaskSource & ">" & TaskDestination & ">" & TaskFolder)
            Writer.Close()

        Catch ex1 As System.IO.IOException
            MsgBox(ex1.ToString)
        End Try

    End Sub

    Private Sub LoadTasks()
        Console.WriteLine("LoadTasks")

        'If the config file exits, load the Tasks.
        If My.Computer.FileSystem.FileExists(ConfigFile) Then
            Dim Reader As New StreamReader(ConfigFile)
            Dim Line As String

            Do While Reader.Peek <> -1
                Line = Reader.ReadLine
                SplitToTaskArray(Line)

                Console.WriteLine("SplitToTaskArray(" & Line & ")")
            Loop

            Reader.Close()

        End If

    End Sub

    Private Sub SplitToTaskArray(ByVal RawTaskData As String)
        Console.WriteLine("SplitToTaskArray")

        ' Split a string containing the data for a Task into their correct arrays (eg. TaskName=TaskSource>TaskDestination)

        Dim TaskName, TaskSource, TaskDestination As String
        Dim TaskFolder As String

        Dim subStrings() As String

        'TaskName
        subStrings = Split(RawTaskData, "=")
        TaskName = subStrings(0)

        'TaskSource
        subStrings = Split(subStrings(1), ">")
        TaskSource = subStrings(0)

        'TaskDestination
        TaskDestination = subStrings(1)

        'Task Folder
        TaskFolder = subStrings(2)

        AddToTaskArray(TaskName, TaskSource, TaskDestination, TaskFolder)
    End Sub

    Private Sub AddToTaskArray(ByVal Taskname As String, ByVal TaskSource As String, ByVal TaskDestination As String, ByVal TaskFolder As String)
        Console.WriteLine("AddToTaskArray")

        ' Add the given Task data to their arrays

        'If this is the first task to be added, add it to the first element. Else expand the arrays and add to elements
        If TaskNameArray(0) = Nothing Then
            TaskNameArray(0) = Taskname
            TaskSourceArray(0) = TaskSource
            TaskDestinationArray(0) = TaskDestination
            TaskFolderArray(0) = TaskFolder

        Else
            ' Expand arrays
            Console.WriteLine("Expanding Arrays")

            ReDim Preserve TaskNameArray(TaskNameArray.GetUpperBound(0) + 1)
            ReDim Preserve TaskSourceArray(TaskSourceArray.GetUpperBound(0) + 1)
            ReDim Preserve TaskDestinationArray(TaskDestinationArray.GetUpperBound(0) + 1)
            ReDim Preserve TaskFolderArray(TaskFolderArray.GetUpperBound(0) + 1)

            ' Add individual strings to the newly created elements
            TaskNameArray(TaskNameArray.GetUpperBound(0)) = Taskname
            TaskSourceArray(TaskSourceArray.GetUpperBound(0)) = TaskSource
            TaskDestinationArray(TaskDestinationArray.GetUpperBound(0)) = TaskDestination
            TaskFolderArray(TaskFolderArray.GetUpperBound(0)) = TaskFolder

        End If

    End Sub

    Private Sub DisplayTaskNames()
        Console.WriteLine("DisplayTaskNames")

        lstTask.Items.Clear()

        ' Display the Task names in the list box.

        For Each Task In TaskNameArray

            If Task <> Nothing Then
                lstTask.Items.Add(Task)
                Console.WriteLine("Adding " & Task & " to task list.")
            End If

        Next

    End Sub

    Private Sub RemoveTask(ByVal TaskIndex As Integer)
        Console.WriteLine("RemoveTask")

        If lstTask.SelectedIndex <> -1 Then
            Console.WriteLine("Removing Task: " & TaskIndex)

            Console.WriteLine("Task Data Before: " & TaskNameArray(TaskIndex) & ", " & TaskSourceArray(TaskIndex) & ", " & TaskDestinationArray(TaskIndex) & ", " & TaskFolderArray(TaskIndex))

            ' Remove the task by clearing it's index
            Array.Clear(TaskNameArray, TaskIndex, 1)
            Array.Clear(TaskSourceArray, TaskIndex, 1)
            Array.Clear(TaskDestinationArray, TaskIndex, 1)
            Array.Clear(TaskFolderArray, TaskIndex, 1)

            Console.WriteLine("Task Data After: " & TaskNameArray(TaskIndex) & ", " & TaskSourceArray(TaskIndex) & ", " & TaskDestinationArray(TaskIndex) & ", " & TaskFolderArray(TaskIndex))
        End If

    End Sub

    Private Sub ReloadArrays()
        Console.WriteLine("ReloadArrays")

        Dim counter As Integer = 0 ' How many times the whole array has been searched
        Dim arrayCounter As Integer = 0 ' How many times a task has been found

        For Each Task In TaskNameArray

            Console.WriteLine("(Counter) Index " & counter & " contained " & TaskNameArray(counter) & ", " & TaskSourceArray(counter) & ", " & TaskDestinationArray(counter) & ", " & TaskFolderArray(counter))

            If Task <> Nothing Then

                TaskNameArray(arrayCounter) = TaskNameArray(counter)
                TaskSourceArray(arrayCounter) = TaskSourceArray(counter)
                TaskDestinationArray(arrayCounter) = TaskDestinationArray(counter)
                TaskFolderArray(arrayCounter) = TaskFolderArray(counter)

                Console.WriteLine("(ArrayCounter) Index " & arrayCounter & " contained " & TaskNameArray(arrayCounter) & ", " & TaskSourceArray(arrayCounter) & ", " & TaskDestinationArray(arrayCounter) & ", " & TaskFolderArray(arrayCounter))

                arrayCounter += 1

            End If

            counter += 1
        Next

        If TaskNameArray.GetUpperBound(0) < 0 Then
            ReDim Preserve TaskNameArray(TaskNameArray.GetUpperBound(0) - 1)
            ReDim Preserve TaskSourceArray(TaskSourceArray.GetUpperBound(0) - 1)
            ReDim Preserve TaskDestinationArray(TaskDestinationArray.GetUpperBound(0) - 1)
            ReDim Preserve TaskFolderArray(TaskFolderArray.GetUpperBound(0) - 1)
        End If

    End Sub

    Private Sub SaveArraysToFile()
        Console.WriteLine("SaveArraysToFile")

        Dim writer As New StreamWriter(ConfigFile, False)
        Dim counter As Integer = 0

        ' Write the arrays in memory to the Config file.
        For Each Task In TaskNameArray

            If Task <> Nothing Then
                writer.WriteLine(TaskNameArray(counter) & "=" & TaskSourceArray(counter) & ">" & TaskDestinationArray(counter) & ">" & TaskFolderArray(counter))
                counter += 1
            End If

        Next

        writer.Close()
    End Sub

    Private Sub TimerExpand_Tick(sender As System.Object, e As System.EventArgs) Handles TimerExpand.Tick

        ' Expand form Width
        Me.Width = Me.Width + FormSizeCounter

        If FormSizeCounter < 50 Then
            FormSizeCounter += 1
        End If

        ' Stop when it has reached it's target
        If Me.Width > FormMaxWidth Then
            TimerExpand.Enabled = False
            Me.Width = FormMaxWidth
        End If

    End Sub

    Private Sub ShowNewTaskPanel()

        If Me.Width = FormMinWidth Then
            TimerExpand.Enabled = True

            ' Show the hidden buttons
            grpNewTask.Visible = True

        End If

        If chkFolder.Checked = True Then
            lblSource.Text = "Source Folder"
        Else
            lblSource.Text = "Source File"
        End If

    End Sub

    Private Sub TimerContract_Tick(sender As System.Object, e As System.EventArgs) Handles TimerContract.Tick

        ' Contract form width.
        Me.Width = Me.Width - FormSizeCounter

        If FormSizeCounter < FormMinWidth Then
            FormSizeCounter += 1
        End If

        ' Stop when it has reached its normal width.
        If Me.Width < FormMinWidth Then
            TimerContract.Enabled = False
            Me.Width = FormMinWidth

            'Hide the hidden buttons
            grpNewTask.Visible = False
        End If
    End Sub



    Private Sub chkFolder_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkFolder.CheckedChanged

        ' Change the labels to reflect the chosen option.
        If chkFolder.Checked = True Then
            lblSource.Text = "Source Folder"
        Else
            lblSource.Text = "Source File"
        End If

    End Sub

    Private Sub HideNewTaskPanel()
        FormSizeCounter = 0

        'If it is already expanded contract it.

        If Me.Width = FormMaxWidth Then
            TimerContract.Enabled = True
        End If
    End Sub
#End Region

End Class
