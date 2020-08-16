using HabitRON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testu.Data;
using testu.SlidingPage;
using testu.Views.DetailViews;
using testu.Views.Effects;
using testu.Views.Flex;
using testu.Views.LayoutScreen;
using testu.Views.ScrollViews;
using testu.Views.TabView;
using testu.Views.Users;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testu.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public static UserDatabaseController userDatabase;
        public Dashboard()
        {
            InitializeComponent();
            Init();
            InitPicker();
           
        }
        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
        }

        Dictionary<string, Color> NameToColor = new Dictionary<string, Color> {
            {"Aqua",Color.Aqua },{"Black",Color.Black},{"Blue",Color.Blue},{"Gray",Color.Gray },{"Lime",Color.Lime},
            { "Navy",Color.Navy},{"Purple",Color.Purple},{"Silver",Color.Silver},{"White",Color.White}, {"Fucshia",Color.Fuchsia },
            { "Green",Color.Green},{"Maroon",Color.Maroon},{"Olive",Color.Olive},{"Red",Color.Red},{"Teal",Color.Teal},{"Yellow",Color.Yellow}
        };
        void InitPicker()
        {
            foreach (string color in NameToColor.Keys)
            {
                picker.Items.Add(color);
            }
            picker.SelectedIndexChanged += (s, e) =>
            {
                if (picker.SelectedIndex == -1)
                {
                    boxview.Color = Color.Default;
                }
                else
                {
                    string colortemp = picker.SelectedItem.ToString();
                    boxview.Color = NameToColor[colortemp];
                }
            };
        }

        //async void TabbedMenuDashboard(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new TabbedDashboard());
        //}
        async void SelectedScreen1(object sender,EventArgs e)
        {
            await Navigation.PushAsync(new InfoScreen1());
        }

        async void LayoutScreen(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LayoutScreenPage());
        }

        async void Binding(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DataBindingExample());
        }

        async void TabbedInterface(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyTabbedPage());
        }

        async void CarouselInterface(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MySliding());
        }
        
        async void SelectedPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        async void ScrollViewButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScrollViewPage());
            // if new page(),true parameters are used you additionaly try to load animations
            // PopAsync = go to previous page
            // PopRootAsync go to the first page e.g MainPage or Login Page
        }

        async void OxyPlotView(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OxyPlotView());
        }

        async void GetUsers(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetUsersView());
        }

        async void Effects_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AnimationsPage());
        }

        async void Flex_Form(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new FlexPage());
        }


        async void AddUser(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Users.AddUserPage());
        }
        private void Editor1_Completed(Object sender, EventArgs e)
        {
            DisplayAlert("Title", "Message ", "Cancel");
        }
    }
}