using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testu.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testu.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailView : ContentPage
    {
        public DetailView(ListViewItem item)
        {
            InitializeComponent();
            ItemDetailText.Text = item.Text;
        }
    }
}