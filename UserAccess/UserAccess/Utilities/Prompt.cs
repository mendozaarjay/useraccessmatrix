using System.Windows.Forms;
namespace UserAccess
{
    public partial class Prompt
    {
        /// <summary>
        /// This will return an information message box.
        /// </summary>
        /// <param name="Message">Message.</param>
        /// <param name="Title">Title.</param>
        public static void Information(string Message,string Title)
        {
            MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// This will return a question messagebox.
        /// </summary>
        /// <param name="Message">Message.</param>
        /// <param name="Title">Title.</param>
        /// <returns></returns>
        public static DialogResult Question(string Message,string Title)
        {
            return MessageBox.Show(Message, Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
        /// <summary>
        /// This will return an error messagebox.
        /// </summary>
        /// <param name="Message">Message.</param>
        /// <param name="Title">Title.</param>
        public static void Error(string Message,string Title)
        {
            MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// This will return a warning messagebox.
        /// </summary>
        /// <param name="Message">Message.</param>
        /// <param name="Title">Title.</param>
        /// <returns></returns>
        public static DialogResult Warning(string Message,string Title)
        {
            return MessageBox.Show(Message, Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        }
    }
}
