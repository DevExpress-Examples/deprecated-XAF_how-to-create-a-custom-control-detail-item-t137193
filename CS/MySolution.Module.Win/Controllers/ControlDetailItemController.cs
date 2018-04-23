using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Layout;
using MySolution.Module.BusinessObjects;
using System;
using System.Windows.Forms;

namespace MySolution.Module.Win.Controllers {
    public class ControlDetailItemController : ViewController {
        public ControlDetailItemController() {
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(Contact);
        }
        protected override void OnActivated() {
            base.OnActivated();
            ControlDetailItem item = ((DetailView)View).FindItem("MyButton") as ControlDetailItem;
            if (item != null) {
                if (item.Control != null) {
                    item_ControlCreated(item, EventArgs.Empty);
                }
                else {
                    item.ControlCreated += item_ControlCreated;
                }
            }
        }
        void item_ControlCreated(object sender, EventArgs e) {
            (((ControlDetailItem)sender).Control as Button).Text = "Click me!";
            (((ControlDetailItem)sender).Control as Button).Click += ButtonClickHandlingWinController_Click;
        }
        void ButtonClickHandlingWinController_Click(object sender, EventArgs e) {
            throw new UserFriendlyException("Action from custom detail item was executed!");
        }
    }
}