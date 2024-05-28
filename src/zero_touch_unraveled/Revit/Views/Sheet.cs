using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zero_touch_unraveled.Revit.Views.Sheet
{
    /// <summary>
    /// Wrapper class for sheet node.
    /// </summary>
    public class Sheet
    {
        // this hides the overall class as a node.
        private Sheet() { }

        /// <summary>
        /// Get all placed views on the input sheet.
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        public static int GetAllPlacedViews(global::Revit.Elements.Views.Sheet sheet)
        {
            // this casts the Dynamo Revit Sheet to a Revit.DB ViewSheet
            ViewSheet viewSheet = sheet.InternalElement as ViewSheet;

            var placedViews = viewSheet.GetAllPlacedViews();

            return placedViews.Count;
        }
    }
}
