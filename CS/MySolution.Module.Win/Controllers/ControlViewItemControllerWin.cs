using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Layout;
using MySolution.Module.BusinessObjects;
using System;
using System.Windows.Forms;

namespace MySolution.Module.Win.Controllers {
    public class ControlViewItemControllerWin : ObjectViewController<DetailView, Contact>
    {
        protected override void OnActivated() {
            base.OnActivated();
            ControlViewItem item = ((DetailView)View).FindItem("MyButton") as ControlViewItem;
            if (item != null) {
                item.ControlCreated += item_ControlCreated;
            }
        }
        void item_ControlCreated(object sender, EventArgs e) {
            (((ControlViewItem)sender).Control as Button).Text = "Click me!";
            (((ControlViewItem)sender).Control as Button).Click += ButtonClickHandlingWinController_Click;
        }
        void ButtonClickHandlingWinController_Click(object sender, EventArgs e) {
            MessageBox.Show("Action from custom View Item was executed!");
        }
    }
}