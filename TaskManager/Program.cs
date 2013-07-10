using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace TaskManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            //try
            //{
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI.MainForm());
            //}
            //catch (Exception exp)
            //{
            //    TaskManager.Languages.ILanguage lang = TaskManagerLocalization.Languages[Settings.Default.CurrentLanguage];
            //    MessageBox.Show(null,
            //        string.Format("{0}\n{1}\n{2}",
            //            lang.Application_ErrorUnrecoverable,
            //            exp.Message,
            //            lang.Application_Shutdown),
            //        lang.Application_FataErrorTitle,
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}