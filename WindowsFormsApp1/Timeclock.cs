using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class TestClock : Form
    {
        public string pFolderRoot;
        public List<string> projSelectorLinks = new List<string>();
        public List<string> openProjFiles = new List<string>();
        public List<string> writeFileQue = new List<string>();
        public string[] rawProjFile;

        /*Project File Definition
         * Data file.readlines--> into rawProjFile
         * Data processed into "projectData" class to set correct "types"
         * rawProjFile[0]  = file name (timelog.txt) -> test for legacy files which will not have it
         * rawProjFile[1]  = file version (0.1) -> test for legacy files and processing variations
         * rawProjFile[2]  = clockVersion version (0.1) -> test for legacy timeclock data and processing variations
         * rawProjFile[3]  = 3ds Max project file, format = parentFolderName.mxp ->(eg. 20200124_SummervillePres_SummervilleNC.mxp); file contains a complete project folder map as text, for future project management
         * rawProjFile[4]  MARKER; expected: "[PM Information]"
         * rawProjFile[5]  = pManager; //full name of Project Manager
         * rawProjFile[6]  = pManPhone; //phone number of project manager
         * rawProjFile[7]  = pManEmail; //manager's full email address
         * rawProjFile[8]  MARKER; expected: "[Project Data]"
         * rawProjFile[9]  = pOrgName; //Full name or organization for the project (eg. First Baptist Church of Chambersburgh)
         * rawProjFile[10] = pOrgShort; //Truncated name for project (eg. FBCChambersburgh)
         * rawProjFile[11] = pContact; //Contact person at the organization/church
         * rawProjFile[12] = pAddress1; //Organization Physical Address: line 1
         * rawProjFile[13] = pAddress2; //Organization Physical Address: line 2
         * rawProjFile[14] = pCity; //Organization Physical Address: City
         * rawProjFile[15] = pState; //Organization Physical Address: State
         * rawProjFile[16] = pZip; //Organization Physical Address: Zip code (12345)
         * rawProjFile[17] = pStartDay; //date project was added to the production que, Not the the first timeclock start
         * rawProjFile[18] = pDueDay; //Delivery date, End of Project
         * rawProjFile[19] = pEstimate; //Estimated time for project in hours (eg. 22)
         * rawProjFile[20] = pTimeTotal; //Time Span object for the total amount of time recorded for the project to date as recorded in the file, loaded as is, updated on pause/stop/save/switch
         * rawProjFile[21] MARKER; expected: "[Timeclock Data]"
         * rawProjFile[21] MARKER; expected: "[Session,0]"->read into timeTrack.timelig as data(List) format [tStart, tSesInc, tIncTotal, tPInc, tResume, tPInc, tResume, ... ]
         * rawProjFile[22] = tStart-> DateTime object as text, tSesInc-> TimeSpan object as text, tIncTotal-> TimeSpan object as text, tPInc-> TimeSpan object as text
         * rawProjFile[23] = tResume->DateTime Object as text, tPInc-> TimeSpan object as text
         * rawProjFile[..] = tResume->DateTime Object as text, tPInc-> TimeSpan object as text
         * rawProjFile[nn] MARKER; expected: "[Session,1]" OR EOF
         * rawProjFile[nn1]  = tStart-> DateTime object as text, tSesInc-> TimeSpan object as text, tIncTotal-> TimeSpan object as text, tPInc-> TimeSpan object as text
         * rawProjFile[nn2]  = tResume->DateTime Object as text, tPInc-> TimeSpan object as text
         * rawProjFile[nn..] = tResume->DateTime Object as text, tPInc-> TimeSpan object as text
         * rawProjFile[nn] MARKER; expected: "[Session,2]" OR EOF

         */

        public TestClock()
        {
            InitializeComponent();
        }

        private void TestClock_Load(object sender, EventArgs e)
        {
            timer1.Start();

            //Console.WriteLine("Hello!");
            timeTrack.Zero = new DateTime(1, 1, 1, 0, 0, 0);
            timeTrack.Toggle = "stop";
            timeTrack.timeLog = new List<List<Object>>();
            timeTrack.SesList = new List<Object>();
            timeTrack.LastRowIndex = 0;
            timeTrack.SesList.Add(new DateTime());
            timeTrack.SesList.Add(new TimeSpan(0));
            timeTrack.SesList.Add(new TimeSpan(0));

            Console.WriteLine("Starting List: ", timeTrack.SesList[0],", ", timeTrack.SesList[1],", ", timeTrack.SesList[2]);

        }

        static class projectData
        {
            public static string pManager; //full name of Project Manager
            public static string pManPhone; //phone number of project manager
            public static string pManEmail; //manager's full email address
            public static DateTime pStartDay; //date project was added to the production que, Not the the first timeclock start
            public static DateTime pDueDay; //Delivery date, End of Project
            public static string pOrgName; //Full name or organization for the project (eg. First Baptist Church of Chambersburgh)
            public static string pOrgShort; //Truncated name for project (eg. FBCChambersburgh)
            public static string pContact; //Contact person at the organization/church
            public static string pAddress1; //Organization Physical Address: line 1
            public static string pAddress2; //Organization Physical Address: line 2
            public static string pCity; //Organization Physical Address: City
            public static string pState; //Organization Physical Address: State
            public static string pZip; //Organization Physical Address: Zip code (12345)
            public static int pEstimate; //Estimated time for project in hours (eg. 22)
            public static TimeSpan pTimeTotal; //Time Span object for the total amount of time recorded for the project to date as recorded in the file, loaded as is, updated on pause/stop/save/switch

            /* compare timespan data to int--> There is the property TotalDays
             * if (ts.Days == 30){   // do something    }
             * There's also TotalHours, TotalMinutes, TotalSeconds and TotalMilliseconds. check out the TimeSpan-properties for more information.
             * https://docs.microsoft.com/en-us/dotnet/api/system.timespan?view=netframework-4.8
             * Eg. -> 30 days 23 hours 59 minutes results: Days = 30, but TotalDays = 30.999xxx ( – Lasse V. Karlsen Aug 1 '18 at 9:11)
            */
        }
        static class timeTrack
        {        
            public static DateTime Zero; //Used to have a 00:00 value for datetime for timespan calculations and conversions
            public static TimeSpan tInc; //time Increment; realtime running time increment, also used for onscreen display/feedback
            public static DateTime CapA; //Time capture A, when was clock started in the current session (Assumes one project timer active at a time)
            public static DateTime CapB; //Time Capture B, When was clock stopped in the current session (Assumes one project timer active at a time)
            public static String Toggle; //Tracking start/stop/pause states (Assumes one project timer active at a time)
            public static int LastRowIndex; //current last row of the Time Log for the current timing project (Assumes one project timer active at a time)
            public static List<List<Object>> timeLog;
            public static List<Object> SesList;
            //public static List<TimeSpan> pIncList;

            /*.timeLog == [[tStart, tSesInc, tIncTotal, tPInc, tResume, tPInc, tResume, ... ],[tStart, tSesInc, tIncTotal, tPInc, tResume, tPInc, tResume, ... ], ... ]
             *..subList info:
             * {timeTrack.timeLog[n][0]   (DateTime)} tStart: Session start time
             * {timeTrack.timeLog[n][1]   (TimeSpan)} tSesInc: Time increment for current session
             * {timeTrack.timeLog[n][2]   (TimeSpan)} tIncTotal: total time recorded to date
             * {timeTrack.timeLog[n][3++] (TimeSpan)} tPInc: Incremental Time when "pause" clicked
             * {timeTrack.timeLog[n][4++] (DateTime)} tResume: Time when "play" button is clicked for timer restart
             *
             */
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            DateTime TimeNow = DateTime.Now;
                        UiTxt_currentTime.Text = TimeNow.ToString("T");
            switch (timeTrack.Toggle)
            {
                case "play":
                    timeTrack.tInc = TimeNow - timeTrack.CapA;
                    UiTxt_cTimeDiff.Text = timeTrack.tInc.ToString(@"hh\:mm\:ss");
                    //Debug.WriteLine("LastRowIndex= " + timeTrack.LastRowIndex);
                    Object n = timeTrack.timeLog[timeTrack.LastRowIndex][1];
                    string a = n.ToString();
                    TimeSpan z = TimeSpan.Parse(a);

                    UiTxt_cTimeSession.Text = z.Add(timeTrack.tInc).ToString(@"hh\:mm\:ss");

                    break;
                case "pause":
                    break;
                case "stop":
                    break;
            }
           
        }


        private void BtnStart(object sender, EventArgs Actn)
        {
            timeTrack.CapA = DateTime.Now;
            
            int tLogRows = timeTrack.timeLog.Count;
            Console.WriteLine("tLogRows= " + tLogRows);
            if (tLogRows > 0) { timeTrack.LastRowIndex = tLogRows - 1; }

            Debug.WriteLine("Start Button");
            //Debug.WriteLine(UiTxtBox_Timelog.Lines[0]);
            //Debug.WriteLine(UiTxtBox_Timelog.Lines.Count());
            Debug.WriteLine("Toggle=" + timeTrack.Toggle);

            switch (timeTrack.Toggle)
            {
                case "stop":
                    timeTrack.timeLog.Add(timeTrack.SesList);
                    Console.WriteLine("tLog Is Null");
                    //Debug.WriteLine(timeTrack.timeLog[0][0].ToString() + ", " + timeTrack.LastRowIndex+1);
                    timeTrack.timeLog[timeTrack.LastRowIndex][0] = timeTrack.CapA;
                    UiTxtBox_Timelog.Clear();
                    UiTxtBox_Timelog.Text = timeTrack.timeLog[timeTrack.LastRowIndex][0].ToString();
                    break;
                case "pause":
                    int tLogLastCol = timeTrack.timeLog[timeTrack.LastRowIndex].Count;
                    //timeTrack.timeLog[timeTrack.LastRowIndex].Add(new DateTime());
                    Console.WriteLine("rows=" + tLogRows + ", RowIndex=" + timeTrack.LastRowIndex);
                    timeTrack.timeLog[timeTrack.LastRowIndex].Add(timeTrack.CapA);

                    Console.WriteLine("Type=" + timeTrack.timeLog[timeTrack.LastRowIndex][0].GetType());

                    string StringTemp = timeTrack.timeLog[timeTrack.LastRowIndex][0].ToString();
                    UiTxtBox_Timelog.Text += "\r\n" + StringTemp;
                    break;
                default:
                    break;
            }

            timeTrack.Toggle = "play";

            Console.WriteLine("Toggle= " + timeTrack.Toggle);
            Console.WriteLine(timeTrack.timeLog[0][0].ToString());

        }

        private void BtnPause(object sender, EventArgs Actn)
        {
            // .timeLog == [[tStart, tSesInc, tIncTotal, tPInc, tResume, tPInc, tResume, ... ], ...

            if (timeTrack.Toggle == "pause" | timeTrack.Toggle == "stop") { }
            else
            {                
                timeTrack.CapB = DateTime.Now;
                timeTrack.tInc = timeTrack.CapB - timeTrack.CapA;
                int tLogRowP = timeTrack.timeLog.Count;
                timeTrack.LastRowIndex = tLogRowP - 1;
                int tLogCols = timeTrack.timeLog[timeTrack.LastRowIndex].Count;

                Object a = timeTrack.timeLog[timeTrack.LastRowIndex][1];
                string b = a.ToString();
                TimeSpan c = TimeSpan.Parse(b);

                timeTrack.timeLog[timeTrack.LastRowIndex][1] = c.Add(timeTrack.tInc);
                timeTrack.timeLog[timeTrack.LastRowIndex].Add(timeTrack.tInc);

                //Debug.WriteLine("timeLog[n][1]= " + timeTrack.timeLog[timeTrack.LastRowIndex][1]);
                Debug.WriteLine("Cols= " + tLogCols);

                timeTrack.Toggle = "pause";
                Console.WriteLine("Toggle= " + timeTrack.Toggle);
                //string StringTempP = timeTrack.timeLog[tLogIndexP][0].ToString("hh:mm:ss");
                //StringTempP += ", "+timeTrack.timeLog[tLogIndexP][3].ToString("HH:mm:ss"); HH = 24 hour format, hh = 12 hour format

                Debug.WriteLine(" index 1,last-1 and last-->" + timeTrack.timeLog[timeTrack.LastRowIndex][1] + ", " + timeTrack.timeLog[timeTrack.LastRowIndex][(tLogCols-1)] + ", " + timeTrack.timeLog[timeTrack.LastRowIndex][tLogCols]);

                Object x = timeTrack.timeLog[timeTrack.LastRowIndex][1];
                string xa = x.ToString();
                TimeSpan xb = TimeSpan.ParseExact(xa, "c", null);
                string xc = xb.ToString(@"hh\:mm\:ss");
                string yc;
                if (tLogCols < 4)
                {
                    Object y = timeTrack.timeLog[timeTrack.LastRowIndex][1];
                    string ya = y.ToString();
                    TimeSpan yb = TimeSpan.ParseExact(ya, "c", null);
                    yc = yb.ToString(@"hh\:mm\:ss");
                }
                else
                {
                    Object y = timeTrack.timeLog[timeTrack.LastRowIndex][(tLogCols - 1)];
                    yc = y.ToString();
                    //DateTime yb = DateTime.ParseExact(ya, "en-US", null);
                    // yc = yb.ToString(@"hh\:mm\:ss");
                }

                Object z = timeTrack.timeLog[timeTrack.LastRowIndex][tLogCols];
                string za = z.ToString();
                TimeSpan zb = TimeSpan.ParseExact(za, "c", null);
                string zc = zb.ToString(@"hh\:mm\:ss");

                string StringTempP = ", " + xc + ", " + yc + ", " + zc;
                //string StringTempP = timeTrack.timeLog[timeTrack.LastRowIndex][1].ToString(@"hh\:mm\:ss");
                //StringTempP += ", " + timeTrack.timeLog[timeTrack.LastRowIndex][2].ToString(@"hh\:mm\:ss");
                //StringTempP += ", " + timeTrack.timeLog[timeTrack.LastRowIndex][(tLogCols-1)].ToString(@"hh\:mm\:ss");
                int mCount = 0;
                foreach (Object CycleN in timeTrack.timeLog[0])
                {
                    Debug.WriteLine($"[{mCount}]= { CycleN }");
                    mCount++;
                }
                Console.WriteLine("timeLog LastCol-2, -1, 0= " + timeTrack.timeLog[timeTrack.LastRowIndex][(tLogCols - 2)] + ", " + timeTrack.timeLog[timeTrack.LastRowIndex][(tLogCols - 1)] + ", " + timeTrack.timeLog[timeTrack.LastRowIndex][tLogCols]);
                UiTxtBox_Timelog.Text += StringTempP;
               
            }

        }
        private void BtnParseDirs(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "Folder Select";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pFolderRoot = Path.GetDirectoryName(openFileDialog1.FileName);
                textOpenFileSelect.Text = pFolderRoot;
                string[] dirs = Directory.GetDirectories(pFolderRoot);
                foreach (string d in dirs)
                {
                    //Console.WriteLine(d);

                    string[] fList = Directory.GetFiles(d);
                    
                    if (fList.Any(x => x.Contains("imelog")))
                    {
                        int pos = Array.FindIndex(fList, element => element.EndsWith("imelog.txt"));
                        //Console.WriteLine(pos);
                        //Console.WriteLine(fList[pos]);
                        pListComboBox.Items.Add(d.Split('\\').Last());
                        projSelectorLinks.Add(fList[pos]);
                    }

                }
                if (projSelectorLinks[0] != null) { pListComboBox.Text = "Select project..."; }
            }
        }

        private void pListComboSelected(object sender, EventArgs e)
        {
            Console.WriteLine(pListComboBox.SelectedIndex);
            Console.WriteLine(projSelectorLinks[pListComboBox.SelectedIndex]);
            //List<string> myTCFile = new List<string>();
            var myTCFile = File.ReadLines(projSelectorLinks[pListComboBox.SelectedIndex]);
            tLogFileDisplay.Text = null;
            foreach (var l in myTCFile)
            {
                tLogFileDisplay.AppendText(l + "\r\n");
            }
        }

        private void readProjDataFile(string fpath)
        {

        }
    }
}
