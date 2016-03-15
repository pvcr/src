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

namespace PVCR.DragDropExample
{
    /// <summary>
    /// Interaction logic for Setup.xaml
    /// </summary>
    public partial class Setup : UserControl
    {
        public Setup()
        {
            InitializeComponent();
        }

        public Setup(Setup c)
        {
            InitializeComponent();
            this.setupUI.Height = c.setupUI.Height;
            this.setupUI.Width = c.setupUI.Height;
            //this.setupLblUI.Content = c.setupLblUI.Content;
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Package the data.
                DataObject data = new DataObject();
                //data.SetData(DataFormats.StringFormat, setupLblUI.Content.ToString());
                data.SetData("Double", setupUI.Height);
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

        public string SourceUri
        {
            get
            {
                return System.IO.Path.GetFullPath(@"images\M9_TOC_Analysis 953x810.png");
            }
        }

        public Uri getUri

        {
            get
            {
                var dirinfo = System.IO.Directory.GetParent(Environment.CurrentDirectory);
                dirinfo = dirinfo.Parent;
                var path = System.IO.Path.Combine(dirinfo.FullName, "images", "M9_TOC_Analysis 953x810.png");
                var uri = new Uri(path);
                return uri;
            }
        }
        public Uri getUri1

        {
            get
            {
                var dirinfo = System.IO.Directory.GetParent(Environment.CurrentDirectory);
                dirinfo = dirinfo.Parent;
                var path = System.IO.Path.Combine(dirinfo.FullName, "images", "M9_TOC_Analysis 953x810.png");
                var uri = new Uri(path);
                return uri;
            }
        }
        public Uri getUri2

        {
            get
            {
                var dirinfo = System.IO.Directory.GetParent(Environment.CurrentDirectory);
                dirinfo = dirinfo.Parent;
                var path = System.IO.Path.Combine(dirinfo.FullName, "images", "Solo VPE 251x496.png");
                var uri = new Uri(path);
                return uri;
            }
        }

        public Uri getUri3

        {
            get
            {
                var dirinfo = System.IO.Directory.GetParent(Environment.CurrentDirectory);
                dirinfo = dirinfo.Parent;
                var path = System.IO.Path.Combine(dirinfo.FullName, "images", "kanban_card .png");
                var uri = new Uri(path);
                return uri;
            }
        }

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);
            int itemsCount = 0;
            // If an element in the panel has already handled the drop,
            // the panel should not also handle it.
            if (e.Handled == false)
            {
                var setupib = new ImageBrush
                {
                    ImageSource = new BitmapImage(getUri3),
                    //Stretch = Stretch.Fill,
                    AlignmentX = AlignmentX.Center,
                    AlignmentY = AlignmentY.Center
                   // Viewport = new Rect(0.25, 0.25, 0.99, 0.85),
                    //Transform = new ScaleTransform(0.5, 0.5)

                };

                this.setupUI.Background = setupib;

                //Panel _panel = (Panel)sender;
                UIElement _element = (UIElement)e.Data.GetData("Object");

                Instrument cl = _element as Instrument;
                if (cl != null)
                {
                   
                    var ib = new ImageBrush
                    {
                        ImageSource = new BitmapImage(getUri),
                        //Stretch = Stretch.Fill,
                        AlignmentX = AlignmentX.Center,
                        AlignmentY = AlignmentY.Center,
                        Viewport = new Rect(0.25, 0.25, 0.99, 0.85),
                        Transform = new ScaleTransform(0.5, 0.5)

                    };


                    cl.instrumentUI.Background = ib;
                    cl.instrumentLblUI.Foreground = System.Windows.Media.Brushes.Black;
                    cl.instrumentLblUI.Width = 114;
                    cl.flaskUI.HorizontalAlignment = HorizontalAlignment.Right;
                    //ScaleTransform scaleTransform1 = new ScaleTransform(.25, .25, 0.50, 0.50);
                    //cl.RenderTransform = scaleTransform1;
                }
                Instrument1 cl1 = _element as Instrument1;
                if (cl1 != null)
                {
                    var ib = new ImageBrush
                    {
                        ImageSource = new BitmapImage(getUri1),//new BitmapImage(new Uri(@"..\images\M9_TOC_Analysis 953x810.png", UriKind.Relative)),
                        Stretch = Stretch.Fill,
                        AlignmentX = AlignmentX.Center,
                        AlignmentY = AlignmentY.Center,
                        Viewport = new Rect(0.25, 0.25, 0.99, 0.85),
                        Transform = new ScaleTransform(0.5, 0.5)

                    };


                    cl1.instrumentUI.Background = ib;
                    cl1.instrumentLblUI.Foreground = System.Windows.Media.Brushes.Black;
                    cl1.instrumentLblUI.Width = 114;
                    cl1.flaskUI.HorizontalAlignment = HorizontalAlignment.Right;

                }
                Instrument2 cl2 = _element as Instrument2;
                if (cl2 != null)
                {
                    var ib = new ImageBrush
                    {
                        ImageSource = new BitmapImage(getUri2),//new BitmapImage(new Uri(@"..\images\Solo VPE 251x496.png", UriKind.Relative)),
                        Stretch = Stretch.Fill,
                        AlignmentX = AlignmentX.Center,
                        AlignmentY = AlignmentY.Center,
                        Viewport = new Rect(0.25, 0.25, 0.99, 0.85),
                        Transform = new ScaleTransform(0.5, 0.5)

                    };


                    cl2.instrumentUI.Background = ib;
                    cl2.instrumentLblUI.Foreground = System.Windows.Media.Brushes.Black;
                    cl2.instrumentLblUI.Width = 114;
                    cl2.flaskUI.HorizontalAlignment = HorizontalAlignment.Right;
                }
                //if (cl != null) { itemsCount = cl.ItemCount(); }

                //CircleList1 cl1 = _element as CircleList1;
                //if(cl1 != null) { itemsCount = cl1.ItemCount(); }

                //CircleList2 cl2 = _element as CircleList2;
                //if (cl2 != null) { itemsCount = cl2.ItemCount(); }



                if (_element != null)
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
                            Circle _circle = new Circle((Circle)_element);
                            // _panel.Children.Add(_circle);
                            // set the value to return to the DoDragDrop call
                            e.Effects = DragDropEffects.Copy;
                        }
                        else if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
                        {
                            _parent.Children.Remove(_element);
                            //_panel.Children.Add(_element); 
                            setupUI.Children.Clear();
                            setupUI.Children.Add(_element);
                            // set the value to return to the DoDragDrop call
                            e.Effects = DragDropEffects.Move;
                        }
                    }
                }
            }





            // If the DataObject contains string data, extract it.
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                // If the string can be converted into a Brush, 
                // convert it and apply it to the ellipse.
                //BrushConverter converter = new BrushConverter();
                //if (converter.IsValid(dataString))
                //{
                //Brush newFill = (Brush)converter.ConvertFromString(dataString);
                //circleUI.Fill = newFill;
                if (itemsCount == 0) { itemsCount = Convert.ToInt32(dataString); }
                // setupLblUI.Content = (Convert.ToInt32(setupLblUI.Content)+ itemsCount).ToString();
                // Set Effects to notify the drag source what effect
                // the drag-and-drop operation had.
                // (Copy if CTRL is pressed; otherwise, move.)
                if (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
                {
                    e.Effects = DragDropEffects.Copy;
                }
                else
                {
                    e.Effects = DragDropEffects.Move;
                }
                //}
            }
            e.Handled = true;
        }
    }
}
