using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;

namespace ApplicationRss
{
    public partial class Form1 : Form
    {

       
        
        public Form1()
        {
            InitializeComponent();
            
            // TODO: populate feeds listview
            // TODO: populate category combobox
        }

        private void btnSaveFeed_Click(object sender, EventArgs e)
        {
            // TODO: add validation / exceptions on input

            string url = tbUrl.Text;
            string name = tbFeedName.Text;
            int updateInterval = int.Parse(cbInterval.SelectedItem.ToString());
            Category category = (Category)cbCategory.SelectedItem;

            Feed feed = new Feed();
            feed.Url = url;
            feed.Name = name;
            feed.UpdateInterval = updateInterval;
            feed.Category = category;

            category.ListOfFeeds.Add(feed);


        }

        private void btnEditFeed_Click(object sender, EventArgs e)
        {
            // TODO: Find object by id
            // TODO: populate URL and name
            // TODO: populate interval combobox, start with current choise
            // TODO: populate category combobox, start with current choise
            // TODO: Update listview

            // TODO: add validation / exceptions on input

        }

        private void btnDeleteFeed_Click(object sender, EventArgs e)
        {
            // TODO: Find objecy by id, delete all data
            // TODO: Update listview
        }


        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            // TODO: Save in ListOfCategories
            // TODO: Update listview
            // TODO: add validation / exceptions on input
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            // TODO: Find object by id in ListOfCategories, update name
            // TODO: Update listview
            // TODO: Update cbSortByCategory

            // TODO: add validation / exceptions on input
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            // TODO: Delete category and all feeds in that category
            // TODO: Warning to user
            // TODO: Update listview
        }

    }
}
