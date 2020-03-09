
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Unnamed_LoggingOut(sender As Object, e As LoginCancelEventArgs)
        Context.GetOwinContext().Authentication.SignOut()
    End Sub

End Class

