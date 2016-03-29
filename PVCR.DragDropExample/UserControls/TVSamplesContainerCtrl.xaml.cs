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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PVCR.DragDropExample.UserControls
{
    /// <summary>
    /// Interaction logic for TVSamplesContainerCtrl.xaml
    /// </summary>
    public partial class TVSamplesContainerCtrl : UserControl
    {
        public int MaxDisplayValue
        {
            get { return (int)GetValue(MaxDisplayValueProperty); }
            set { SetValue(MaxDisplayValueProperty, value); }
        }

        public static readonly DependencyProperty MaxDisplayValueProperty =
            DependencyProperty.Register("MaxDisplayValue", typeof(int), typeof(TVSamplesContainerCtrl), new FrameworkPropertyMetadata(0));


        public string DisplayMethodName
        {
            get { return (string)GetValue(DisplayMethodNameProperty); }
            set { SetValue(DisplayMethodNameProperty, value); }
        }

        public static readonly DependencyProperty DisplayMethodNameProperty =
            DependencyProperty.Register("DisplayMethodName", typeof(string), typeof(TVSamplesContainerCtrl),
                  new FrameworkPropertyMetadata("Default"));


        public TVSamplesContainerCtrl()
        {
            InitializeComponent();
            Loaded += TVSamplesGroupCtrl_Loaded;
        }

        private void TVSamplesGroupCtrl_Loaded(object sender, RoutedEventArgs e)
        {
            int temp = MaxDisplayValue;
            do
            {
                if (temp < 10)
                {
                    tvsamplesGroupCtrlImgContainer.Children.Add(GetDisplayCtrl(temp));
                    temp = 0;
                }
                else
                {
                    tvsamplesGroupCtrlImgContainer.Children.Add(GetDisplayCtrl(10));
                    temp = temp - 10;
                }

            }
            while (temp > 0);


        }

        private UIElement GetDisplayCtrl(int maxValue)
        {
            var samplesCtrl = new TVSamplesGroupCtrl();
            samplesCtrl.Margin = new Thickness(0, 5, 0, 0);
            samplesCtrl.DisplayMethodName = DisplayMethodName;
            samplesCtrl.DisplayValue = maxValue;
            samplesCtrl.DisplayDueDate = DateTime.Now.ToShortDateString();

            return samplesCtrl;
        }
    }
}
