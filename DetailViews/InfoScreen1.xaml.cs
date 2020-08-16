using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testu.QuestionPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testu.Views.DetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoScreen1 : ContentPage
    {
        public InfoScreen1()
        {
          

       
            Title = "My Page ";

            Label label = new Label { Text = "Dial your phone number " };

            /*
           *  NUMBER
           *  7 8 9
           *  4 5 6
           *  1 2 3
           *  -- 0 --
           */
            var grid = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition {Height= new GridLength(1.4,GridUnitType.Star) },
                     new RowDefinition {Height= new GridLength(1,GridUnitType.Star) },
                      new RowDefinition {Height= new GridLength(1,GridUnitType.Star) },
                       new RowDefinition {Height= new GridLength(1,GridUnitType.Star) },
                        new RowDefinition {Height= new GridLength(1,GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width = new GridLength(1,GridUnitType.Star)},
                    new ColumnDefinition{ Width = new GridLength(1,GridUnitType.Star)},
                    new ColumnDefinition{ Width = new GridLength(1,GridUnitType.Star)}
                }

            };

            Label _number;

            var bg = new Image
            {
                Aspect = Aspect.AspectFill,
                Source = ImageSource.FromResource("testu.Images.background.png"),
                HorizontalOptions=LayoutOptions.CenterAndExpand,
                VerticalOptions= LayoutOptions.CenterAndExpand
            };
           
            _number = new Label
            {
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 60
            };
            //grid.Children.Add(bg);

            grid.Children.Add(_number, left:0 , right:3,top:0,bottom:1);  //left right top bottom

            grid.Children.Add(CreateButton("7"), left: 0, top: 1);
            grid.Children.Add(CreateButton("8"), left: 1, top: 1);
            grid.Children.Add(CreateButton("9"), left: 2, top: 1);

            grid.Children.Add(CreateButton("4"), left: 0, top: 2);
            grid.Children.Add(CreateButton("5"), left: 1, top: 2);
            grid.Children.Add(CreateButton("6"), left: 2, top: 2);

            grid.Children.Add(CreateButton("1"), left: 0, top: 3);
            grid.Children.Add(CreateButton("2"), left: 1, top: 3);
            grid.Children.Add(CreateButton("3"), left: 2, top: 3);

            var btnZero = CreateButton("Exam");
            Grid.SetColumn(btnZero, 0);
            Grid.SetRow(btnZero, 4);
            Grid.SetColumnSpan(btnZero, 3);
           // Grid.SetRowSpan(btnZero, 0);
            grid.Children.Add(btnZero);

            Content = grid;

            //layout.Children.Add(label);

            //Grid.SetColumn(label, 1);
            //Grid.SetRow(label, 1);
            //Grid.SetColumnSpan(label, 2);
            //Grid.SetRowSpan(label, 1);
            //layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) });

            // layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });  // its gonna select the largest one  the numeric type is ignored on auto mode

            // layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });  //  the numeric value is a multiplier between star sized 

            // or layout.Children.Add(label,0,1);   Left =0 and Top=1
            // layout.Children.Add(button,0,2,2,2); L=0 R=2 T=2 B=2


            int clickCount = 0;
            var button = new Button
            {
                Text = $"Start Exam!",
                BackgroundColor = Color.FromHex("#0892d0"),
                TextColor = Color.White,
                Font = Font.SystemFontOfSize(NamedSize.Medium)
            };

            var ActivitySpinner = new ActivityIndicator
            {
                IsVisible = true,
                //BackgroundColor = Color.Orange,
                IsRunning =true,
                Color =Color.Orange,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };


            //ading an absolute layout pinpoints our elements

          
            //grid.Children.Add(ActivitySpinner);
            //grid.Children.Add(label);
            //grid.Children.Add(button);

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,

                Children =
                    {
                      bg,
                     grid,
                   btnZero,
                    ActivitySpinner,
                    label,
                    button,
                    

                }
            };

           // InitializeComponent();
           // Init();

        

        View CreateButton(string text)
        {
            var btn = new Button
            {
                Text = text,
                BackgroundColor = Color.Blue,
                TextColor = Color.Yellow,
                Font = Font.SystemFontOfSize(30,FontAttributes.Bold)
            };


                btn.Clicked += OnStartClicked;

                //ActivitySpinner.IsVisible = true,
                //clickCount++;

               
                //Content.Children.Add(bg, new Rectangle(0, 0, 1, 1), AbsoluteLayout.All);

              //  NavigationPage.SetHasNavigationBar(this, false);

            return btn;
        }
            //private void Clicked(object sender, EventArgs e)
            //{

            //}

            async void OnStartClicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new QuestionsPage());
            }

        }

       
       
    }
}