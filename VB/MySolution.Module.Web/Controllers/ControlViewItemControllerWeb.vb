Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Web
Imports DevExpress.Web
Imports MySolution.Module.BusinessObjects
Imports System

Namespace MySolution.Module.Web.Controllers
    Public Class ControlDetailItemControllerWeb
        Inherits ObjectViewController(Of DetailView, Contact)

        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            Dim item As ControlViewItem = TryCast(CType(View, DetailView).FindItem("MyButton"), ControlViewItem)
            If item IsNot Nothing Then
                If item.Control IsNot Nothing Then
                    item_ControlCreated(item, EventArgs.Empty)
                Else
                    AddHandler item.ControlCreated, AddressOf item_ControlCreated
                End If
            End If
        End Sub
        Private Sub item_ControlCreated(ByVal sender As Object, ByVal e As EventArgs)
            Dim button As ASPxButton = TryCast(DirectCast(sender, ControlViewItem).Control, ASPxButton)
            If button Is Nothing Then
                Return
            End If
            button.ID = "MyButton"
            button.Text = "Click me!"
            AddHandler button.Click, AddressOf ButtonClickHandlingWebController_Click
        End Sub

        Private Sub ButtonClickHandlingWebController_Click(ByVal sender As Object, ByVal e As EventArgs)
            WebWindow.CurrentRequestWindow.RegisterClientScript("ShowAlert", "alert('Action from custom View Item was executed!');")
        End Sub
    End Class
End Namespace