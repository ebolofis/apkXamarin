using OxyPlot;
using OxyPlot.Series;
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
    public partial class OxyPlotView : ContentPage
    {
        public OxyPlotInfo oxyPlotInfo;
        public OxyPlotView()
        {
            InitializeComponent();
           this. Init();
        }
        public void Init()
        {
            
            this.Title = "Oxyplot";
            oxyPlotInfo = new OxyPlotInfo();
            oxyPlotInfo.info = "My pites";
            List<OxyPlotItem> Items = new List<OxyPlotItem>();
            Items.Add(new OxyPlotItem { Label = "spanakopita", value = 25, Color=OxyColor.FromRgb(122,122,122) });
            Items.Add(new OxyPlotItem { Label = "turopita", value = 50, Color = OxyColor.FromRgb(20, 22, 22) });
            Items.Add(new OxyPlotItem { Label = "zabonoturopita", value = 100, Color = OxyColor.FromRgb(222, 222, 222) });
            oxyPlotInfo.Items = Items;
            this.BindingContext = this.oxyPlotInfo;

           this. MakePlot();
        }

        public void MakePlot()
        {
            PlotModel plotmodel = new PlotModel
            {
                Title = "Oxyplot Test",
                TextColor = OxyColor.FromRgb(122, 122, 122)
            };
            var ps = new PieSeries
            {
                StrokeThickness = .25,
                InsideLabelPosition = .25,
                AngleSpan = 360,
                StartAngle = 0,
                TextColor = OxyColor.FromRgb(100, 100, 100)
            };
            foreach(var oxyitem in oxyPlotInfo.Items)
            {
                ps.Slices.Add(new PieSlice(oxyitem.Label, oxyitem.value) { IsExploded = false, Fill = oxyitem.Color });
            }
            plotmodel.Series.Add(ps);
            this.plotModel.Model = plotmodel;
        }

    }
}