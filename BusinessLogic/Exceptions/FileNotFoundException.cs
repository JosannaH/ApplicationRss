
using System.Windows.Forms;

namespace BusinessLogic.Exceptions
{
    internal class FileNotFoundException
    {
        public static void FileNotFound(string message)
        {
            MessageBox.Show(message, "Could not find file", MessageBoxButtons.OK);
        }
    }
}
