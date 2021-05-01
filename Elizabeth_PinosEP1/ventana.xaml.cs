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
    public partial class ventana : ContentPage
    {
        public ventana(string usuario, string clave)
        {
            InitializeComponent();
            lblUsuario.Text = usuario;
        }

        private async void btnCalcular_Clicked(object sender, EventArgs e)
        {
            Double monto = Convert.ToDouble(txtMontoInicial.Text);
            Double pagoMensual = Convert.ToDouble(txtPagoMensual.Text);
            Double cuotaTotal = 0;
            try
            {
                if (monto <= 0 || monto > 1800)
                {
                    await DisplayAlert("Error", "Valor del monto inicial no es valido.", "Aceptar");
                }
                else
                {
                    pagoMensual = (1800 - monto) / 3;
                    cuotaTotal = Math.Round((pagoMensual * 0.05) + pagoMensual, 2);
                    txtPagoMensual.Text = Convert.ToString(cuotaTotal);

                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }

        }
        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {

            try
            {
                if (txtPagoMensual.Text == "")
                {
                    await DisplayAlert("Error", "Calcule su cuota mensual, antes de guardar", "Aceptar");
                }
                else
                {
                    bool opcion = await DisplayAlert("Confirmar", "¿Esta segura de la cuota mensual?", "Si", "No");
                    if (opcion == true)
                    {
                        await DisplayAlert(Title, "Elemento guardado con exito.", "Aceptar");
                        await Navigation.PushModalAsync(new ventana2(txtNombre.Text, txtMontoInicial.Text, txtPagoMensual.Text, Title));
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}