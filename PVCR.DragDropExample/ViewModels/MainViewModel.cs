using PVCR.DragDropExample.DB;
using PVCR.DragDropExample.Model;
using PVCR.DragDropExample.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using PVCR.DragDropExample.Utils;

namespace PVCR.DragDropExample.ViewModels
{
    public class MainViewModel
    {
        private IScheduleService _scheduleServ;
        private ISampleService _sampleServ;
        private ITestingService _testingServ;
        private IWriteupService _writeupServ;

        private LogWriter _loger;
        public MainViewModel(LogWriter loger)
        {
            _loger = loger;

            _sampleServ = new SampleService();
            _scheduleServ = new ScheduleService();
            _testingServ = new TestingService();
            _writeupServ = new WriteupService();

            Init();

           Appointments= GetAppointments();

            GetSamples();

            GetTestings();

            GetWriteup();

            CreateWriteups();
        }

       




        #region Properties

        public string CopyRight { get; set; }

        public string Status { get; set; }

        public string CurrentDate { get; set; }

        public string Version { get; set; }

        public string SampleTitle { get; set; }

        public SampleModel SampleGroup1 { get; set; }

        public SampleModel SampleGroup2 { get; set; }

        public SampleModel SampleGroup3 { get; set; }

        public SampleModel SampleGroup4 { get; set; }

        public SampleModel SampleGroup5 { get; set; }

        public SampleModel SampleGroup6 { get; set; }

        public SampleModel SampleGroup7 { get; set; }



        public string InstrumentTitle { get; set; }

        public string SetupTitle { get; set; }

        public string TestingTitle { get; set; }

        public string WriteupTitle { get; set; }

        public string ReviewTitle { get; set; }

        public string ExceptionsTitle { get; set; }

        public TestingModel TestingModel1 { get; set; }

        public TestingModel TestingModel2 { get; set; }

        public TestingModel TestingModel3 { get; set; }

        public TestingModel TestingModel4 { get; private set; }

        public WriteupModel WriteupModel1 { get; set; }

        public WriteupModel WriteupModel2 { get; set; }

        public WriteupModel WriteupModel3 { get; set; }

        public ObservableCollection<CustomAppointment> Appointments { get; set; }

        public ObservableCollection<WriteupModel> Writeups { get; set; }

        public ObservableCollection<TestingModel> Testings { get; set; }

        public ObservableCollection<SampleModel> Samples { get; set; }

        public ObservableCollection<SampleModel> GreenSamples { get; set; }

        public ObservableCollection<SampleModel> YellowSamples { get; set; }

        public ObservableCollection<SampleModel> RedSamples { get; set; }
       

        #endregion


        #region Functions

        private void CreateWriteups()
        {
            Writeups = new ObservableCollection<WriteupModel>() { new WriteupModel { Message="Test1",Count=10 }, new WriteupModel { Message = "Test2", Count = 10 }, new WriteupModel { Message = "Test3", Count = 10 } };
        }

        private ObservableCollection<CustomAppointment> GetAppointments()
        {
           return _scheduleServ.GetAppointments();
        }
       

        private ObservableCollection<SampleModel> LoadSampleData()
        {
            ObservableCollection<SampleModel> retVal = null;
            try
            {
                _loger.LogWrite("LoadSampleData() start");
                retVal = _sampleServ.GetAllSamples().ToObservableCollection<SampleModel>();
                _loger.LogWrite("LoadSampleData() finished");
            }
            catch (Exception ex)
            {
                _loger.LogWrite(ex.Message);
            }


            return retVal;

        }

        private ObservableCollection<TestingModel> LoadTestingData()
        {
            ObservableCollection<TestingModel> retVal = null;
            try
            {
                _loger.LogWrite("LoadTestingData() start");
                retVal = _testingServ.GetAllTestings().ToObservableCollection<TestingModel>();
                _loger.LogWrite("LoadTestingData() finished");
            }
            catch (Exception ex)
            {
                _loger.LogWrite(ex.Message);
            }


            return retVal;
        }


        private ObservableCollection<WriteupModel> LoadWriteupData()
        {
            ObservableCollection<WriteupModel> retVal = null;
            try
            {
                _loger.LogWrite("LoadWriteupData() start");
                retVal = _writeupServ.GetAllWriteups().ToObservableCollection<WriteupModel>();
                _loger.LogWrite("LoadWriteupData() finished");
            }
            catch (Exception ex)
            {
                _loger.LogWrite(ex.Message);
            }


            return retVal;
        }



        private void GetSamples()
        {
            ObservableCollection<SampleModel> _lstSamples = LoadSampleData();

            if (_lstSamples == null) { _loger.LogWrite("No samples data."); GetSampleTestData(); return; }

            //Get only PROD Date not null
            var grps = from sm in _lstSamples
                       where sm.ProductionDate != DateTime.MinValue
                       select sm;

            var redItems = from sm in grps
                           where sm.ProductionDate < DateTime.Now
                           select sm;


            var greenItems = from sm in grps
                             where sm.ProductionDate > DateTime.Now.AddDays(15)
                             select sm;

            var yellowItems = from sm in grps
                              where (sm.ProductionDate > DateTime.Now) && sm.ProductionDate < DateTime.Now.AddDays(14)
                              select sm;


            var redGroups = from sm in redItems
                            group sm by sm.MethodName
                              into g
                            select new SampleModel
                            {
                                MethodName = g.Key,
                                Count = g.Count()

                            };
            RedSamples = redGroups.ToObservableCollection<SampleModel>();

            SampleGroup1 = RedSamples[0];
            SampleGroup2 = RedSamples[1];
            SampleGroup3 = RedSamples[2];


            var greenGroups = from sm in greenItems
                              group sm by sm.MethodName
                             into g
                              select new SampleModel
                              {
                                  MethodName = g.Key,
                                  Count = g.Count()

                              };
            GreenSamples = greenGroups.ToObservableCollection<SampleModel>();
            SampleGroup4 = GreenSamples[0];
            SampleGroup5 = GreenSamples[1];


            var yellowGroups = from sm in yellowItems
                               group sm by sm.MethodName
                            into g
                               select new SampleModel
                               {
                                   MethodName = g.Key,
                                   Count = g.Count()

                               };

            YellowSamples = yellowGroups.ToObservableCollection<SampleModel>();
            SampleGroup6 = YellowSamples[0];
            SampleGroup7 = YellowSamples[1];
        }

        private void GetSampleTestData()
        {
            var redlst = new ObservableCollection<SampleModel>();


            for(int i=1;i<5;i++)
            {
                redlst.Add( new SampleModel { MethodName = "RedGroup "+i, Count = i*6 });
            }

            SampleGroup1 = redlst[0];
            SampleGroup2 = redlst[1];
            SampleGroup3 = redlst[2];
            RedSamples = redlst;

            var yellowlst = new ObservableCollection<SampleModel>();

            for (int i = 1; i < 3; i++)
            {
                yellowlst.Add(new SampleModel { MethodName = "YellowGroup " + i, Count = i * 6 });
            }
            SampleGroup4 = yellowlst[0];
            SampleGroup5 = yellowlst[1];
           
            YellowSamples = yellowlst;

            var greenlst = new ObservableCollection<SampleModel>();

            for (int i = 1; i < 5; i++)
            {
                greenlst.Add(new SampleModel { MethodName = "GreenGroup " + i, Count = i * 6 });
            }
            SampleGroup6 = greenlst[0];
            SampleGroup7 = greenlst[1];
            GreenSamples = greenlst;
        }

        private void GetTestings()
        {
            ObservableCollection<TestingModel> _lst = LoadTestingData();

            if (_lst == null) { _loger.LogWrite("No testing data."); GetTestingTestData(); return; }

            Testings = _lst;
            TestingModel1 = Testings[0];
            TestingModel2 = Testings[1];
            TestingModel3 = Testings[2];
            TestingModel4 = Testings[3];
        }

        private void GetTestingTestData()
        {

            var testlst = new ObservableCollection<TestingModel>();


            for (int i = 1; i < 5; i++)
            {
                testlst.Add(new TestingModel { Name = "Name " + i, MethodNumber= "MethodNumber" + i, Count = i * 6 });
            }

            Testings = testlst;

            TestingModel1 = Testings[0];
            TestingModel2 = Testings[1];
            TestingModel3 = Testings[2];
            TestingModel4 = Testings[3];


        }

        private void GetWriteup()
        {
            ObservableCollection<WriteupModel> _lst = LoadWriteupData();

            if (_lst == null) { _loger.LogWrite("No Writeup data.");  return; }

            var groups = from m in _lst
                         group m by m.Message
                              into g
                         select new WriteupModel
                         {
                             Message = g.Key,
                             Count = g.Count()

                         };

            if (groups.Count() > 0)
            {
                WriteupModel1 = new WriteupModel { Message = groups.ElementAt(0).Message, Count = groups.ElementAt(0).Count };

                WriteupModel2 = new WriteupModel { Message = groups.ElementAt(0).Message, Count = groups.ElementAt(0).Count };

                WriteupModel3 = new WriteupModel { Message = groups.ElementAt(0).Message, Count = groups.ElementAt(0).Count };


            }
            else
            {
                WriteupModel1 = new WriteupModel { Message = "No Data", Count = 0 };

                WriteupModel2 = new WriteupModel { Message = "No Data", Count = 0 };

                WriteupModel3 = new WriteupModel { Message = "No Data", Count = 0 };
            }
        }

        private void Init()
        {




            CopyRight = "Copyright © 2016.All rights reserved.";
            Status = "Status";
            CurrentDate = DateTime.Now.ToLongDateString();
            Version = "1.0";

            SampleTitle = "Samples";


            InstrumentTitle = "Instruments";

            SetupTitle = "Setup";

            TestingTitle = "Testing";

            WriteupTitle = "Writeup";

            ReviewTitle = "Review";

            ExceptionsTitle = "Exceptions";
        }


        #endregion

    }
}
