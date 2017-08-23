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
    public partial class SignUpPage : ContentPage
    {
        IMobileServiceTable<Models.User> UsersTable = App.MobileService.GetTable<Models.User>();

        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void SignUpClicked(object sender, EventArgs e)
        {
            if (SignUp_Password.Text == SignUp_PassConfirm.Text)
            {
                var users = await UsersTable.Where(x => x.Email == SignUp_Email.Text).ToListAsync();
                if (users.Count == 0)
                {
                    var user = new Models.User()
                    {
                        Email = SignUp_Email.Text,
                        Location = SignUp_Location.Text,
                        Name = SignUp_Name.Text,
                        Password = SignUp_Password.Text,
                        Surname = SignUp_Surname.Text,
                        Phone = SignUp_Phone.Text,
                        Instrument = SignUp_Instrument.SelectedItem.ToString()
                    };

                    await UsersTable.InsertAsync(user);

                    if (user.Id != null)
                    {
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Error", "access denied", "Cancel");  //TODO: Insert Error Alert
                    }
                }
                else
                {
                    await DisplayAlert("Error", "User exists", "Try Again"); //TODO: Exists User Error
                }
            }
            else
            {
                await DisplayAlert("Error", "Validation Error", "Cancel"); //TODO: Validation Error Alert
            }
        }
    }
}