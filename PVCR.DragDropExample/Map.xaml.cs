using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls.Map;

namespace PVCR.DragDropExample
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : Window
    {
        public Map()
        {
            InitializeComponent();
            
            UserControl u = NavMap;
            var map1 = u.FindName("Map1") as GradientStop;
            var map2 = u.FindName("Map2") as GradientStop;
            var map3 = u.FindName("Map3") as GradientStop;
            map1.Color = (Color)ColorConverter.ConvertFromString("#D17E1F");
            map2.Color = (Color)ColorConverter.ConvertFromString("#D17E1F");
            map3.Color = (Color)ColorConverter.ConvertFromString("#D17E1F");


            var main1 = u.FindName("Main1") as GradientStop;
            var main2 = u.FindName("Main2") as GradientStop;
            var main3 = u.FindName("Main3") as GradientStop;
            main1.Color = (Color)ColorConverter.ConvertFromString("#004BA9");
            main2.Color = (Color)ColorConverter.ConvertFromString("#004BA9");
            main3.Color = (Color)ColorConverter.ConvertFromString("#004BA9");
        }

      
    }
}
