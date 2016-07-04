Imports FunWithCars_4.ConsoleUI

Module Module1

    Sub Main()
        Console.SetBufferSize(80, 29)
        Console.SetWindowSize(80, 30)
        DrawBase()

        Console.ReadKey()

    End Sub

    Private Sub DrawBase()
        Console.WriteLine("+-----------------------------------------------------------------------------+")
        Console.WriteLine("|                                Fun With Cars                                |")
        Console.WriteLine("|-----------------------------------------------------------------------------|")
        Console.WriteLine("|                                                                             |")
        Console.WriteLine("|    +--------- Menu --------+           +-| Database Information |-+         |")
        Console.WriteLine("|    | [A] - Add Car         |           |Current Database:         |         |")
        Console.WriteLine("|    |-----------------------|           |Default                   |         |")
        Console.WriteLine("|    | [E] - Edit Car        |           |                          |         |")
        Console.WriteLine("|    |-----------------------|           |Cars In Database:         |         |")
        Console.WriteLine("|    | [V] - View Cars       |           |0                         |         |")
        Console.WriteLine("|    |-----------------------|           +--------------------------+         |")
        Console.WriteLine("|    | [S] - View Statistics |                                                |")
        Console.WriteLine("|    |-----------------------|                                                |")
        Console.WriteLine("|    | [R] - Remove Car      |                                                |")
        Console.WriteLine("|    |-----------------------|                                                |")
        Console.WriteLine("|    | [D] - Manage Databases|                                                |")
        Console.WriteLine("|    |-----------------------|                                                |")
        Console.WriteLine("|    | [Q] - Quit            |                                                |")
        Console.WriteLine("|    +-----------------------+                                                |")
        Console.WriteLine("|                                                                             |")
        Console.WriteLine("|                                                                             |")
        Console.WriteLine("|                                                                             |")
        Console.WriteLine("|                                                                             |")
        Console.WriteLine("|                                                                             |")
        Console.WriteLine("+-----------------------------------------------------------------------------+")
        Console.WriteLine("| Use the keys shows in the menu to select a option or use the arrow keys     |")
        Console.WriteLine("| ArrowKeys  - ChangeSelection                                                |")
        Console.WriteLine("| [ESC]      - Close Program                                                  |")
        Console.WriteLine("+-----------------------------------------------------------------------------+")

    End Sub
End Module
