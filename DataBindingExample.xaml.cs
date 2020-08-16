using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testu.Models;
using testu.Seed;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testu.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataBindingExample : ContentPage
    {
        public DataBindingExample()
        {
            //Student student = new Student();
            //student.StudentName = "Vagelis";
            //student.DateOfBirthday = new DateTime(1991, 6, 16);
            StudentSeed students = new StudentSeed();

            BindingContext = students.GetDefaults();
            InitializeComponent();
            InitializeComponent();
        }
    }
}