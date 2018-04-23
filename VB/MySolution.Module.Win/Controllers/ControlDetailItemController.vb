Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Layout
Imports MySolution.Module.BusinessObjects
Imports System
Imports System.Windows.Forms

Namespace MySolution.Module.Win.Controllers
    Public Class ControlDetailItemController
        Inherits ViewController

        Public Sub New()
            TargetViewType = ViewType.DetailView
            TargetObjectType = GetType(Contact)
        End Sub
        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            Dim item As ControlDetailItem = TryCast(CType(View, DetailView).FindItem("MyButton"), ControlDetailItem)
            If item IsNot Nothing Then
                If item.Control IsNot Nothing Then
                    item_ControlCreated(item, EventArgs.Empty)
                Else
                    AddHandler item.ControlCreated, AddressOf item_ControlCreated
                End If
            End If
        End Sub
        Private Sub item_ControlCreated(ByVal sender As Object, ByVal e As EventArgs)
            TryCast(DirectCast(sender, ControlDetailItem).Control, Button).Text = "Click me!"
            AddHandler TryCast(DirectCast(sender, ControlDetailItem).Control, Button).Click, AddressOf ButtonClickHandlingWinController_Click
        End Sub
        Private Sub ButtonClickHandlingWinController_Click(ByVal sender As Object, ByVal e As EventArgs)
            Throw New UserFriendlyException("Action from custom detail item was executed!")
        End Sub
    End Class
End Namespace