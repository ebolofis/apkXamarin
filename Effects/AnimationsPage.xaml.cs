using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testu.Views.Effects
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimationsPage : ContentPage
    {
        public AnimationsPage()
        {
           // Animation.CurrentAnimation = 'noodles.json';
            InitializeComponent();

            CheckConnectivity();
            //InternetConnectivity
        }

        private void CheckConnectivity()
        {
          var isConnected=  CrossConnectivity.Current.IsConnected;
            // Application.Current.Properties;
            if (isConnected == true)
            {
                InternetConnectivity.Text = " You are connected :) ";
;            }
            else
            {
                InternetConnectivity.Text = "You are not connected :( ";
                DisplayAlert("Message", "You are not connected ", "Ok");
            }
        }

        async void Translate_Clicked(object sender, EventArgs e)
        {
            await translateButton.TranslateTo(100, 0, 500, Easing.BounceOut);
            await translateButton.TranslateTo(0, 0);
        }
        async void Scale_Clicked(object sender, EventArgs e)
        {
            await scaleButton.ScaleTo(3, 1000);
            await scaleButton.ScaleTo(1, 1000, Easing.SpringOut);
        }
        async void Rotate_Clicked(object sender, EventArgs e)
        {
            await rotateButton.RotateTo(180);
            await rotateButton.RotateTo(0, 500, Easing.SpringOut);
        }
        async void Fade_Clicked(object sender, EventArgs e)
        {
            await fadeButton.FadeTo(0, 500, Easing.SinInOut);

        }

        void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            double value = e.NewValue;
            _rotatingLabel.Rotation = value;
            _displayLabel.Text = string.Format("The Stepper value is {0}", value);
        }
    }
}