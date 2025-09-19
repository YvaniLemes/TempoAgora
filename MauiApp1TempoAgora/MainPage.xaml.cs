using MauiApp1TempoAgora.Models;
using MauiApp1TempoAgora.Services;
using System.Threading.Tasks;

namespace MauiApp1TempoAgora
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        // Apresentação do .NET Maui (apagada)

        //Evento gerado na MainPage.xaml para o botão de busca
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);
                    if (t != null)
                    {
                        string dados_previsao = "";

                        dados_previsao = $"Descrição:  {t.description} \n" +
                                         $"Temp Min: {t.temp_min} \n" +
                                         $"Temp Max: {t.temp_max} \n" +
                                         $"Vento: {t.speed} \n" +
                                         $"Visibilidade:  {t.visibility} \n" +
                                         $"Latitude:  {t.lat} \n" +
                                         $"Longitude:  {t.lon} \n" +
                                         $"Nascer do Sol: {t.sunrise} \n" +
                                         $"Por do Sol: {t.sunset} \n";

                        lbl_res.Text = dados_previsao;

                    }
                    else
                    {
                        lbl_res.Text = "Sem dados de Previsão!";
                    }

                }
                else
                {
                    lbl_res.Text = "Preencha a cidade!";
                }

            }
            catch (HttpRequestException) 
            {
                lbl_res.Text = "Erro de conexão! Verifique sua internete e tente novamente!";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK!");
            }
        }
    }

}
