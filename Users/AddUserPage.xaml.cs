using HabitRON.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testu.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testu.Views.Users
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    
    public partial class AddUserPage : ContentPage
    {

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "TestDB.db3");
        public AddUserPage()
        {
            InitializeComponent();
   
        }

        private void SaveUser(object sender, EventArgs e)
        {
            if (saveBtn.Text=="Save")
            { 
                var db = new SQLiteConnection(_dbPath);
                db.CreateTable<User>();
                var maxPk = db.Table<User>().OrderByDescending(c => c.Id).FirstOrDefault();
                User user = new User();
                user.UserName = name.Text;
                user.Password = password.Text;
                user.Address = address.Text;
                user.PhoneNumber = phonenumber.Text;
                user.Email = email.Text;

                bool res = DependencyService.Get<ISQLite>().SaveUser(user);

                if(res)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "Data Failed to Save", "Ok");
                }
            }
        }
    }
}