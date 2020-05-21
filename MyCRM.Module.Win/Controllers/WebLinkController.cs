using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using DevExpress.DocumentView.Controls;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraEditors;
using MyCRM.Module.BusinessObjects;

namespace MyCRM.Module.Win.Controllers
{
    public class WebLinkController: ViewController<DetailView>
    {
        private StringPropertyEditor websiteEditor;
        public WebLinkController()
        {
            TargetObjectType = typeof(Company);
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();

             websiteEditor = View.FindItem("Website") as StringPropertyEditor;

            if (websiteEditor?.Control != null)
            {
                websiteEditor.Control.Font = new System.Drawing.Font(websiteEditor.Control.Font, System.Drawing.FontStyle.Underline);
                websiteEditor.Control.ForeColor = System.Drawing.Color.Blue;
                websiteEditor.Control.DoubleClick += Control_DoubleClick;
            }
        }

        protected override void OnDeactivated()
        {
            if (websiteEditor?.Control != null)
            {
                websiteEditor.Control.DoubleClick -= Control_DoubleClick;
            }
            base.OnDeactivated();

        }

        private void Control_DoubleClick(object sender, EventArgs e)
        {
            TextEdit edit = (TextEdit)sender;
            System.Diagnostics.Process.Start(edit.Text);

        }
    }
}
