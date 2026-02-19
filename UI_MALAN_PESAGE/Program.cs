using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_MALAN_PESAGE
{
    internal class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        /// 
        public static string id_user;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Page_login());
        }
    }
}
