Module Module1



    Sub Main()
        Console.Title = "Join Group"

        Dim UserName As String

        Dim UserAge As Integer



        'Gather name.

        Console.WriteLine("What is your name?")

        UserName = Console.ReadLine()



        'Gather age.

        Console.WriteLine("How old are you?")

        UserAge = CInt(Console.ReadLine())



        Console.WriteLine("Hi " + UserName + ". You are " + CStr(UserAge) + ".")



        'Allow?

        If UserAge < 14 Then

            Console.WriteLine("You need a parent's permission to join our group.")

        Else

            Console.WriteLine("Welcome to our group.")

        End If



        'Exit.

        Console.WriteLine()

        Console.WriteLine("Press [ANYKEY] to exit.")

        Console.ReadLine()

    End Sub

End Module