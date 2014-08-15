Public Class Password

    Private Sub btnSignIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignIn.Click
        Dim SetPassword, Password, SetUsername, Username As String


        SetUsername = "h5"
        SetPassword = "123"
        Password = PasswordBox.Text
        Username = UsernameBox.Text

        lblIncorrectPassword.Text = " "
        lblSignedIn.Text = " "

        If Username = SetUsername Then
            If Password = SetPassword Then
                lblSignedIn.Text = "You are now signed in"
            Else
                lblIncorrectPassword.Text = "Incorrect Username or Password"
            End If

        Else
            lblIncorrectPassword.Text = "Incorrect Username or Password"

        End If


    End Sub

    Private Sub btnSignOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignOut.Click

        If lblSignedIn.Text = "You are now signed in" Then
            lblSignedIn.Text = "You are now signed out"
        End If



    End Sub
End Class