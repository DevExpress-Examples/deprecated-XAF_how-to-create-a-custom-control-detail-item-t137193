Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Mobile.MobileModel
Imports MySolution.Module.BusinessObjects

Namespace MySolution.Module.Mobile.Controllers
    Public Class ControlViewItemControllerMobile
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
            Dim button As Button = TryCast(DirectCast(sender, ControlViewItem).Control, Button)
            If button Is Nothing Then
                Return
            End If
            button.Text = "Click me!"
            button.OnClick = "DevExpress.ui.notify({ " & ControlChars.CrLf & _
                "message: 'Action from custom View Item was executed!' " & ControlChars.CrLf & _
		    "})"
        End Sub
    End Class
End Namespace
