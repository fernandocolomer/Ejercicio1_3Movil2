using Ejercicio1_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio1_3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLista : ContentPage
    {
        public PageLista()
        {
            InitializeComponent();
        }

        private async void toolAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());

        }

        private async void ListEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Models.Persona persona = (Models.Persona)e.CurrentSelection.FirstOrDefault();
            Models.Empleados perd = new Empleados();
            perd = e.CurrentSelection.FirstOrDefault() as Models.Empleados;
            var pag = new PageAcciones();
            pag.BindingContext = perd;
            await Navigation.PushAsync(pag);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ListEmpleados.ItemsSource = await App.BEmpleados.ListaPersonas() ;
           // ListaPersonas.ItemsSource = await App.BEmpleados.ListaPersonas();

        }
    }
}