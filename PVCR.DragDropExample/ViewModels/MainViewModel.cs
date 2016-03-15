﻿using PVCR.DragDropExample.DB;
using PVCR.DragDropExample.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PVCR.DragDropExample.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Init();

            GetSamples();

            GetTestings();

            GetWriteup();


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

        public string InstrumentTitle { get; set; }

        public string SetupTitle { get; set; }

        public string TestingTitle { get; set; }

        public string WriteupTitle { get; set; }

        public string ExceptionsTitle { get; set; }

        public TestingModel TestingModel1 { get; set; }

        public TestingModel TestingModel2 { get; set; }

        public TestingModel TestingModel3 { get; set; }

        public WriteupModel WriteupModel1 { get; set; }

        public WriteupModel WriteupModel2 { get; set; }

        public WriteupModel WriteupModel3 { get; set; }

        public ObservableCollection<CustomAppointment> Appointments { get; set; }

        #endregion


        #region Functions

        private ObservableCollection<CustomAppointment> AddManualAppointments()
        {
            DateTime firstDayOfThisWeek = DateTime.Now.Date.AddDays(-(int)DateTime.Now.Date.DayOfWeek);
            ObservableCollection<CustomAppointment> appointments = new ObservableCollection<CustomAppointment>();

            appointments.Add(new CustomAppointment()
            {
                Start = firstDayOfThisWeek.AddDays(0).AddHours(11),
                End = firstDayOfThisWeek.AddDays(0).AddHours(11).AddMinutes(56),
                Subject = "War",
                LecturePart = "Lecture-Part 1:",
                BackgroundBrush = new SolidColorBrush(Color.FromArgb(255, 22, 171, 169)),
                PathData = "M0.44447401,0 L5.1489239,0 L5.1489239,1.6991746 L8.1489239,1.6991746 L8.1489239,0 L13.277808,0 L11.861381,4.0897064 L7.4670901,4.0897064 L7.4677043,4.0907907 L8.9517078,6.8538327 C9.155654,7.2340717 9.6919937,7.592236 10.147931,7.6526055 L13.466473,8.0963678 C14.043013,8.1729574 14.172441,8.5387802 13.755722,8.912261 L11.353961,11.063947 C11.024508,11.359488 10.819582,11.938858 10.897042,12.35694 L11.464268,15.393898 C11.561829,15.921458 11.223552,16.148069 10.707804,15.898481 L7.7393055,14.464476 C7.3314133,14.268048 6.668097,14.268048 6.2602043,14.464476 L3.2926869,15.898481 C2.7764478,16.148069 2.4381711,15.921458 2.5357323,15.393898 L3.102958,12.35694 C3.1809089,11.938858 2.9759817,11.359488 2.6460397,11.063947 L0.2442774,8.912261 C-0.17243995,8.5387802 -0.0430125,8.1729574 0.53352809,8.0963678 L3.8520687,7.6526055 C4.3080063,7.592236 4.8448362,7.2340717 5.0482922,6.8538327 L6.5327864,4.0903401 L6.5331454,4.0897064 L1.8609003,4.0897064 z"
            });
            //appointments.Add(new CustomAppointment()
            //{
            //    Start = firstDayOfThisWeek.AddDays(0).AddHours(13),
            //    End = firstDayOfThisWeek.AddDays(0).AddHours(13).AddMinutes(56),
            //    Subject = "War",
            //    LecturePart = "Lecture-Part 2:",
            //    BackgroundBrush = new SolidColorBrush(Color.FromArgb(255, 22, 171, 169)),
            //    PathData = "M0.44447401,0 L5.1489239,0 L5.1489239,1.6991746 L8.1489239,1.6991746 L8.1489239,0 L13.277808,0 L11.861381,4.0897064 L7.4670901,4.0897064 L7.4677043,4.0907907 L8.9517078,6.8538327 C9.155654,7.2340717 9.6919937,7.592236 10.147931,7.6526055 L13.466473,8.0963678 C14.043013,8.1729574 14.172441,8.5387802 13.755722,8.912261 L11.353961,11.063947 C11.024508,11.359488 10.819582,11.938858 10.897042,12.35694 L11.464268,15.393898 C11.561829,15.921458 11.223552,16.148069 10.707804,15.898481 L7.7393055,14.464476 C7.3314133,14.268048 6.668097,14.268048 6.2602043,14.464476 L3.2926869,15.898481 C2.7764478,16.148069 2.4381711,15.921458 2.5357323,15.393898 L3.102958,12.35694 C3.1809089,11.938858 2.9759817,11.359488 2.6460397,11.063947 L0.2442774,8.912261 C-0.17243995,8.5387802 -0.0430125,8.1729574 0.53352809,8.0963678 L3.8520687,7.6526055 C4.3080063,7.592236 4.8448362,7.2340717 5.0482922,6.8538327 L6.5327864,4.0903401 L6.5331454,4.0897064 L1.8609003,4.0897064 z"
            //});
            //appointments.Add(new CustomAppointment()
            //{
            //    Start = firstDayOfThisWeek.AddDays(1).AddHours(10),
            //    End = firstDayOfThisWeek.AddDays(1).AddHours(10).AddMinutes(115),
            //    Subject = "Action-Adventure",
            //    LecturePart = "Lecture-Part 1:",
            //    BackgroundBrush = new SolidColorBrush(Color.FromArgb(255, 255, 105, 0)),
            //    PathData = "M9.999999,20 L11.999999,20 L11.999999,22 L9.999999,22 z M9.9509106,10.000079 L9.9509106,12.000078 L11.950911,12.000079 L11.950911,10.000079 z M20,10.000002 L22,10.000002 L22,12.000002 L20,12.000002 z M0,10.000001 L2,10.000001 L2,12.000001 L0,12.000001 z M17.658268,4.0932026 L13.327535,12.924206 L4.7830901,17.136412 L8.8539305,8.5222139 z M9.999999,0 L11.999999,0 L11.999999,2 L9.999999,2 z",
            //    PathWidth = 22,
            //    PathHeight = 22
            //});
            //appointments.Add(new CustomAppointment()
            //{
            //    Start = firstDayOfThisWeek.AddDays(1).AddHours(12),
            //    End = firstDayOfThisWeek.AddDays(1).AddHours(12).AddMinutes(56),
            //    Subject = "Epic",
            //    LecturePart = "Lecture-Part 2:",
            //    BackgroundBrush = new SolidColorBrush(Color.FromArgb(255, 83, 52, 174)),
            //    PathData = "M12.630771,9.8620253 C14.174896,9.8729792 14.972476,11.457651 14.972476,11.457651 C14.972476,11.457651 16.573185,14.533286 16.471432,16.027985 C9.2468405,14.808113 2.4760811,16.045973 2.4760811,16.045973 C2.4760811,16.045973 2.700141,13.469728 3.7896118,11.587824 C4.8559475,9.745923 6.4955502,9.7860565 8.1375074,10.250444 C9.7794638,10.714832 9.6577892,10.611901 11.923445,9.9628887 C12.174356,9.8910122 12.410182,9.8604603 12.630771,9.8620253 z M8.4888601,1.7615315E-05 C8.7479782,-0.00069351424 8.9034595,0.020328972 8.9092226,0.026400639 C8.9461031,0.065259777 8.8354292,6.0094848 8.8354292,6.0094848 C8.8354292,6.0094848 10.487353,6.0093865 10.487353,6.0093865 C10.487353,6.0093865 10.42962,0.022760738 10.511567,0.0262204 C16.59627,0.28311652 16.54697,8.1618347 16.54697,8.1618347 L19.384003,15.726418 L17.655422,15.590263 C17.655422,15.590263 17.163023,11.370955 15.540168,9.3895359 C13.917313,7.4081163 11.667513,8.3405371 11.151148,8.4959412 C10.634753,8.6513443 10.118513,9.2729588 8.0161438,8.5347672 C5.9137735,7.7965922 4.4604778,8.1682625 3.3540184,9.8000317 C2.2475278,11.431785 1.4534827,15.790035 1.4534829,15.790035 L0,15.726418 C0,15.726418 2.4371302,9.3705492 2.4816675,7.689312 C2.6683772,0.6414578 7.0896249,0.0038589214 8.4888601,1.7615315E-05 z",
            //    PathWidth = 19
            //});
            //appointments.Add(new CustomAppointment()
            //{
            //    Start = firstDayOfThisWeek.AddDays(1).AddHours(14),
            //    End = firstDayOfThisWeek.AddDays(1).AddHours(14).AddMinutes(56),
            //    Subject = "Horror",
            //    LecturePart = "Lecture-Part 3:",
            //    BackgroundBrush = new SolidColorBrush(Color.FromArgb(255, 80, 152, 173)),
            //    PathData = "M12.329087,0.5780158 C14.147904,0.64922398 15.849243,2.1728585 16.444715,3.6797624 C17.23424,5.6777334 15.460253,10.320665 10.93055,9.2301731 C10.057043,9.0198832 9.8982782,8.8344631 9.6478653,8.8064919 C9.5494194,8.795495 8.9979725,9.5786867 8.5733814,10.289268 C8.5733814,10.289268 10.030326,11.753561 10.055088,13.644787 C10.077997,15.394441 9.316514,16.964355 8.0683889,17.898184 L7.9696903,17.9702 L0,12.723413 L0.01851918,12.638308 C0.54255295,10.367191 2.7273285,8.6261835 4.9446101,8.7062006 C5.7723169,8.7360706 6.9101892,9.113903 6.9101892,9.113903 C7.6163697,8.1748972 8.8318443,6.1609921 8.8318443,6.1609921 C9.1598892,7.3441672 10.795523,8.1352386 12.227292,7.6790104 C14.264352,7.0299091 14.657213,4.8512897 14.242661,3.762943 C13.408005,1.5716745 11.133412,1.2954876 10.08071,1.5634208 C10.08071,1.5634208 9.7241936,1.4545749 9.8180618,1.3098075 C10.349765,0.48979843 11.587783,0.54899311 12.329087,0.5780158 z",
            //    PathWidth = 15
            //});
            //appointments.Add(new CustomAppointment()
            //{
            //    Start = firstDayOfThisWeek.AddDays(2).AddHours(11),
            //    End = firstDayOfThisWeek.AddDays(2).AddHours(11).AddMinutes(56),
            //    Subject = "Comedy",
            //    LecturePart = "Lecture-Part 1:",
            //    BackgroundBrush = new SolidColorBrush(Color.FromArgb(255, 198, 43, 109)),
            //    PathData = "M6.1469989,16.095991 C6.1469989,16.095991 7.939939,20.026072 10.68145,20.126032 C13.151414,20.216093 15.146888,17.21056 15.676001,16.144348 C15.676001,16.144348 10.734225,17.675112 10.734225,17.675112 C8.7308645,17.130898 6.1469989,16.095991 6.1469989,16.095991 z M4.5350595,7.6300144 L5.0757766,10.613793 L6.9925961,8.1413097 L9.6498098,8.9111481 L10.130981,5.9111576 L7.1317577,5.463829 z M12.151978,5.9155736 L12.676856,8.9155617 L15.035067,8.1521673 L17.4405,10.507543 L17.921673,7.5075526 L15.084047,5.5142369 z M11.067101,0.0004808036 C16.01227,-0.024569884 20.937035,0.92939287 21.662029,2.8328648 C23.382338,7.3494992 20.41695,26.373674 10.647985,25.139986 C1.4207271,25.760931 -1.2616298,7.0628238 0.34974712,3.0421772 C1.156361,1.0295956 6.1219335,0.025531501 11.067101,0.0004808036 z",
            //    PathHeight = 14
            //});
            //appointments.Add(new CustomAppointment()
            //{
            //    Start = firstDayOfThisWeek.AddDays(2).AddHours(13),
            //    End = firstDayOfThisWeek.AddDays(2).AddHours(13).AddMinutes(115),
            //    Subject = "Animation",
            //    LecturePart = "Lecture-Part 1&2:",
            //    BackgroundBrush = new SolidColorBrush(Color.FromArgb(255, 251, 181, 32)),
            //    PathData = "M4.5416865,8.1809902 L3.8701169,8.8524265 C4.4809332,9.7071581 5.152503,11.294668 8.2060528,11.905252 C11.259603,12.515834 12.542078,10.806305 12.542078,10.806305 C12.542078,10.806305 12.610724,10.085094 12.645048,9.8275166 L12.645643,9.8231325 L12.648283,9.818965 C12.658821,9.8006096 12.664117,9.7836313 12.664117,9.7683678 C12.664117,9.745472 12.663044,9.7359924 12.6611,9.7376137 C12.658184,9.7400455 12.653307,9.7674561 12.647148,9.8120327 L12.645643,9.8231325 L12.639399,9.8329859 C12.445356,10.113596 11.113762,10.675762 8.8168249,10.440093 C6.434978,10.195723 4.5416865,8.1809902 4.5416865,8.1809902 z M8.6359282,6.0540328 C8.3392839,6.0532293 8.1175261,6.0850992 7.9984894,6.1315928 C7.7722044,6.2199612 7.2677965,6.8365908 6.8084545,6.8365908 C6.3491125,6.8365908 5.8242455,8.2308531 6.5460215,8.3702965 C7.2677965,8.5097408 7.1208181,7.7544532 7.4489193,7.9636192 C7.7770205,8.1727848 7.7542257,8.6964607 8.8532696,8.8798094 C10.091805,9.086442 10.305022,8.5132627 10.501884,8.5132627 C10.698744,8.5132627 11.139058,8.9280472 11.139058,8.9280472 C11.139058,8.9280472 11.804131,8.4252996 11.335966,7.9519653 C10.501884,7.1086888 10.811243,6.4181066 9.8925591,6.2089405 C9.4045086,6.0978212 8.9721251,6.0549436 8.6359282,6.0540328 z M11.43874,3.9815907 C11.42903,3.9810011 11.420464,3.98102 11.413433,3.9818337 C10.572924,4.0791349 10.065676,5.0388775 10.302391,5.2755666 C11.537951,6.5108833 12.723991,5.2176757 12.723991,5.2176757 C12.723991,5.2176757 12.718979,4.0106316 11.675568,4.0192814 C11.630667,4.0196533 11.506705,3.9857185 11.43874,3.9815907 z M6.6090717,3.0739918 C5.486732,3.0705483 4.7648921,4.1684093 5.0719662,4.4630423 C6.2318487,5.57586 7.9945631,4.9821348 7.9945631,4.9821343 C7.9945631,4.9821348 7.9034567,3.1567709 6.718914,3.077827 C6.6818972,3.0753598 6.6452761,3.0741029 6.6090717,3.0739918 z M8.242959,3.194809E-05 C8.5060663,-0.0009393692 8.7832699,0.020266056 9.0750685,0.067412853 C11.713264,0.49368429 13.42814,2.8063238 13.559953,3.3540521 C13.792697,4.3212805 13.230286,4.9973202 13.230286,4.9973202 C13.230286,4.9973202 14.306152,5.1226463 14.570004,5.0617828 C14.833856,5.0009193 14.67832,3.4353015 16.19018,3.7229917 C16.841343,3.8469007 17.297241,5.9919715 16.373829,6.2354255 C15.450417,6.4788785 13.560043,5.7885842 13.625995,6.2754903 C13.691946,6.7623973 14.087475,7.5537448 14.219603,8.466445 C14.360419,9.4391785 15.185464,14.071305 11.185967,16.338551 C6.6998153,18.881672 1.2226901,15.463759 1.0081599,11.935881 C0.76389408,7.9190116 2.6770492,6.0929422 2.9408553,5.1799932 C3.2047062,4.2670431 3.2047062,3.5975468 2.6770492,3.3540936 C2.1493917,3.1106403 -0.24502513,3.6537836 -0.31097671,2.9842875 C-0.37692854,2.3147912 0.63070583,0.2074194 1.8177435,0.085692883 C3.004781,-0.036034107 2.5642643,2.1085324 3.0259702,2.3520064 C3.4876759,2.5954804 3.9962597,3.110765 3.9962599,3.110765 C3.9962597,3.110765 5.1382847,0.011490822 8.242959,3.194809E-05 z",
            //    PathHeight = 14
            //});
            //appointments.Add(new CustomAppointment()
            //{
            //    Start = firstDayOfThisWeek.AddDays(3).AddHours(10),
            //    End = firstDayOfThisWeek.AddDays(3).AddHours(10).AddMinutes(56),
            //    Subject = "Western",
            //    LecturePart = "Lecture-Part 1&2:",
            //    BackgroundBrush = new SolidColorBrush(Color.FromArgb(255, 152, 104, 39)),
            //    PathData = "M10.629973,4.9080153 L10.628599,4.9112968 L9.6699991,7.200047 L6.630136,7.200047 L9.1021767,8.6163149 L8.1580238,10.908014 L10.630136,9.4917059 L13.102247,10.908014 L12.157988,8.6163769 L14.630135,7.2000475 L11.589231,7.2000475 L10.63144,4.9115758 z M7.9629254,0.00055603631 C8.1890106,-0.0094743175 8.4417505,0.11529873 8.7136049,0.44805107 C9.5044546,1.4160579 10.199466,3.0797195 10.798619,3.2007234 C11.397754,3.3217273 11.014304,3.3519721 11.373784,3.1704786 C11.733265,2.9889851 13.00354,0.99248195 13.410958,0.53873581 C13.818377,0.084989473 14.440949,-0.40664661 15.088554,1.1437306 C15.783526,2.8074915 15.68761,7.2844644 15.999171,7.3752112 C16.310732,7.4659581 21.783356,7.5598621 21.990669,9.1297064 C22.062557,9.6741371 21.703077,10.127871 21.463425,10.460638 C21.21735,10.802305 18.472895,14.03023 10.606905,13.999774 C2.794054,13.969529 0.44543636,10.490821 0.15786375,9.8858252 C-0.12972848,9.2808304 0.046722628,9.1954288 0.13379611,8.9481258 C0.22965352,8.6758728 0.93106592,7.6602182 6.0358186,7.4787869 C6.398293,7.4659081 5.9335799,3.8965645 7.011982,1.0227765 C7.1968369,0.53016257 7.5313077,0.019705068 7.9629254,0.00055603631 z",
            //    PathWidth = 22,
            //    PathHeight = 14
            //});
            //appointments.Add(new CustomAppointment()
            //{
            //    Start = firstDayOfThisWeek.AddDays(3).AddHours(12),
            //    End = firstDayOfThisWeek.AddDays(3).AddHours(12).AddMinutes(56),
            //    Subject = "Action",
            //    LecturePart = "Lecture-Part 1&2:",
            //    BackgroundBrush = new SolidColorBrush(Color.FromArgb(255, 51, 102, 204)),
            //    PathData = "M78.130898,12.272297 L68.102562,14.700339 L73.73542,49.889809 C73.73542,49.889809 70.244881,50.448959 69.332191,50.811226 C67.717484,51.45216 65.184967,52.531857 65.754677,58.108196 L59.29221,61.700161 L51.545982,24.957293 L44.399227,17.613991 L33.915058,23.926899 L42.995541,29.671801 L53.391689,64.693466 C53.391689,64.693466 43.074802,72.086662 41.720207,73.2155 C41.499405,73.399498 32.10804,37.095127 32.10804,37.095127 L23.430893,30.725416 L12.035058,38.980759 L24.170078,42.243679 L35.560116,78.072121 C29.843431,81.73732 26.621193,80.692863 23.803928,75.527153 C22.114847,72.430176 21.313889,90.163246 31.717682,87.851357 C42.121479,85.539452 50.634644,76.980438 50.634644,76.980438 C50.634644,76.980438 50.679195,90.265434 57.036934,92.288261 C63.394672,94.311089 49.634811,73.115761 66.57238,68.880775 C67.2948,68.70015 67.921982,68.528343 68.464401,68.365082 L68.646606,68.309074 C68.646606,68.309074 71.093246,87.14325 92.994621,84.697052 C94.185623,84.564026 95.391052,76.968536 95.391052,76.968536 C95.391052,76.968536 73.592857,74.382736 71.128975,60.323582 C69.930824,53.486675 93.593636,48.732063 93.593636,48.732063 C93.593636,48.732063 86.626892,47.488106 79.503998,48.079704 z M50.825893,0 L69.371376,5.4813728 L75.552917,1.7130151 C75.552917,1.7130139 95.814026,-1.3706199 101.30885,3.4257836 C106.80368,8.2221231 99.249321,44.880203 99.249321,44.880203 L111.26813,44.195049 C111.26813,44.195049 120.19739,53.788097 120.54131,59.269474 C120.88522,64.750847 122.60157,63.380657 119.51067,74.343773 C116.41978,85.306892 93.411324,120.59441 88.603333,120.93699 C83.795341,121.27957 83.795219,119.9095 82.078499,120.25134 C78.313072,121.00109 78.987106,169.92888 78.987106,169.92888 C78.987106,169.92888 40.889389,170.636 37.455078,170.636 C34.020763,170.636 26.787052,168.55881 26.787052,168.55881 L29.190741,120.59466 L15.110314,116.82618 L1.3736774,63.723236 L0,39.741287 L8.5848598,30.491121 L18.200962,15.759336 L28.160112,16.10216 z",
            //    PathWidth = 12
            //});
            //appointments.Add(new CustomAppointment()
            //{
            //    Start = firstDayOfThisWeek.AddDays(3).AddHours(14),
            //    End = firstDayOfThisWeek.AddDays(3).AddHours(14).AddMinutes(56),
            //    Subject = "Crime",
            //    LecturePart = "Lecture-Part 1&2:",
            //    BackgroundBrush = new SolidColorBrush(Color.FromArgb(255, 153, 0, 51)),
            //    PathData = "M13,5 C13,4.8518825 12.14505,5.3905897 13,6 C12.612922,7.2620988 11.55382,8.1690302 10.219949,7.2379684 C8.8860779,6.3069181 7.9218359,9.5030956 10.446035,9.5249424 C13.441072,9.5508976 14.548957,9.9729156 14.588006,6.5900807 C14.602383,5.3449488 14.038363,4.8910131 13.46317,4.8726707 z M24.108585,-1.1048107 L26.6134,0.89732778 L26.762058,2.840477 L24.954372,5.0966311 L17.039537,5.3510289 C17.039537,5.3510289 17.039537,7.0203948 17.039537,9.0652876 C17.039537,11.110182 13.971913,11.51916 13.971913,11.51916 L9.4838591,11.50211 L9.5038748,14.911101 L8.4620504,19.272949 L2.6609101,19.474613 L1.0187652,14.571759 C1.0187651,14.571759 2.7238357,9.2701435 3.3373847,8.4521255 C3.9508121,7.6341071 2.9283926,5.5891523 2.9283924,5.5891523 L1.2923018,5.9985585 C1.292302,5.9985585 0.67911881,5.7945576 0.065691441,5.1809673 C-0.54773569,4.5673771 3.3257341,-0.30752492 3.3257341,-0.30752507 z",
            //    PathWidth = 15,
            //    PathHeight = 12
            //});
            //appointments.Add(new CustomAppointment()
            //{
            //    Start = firstDayOfThisWeek.AddDays(4).AddHours(11),
            //    End = firstDayOfThisWeek.AddDays(4).AddHours(11).AddMinutes(115),
            //    Subject = "Superhero",
            //    LecturePart = "Lecture-Part 1:",
            //    BackgroundBrush = new SolidColorBrush(Color.FromArgb(255, 142, 188, 0)),
            //    PathData = "M8.166995,8.2622185 C4.2264047,8.2622185 0.78751934,9.5919333 0.75650108,9.8715858 C0.56881946,11.563693 4.2264047,14.42807 8.166995,14.42807 C12.107587,14.42807 15.30034,11.543174 15.30034,9.8405209 C15.361872,9.6852226 12.107587,8.2622185 8.166995,8.2622185 z M14.598091,0 C14.598091,0 16.615725,8.4121895 15.810009,10.808696 L15.793567,10.824672 C15.793567,12.979307 13.735582,14.813111 11.034935,15.595349 L10.724084,15.679485 L10.750474,15.683934 C12.552212,16.006147 13.881172,16.670254 14.187068,17.319378 L10.718438,18.956118 L6.3361139,18.854843 L2.6950686,17.297621 C2.9332979,16.689955 4.065454,16.098841 5.6506414,15.764253 L5.8066564,15.732963 L5.6901159,15.707401 C2.8239591,15.030147 0.43771031,13.247484 0.26588747,11.102097 C0.26588762,11.102097 0.25306225,11.138354 0.24620198,11.115506 C-0.77281862,7.721436 1.7008473,0.2174733 1.7008473,0.21747337 C1.7008473,0.2174733 2.9379811,2.1809924 3.29178,2.0747049 C9.5272779,0.20160754 12.689193,2.0409009 12.689193,2.0409012 z",
            //    PathWidth = 16,
            //    PathHeight = 18
            //});
            //appointments.Add(new CustomAppointment()
            //{
            //    Start = firstDayOfThisWeek.AddDays(4).AddHours(13),
            //    End = firstDayOfThisWeek.AddDays(4).AddHours(13).AddMinutes(115),
            //    Subject = "Fantasy",
            //    LecturePart = "Lecture-Part 1&2:",
            //    BackgroundBrush = new SolidColorBrush(Color.FromArgb(255, 126, 81, 161)),
            //    PathData = "M7.0152168,3.749053 L7.4670901,4.0897064 L7.4677043,4.0907907 L8.9517078,6.8538327 C9.155654,7.2340717 9.6919937,7.592236 10.147931,7.6526055 L13.466473,8.0963678 C14.043013,8.1729574 14.172441,8.5387802 13.755722,8.912261 L11.353961,11.063947 C11.024508,11.359488 10.819582,11.938858 10.897042,12.35694 L11.464268,15.393898 C11.561829,15.921458 11.223552,16.148069 10.707804,15.898481 L7.7393055,14.464476 C7.6461968,14.419638 7.6928353,24.024776 7.5791841,24.000408 C7.323041,23.945488 6.5621786,23.952503 6.302114,24.001562 C6.1720634,24.026094 6.2699609,14.36819 6.1650229,14.418724 L3.2926869,15.898481 C2.7764478,16.148069 2.4381711,15.921458 2.5357323,15.393898 L3.102958,12.35694 C3.1809089,11.938858 2.9759817,11.359488 2.6460397,11.063947 L0.2442774,8.912261 C-0.17243995,8.5387802 -0.0430125,8.1729574 0.53352809,8.0963678 L3.8520687,7.6526055 C4.3080063,7.592236 4.8448362,7.2340717 5.0482922,6.8538327 L6.5327864,4.0903401 L6.5331454,4.0897064 z",
            //    PathHeight = 20
            //});
            //appointments.Add(new CustomAppointment()
            //{
            //    Start = firstDayOfThisWeek.AddDays(5).AddHours(14),
            //    End = firstDayOfThisWeek.AddDays(5).AddHours(14).AddMinutes(56),
            //    Subject = "Thriller",
            //    LecturePart = "Lecture-Part 1:",
            //    BackgroundBrush = new SolidColorBrush(Color.FromArgb(255, 47, 100, 149)),
            //    PathData = "M9.5699129,15.359915 C10.099503,15.34199 11.280672,17.18675 11.459169,17.750982 C11.990026,19.429026 10.807702,20.17411 9.3418999,20.012243 C8.0626516,19.870977 8.2013874,16.542011 9.0813122,15.779777 C9.1299734,15.737627 9.5151272,15.361769 9.5699129,15.359915 z M14.686213,2.0621781 L7.6488357,8.8947124 C7.6488357,8.8947124 9.1902428,11.042794 10.440032,10.629702 C11.074125,10.420115 11.8148,7.7380538 12.189737,6.5813947 C12.736592,4.8943787 13.152062,4.0742216 13.152062,4.0742216 L14.672694,3.6645942 z M15.546359,0.00020635121 C15.799494,-0.013016408 16.247925,0.61084354 16.166187,1.4084752 C15.731754,7.6666722 13.594878,11.63328 11.1006,13.988981 C11.1006,13.988981 10.453573,14.060269 10.453573,14.060269 C10.453573,14.060269 7.5772052,9.9294596 7.7754345,11.414742 C7.8284636,11.812073 4.638361,17.92976 2.3578653,17.500008 C1.1618214,17.274618 7.3729289E-09,14.822733 0,14.822733 C7.3729289E-09,14.822733 14.32763,0.53570235 15.498551,0.0114828 C15.513476,0.004801014 15.529484,0.0010880086 15.546359,0.00020635121 z",
            //    PathWidth = 13,
            //    PathHeight = 15
            //});

            return appointments;
        }

        private ObservableCollection<SampleModel> LoadSampleData()
        {
            string connString = "Data Source = vwsql01-sql; Initial Catalog = SHIRE_PRD; Persist Security Info = True; User ID = reporter; Password = rep391prd;";


            string query = @"select 
                            distinct s.sample_number, s.status, t.analysis, t.STATUS, t.BATCH, t.X_METHOD_NUMBER, s.X_CAUGHT_ON, s.PRODUCT, l.X_LOT_NAME, s.LOCATION,
                            l.PRODUCTION_DATE, s.SAMPLE_TYPE, a.ANALYSIS_TYPE, s.SPEC_TYPE
                            from LimsUser.SAMPLE s, LimsUser.RESULT r, LimsUser.TEST t, LimsUser.LOT l, ANALYSIS a
                            WHERE s.SAMPLE_NUMBER = t.SAMPLE_NUMBER
                            and t.TEST_NUMBER = r.TEST_NUMBER
                            and a.[NAME] = t.ANALYSIS
                            and a.VERSION = t.VERSION
                            and s.status IN('U','I')
                            and s.LOT = l.LOT_NUMBER
                            and s.sample_type NOT IN ('RAW_MAT','EM')
                            and s.LOCATION NOT IN ('DISCARD','PPD','PAD','CCPD')
                            and a.ANALYSIS_TYPE NOT IN ('PAD', 'MFG','CONTRACT','MICRO')
                            and s.PRODUCT NOT IN ('WATER','MFG_QUAL')
                            and s.spec_type NOT IN('BACKUP','BACKUP2','BACKUP3','SATELLITE')
                            and a.ANALYSIS_TYPE = 'TEST_TECH'
                            and s.sample_number > 1240666";

            ObservableCollection<SampleModel> _lstSamples = new ObservableCollection<SampleModel>();
            try
            {
                //Open the connection

                using (DBHelper o = new DBHelper(connString))

                {
                    //MainWindow mainW=  this.FindName("mainWindow") as MainWindow;

                    SqlCommand oCommand = o.GetCommand(query);

                    SqlDataReader oReader = oCommand.ExecuteReader();

                    while (oReader.Read())

                    {


                        SampleModel sm = new SampleModel();

                        var mnum = oReader["X_METHOD_NUMBER"];
                        if (mnum != null)
                        {
                            sm.MethodName = mnum.ToString();
                        }
                        else
                        {
                            sm.MethodName = "No Data";
                        }


                        _lstSamples.Add(sm);
                    }//while loop


                }//using


            }

            catch (Exception ex)
            {

            }
            return _lstSamples;
        }

        private ObservableCollection<TestingModel> LoadTestingDate()
        {
            string connString = "Data Source = vwsql01-sql; Initial Catalog = SHIRE_PRD; Persist Security Info = True; User ID = reporter; Password = rep391prd;";


            string query = @"select 
                            distinct s.sample_number, s.status, t.analysis, t.STATUS, t.BATCH, t.X_METHOD_NUMBER, s.X_CAUGHT_ON, s.PRODUCT, l.X_LOT_NAME, s.LOCATION,
                            l.PRODUCTION_DATE, s.SAMPLE_TYPE, a.ANALYSIS_TYPE, s.SPEC_TYPE
                            from LimsUser.SAMPLE s, LimsUser.RESULT r, LimsUser.TEST t, LimsUser.LOT l, ANALYSIS a
                            WHERE s.SAMPLE_NUMBER = t.SAMPLE_NUMBER
                            and t.TEST_NUMBER = r.TEST_NUMBER
                            and a.[NAME] = t.ANALYSIS
                            and a.VERSION = t.VERSION
                            and s.status IN('U','I')
                            and s.LOT = l.LOT_NUMBER
                            and s.sample_type NOT IN ('RAW_MAT','EM')
                            and s.LOCATION NOT IN ('DISCARD','PPD','PAD','CCPD')
                            and a.ANALYSIS_TYPE NOT IN ('PAD', 'MFG','CONTRACT','MICRO')
                            and s.PRODUCT NOT IN ('WATER','MFG_QUAL')
                            and s.spec_type NOT IN('BACKUP','BACKUP2','BACKUP3','SATELLITE')
                            and a.ANALYSIS_TYPE = 'TEST_TECH'
                            and s.sample_number > 1240666";

            ObservableCollection<TestingModel> lstTesting = new ObservableCollection<TestingModel>();
            try
            {
                //Open the connection

                using (DBHelper o = new DBHelper(connString))

                {
                    //MainWindow mainW=  this.FindName("mainWindow") as MainWindow;

                    SqlCommand oCommand = o.GetCommand(query);

                    SqlDataReader oReader = oCommand.ExecuteReader();

                    while (oReader.Read())

                    {


                        TestingModel tm = new TestingModel();

                        var mnum = oReader["X_METHOD_NUMBER"];
                        if (mnum != null)
                        {
                            tm.Message = mnum.ToString();
                        }
                        else
                        {
                            tm.Message = "No Data";
                        }


                        lstTesting.Add(tm);
                    }//while loop


                }//using


            }

            catch (Exception ex)
            {

            }
            return lstTesting;
        }


        private ObservableCollection<WriteupModel> LoadWriteupDate()
        {
            string connString = "Data Source = vwsql01-sql; Initial Catalog = SHIRE_PRD; Persist Security Info = True; User ID = reporter; Password = rep391prd;";


            string query = @"select 
                            distinct s.sample_number, s.status, t.analysis, t.STATUS, t.BATCH, t.X_METHOD_NUMBER, s.X_CAUGHT_ON, s.PRODUCT, l.X_LOT_NAME, s.LOCATION,
                            l.PRODUCTION_DATE, s.SAMPLE_TYPE, a.ANALYSIS_TYPE, s.SPEC_TYPE
                            from LimsUser.SAMPLE s, LimsUser.RESULT r, LimsUser.TEST t, LimsUser.LOT l, ANALYSIS a
                            WHERE s.SAMPLE_NUMBER = t.SAMPLE_NUMBER
                            and t.TEST_NUMBER = r.TEST_NUMBER
                            and a.[NAME] = t.ANALYSIS
                            and a.VERSION = t.VERSION
                            and s.status IN('U','I')
                            and s.LOT = l.LOT_NUMBER
                            and s.sample_type NOT IN ('RAW_MAT','EM')
                            and s.LOCATION NOT IN ('DISCARD','PPD','PAD','CCPD')
                            and a.ANALYSIS_TYPE NOT IN ('PAD', 'MFG','CONTRACT','MICRO')
                            and s.PRODUCT NOT IN ('WATER','MFG_QUAL')
                            and s.spec_type NOT IN('BACKUP','BACKUP2','BACKUP3','SATELLITE')
                            and a.ANALYSIS_TYPE = 'TEST_TECH'
                            and s.sample_number > 1240666";

            ObservableCollection<WriteupModel> lstWriteup = new ObservableCollection<WriteupModel>();
            try
            {
                //Open the connection

                using (DBHelper o = new DBHelper(connString))

                {
                    //MainWindow mainW=  this.FindName("mainWindow") as MainWindow;

                    SqlCommand oCommand = o.GetCommand(query);

                    SqlDataReader oReader = oCommand.ExecuteReader();



                    while (oReader.Read())

                    {


                        WriteupModel wm = new WriteupModel();

                        var mnum = oReader["X_METHOD_NUMBER"];
                        if (mnum != null)
                        {
                            wm.Message = mnum.ToString();
                        }
                        else
                        {
                            wm.Message = "No Data";
                        }


                        lstWriteup.Add(wm);
                    }//while loop


                }//using


            }

            catch (Exception ex)
            {

            }
            return lstWriteup;
        }



        private void GetSamples()
        {
            ObservableCollection<SampleModel> _lstSamples = LoadSampleData();

            var groups = from sm in _lstSamples
                         group sm by sm.MethodName
                              into g
                         select new SampleModel
                         {
                             MethodName = g.Key,
                             Count = g.Count()

                         };

            if (groups.Count() > 0)
            {
                SampleGroup1 = new SampleModel { MethodName = groups.ElementAt(20).MethodName, Count = groups.ElementAt(20).Count };

                SampleGroup2 = new SampleModel { MethodName = groups.ElementAt(10).MethodName, Count = groups.ElementAt(10).Count };

                SampleGroup3 = new SampleModel { MethodName = groups.ElementAt(5).MethodName, Count = groups.ElementAt(5).Count };


            }
        }

        private void GetTestings()
        {
            ObservableCollection<TestingModel> _lst = LoadTestingDate();

            var groups = from m in _lst
                         group m by m.Message
                              into g
                         select new TestingModel
                         {
                             Message = g.Key,
                             Count = g.Count()

                         };

            if (groups.Count() > 0)
            {
                TestingModel1 = new TestingModel { Message = groups.ElementAt(0).Message, Count = groups.ElementAt(0).Count };

                TestingModel2 = new TestingModel { Message = groups.ElementAt(0).Message, Count = groups.ElementAt(0).Count };

                TestingModel3 = new TestingModel { Message = groups.ElementAt(0).Message, Count = groups.ElementAt(0).Count };


            }
            else
            {
                TestingModel1 = new TestingModel { Message = "No Data", Count =0 };
                                                                              
                TestingModel2 = new TestingModel { Message = "No Data", Count =0 };
                                                                            
                TestingModel3 = new TestingModel { Message = "No Data", Count =0 };
            }
        }

        private void GetWriteup()
        {
            ObservableCollection<WriteupModel> _lst = LoadWriteupDate();

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
                WriteupModel1 = new WriteupModel { Message = "No Data", Count =0 };
                                                                              
                WriteupModel2 = new WriteupModel { Message = "No Data", Count =0 };
                                                                             
                WriteupModel3 = new WriteupModel { Message = "No Data", Count =0 };
            }
        }

        private void Init()
        {
            CopyRight = "Copyright © 2016.All rights reserved.";
            Status = "Status";
            CurrentDate = DateTime.Now.ToLongDateString();
            Version = "1.0";

            Appointments = AddManualAppointments();

            SampleTitle = "Samples";


            InstrumentTitle = "Instruments";

            SetupTitle = "Setup";

            TestingTitle = "Testing";

            WriteupTitle = "Writeup";

            ExceptionsTitle = "Exceptions";
        }


        #endregion

    }
}
