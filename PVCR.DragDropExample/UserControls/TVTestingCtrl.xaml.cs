using System;
using System.Collections.Generic;
using System.DirectoryServices;
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
    /// Interaction logic for TVTestingCtrl.xaml
    /// </summary>
    public partial class TVTestingCtrl : UserControl
    {
        public string InstrumentName
        {
            get { return (string)GetValue(InstrumentNameProperty); }
            set { SetValue(InstrumentNameProperty, value); }
        }
        public static readonly DependencyProperty InstrumentNameProperty =
          DependencyProperty.Register("InstrumentName", typeof(string), typeof(TVTestingCtrl), new FrameworkPropertyMetadata("Default", OnInstrumentNamePropertyChanged));

        public int DisplayValue
        {
            get { return (int)GetValue(DisplayValueProperty); }
            set { SetValue(DisplayValueProperty, value); }
        }

        public static readonly DependencyProperty DisplayValueProperty =
            DependencyProperty.Register("DisplayValue", typeof(int), typeof(TVTestingCtrl), new FrameworkPropertyMetadata(0, OnDisplayValuePropertyChanged));


        public string DisplayMethodName
        {
            get { return (string)GetValue(DisplayMethodNameProperty); }
            set { SetValue(DisplayMethodNameProperty, value); }
        }

        public static readonly DependencyProperty DisplayMethodNameProperty =
            DependencyProperty.Register("DisplayMethodName", typeof(string), typeof(TVTestingCtrl),
                  new FrameworkPropertyMetadata("Default", OnMethodNamePropertyChanged));

        public string DisplayDueDate
        {
            get { return (string)GetValue(DisplayDueDateProperty); }
            set { SetValue(DisplayDueDateProperty, value); }
        }

        public static readonly DependencyProperty DisplayDueDateProperty =
            DependencyProperty.Register("DisplayDueDate", typeof(string), typeof(TVTestingCtrl), new FrameworkPropertyMetadata("DueDate", OnDueDatePropertyChanged));

        private static void OnDisplayValuePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            TVTestingCtrl control = source as TVTestingCtrl;
            control.sampleCount.Text = e.NewValue.ToString();

        }

        private static void OnInstrumentNamePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            TVTestingCtrl control = source as TVTestingCtrl;
            control.instrumentName.Text = e.NewValue.ToString();
            // inst.sampleCount.Text = e.NewValue.ToString();

        }

        private static void OnMethodNamePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            TVTestingCtrl control = source as TVTestingCtrl;
            control.methodName.Text = e.NewValue.ToString();
        }

        private static void OnDueDatePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            TVTestingCtrl control = source as TVTestingCtrl;
            // control.dueDate.Text = e.NewValue.ToString();

        }

        public string DisplayImageName
        {
            get { return (string)GetValue(DisplayImageNameProperty); }
            set { SetValue(DisplayImageNameProperty, value); }
        }

        public static readonly DependencyProperty DisplayImageNameProperty =
            DependencyProperty.Register("DisplayImageName", typeof(string), typeof(TVTestingCtrl),
                  new FrameworkPropertyMetadata("lab-icon_2_128.png", OnDisplayImageNamePropertyChanged));

        private static void OnDisplayImageNamePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            InstrumentCtrl control = source as InstrumentCtrl;
            //control.DisplayImageName = e.NewValue.ToString();
            //DateTime time = (DateTime)e.NewValue;
            // Put some update logic here...
        }

        public TVTestingCtrl()
        {
            InitializeComponent();
            DisplayDueDate = DateTime.Now.ToShortDateString();
            Loaded += TVTestingCtrl_Loaded;
        }


        private void TVTestingCtrl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadImages();
            SetProfileImage();
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

                    //instrumentName.Text = DisplayImageName.Substring(0, DisplayImageName.Length - Path.GetExtension(DisplayImageName).Length); ;
                }
                if (Path.GetFileName(file) == "kanban_card .png")
                {
                    layoutTVTestingCtrlRoot.Background = new ImageBrush(new BitmapImage(new Uri(file)));
                }

            }
            this.methodName.Foreground = Brushes.Black;
            this.sampleCount.Foreground = Brushes.Black;





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

        private void NavTopPage_Loaded(object sender, RoutedEventArgs e)
        {
            //SetProfileImage();
        }

        private void SetProfileImage()
        {


            try
            {
                DirectoryEntry de = new DirectoryEntry();

                de.Path = "LDAP://corp.shire.com";

                DirectorySearcher search = new DirectorySearcher();
                search.SearchRoot = de;
                search.Filter = "(&(objectClass=user)(objectCategory=person)(sAMAccountName=rosmith))";
                search.PropertiesToLoad.Add("samaccountname");
                search.PropertiesToLoad.Add("thumbnailPhoto");
                SearchResult user;
                user = search.FindOne();

                String userName;

                userName = (String)user.Properties["sAMAccountName"][0];
                byte[] bb = (byte[])user.Properties["thumbnailPhoto"][0];
                BitmapImage biImg = new BitmapImage();
                MemoryStream ms = new MemoryStream(bb);
                biImg.BeginInit();
                biImg.StreamSource = ms;
                biImg.EndInit();

                ImageSource imgSrc = biImg as ImageSource;

                ImageBrush ib = new ImageBrush(imgSrc);
                tvTestingimgProfile.Fill = ib;
                //imgprofile.
            }
            catch
            {

            }

        }
    }
}
