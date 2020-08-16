using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testu.Custom_Form_Elements;
using testu.Models;
using testu.Views;
using testu.Views.Menu;
using Xamarin.Forms;


namespace testu
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        //List<string> Items;
        List<ListViewItem> Items;

        //Dictionary<string, Color> NameToColor = new Dictionary<string, Color> {
        //    {"Aqua",Color.Aqua },{"Black",Color.Black},{"Blue",Color.Blue},{"Gray",Color.Gray },{"Lime",Color.Lime},
        //    { "Navy",Color.Navy},{"Purple",Color.Purple},{"Silver",Color.Silver},{"White",Color.White}, {"Fucshia",Color.Fuchsia },
        //    { "Green",Color.Green},{"Maroon",Color.Maroon},{"Olive",Color.Olive},{"Red",Color.Red},{"Teal",Color.Teal},{"Yellow",Color.Yellow}
        //};
        public MainPage()
        {
            InitializeComponent();
            InitList();
            InitSearch();
            //InitPicker();
            InitSwitch();
            //GetDateTime();
            InitCircleImage();



        }

        private void InitCircleImage()
        {
            ImageCircle img = new ImageCircle
            {
                CircleName = "ExampleImage",
                BorderColor = Color.Aqua,
                BorderThickness = 4,
                HeightRequest = 200,
                WidthRequest = 200,
                Aspect = Aspect.AspectFit,
                HorizontalOptions = LayoutOptions.Center,
                Source = "LoginIcon.png",
                Margin = new Thickness(0, 40, 0, 40)
            };
            ImgCircleStack.Children.Add(img);
        }
        //void GetDateTime()
        //{
        //    DateTime date = DatePickerT.Date;
        //    DatePickerT.DateSelected += DatePickerT_DateSelected;
        //}
        //private void DatePickerT_DateSelected(object sender, DateChangedEventArgs e)
        //{

        //    DisplayAlert("Title", "Date selected:" + e.NewDate, "Cancel");
        //}

        void InitSwitch()
        {
            SwitchT.Toggled += SwitchT_Toggled;
        }
        private void SwitchT_Toggled(object sender, ToggledEventArgs e)
        {
            DisplayAlert("Switch","Its on" +e.Value,"Cancel");
        }
        void InitSearch()
        {
            sb_search.TextChanged += (s, e) => FilterItem(sb_search.Text);
            sb_search.SearchButtonPressed += (s, e) => FilterItem(sb_search.Text);
        }


        private void FilterItem(string filter)
        {
            habitlist.BeginRefresh();
                    if (string.IsNullOrWhiteSpace(filter))
                    {
                habitlist.ItemsSource = Items;
                    }
                    else
                    {
                habitlist.ItemsSource = Items.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
            }
            habitlist.EndRefresh();
        }
        void InitList()
        {
            //Items = new List<string>();

            //Items.Add("Item1");
            //Items.Add("Item2");
            //Items.Add("Item3");
            //Items.Add("Item4");

            Items = new List<ListViewItem>();

            Items.Add(new ListViewItem
            {
                Name = "Gym",
                Value = 1,
                Text = "pump it up! is the first view "
            });


            Items.Add(new ListViewItem
            {
                Name = "Saxophone",
                Value = 2,
                Text = "do re mi fa so la si do is the second view"
            });

            Items.Add(new ListViewItem
            {
                Name = "tennis",
                Value = 3,
                Text = "15 love 30 love 40 love game set and match is the third view"
            });


            habitlist.ItemsSource =  Items;
            habitlist.ItemTapped += habitlist_ItemTapped;
        }

        private void habitlist_ItemTapped(object sender,ItemTappedEventArgs e)
        {
            ListViewItem Item = (ListViewItem)e.Item;
            Navigation.PushAsync(new DetailView(Item) );
        }


        void CancelClicked(Object sender, EventArgs e)
        {
            DisplayAlert("Toolbar","Cancel button","OK");
        }

        void SaveClicked(Object sender, EventArgs e)
        {
            DisplayAlert("Toolbar", "Save Button", "OK");
        }
        async void EditClicked(Object sender, EventArgs e)
        {
            
                        List<string> buttons = new List<string> {
                            "Button1",
                            "Button2",
                            "Button3"
                                            };
            string reaction = await DisplayActionSheet("Title", "Edit ", "OK", buttons.ToArray()) ;

            switch(reaction)
            {
                case "Button1":
                    DisplayAlert("DisplayActionSheet", "Case of 1st Button", "OK");
                    break;
                case "Button2":
                    DisplayAlert("DisplayActionSheet", "Case of 2nd Button", "OK");
                    break;
                case "Button3":
                    DisplayAlert("DisplayActionSheet", "Case of 3rd Button", "OK");
                    break;
            }
        }
        void SettingsClicked(Object sender, EventArgs e)
        {
            DisplayAlert("Toolbar", "Settings button", "OK");
        }

    }
}
