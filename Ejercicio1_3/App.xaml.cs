using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio1_3
{
    public partial class App : Application
    {
        static Controllers.DBEmpleados bEmpleados;

        public static Controllers.DBEmpleados BEmpleados
        {
            get
            {

                if (bEmpleados == null)
                {
                    var Pathapp = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    var DBName = Models.Configuraciones.DBName;
                    var PathFull = Path.Combine(Pathapp, DBName);
                    bEmpleados = new Controllers.DBEmpleados(PathFull);
                }

                return bEmpleados;


            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.PageLista());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
