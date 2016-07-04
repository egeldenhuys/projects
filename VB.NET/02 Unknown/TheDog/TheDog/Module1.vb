Imports System.Console

Module Module1



    Sub Main()
        Dim playerName, tmp As String

        WriteLine("PLEASE ENTER NAME:")
        Write(">")
        playerName = ReadLine()
        WriteLine("Hello " & playerName)
        WriteLine("Do you want to play a game?")
        Write(">")

        If ReadLine.ToLower = "yes" Then
            WriteLine("You see a dog with a gun in it's mouth. What do you do? You have 2 options.")
            Write(">")
            tmp = ReadLine()

            Select Case tmp.ToLower

                Case "kill it"
                    WriteLine("You kick the dog to death, are you happy now?")

                Case "run away"
                    WriteLine("You run away but fall over a dead cat. The dog chews your face off. You are dead.")

                Case Else
                    WriteLine("You do not know how to do that, so instead you wet your pants.")
            End Select
        End If

        WriteLine("Press any key to exit...")
        ReadKey()

    End Sub



End Module
