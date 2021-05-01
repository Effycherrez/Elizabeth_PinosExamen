using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elizabeth_PinosEP1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ventana2 : ContentPage
    {
        public ventana2(String nombre, String montoInicial, String cuotaMensual, String user)
        {
            InitializeComponent();
            this.Title = user;
            lblMontoInicial.Text = montoInicial;
            lblNombre.Text = nombre;
            lblPagoMensual.Text = cuotaMensual;
            lblUser.Text = user;
        }
        private async void btnFinalizar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}