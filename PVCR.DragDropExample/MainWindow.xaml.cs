using PVCR.DragDropExample.DB;
using PVCR.DragDropExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Odbc;
using System.Data.SqlClient;
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
using Telerik.Windows.Controls.ScheduleView;

namespace PVCR.DragDropExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _vwModel;
        public MainWindow()
        {
            InitializeComponent();

            _vwModel = new MainViewModel();

            DataContext = _vwModel;


            // this.ScheduleView.Background= new SolidColorBrush(new Color());
            // AddManualAppointments();
        }

       

      



     
    }

    //public class CustomAppointment : Appointment
    //{
    //    private Brush backgroundBrush;
    //    private string lecturePart;
    //    private string pathData;
    //    private int pathWidth;
    //    private int pathHeight;

    //    public CustomAppointment()
    //    {
    //        this.backgroundBrush = new SolidColorBrush(Color.FromArgb(255,255,255, 0));
    //        this.lecturePart = "Demo";
    //        this.pathData = string.Empty;
    //        this.pathWidth = 14;
    //        this.pathHeight = 16;
    //    }

    //    public Brush BackgroundBrush
    //    {
    //        get
    //        {
    //            return this.backgroundBrush;
    //        }
    //        set
    //        {
    //            this.backgroundBrush = value;
    //        }
    //    }

    //    public string LecturePart
    //    {
    //        get
    //        {
    //            return this.lecturePart;
    //        }
    //        set
    //        {
    //            this.lecturePart = value;
    //        }
    //    }

    //    public string PathData
    //    {
    //        get
    //        {
    //            return this.pathData;
    //        }
    //        set
    //        {
    //            this.pathData = value;
    //        }
    //    }

    //    public int PathWidth
    //    {
    //        get
    //        {
    //            return this.pathWidth;
    //        }
    //        set
    //        {
    //            this.pathWidth = value;
    //        }
    //    }

    //    public int PathHeight
    //    {
    //        get
    //        {
    //            return this.pathHeight;
    //        }
    //        set
    //        {
    //            this.pathHeight = value;
    //        }
    //    }
    //}
}
