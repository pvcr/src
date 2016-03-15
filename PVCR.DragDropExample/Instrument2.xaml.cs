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
    /// Interaction logic for Instrument.xaml
    /// </summary>
    public partial class Instrument2 : UserControl
    {
        public Instrument2()
        {
            InitializeComponent();
        }

        public Instrument2(Instrument c)
        {
            InitializeComponent();
            this.instrumentUI.Height = c.instrumentUI.Height;
            this.instrumentUI.Width = c.instrumentUI.Height;
            this.instrumentLblUI.Content = c.instrumentLblUI.Content;
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Package the data.
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, instrumentLblUI.Content.ToString());
                data.SetData("Double", instrumentUI.Height);
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
            int itemsCount = 0;
            // If an element in the panel has already handled the drop,
            // the panel should not also handle it.
            if (e.Handled == false)
            {
                //Panel _panel = (Panel)sender;
                UIElement _element = (UIElement)e.Data.GetData("Object");

                CircleList cl = _element as CircleList;
                if (cl != null) { itemsCount = cl.ItemCount(); }

                CircleList1 cl1 = _element as CircleList1;
                if(cl1 != null) { itemsCount = cl1.ItemCount(); }

                CircleList2 cl2 = _element as CircleList2;
                if (cl2 != null) { itemsCount = cl2.ItemCount(); }



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
                if(itemsCount==0) { itemsCount = Convert.ToInt32(dataString); }
                instrumentLblUI.Content = (Convert.ToInt32(instrumentLblUI.Content)+ itemsCount).ToString();
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
