Imports CS_DLL
Imports System.Reflection

Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim StuffThings As New CS_DLL.MahFunctions
        Dim DynThing As Assembly
        Dim oType As System.Type
        Dim oObject As System.Object

        DynThing = Assembly.LoadFrom("C:\Users\Evert\Documents\Visual Studio 2010\Projects\CS_DLL\CS_DLL\bin\Release\CS_DLL.dll")
        oType = DynThing.GetType("MahFunctions")
        oObject = Activator.CreateInstance(oType)



        'Label2.Text = CStr(StuffThings.AddStuff(CInt(TextBox1.Text), CInt(TextBox2.Text)))

    End Sub
End Class
