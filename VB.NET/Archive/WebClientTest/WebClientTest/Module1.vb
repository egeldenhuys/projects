Imports System.Net

Module Module1

    Sub Main()
        Dim wc As New WebClient

        wc.Proxy = HttpWebRequest.DefaultWebProxy
        wc.Proxy.Credentials = CredentialCache.DefaultCredentials


        Try
            Console.WriteLine(wc.DownloadString(New Uri("http://google.com/")))
        Catch ex As Exception
            Console.WriteLine(ex.Message)

        End Try

        Console.ReadKey()


    End Sub

End Module
