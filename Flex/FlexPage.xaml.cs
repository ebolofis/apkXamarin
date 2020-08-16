using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testu.Views.Flex
{
    [XamlCompilation(XamlCompilationOptions.Compile)]



    public partial class FlexPage : ContentPage
    {

        public FlexPage()
        {
            InitializeComponent();
        }

        FlexLayout test()
        {
            FlexLayout flexstack = null;
            flexstack = new FlexLayout()
            {
                Wrap = FlexWrap.Wrap,
                    WidthRequest = 200,
                    Direction=FlexDirection.Column,
                    //Children = { nameLabel, textbox },
                };

            return flexstack;
        }

    }
}