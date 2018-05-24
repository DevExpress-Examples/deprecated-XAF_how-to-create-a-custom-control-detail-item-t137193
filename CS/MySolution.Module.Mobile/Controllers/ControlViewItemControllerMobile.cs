using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Mobile.MobileModel;
using MySolution.Module.BusinessObjects;

namespace MySolution.Module.Mobile.Controllers
{
    public class ControlViewItemControllerMobile : ObjectViewController<DetailView, Contact>
    {
        protected override void OnActivated()
        {
            base.OnActivated();
            ControlViewItem item = ((DetailView)View).FindItem("MyButton") as ControlViewItem;
            if (item != null)
            {
                if (item.Control != null)
                {
                    item_ControlCreated(item, EventArgs.Empty);
                }
                else
                {
                    item.ControlCreated += item_ControlCreated;
                }
            }
        }
        private void item_ControlCreated(object sender, EventArgs e)
        {
            Button button = ((ControlViewItem)sender).Control as Button;
            if (button == null) return;
            button.Text = "Click me!";
            button.OnClick = @"DevExpress.ui.notify({ 
                message: 'Action from custom View Item was executed!' })";
        }
    }
}
