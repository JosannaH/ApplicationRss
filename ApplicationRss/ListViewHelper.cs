using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationRss
{
    public static class ListViewHelper
    {
        // the method selected items returns a collection of all selected items
        public static String GetSelectedItem(ListView listView)
        {
            String itemName = listView.SelectedItems[0].Text;


            return itemName;
           // return listView.SelectedItems[0];
            //string firstColumn = drv.Row[0] != null ? drv.Row[0].ToString() : String.Empty;
            
            
            //if (itemRow.Items[0].Checked == true)
            //{
            //    int taskId = Convert.ToInt32(itemRow.SubItems[0].Text);

            //    string taskDate = itemRow.SubItems[1].ToString();
            //    string taskDescription = itemRow.SubItems[2].ToString();
            //}
        }
    }
}
