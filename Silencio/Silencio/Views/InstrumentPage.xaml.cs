using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Silencio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstrumentPage : ContentPage
    {
        public InstrumentPage()
        {
            InitializeComponent();
        }

        private async void Guitar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ArtiestListPage()
            {
                Instrument = "Guitarist"
            });
        }

        private async void Vocal_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ArtiestListPage()
            {
                Instrument = "Vocalist"
            });
        }

        private async void Drum_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ArtiestListPage()
            {
                Instrument = "Drummer"
            });
        }
    }
}