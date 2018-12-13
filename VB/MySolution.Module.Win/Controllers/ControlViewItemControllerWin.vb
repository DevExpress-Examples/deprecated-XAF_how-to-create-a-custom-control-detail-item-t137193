Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Layout
Imports MySolution.Module.BusinessObjects
Imports System
Imports System.Windows.Forms

Namespace MySolution.Module.Win.Controllers
    Public Class ControlViewItemControllerWin
        Inherits ObjectViewController(Of DetailView, Contact)

        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            Dim item As ControlViewItem = TryCast(CType(View, DetailView).FindItem("MyButton"), ControlViewItem)
            If item IsNot Nothing Then
                AddHandler item.ControlCreated, AddressOf item_ControlCreated
            End If
        End Sub
        Private Sub item_ControlCreated(ByVal sender As Object, ByVal e As EventArgs)
            TryCast(DirectCast(sender, ControlViewItem).Control, Button).Text = "Click me!"
            AddHandler TryCast(DirectCast(sender, ControlViewItem).Control, Button).Click, AddressOf ButtonClickHandlingWinController_Click
        End Sub
        Private Sub ButtonClickHandlingWinController_Click(ByVal sender As Object, ByVal e As EventArgs)
            MessageBox.Show("Action from custom View Item was executed!")
        End Sub
    End Class
End Namespace