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
    public partial class PageAcciones : ContentPage
    {
        public PageAcciones()
        {
            InitializeComponent();
        }


       

    

     
        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id.Text))
            {
                Empleados personas = new Empleados()
                {
                    Id = Convert.ToInt32(id.Text),
                    Nombre = nombres.Text,
                    Apellidos = apellidos.Text,
                    Edad = Convert.ToInt32(edad.Text),
                    Correo = correo.Text,
                    Direccion = direccion.Text
                };
                await App.BEmpleados.storeEquipo(personas);
                await DisplayAlert("Aviso", "Actualizado Correctamente", "OK");
                await Navigation.PopAsync();

            }
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            var Persons = await App.BEmpleados.GetPersonas(Convert.ToInt32(id.Text));
            if (Persons != null)
            {
                await App.BEmpleados.DeletePersonasItem(Persons);
                await DisplayAlert("Aviso", "Eliminado Correctamente", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}