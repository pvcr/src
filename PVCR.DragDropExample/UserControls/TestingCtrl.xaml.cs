using System;
using System.Collections.Generic;
using System.IO;
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
//using System.Windows.Shapes;

namespace PVCR.DragDropExample.UserControls
{
    /// <summary>
    /// Interaction logic for TestingCtrl.xaml
    /// </summary>
    public partial class TestingCtrl : UserControl
    {

        public int DisplayValue
        {
            get { return (int)GetValue(DisplayValueProperty); }
            set { SetValue(DisplayValueProperty, value); }
        }

        public static readonly DependencyProperty DisplayValueProperty =
            DependencyProperty.Register("DisplayValue", typeof(int), typeof(TestingCtrl), new FrameworkPropertyMetadata(0, OnDisplayValuePropertyChanged));


        public string DisplayMethodName
        {
            get { return (string)GetValue(DisplayMethodNameProperty); }
            set { SetValue(DisplayMethodNameProperty, value); }
        }

        public static readonly DependencyProperty DisplayMethodNameProperty =
            DependencyProperty.Register("DisplayMethodName", typeof(string), typeof(TestingCtrl),
                  new FrameworkPropertyMetadata("Default", OnMethodNamePropertyChanged));

        public string DisplayDueDate
        {
            get { return (string)GetValue(DisplayDueDateProperty); }
            set { SetValue(DisplayDueDateProperty, value); }
        }

        public static readonly DependencyProperty DisplayDueDateProperty =
            DependencyProperty.Register("DisplayDueDate", typeof(string), typeof(TestingCtrl), new FrameworkPropertyMetadata("DueDate", OnDueDatePropertyChanged));

        private static void OnDisplayValuePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            TestingCtrl control = source as TestingCtrl;
            control.DisplayValue = Convert.ToInt32(e.NewValue);
          
        }

        private static void OnMethodNamePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            TestingCtrl control = source as TestingCtrl;
            control.methodName.Text = e.NewValue.ToString();
          
        }

        private static void OnDueDatePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            TestingCtrl control = source as TestingCtrl;
            control.dueDate.Text = e.NewValue.ToString();
          
        }

        public string DisplayImageName
        {
            get { return (string)GetValue(DisplayImageNameProperty); }
            set { SetValue(DisplayImageNameProperty, value); }
        }

        public static readonly DependencyProperty DisplayImageNameProperty =
            DependencyProperty.Register("DisplayImageName", typeof(string), typeof(TestingCtrl),
                  new FrameworkPropertyMetadata("lab-icon_2_128.png", OnDisplayImageNamePropertyChanged));

        private static void OnDisplayImageNamePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            InstrumentCtrl control = source as InstrumentCtrl;
            //control.DisplayImageName = e.NewValue.ToString();
            //DateTime time = (DateTime)e.NewValue;
            // Put some update logic here...
        }

        public TestingCtrl()
        {
            InitializeComponent();
            DisplayDueDate = DateTime.Now.ToShortDateString();
            Loaded += TestingCtrl_Loaded;
        }

        private void TestingCtrl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadImages();
        }

      
        private void LoadImages()
        {
            string root = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string[] supportedExtensions = new[] { ".bmp", ".jpeg", ".jpg", ".png", ".tiff" };
            var files = Directory.GetFiles(Path.Combine(root, "Images"), "*.*").Where(s => supportedExtensions.Contains(Path.GetExtension(s).ToLower()));

            foreach (var file in files)
            {
                if (Path.GetFileName(file) == DisplayImageName)
                {
                    testingImgContainer.Children.Clear();

                    testingImgContainer.Children.Add(GetDisplayImage(file));
                }

            }



        }

        private UIElement GetDisplayImage(string path)
        {
            var bm = new BitmapImage(new Uri(path));
            var im = new Image
            {
                Source = bm,
                //Height = bm.PixelHeight,
                //Width = bm.PixelWidth

            };
            return im;
        }
    }
}
