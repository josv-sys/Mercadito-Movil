using System;
using System.Windows.Forms;
using ReaLTaiizor.Manager;
using MercaditoMovil.Views.WinForms;

namespace MercaditoMovil.Views.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
           

            ApplicationConfiguration.Initialize();

            var skinManager = MaterialSkinManager.Instance;
            skinManager.Theme = MaterialSkinManager.Themes.DARK;

            System.Windows.Forms.Application.Run(new FrmLogin());

        }
       
    }
}
