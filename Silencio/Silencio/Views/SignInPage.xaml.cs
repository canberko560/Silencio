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
    public partial class SignInPage : ContentPage
    {
        IMobileServiceTable<Models.User> UsersTable = App.MobileService.GetTable<Models.User>();

        public SignInPage()
        {
            InitializeComponent();
        }

        private async void SignInClicked(object sender, EventArgs e)
        {
            var users = await UsersTable.Where(x => x.Email == emailEntry.Text & x.Password == passwordEntry.Text).ToListAsync();
            if (users.Count == 1)
            {
                Settings.UserId = users[0].Id;
                App.Current.MainPage = new NavigationPage(new InstrumentPage());
            }
            else
            {
                await DisplayAlert("Test", "Kullanıcı adınız veya şifreniz hatalıdır", "Tamam");
            }
        }

        private async void SignUpClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}