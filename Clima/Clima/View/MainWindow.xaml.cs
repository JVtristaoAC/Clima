using Clima.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Clima.Services;

namespace Clima.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainWindow : ContentPage
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Previsão do Tempo";
            this.BindingContext = new Tempo();

        }

        private async void btn_Previsao_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(ent_Cidade.Text))
                {
                    Tempo tempo = await DataService.GetPrevisaoTempo(ent_Cidade.Text);
                    this.BindingContext = tempo;
                    btn_Previsao.Text = "Nova Previsão";
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}