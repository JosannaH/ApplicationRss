using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLogic
{
    public class MessageCreator
    {
        public string MessageHeading()
        {
            return "Please check fields:";
        }
        public string EmptyName() 
        {
            return "Name is empty.";
        }
        public string EmptyUrl()
        {
            return "Url is empty.";
        }
        public string InvalidUrl()
        {
            return "Url is not valid.";
        }
        public string NameExists()
        {
            return "Name already exists.";
        }
        public string UrlExists()
        {
            return "Url already exists.";
        }

        public void ShowMessage(string message)
        {
            MessageBoxButtons button = MessageBoxButtons.OK;
            MessageBox.Show(message, MessageHeading(), button);
        }
    }
}
