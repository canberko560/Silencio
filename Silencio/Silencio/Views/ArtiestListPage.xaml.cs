using Microsoft.WindowsAzure.MobileServices;
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
    public partial class ArtiestListPage : ContentPage
    {
        IMobileServiceTable<Models.User> UserTable = App.MobileService.GetTable<Models.User>();
        public string Instrument { get; set; }

        public ArtiestListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Load();
        }

        async void Load()
        {
            var users = await UserTable.Where(x => x.Instrument == this.Instrument).ToListAsync();
            listArtists.ItemsSource = users;
        }       
    }
}