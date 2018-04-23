using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Web;
using DevExpress.Web;
using MySolution.Module.BusinessObjects;
using System;

namespace MySolution.Module.Web.Controllers {
    public class ControlDetailItemController : ViewController {
        public ControlDetailItemController() {
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(Contact);
        }
        protected override void OnActivated() {
            base.OnActivated();
            ControlViewItem item = ((DetailView)View).FindItem("MyButton") as ControlViewItem;
            if (item != null) {
                if (item.Control != null) {
                    item_ControlCreated(item, EventArgs.Empty);
                }
                else {
                    item.ControlCreated += item_ControlCreated;
                }
            }
        }
        private void item_ControlCreated(object sender, EventArgs e) {
            ASPxButton button = ((ControlViewItem)sender).Control as ASPxButton;
            if (button == null) return;
            button.ID = "MyButton";
            button.Text = "Click me!";
            button.Click += ButtonClickHandlingWebController_Click;
        }

        void ButtonClickHandlingWebController_Click(object sender, EventArgs e) {
            WebWindow.CurrentRequestWindow.RegisterClientScript("ShowAlert", @"alert('Action from custom detail item was executed!');");
        }
    }
}