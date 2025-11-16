using System;
using System.Windows.Forms;

namespace HastaneOtomasyonu
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Uygulamayı Form1 (Giriş Ekranı) ile başlatıyoruz
            Application.Run(new GirisPanel());
        }
    }
}