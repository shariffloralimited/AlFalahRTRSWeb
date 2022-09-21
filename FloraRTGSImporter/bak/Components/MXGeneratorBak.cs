using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Configuration;

namespace FloraSoft
{
    public class MXGeneratorBak
    {
        protected string ExtnLog = ConfigurationManager.AppSettings["ExtensiveLogging"].ToUpper();
        protected string LogPath = ConfigurationManager.AppSettings["LogPath"]; 

        public string GenPacs008(string OutwardID, string CartID, string Priority, string UserName, string UserIP)
        {
            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
            RTGSImporter.XmlString str = new RTGSImporter.XmlString();

            RTGSImporter.Pacs008 pacs = db.GetSingleCartOutward08(OutwardID, CartID);

            if (pacs.PacsID == "")
            {
                ExtLog("GetSingleCartOutward08(" + OutwardID + "," + CartID + "): NOT FOUND");
                return "";
            }

            string xml = str.GetPacs8(pacs, Priority);

            ExtLog(xml);

            string filename = pacs.BizMsgIdr + ".xml";
            string path = ConfigurationManager.AppSettings["LocalPath"] + "\\Export\\MX\\" + filename;

            ExtLog("Path: " + path);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.Save(path);

            string[] lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines);

            ExtLog(path + " :Created");
            
            if(File.Exists(path))
            {
                long length = new System.IO.FileInfo(path).Length;

                if (length > 1024)
                {
                    db.SendOutward08(OutwardID, UserName, UserIP);
                    ExtLog("Status Updated to STP: "+OutwardID);
                }
            }
            return "";
        }
        public string GenPacs009(string OutwardID, string CartID, string  Priority, string UserName, string UserIP)
        {
            RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();
            RTGSImporter.XmlString str = new RTGSImporter.XmlString();

            RTGSImporter.Pacs009 pacs = db.GetSingleCartOutward09(OutwardID, CartID);

            if (pacs.PacsID == "")
                return "GetSingleCartOutward09(" + OutwardID + "," + CartID + "): NOT FOUND";

            string xml = str.GetPacs9(pacs, Priority);

            ExtLog(xml);

            string filename = pacs.BizMsgIdr + ".xml";
            string path = ConfigurationManager.AppSettings["LocalPath"] + "\\Export\\MX\\" + filename;

            ExtLog("Path: " + path);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.Save(path);

            string[] lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines);

            ExtLog(path + " :Created");

            if (File.Exists(path))
            {
                long length = new System.IO.FileInfo(path).Length;

                if (length > 1024)
                {
                    db.SendOutward09(OutwardID, UserName, UserIP);
                    ExtLog("Status Updated to STP: " + OutwardID);
                }
            }
            return "";
        }
        public string GenPacs004(string OutwardID, string CartID, string Priority, string UserName, string UserIP)
        {
            RTGSImporter.TeamGreenDB db = new RTGSImporter.TeamGreenDB();
            RTGSImporter.XmlString str = new RTGSImporter.XmlString();
            
            RTGSImporter.Pacs004 pacs = db.GetSingleCartOutward04(OutwardID, CartID);

            if (pacs.PacsID == "")
                return "GetSingleCartOutward04(" + OutwardID + "," + CartID + "): NOT FOUND";

            string xml = str.GetPacs4(pacs, Priority);
            ExtLog(xml);

            string filename = pacs.BizMsgIdr + ".xml";
            string path = ConfigurationManager.AppSettings["LocalPath"] + "\\Export\\MX\\" + filename;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.Save(path);

            string[] lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines);

            ExtLog(path + " :Created");

            if (File.Exists(path))
            {
                db.SendOutward04(OutwardID, UserName, UserIP);
                ExtLog("Status Updated to STP: " + OutwardID);
            }
            return "";
        }

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
            if (ExtnLog == "TRUE")
            {
                WriteLog(Msg);
            }
        }
    }

}