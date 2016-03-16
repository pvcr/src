using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PVCR.DragDropExample.Utils;

namespace PVCR.DragDropExample.Content
{
    /// <summary>
    /// Interaction logic for NavTopPage.xaml
    /// </summary>
    public partial class NavTopPage : UserControl
    {
        
        public NavTopPage()
        {
            InitializeComponent();
        }
        //private void tabmap_Click(object sender, EventArgs e)
        //{
        //    Map m = new Map();
        //    m.Show();
        //    Application.Current.Windows[0].Close();


        //}

        //private void tabmain_Click(object sender, EventArgs e)
        //{
        //    MainWindow w = new MainWindow();
        //    w.Show();
        //    Application.Current.Windows[0].Close();

        //}



        private void tabmap_Click(object sender, EventArgs e)
        {
            //MapPage m = new MapPage();
            //m.Show();
            //Application.Current.Windows[0].Close();

            UniformGrid ct = UIHelper.FindChild<UniformGrid>(Application.Current.MainWindow, "bodyContainer");


            if (ct != null)
            {
                ct.Children.Clear();
                ct.Children.Add(GetMap());
            }


        }

        private UIElement GetMap()
        {
            return new MapPage();
        }

        private UIElement GetMain()
        {
            return new ContentPage();
        }

        private void tabmain_Click(object sender, EventArgs e)
        {
            UniformGrid ct = UIHelper.FindChild<UniformGrid>(Application.Current.MainWindow, "bodyContainer");


            if (ct != null)
            {
                ct.Children.Clear();
                ct.Children.Add(GetMain());
            }

        }




    }
}
