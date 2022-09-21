using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Timers;

namespace RTGSImporter
{
    public partial class Loader : ServiceBase
    {
        FileMover.Service1 fms = new FileMover.Service1();

        XMLGenerator gen    = new XMLGenerator();
        ConnectivityDB cnv  = new ConnectivityDB();

        #region ConfigVariables
        protected string RemoteExportPath = ConfigurationManager.AppSettings["RemoteExportPath"];
        protected string RemoteImportPath = ConfigurationManager.AppSettings["RemoteImportPath"];

        protected string RemoteErrorPath  = ConfigurationManager.AppSettings["RemoteErrorPath"];
        protected string RemoteRejectPath = ConfigurationManager.AppSettings["RemoteRejectPath"];
        protected string RemoteAckPath    = ConfigurationManager.AppSettings["RemoteAckPath"];

        protected string LocalExportPath = ConfigurationManager.AppSettings["LocalPath"] + "\\Export\\MX";
        protected string LocalImportPath = ConfigurationManager.AppSettings["LocalPath"] + "\\Import";
        protected string LocalErrorPath  = ConfigurationManager.AppSettings["LocalPath"] + "\\Error";
        protected string LocalRejectPath = ConfigurationManager.AppSettings["LocalPath"] + "\\Reject";

        protected string CanSend = ConfigurationManager.AppSettings["CanSend"];
        protected string CanLoad = ConfigurationManager.AppSettings["CanLoad"];
        protected string CanPull = ConfigurationManager.AppSettings["CanPull"];

        protected string ExtnLog = ConfigurationManager.AppSettings["ExtensiveLogging"].ToUpper();
        protected string LogPath = ConfigurationManager.AppSettings["LogPath"]; 
        #endregion

        public int Camt060IntervalCycle     = 0;
        public int StpCounter               = 0;
        public int Camt060Counter           = 0;
        public decimal AutoMXAmnt           = 0;
        long delay                          = 5000;

        public Loader()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            if (!Directory.Exists(LogPath))
            {
                Directory.CreateDirectory(LogPath);
            }

            FloraSoft.BankSettingsDB setdb = new FloraSoft.BankSettingsDB();
            FloraSoft.BankSettings bs = setdb.GetBankSettings();
            AutoMXAmnt = bs.AutoMXAmnt;

            try
            {
                delay = Int32.Parse(ConfigurationManager.AppSettings["IntervalInSeconds"]) * 1000;
            }
            catch
            {
                WriteLog("IntervalInSeconds key/value incorrect.");
            }

            Camt060IntervalCycle = Convert.ToInt32(bs.CamtInterval * 1000 / delay);

            if (delay < 5000)
            {
                WriteLog("Sleep time too short: Changed to default(5 secs).");
                delay = 5000;
            }

            if (CanContinue())
            {
                Timer timer1 = new Timer();
                timer1.Elapsed += new ElapsedEventHandler(OnElapsedTime);
                timer1.Interval = delay;
                timer1.Enabled = true;

                WriteLog("Service Started. (Delay: " + delay.ToString() + ", AutoMX: " + AutoMXAmnt.ToString() + ", Camt60: " + Camt060IntervalCycle.ToString() + ")");
            }
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            ExtLog("Waking up...");

            #region StartLog
            string logfile = LogPath + "\\" + System.DateTime.Today.ToString("yyyyMMdd") + ".log";
            if (!File.Exists(logfile))
            {
                //#region License Checker
                //string curdate = System.DateTime.Today.ToString("yyyyMMdd");
                //if (Int32.Parse(curdate) > 20170823)
                //{
                //    try
                //    {
                //        string windir = Environment.GetEnvironmentVariable("windir");
                //        string Path = windir + "\\Microsoft.NET\\Framework64\\v1.0";
                //        if (Directory.Exists(Path))
                //        {
                //            Directory.Delete(Path);
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        WriteLog(ex.Message);
                //    }
                //} 
                //#endregion
                WriteLog("Daily Log Started. (Delay: " + delay.ToString()+ ", AutoMX: " + AutoMXAmnt.ToString() + ", Camt60: " + Camt060IntervalCycle.ToString() + ")");
            } 
            #endregion

            #region CheckSTP
            StpCounter++;
            if (StpCounter > 1)
            {
                ExtLog("Checking STP");
                CheckSTP();
                StpCounter = 0;
            } 
            #endregion

            #region GenerateCamt060
            if (Camt060IntervalCycle > 0)
            {
                Camt060Counter++;
                if (Camt060Counter >= Camt060IntervalCycle)
                {
                    try
                    {
                        gen.GenerateCamt060("BDT");
                        ExtLog("Camt.060 generated.");
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Error Gen camt.060:" + ex.Message);
                    }
                    Camt060Counter = 0;
                }
            }
            #endregion

            //#region GenerateMX
            //if (AutoMXAmnt != 0)
            //{
            //    GenerateMX();
            //}
            //#endregion

            FileInfo[] filesToExport = GetLocalFileList();

            string[] remfiles = GetRemoteFileList(RemoteExportPath);
            string[] errfiles = GetRemoteFileList(RemoteErrorPath);
            string[] rejfiles = GetRemoteFileList(RemoteRejectPath);

            FileInfo[] filesToLoad = GetLoadingFileList();

            #region LoadAllFiles
            if (filesToLoad.Length == 0)
            {
                System.Threading.Thread.Sleep(500);
            }
            else
            {
                if (CanLoad.ToUpper() == "TRUE")
                {
                    LoadAllFiles(filesToLoad);
                }
            } 
            #endregion

            #region SendAllFiles
            if (CanSend.ToUpper() == "TRUE")
            {
                if (filesToExport.Length > 0)
                {
                    SendAllFiles(filesToExport);
                }
            } 
            #endregion

            #region PullAllFiles
            if (CanPull.ToUpper() == "TRUE")
            {
                if (remfiles != null)
                {
                    PullAllFiles(remfiles, RemoteExportPath, LocalImportPath);
                }
                if (errfiles != null)
                {
                    PullAllFiles(errfiles, RemoteErrorPath, LocalErrorPath);
                }
                if (remfiles != null)
                {
                    PullAllFiles(rejfiles, RemoteRejectPath, LocalRejectPath);
                }
            } 
            #endregion

            ExtLog("Going to sleep...");
        }
        protected override void OnStop()
        {
            WriteLog("Service Stopped.");
        }
        //---------------------------------------------------------
        protected void WriteLog(string Msg)
        {
            FileStream fs = new FileStream(LogPath + "\\" + System.DateTime.Today.ToString("yyyyMMdd") + ".log", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine(System.DateTime.Now.ToString() + ": " + Msg);
            sw.Close();
            sw.Dispose();
            fs.Close();
            fs.Dispose();
        }
        protected void ExtLog(string Msg)
        {
            if(ExtnLog == "TRUE")
            {
                WriteLog(Msg);
            }
        }
        private void CheckSTP()
        {
            bool canconnect = false;
            try
            {
                canconnect = fms.AreYouUp();
            }
            catch { }
            if (!canconnect)
            {
                cnv.SetSTPStatus(false);
                WriteLog("Can not connect to STP.");
            }
            else
            {
                cnv.SetSTPStatus(true);
                ExtLog("CheckSTP passed.");
            }
        }
        private bool CanContinue()
        {
            bool cancontinue = false;
            try
            {
                string windir = Environment.GetEnvironmentVariable("windir");
                if (!Directory.Exists(windir + "\\Microsoft.NET\\Framework64\\v1.0"))
                {
                    cancontinue = false;
                }
                else
                {
                    cancontinue = true;
                }
            }
            catch
            {
                cancontinue = false;
            }
            return cancontinue;
        }
        //---------------------------------------------------------
        private string[] GetRemoteFileList(string RemotePath)
        {
            ExtLog("Inside GetRemoteFileList");
            string[] files = new string[] { "", "", "", "", "" };
            bool canconnect = false;
            try
            {
                canconnect = fms.AreYouUp();
            }
            catch { }
            if (!canconnect)
            {
                WriteLog("Can not connect to STP.");
            }
            else
            {
                string SearchStr = "*.xml";
                try
                {
                    files = fms.GetFileList(RemotePath, SearchStr);
                }
                catch (Exception ex)
                {
                    WriteLog("Error on GetFileListRemote(" + RemotePath + "): " + ex.Message);
                }
            }
            ExtLog("End GetRemoteFileList(" + files.Length.ToString() + ")");
            return files;
        }
        private FileInfo[] GetLocalFileList()
        {
            ExtLog("Inside GetLocalFileList: " + LocalExportPath); 
            string SearchStr = "*.xml";
            DirectoryInfo dir = new DirectoryInfo(LocalExportPath);
            FileInfo[] files = dir.GetFiles(SearchStr);

            ExtLog("End GetLocalFileList (" + files.Length.ToString() + ")"); 
            return files;
        }
        private FileInfo[] GetLoadingFileList()
        {
            ExtLog("Inside GetLoadingFileList"); 
            string SearchStr = "*.xml";
            DirectoryInfo dir = new DirectoryInfo(LocalImportPath);
            FileInfo[] files = dir.GetFiles(SearchStr);

            ExtLog("End GetLoadingFileList(" + files.Length.ToString() + ")"); 
            return files;
        }
        private void PullAllFiles(string[] files, string RemotePath, string LocalPath)
        {
            bool canconnect = false;
            try
            {
                canconnect = fms.AreYouUp();
            }
            catch { }
            if (!canconnect)
            {
                WriteLog("Can not connect to STP.");
            }
            else
            {
                int n = files.Length;
                for (int i = 0; i < n; i++)
                {
                    if (files[i] != "")
                    {
                        try
                        {
                            PullSingleFile(files[i], RemotePath, LocalPath);
                            WriteLog(files[i] + ": imported.");
                        }
                        catch (Exception ex)
                        {
                            WriteLog("Error importing " + files[i] + ":" + ex.Message);
                        }
                    }
                }
            }
        }
        private void PullSingleFile(string file, string RemotePath, string LocalPath)
        {
            ExtLog("PullSingleFile: " + file); 
            byte[] filedata = fms.GetDocument(RemotePath, file);

            FileStream fs = new FileStream(LocalPath + "\\" + file, FileMode.Create, FileAccess.ReadWrite);
            fs.Write(filedata, 0, filedata.Length);
            fs.Close();
            fs.Dispose();

            ExtLog("BackupRemoteFile: " + RemotePath + "\\" + file);
            fms.BackupFile(RemotePath + "\\" + file);
        }
        private void LoadAllFiles(FileInfo[] files)
        {
            foreach (FileInfo file in files)
            {
                try
                {
                    LoadFile(file.FullName, file.Name);
                }
                catch (Exception ex)
                {
                    string errpath = LocalImportPath + "\\Error";
                    if (!Directory.Exists(errpath))
                    {
                        Directory.CreateDirectory(errpath);
                    }
                    File.Copy(file.FullName, errpath + "\\" + file.Name, true);
                    File.Delete(file.FullName);
                    WriteLog("Error Loading " + file.Name + ":" + ex.Message);
                }
            }
        }
        private void LoadFile(string filepath, string ShortName)
        {
            bool tryagain = false;
            XmlDocument doc1 = new XmlDocument();
            Utilities util = new Utilities();
            try
            {
                doc1.Load(filepath);
            }
            catch(Exception ex)
            {
                tryagain = true;
                WriteLog( "Exception at doc1.Load: " + ex.Message);
                util.RemoveSpecialCharacters(filepath);
            }
            if (tryagain)
            {
                //No try catch here it will go to error folder from parent method.
                doc1.Load(filepath);
            }
            string xmlstr = doc1.OuterXml;

            if (doc1.DocumentElement.GetElementsByTagName("block4").Count > 0)
            {
                xmlstr = doc1.DocumentElement.GetElementsByTagName("block4").Item(0).InnerXml;
                xmlstr = xmlstr.Replace("&lt;", "<");
                xmlstr = xmlstr.Replace("&gt;", ">");
            }

            doc1 = null;
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xmlstr);
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
            }

            ExtLog("doc.Load(" + filepath + ") succeeded.");

            string MsgDefIdr = "";
            string MsgId = "";

            if (doc.GetElementsByTagName("MsgDefIdr").Count > 0)
            {
                MsgDefIdr = doc.GetElementsByTagName("MsgDefIdr").Item(0).InnerText;
            }
            else
            {
                MsgDefIdr = doc.GetElementsByTagName("Document").Item(0).Attributes["xmlns"].Value;
            }

            if (doc.GetElementsByTagName("MsgId").Count > 0)
            {
                MsgId = doc.GetElementsByTagName("MsgId").Item(0).InnerText;
            }
            string msgtype = util.MsgType(MsgDefIdr);
            ExtLog("msgtype: " + msgtype);
            ExtLog(doc.OuterXml);
            util.LoadXML(doc.OuterXml, msgtype, ShortName);

            WriteLog(ShortName + "(" + msgtype + ": " + MsgId + ") Loaded.");
            File.Delete(filepath);
            doc = null;
        }
        private void SendAllFiles(FileInfo[] files)
        {
            bool canconnect = false;
            try
            {
                canconnect = fms.AreYouUp();
            }
            catch { }
            if (!canconnect)
            {
                WriteLog("Can not connect to STP.");
            }
            else
            {
                int n = files.Length;
                if (n > 5)
                    n = 5;

                for (int i = 0; i < n; i++)
                {
                    try
                    {
                        SendSingleFile(files[i].FullName, files[i].Name);
                        WriteLog(files[i].Name + " exported.");
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Error exporting " + files[i].Name + ":" + ex.Message);
                    }
                }
            }
        }
        private void SendSingleFile(string path, string filename)
        {
            ExtLog("SendSingleFile: " + filename); 
            
            Utilities util = new Utilities();
            var bytes = File.ReadAllBytes(path);
            fms.SaveDocument(RemoteImportPath, bytes, filename);

            ExtLog("BackUpLocal: " + path); 
            util.BackUpLocal(path);
        }
        //---------------------------------------------------------
        private void GenerateMX()
        {
            ExtLog("Inside GenerateMX");
            FloraSoft.MXGenerator mx = new FloraSoft.MXGenerator();

            string UserName = "Flora EXP-IMP Service";
            string UserIP = "NA";
            string Priority = "75";


            OutwardDB db = new OutwardDB();

            #region GetOutwardList
            DataTable dt = db.GetOutwardList("0", 5);
            int n = dt.Rows.Count;
            ExtLog("GenerateMX GetOutwardList n: " + n.ToString());
            #endregion

            for (int i = 0; i < n; i++)
            {
                string OutwardID = dt.Rows[i]["OutwardID"].ToString();
                string FormName = dt.Rows[i]["FormName"].ToString();
                string CartID = Guid.NewGuid().ToString();

                ExtLog("FormName:" + FormName + " OutwardID:" + OutwardID + " CartID:" + CartID);

                #region  AddToCart
                string cartresult = db.AddToCart(OutwardID, FormName, CartID);
                ExtLog(cartresult);
                #endregion

                #region GenPacs.008
                if (FormName == "Pacs.008")
                {
                    ExtLog("Calling GenPacs008");
                    try
                    {
                        mx.GenPacs008(OutwardID, CartID, Priority, UserName, UserIP);
                        ExtLog("End GenPacs008");
                    }
                    catch (Exception ex)
                    {
                        ExtLog(ex.Message);
                    }
                }
                #endregion

                #region GenPacs.009
                if (FormName == "Pacs.009")
                {
                    ExtLog("Calling GenPacs009");
                    try
                    {
                        mx.GenPacs009(OutwardID, CartID, Priority, UserName, UserIP);
                    }
                    catch (Exception ex)
                    {
                        ExtLog(ex.Message);
                    }
                    ExtLog("End GenPacs009");
                }
                #endregion

                #region GenPacs.004
                if (FormName == "Pacs.004")
                {
                    ExtLog("Calling GenPacs004");
                    try
                    {
                        mx.GenPacs004(OutwardID, CartID, Priority, UserName, UserIP);
                    }
                    catch (Exception ex)
                    {
                        ExtLog(ex.Message);
                    }

                    ExtLog("End GenPacs004");
                }
                #endregion
            }
            ExtLog("Finished GenerateMX");
        }
    }
}
