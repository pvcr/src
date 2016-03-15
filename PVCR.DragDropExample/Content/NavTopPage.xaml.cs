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
        private void tabmap_Click(object sender, EventArgs e)
        {
            Map m = new Map();
            m.Show();
            Application.Current.Windows[0].Close();


        }

        private void tabmain_Click(object sender, EventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            Application.Current.Windows[0].Close();

        }
    }
}
