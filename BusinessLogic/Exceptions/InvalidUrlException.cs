using System;
using System.Windows.Forms;

namespace BusinessLogic.Exceptions
{
    public class InvalidUrlException
    {
        public static void UrlException(string message)
        {
            MessageBox.Show(message, "Invalid URL", MessageBoxButtons.OK);
        }
    }
}
