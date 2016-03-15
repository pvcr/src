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
    /// Interaction logic for InstrumentCtrl.xaml
    /// </summary>
    public partial class InstrumentCtrl : UserControl
    {
        #region DisplayImageName
        public string DisplayImageName
        {
            get { return (string)GetValue(DisplayImageNameProperty); }
            set { SetValue(DisplayImageNameProperty, value); }
        }

        public static readonly DependencyProperty DisplayImageNameProperty =
            DependencyProperty.Register("DisplayImageName", typeof(string), typeof(InstrumentCtrl),
                  new FrameworkPropertyMetadata("lab-icon_2_128.png", OnDisplayImageNamePropertyChanged));

        private static void OnDisplayImageNamePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            InstrumentCtrl control = source as InstrumentCtrl;
            //control.DisplayImageName = e.NewValue.ToString();
            //DateTime time = (DateTime)e.NewValue;
            // Put some update logic here...
        }


        #endregion

        public InstrumentCtrl()
        {
            InitializeComponent();

            Loaded += InstrumentCtrl_Loaded;
        }

        private void InstrumentCtrl_Loaded(object sender, RoutedEventArgs e)
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
                    instImgContainer.Children.Clear();

                    instImgContainer.Children.Add(GetDisplayImage(file));
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



        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Package the data.
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, methodName.Text);
                data.SetData("Double", layoutInstrumentCtrlRoot.Height);
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

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);

            // If an element in the panel has already handled the drop,
            // the panel should not also handle it.
            if (e.Handled == false)
            {
                //Panel _panel = (Panel)sender;
                UIElement _element = (UIElement)e.Data.GetData("Object");

                SingleSampleCtrl ssc = _element as SingleSampleCtrl;


                SamplesGroupCtrl sgc = _element as SamplesGroupCtrl;


                if (ssc != null || sgc != null)
                {
                    // Get the panel that the element currently belongs to,
                    // then remove it from that panel and add it the Children of
                    // the panel that its been dropped on.
                    Panel _parent = (Panel)VisualTreeHelper.GetParent(_element);

                    if (_parent != null)
                    {
                        if (e.KeyStates == DragDropKeyStates.ControlKey &&
                            e.AllowedEffects.HasFlag(DragDropEffects.Copy))
                        {
                            SingleSampleCtrl _circle = new SingleSampleCtrl((SingleSampleCtrl)_element);
                            // _panel.Children.Add(_circle);
                            // set the value to return to the DoDragDrop call
                            e.Effects = DragDropEffects.Copy;
                        }
                        else if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
                        {
                            _parent.Children.Remove(_element);
                            //_panel.Children.Add(_element);
                            // set the value to return to the DoDragDrop call
                            e.Effects = DragDropEffects.Move;
                        }
                    }
                    if (sgc != null)
                    {
                        //this.methodName.Text = sgc.DisplayMethodName;
                        this.sampleCount.Text = (Convert.ToInt32(this.sampleCount.Text) + sgc.DisplayValue).ToString();
                    }
                    if (ssc != null)
                    {
                       // this.methodName.Text = ssc.MethodName;
                        this.sampleCount.Text = (Convert.ToInt32(this.sampleCount.Text) + ssc.SampleCount).ToString();
                    }
                }
            }

            e.Handled = true;
        }
    }
}
