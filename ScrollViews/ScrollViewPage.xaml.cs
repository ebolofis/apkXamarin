using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testu.Views.ScrollViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScrollViewPage : ContentPage
    {
        public ScrollViewPage()
        {
            InitializeComponent();
            for (int i = 0; i < 100; i++)
            {
                StackLayoutScrollView.Children.Add(new Label
                {
                    Text = "Blabla number: " + i
                }
                    );
            }
             ScrollView.Scrolled += ScrollView_Scrolled;
        }
        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            ScrolledLabel.Text = "Position: x=" + e.ScrollX + " y= " + e.ScrollY;
        }
    }
}