using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win.Editors;

namespace MyCRM.Module.Win.Controllers
{
    public class GridCustomizationController: ViewController<ListView>
    {
        public GridCustomizationController() { }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();

            GridListEditor editor = View.Editor as GridListEditor;

            if (editor != null)
            {
                Font font = editor.GridView.Appearance.HeaderPanel.Font;
                editor.GridView.Appearance.HeaderPanel.Font = new System.Drawing.Font(font, System.Drawing.FontStyle.Bold);
            }
        }
    }
}
