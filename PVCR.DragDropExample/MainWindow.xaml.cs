using PVCR.DragDropExample.DB;
using PVCR.DragDropExample.Utils;
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
        private LogWriter _loger;
        public MainWindow()
        {
            _loger = new LogWriter();
            try
            {
                InitializeComponent();

                _loger.LogWrite("MainWindow() start....");
                _vwModel = new MainViewModel(_loger);

                DataContext = _vwModel;
                _loger.LogWrite("MainWindow() finished....");
            }
            catch(Exception ex)
            {
                _loger.LogWrite(ex.Message);
            }
           

        }

       

      



     
    }

  
}
