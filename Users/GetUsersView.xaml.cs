using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testu.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testu.Views.Users
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetUsersView : ContentPage
    {
         //ListView listview;
        public GetUsersView()
        {
            InitializeComponent();
            PopulateUserList();
        }


        public void PopulateUserList()
        {
            
            UserList.ItemsSource = null;
            UserList.ItemsSource = DependencyService.Get<ISQLite>().GetUsers();

        }

        private void EditUser(object sender, ItemTappedEventArgs e)
        { }

    }
}