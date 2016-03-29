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
using System.DirectoryServices;
using System.IO;

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
            Loaded += NavTopPage_Loaded;
        }

        private void NavTopPage_Loaded(object sender, RoutedEventArgs e)
        {
            SetProfileImage();
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
                imgProfile.Fill = ib;
                //imgprofile.
            }
            catch
            {

            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private UIElement GetMap()
        {
            return new MapPage();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private UIElement GetMain()
        {
            return new ContentPage();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private UIElement GetTeamView()
        {
            return new TeamViewPage();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private UIElement GetMoreView()
        {
            return new MoreViewPage();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabmap_Click(object sender, EventArgs e)
        {
            UniformGrid ct = UIHelper.FindChild<UniformGrid>(Application.Current.MainWindow, "bodyContainer");

            if (ct != null)
            {
                ct.Children.Clear();
                ct.Children.Add(GetMap());
            }
            var bc = new BrushConverter();
            bmapview.Background = (Brush)bc.ConvertFrom("#D17E1F");
            bmyview.Background = (Brush)bc.ConvertFrom("#004BA9");
            bteamview.Background= (Brush)bc.ConvertFrom("#004BA9");
            bmoreview.Background= (Brush)bc.ConvertFrom("#004BA9");


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabmain_Click(object sender, EventArgs e)
        {
            UniformGrid ct = UIHelper.FindChild<UniformGrid>(Application.Current.MainWindow, "bodyContainer");
            if (ct != null)
            {
                ct.Children.Clear();
                ct.Children.Add(GetMain());
            }
            var bc = new BrushConverter();
            bmyview.Background = (Brush)bc.ConvertFrom("#D17E1F");
            bmapview.Background = (Brush)bc.ConvertFrom("#004BA9");
            bteamview.Background = (Brush)bc.ConvertFrom("#004BA9");
            bmoreview.Background = (Brush)bc.ConvertFrom("#004BA9");
        }

        private void tabmore_Click(object sender, EventArgs e)
        {
            UniformGrid ct = UIHelper.FindChild<UniformGrid>(Application.Current.MainWindow, "bodyContainer");
            if (ct != null)
            {
                ct.Children.Clear();
                ct.Children.Add(GetMoreView());
            }
            var bc = new BrushConverter();
            bmoreview.Background = (Brush)bc.ConvertFrom("#D17E1F");
            bmapview.Background = (Brush)bc.ConvertFrom("#004BA9");
            bteamview.Background = (Brush)bc.ConvertFrom("#004BA9");
            bmyview.Background = (Brush)bc.ConvertFrom("#004BA9");
        }

        private void tabteamview_Click(object sender, EventArgs e)
        {
            UniformGrid ct = UIHelper.FindChild<UniformGrid>(Application.Current.MainWindow, "bodyContainer");
            if (ct != null)
            {
                ct.Children.Clear();
                ct.Children.Add(GetTeamView());
            }
            var bc = new BrushConverter();
            bteamview.Background = (Brush)bc.ConvertFrom("#D17E1F");
            bmapview.Background = (Brush)bc.ConvertFrom("#004BA9");
            bmyview.Background = (Brush)bc.ConvertFrom("#004BA9");
            bmoreview.Background = (Brush)bc.ConvertFrom("#004BA9");
        }




    }
}
