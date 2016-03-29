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
    /// Interaction logic for TVTVSamplesGroupCtrl.xaml
    /// </summary>
    public partial class TVSamplesGroupCtrl : UserControl
    {
        public int DisplayValue
        {
            get { return (int)GetValue(DisplayValueProperty); }
            set { SetValue(DisplayValueProperty, value); }
        }

        public static readonly DependencyProperty DisplayValueProperty =
            DependencyProperty.Register("DisplayValue", typeof(int), typeof(TVSamplesGroupCtrl), new FrameworkPropertyMetadata(0, OnDisplayValuePropertyChanged));


        public string DisplayMethodName
        {
            get { return (string)GetValue(DisplayMethodNameProperty); }
            set { SetValue(DisplayMethodNameProperty, value); }
        }

        public static readonly DependencyProperty DisplayMethodNameProperty =
            DependencyProperty.Register("DisplayMethodName", typeof(string), typeof(TVSamplesGroupCtrl),
                  new FrameworkPropertyMetadata("Default", OnMethodNamePropertyChanged));

        public string DisplayDueDate
        {
            get { return (string)GetValue(DisplayDueDateProperty); }
            set { SetValue(DisplayDueDateProperty, value); }
        }

        public static readonly DependencyProperty DisplayDueDateProperty =
            DependencyProperty.Register("DisplayDueDate", typeof(string), typeof(TVSamplesGroupCtrl), new FrameworkPropertyMetadata("DueDate", OnDueDatePropertyChanged));

        private static void OnDisplayValuePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            TVSamplesGroupCtrl control = source as TVSamplesGroupCtrl;
            control.DisplayValue = Convert.ToInt32(e.NewValue);
            //control.methodName.Text = e.NewValue.ToString();
            //DateTime time = (DateTime)e.NewValue;
            // Put some update logic here...
        }

        private static void OnMethodNamePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            TVSamplesGroupCtrl control = source as TVSamplesGroupCtrl;
           control.methodName.Text = e.NewValue.ToString();
            //DateTime time = (DateTime)e.NewValue;
            // Put some update logic here...
        }

        private static void OnDueDatePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            TVSamplesGroupCtrl control = source as TVSamplesGroupCtrl;
            control.dueDate.Text = e.NewValue.ToString();
            //DateTime time = (DateTime)e.NewValue;
            // Put some update logic here...
        }


        
        public TVSamplesGroupCtrl()
        {
            InitializeComponent();
            Loaded += TVSamplesCtrl_Loaded;
        }

       

        private void TVSamplesCtrl_Loaded(object sender, RoutedEventArgs e)
        {
            //Sample  dc = DataContext as Sample;
            //methodName.Text = dc.Sample1.MethodName;
            //dueDate.Text = DisplayDueDate;
            LoadImages();
        }

        private void LoadImages()
        {
            string root = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string[] supportedExtensions = new[] { ".bmp", ".jpeg", ".jpg", ".png", ".tiff" };
            var files = Directory.GetFiles(System.IO.Path.Combine(root, "Images"), "*.*").Where(s => supportedExtensions.Contains(Path.GetExtension(s).ToLower()));


            foreach (var file in files)
            {

                if (Path.GetFileName(file) == "laboratory-icon32.png")
                {
                    for (int i = 0; i < DisplayValue; i++)
                    {
                        imgContainer.Children.Add(GetDisplayImage(file));
                    }
                }


            }


        }

        private UIElement GetDisplayImage(string path)
        {
            var im = new SingleSampleCtrl { MethodName = DisplayMethodName, SampleCount = 1 };
            im.Margin = new Thickness(4);
            return im;
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Package the data.
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, "5");
                //data.SetData("Double", circleUI.Height);
                data.SetData("Object", this);

                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);
            // These Effects values are set in the drop target's
            // DragOver event handler.
            if (e.Effects.HasFlag(DragDropEffects.Copy))
            {
                Mouse.SetCursor(Cursors.Cross);
            }
            else if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(Cursors.Pen);
            }
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }
    }
}
