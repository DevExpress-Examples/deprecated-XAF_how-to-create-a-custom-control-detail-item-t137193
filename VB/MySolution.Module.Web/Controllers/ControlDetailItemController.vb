Imports Microsoft.VisualBasic
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Web
Imports DevExpress.Web.ASPxEditors
Imports MySolution.Module.BusinessObjects
Imports System

Namespace MySolution.Module.Web.Controllers
	Public Class ControlDetailItemController
		Inherits ViewController
		Public Sub New()
			TargetViewType = ViewType.DetailView
			TargetObjectType = GetType(Contact)
		End Sub
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			Dim item As ControlDetailItem = TryCast((CType(View, DetailView)).FindItem("MyButton"), ControlDetailItem)
			If item IsNot Nothing Then
				If item.Control IsNot Nothing Then
					item_ControlCreated(item, EventArgs.Empty)
				Else
					AddHandler item.ControlCreated, AddressOf item_ControlCreated
				End If
			End If
		End Sub
		Private Sub item_ControlCreated(ByVal sender As Object, ByVal e As EventArgs)
			Dim button As ASPxButton = TryCast((CType(sender, ControlDetailItem)).Control, ASPxButton)
			If button Is Nothing Then
				Return
			End If
			button.ID = "MyButton"
			button.Text = "Click me!"
			AddHandler button.Click, AddressOf ButtonClickHandlingWebController_Click
		End Sub

		Private Sub ButtonClickHandlingWebController_Click(ByVal sender As Object, ByVal e As EventArgs)
			WebWindow.CurrentRequestWindow.RegisterClientScript("ShowAlert", "alert('Action from custom detail item was executed!');")
		End Sub
	End Class
End Namespace