using HabitRON.Models;
using Plugin.Toasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testu.Views.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testu.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
       
        public LoginPage()
        {
            InitializeComponent();
            Init();
           
        }

        void Init()
        {

            Effect shadowEffect = Effect.Resolve("MyCompany.ShadowEffect");
            //Btn_LogIn.Effects.Add(shadowEffect);

            ShadowEffect.SetColor(Btn_LogIn, Color.Red);
            MainPicker.Items.Add("Vag");
            MainPicker.Items.Add("George");
            MainPicker.Items.Add("Nick");
            ///////////////////////////////////////////////////

            BackgroundColor = Constants.BackgroundColor;
            Lbl_Username.TextColor = Constants.MainTextColor;
             Lbl_Password.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = true;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            // Entry_Username.TextChanged += (s, e) => OnUserNameCompletion(s, e);

            Entry_Password.Completed += (s, e) => LogInProcedure(s, e);
        }

     

        void LogInProcedure (object sender,EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if(user.CheckInformation())
            {
                ActivitySpinner.IsVisible = false;
                App.UserDatabase.SaveUser(user);
                DisplayAlert("Login", "Login Success", "OK");

                
                Application.Current.MainPage = new NavigationPage(new Dashboard());
            }
            else
            {
               
                DisplayAlert("Login", "Login Failure", "OK");
           
            }
        }

        private async void  OnUserNameCompletion(object sender,TextChangedEventArgs e)
        {
            var notificator = DependencyService.Get<IToastNotificator>();

            var options = new NotificationOptions()
            {
                Title = "Title",
                Description = "Please add a password"
            };

            var result = await notificator.Notify(options);
        }
        //Progress Bar

        private async void ProgressButton_Clicked(object sender, EventArgs e)
        {
          
            await this.ProcessBar.ProgressTo(1, 1000, Easing.Linear);

        }

        private void MainPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = MainPicker.Items[MainPicker.SelectedIndex];

            DisplayAlert(name, "selected value", "ok");
        }



    }

}