using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;

namespace RTGSImporter
{
    class Utilities
    {
        public string MsgType(string MsgDefIdr)
        {
            MsgDefIdr = MsgDefIdr.ToLower();

            if (MsgDefIdr.Contains("pacs.002"))
                return "pacs.002";
            if (MsgDefIdr.Contains("pacs.004"))
                return "pacs.004";
            if (MsgDefIdr.Contains("pacs.008"))
                return "pacs.008";
            if (MsgDefIdr.Contains("pacs.009"))
                return "pacs.009";

            if (MsgDefIdr.Contains("camt.003"))
                return "camt.003";
            if (MsgDefIdr.Contains("camt.004"))
                return "camt.004";
            if (MsgDefIdr.Contains("camt.005"))
                return "camt.005";
            if (MsgDefIdr.Contains("camt.006"))
                return "camt.006";
            if (MsgDefIdr.Contains("camt.007"))
                return "camt.007";
            if (MsgDefIdr.Contains("camt.019"))
                return "camt.019";
            if (MsgDefIdr.Contains("camt.025"))
                return "camt.025";
            if (MsgDefIdr.Contains("camt.052"))
                return "camt.052"; 
            if (MsgDefIdr.Contains("camt.053"))
                return "camt.053";
            if (MsgDefIdr.Contains("camt.054"))
                return "camt.054";
            if (MsgDefIdr.Contains("camt.998"))
                return "camt.998";

            return MsgDefIdr.Replace("urn:iso:std:iso:20022:tech:xsd:","");
        }

        public void LoadXML(string xmlstring, string msgtype, string FileName)
        {
            TeamGreenImporter tg = new TeamGreenImporter();
            TeamBlueImporter tb = new TeamBlueImporter();
            TeamRedImporter tr = new TeamRedImporter();
            OtherImporter to = new OtherImporter();

            //string msgtype = MsgType(MsgDefIdr);

            switch (msgtype)
            {
                case "pacs.002":
                    tr.LoadPacs002(FileName, xmlstring);
                    break;
                case "pacs.004":
                    tg.LoadPacs004(FileName, xmlstring);
                    break;
                case "pacs.008":
                    tr.LoadPacs008(FileName, xmlstring);
                    break;
                case "pacs.009":
                    tb.LoadPacs009(FileName, xmlstring);
                    break;
                case "camt.003":
                    break;
                case "camt.004":
                    tr.Loadcamt04(FileName, xmlstring);
                    break;
                case "camt.006":
                    tb.LoadCamt06(FileName, xmlstring);
                    break;
                case "camt.007":
                    break;
                case "camt.019":
                    tb.LoadCamt019(FileName, xmlstring);
                    break;
                case "camt.025":
                    tb.LoadCamt25(FileName, xmlstring);
                    break;
                case "camt.052":
                    tg.LoadCamt52(FileName, xmlstring);
                    break;
                case "camt.053":
                    tg.LoadCamt53(FileName, xmlstring);
                    break;
                case "camt.054":
                    tg.LoadCamt54(FileName, xmlstring);
                    break;
                case "camt.998":
                    tb.LoadCamt998(FileName, xmlstring);
                    break;
                default:
                    to.LoadOther(FileName, msgtype, xmlstring);
                    break;
            }
        }

        public static string intPattern = "(?<Number>[0-9])";
        public static string GetInteger(string SourceString, bool PosOnly = false)
        {
            string newNumber = string.Empty;
            if (!PosOnly)
                if (SourceString.StartsWith("-"))
                    newNumber += "-";

            Regex r = new Regex(intPattern);
            Match m = r.Match(SourceString);
            while (m.Success)
            {
                newNumber += m.Groups["Number"].Value;
                m = m.NextMatch();
            }
            return newNumber;
        }
        public void BackUpLocal(string file)
        {
            string destdir = file.Substring(0, file.LastIndexOf("\\") + 1) + "bak\\";
            if (!Directory.Exists(destdir))
            {
                Directory.CreateDirectory(destdir);
            }

            string filename = file.Substring(file.LastIndexOf("\\") + 1);
            string destfile = destdir + filename;
            try
            {
                File.Copy(file, destfile, true);
            }
            catch { }
            try
            {
                File.Delete(file);
            }
            catch { }
        }

        public void RemoveSpecialCharacters(string fullpath)
        {
            StreamReader sr = new StreamReader(fullpath);
            string filetext = sr.ReadToEnd();

            filetext = Regex.Replace(filetext, @"[«,»,�]", "\"");

            sr.Close();
            sr.Dispose();

            System.IO.File.Delete(fullpath);

            StreamWriter sw = new StreamWriter(fullpath);
            sw.Write(filetext);
            sw.Close();
            sw.Dispose();
        }
    }
}
