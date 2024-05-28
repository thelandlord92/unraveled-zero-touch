using Autodesk.Revit.DB;
using Revit.Elements;
using Revit.Transaction;
using RevitServices.Persistence;
using RevitServices.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zero_touch_unraveled.Revit.Views
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
        /// <param name="sheet">Add a sheet input</param>
        /// <returns name="views">the views on the input sheet</returns>
        public static List<global::Revit.Elements.Views.View> GetAllPlacedViews(global::Revit.Elements.Views.Sheet sheet)
        {
            // get the current document.
            Autodesk.Revit.DB.Document doc = DocumentManager.Instance.CurrentDBDocument;

            // this casts the Dynamo Revit Sheet to a Revit.DB ViewSheet
            ViewSheet viewSheet = sheet.InternalElement as ViewSheet;

            // get view ids of the placed views on the sheet. 
            var placedViewsIds = viewSheet.GetAllPlacedViews();

            // list to host views for output
            var placedViews = new List<global::Revit.Elements.Views.View>();

            // get the views by ID and add to the placedViews list.
            foreach (ElementId viewId in placedViewsIds)
            {
                var internalView = doc.GetElement(viewId) as Autodesk.Revit.DB.View;

                placedViews.Add(internalView.ToDSType(false) as global::Revit.Elements.Views.View);
            }

            // return the views.
            return placedViews;
        }
        /// <summary>
        /// Sets the number of the sheet.
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="sheetNumber"></param>
        /// <returns></returns>
        public static global::Revit.Elements.Views.Sheet SetSheetNumber(global::Revit.Elements.Views.Sheet sheet, string sheetNumber)
        {
            // get the current document.
            Autodesk.Revit.DB.Document doc = DocumentManager.Instance.CurrentDBDocument;

            // this casts the Dynamo Revit Sheet to a Revit.DB ViewSheet.
            ViewSheet viewSheet = sheet.InternalElement as ViewSheet;

            // start the transaction in the current Revit document.
            TransactionManager.Instance.EnsureInTransaction(doc);

            try
            {
                // set the number of the sheet.
                viewSheet.SheetNumber = sheetNumber;
            }
            catch (System.Exception)
            {
                throw new System.Exception("Sorry can't have two sheets with the same number.");
            }

            // End the transaction.
            TransactionManager.Instance.TransactionTaskDone();

            return sheet;

        }

    }
}