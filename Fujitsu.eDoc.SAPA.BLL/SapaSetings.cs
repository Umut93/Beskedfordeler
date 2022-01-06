using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Fujitsu.eDoc.SAPA.BLL
{
    public class SapaSetings
    {
        public static Settings GetSettings()
        {
            Settings settings = new Settings();
            Dictionary<string, string> settingsData = GetSAPASettings();

            if (!settingsData.TryGetValue("CaseServiceEndPoint", out settings.CaseServiceEndPoint))
            {
                EventLog.LogToEventLog($"CaseServiceEndPoint MISSING IT'S VALUE IN THE CODE TABLE: Fu SAPA Configuration", System.Diagnostics.EventLogEntryType.Error);                
            }
            if (!settingsData.TryGetValue("DistributionServiceEndPoint", out settings.DistributionServiceEndPoint))
            {
                EventLog.LogToEventLog($"DistributionServiceEndPoint MISSING IT'S VALUE IN THE CODE TABLE: Fu SAPA Configuration", System.Diagnostics.EventLogEntryType.Error);
            }
            if (!settingsData.TryGetValue("DB", out settings.DBConnection))
            {
                EventLog.LogToEventLog($"DB MISSING IT'S VALUE IN THE CODE TABLE: Fu SAPA Configuration", System.Diagnostics.EventLogEntryType.Error);                
            }
            if (!settingsData.TryGetValue("CVR", out settings.MunicipalityCVR))
            {
                EventLog.LogToEventLog($"CVR MISSING IT'S VALUE IN THE CODE TABLE: Fu SAPA Configuration", System.Diagnostics.EventLogEntryType.Error);                
            }
            if (!settingsData.TryGetValue("CertificateSerialNumber", out settings.CertificateSerialNumber))
            {
                EventLog.LogToEventLog($"CertificateSerialNumber MISSING IT'S VALUE IN THE CODE TABLE: Fu SAPA Configuration", System.Diagnostics.EventLogEntryType.Error);                
            }
            if (!settingsData.TryGetValue("ReceiverPath", out settings.ReceiverPath))
            {
                EventLog.LogToEventLog($"ReceiverPath MISSING IT'S VALUE IN THE CODE TABLE: Fu SAPA Configuration", System.Diagnostics.EventLogEntryType.Error);                
            }
            if (!settingsData.TryGetValue("ReceiverPath", out settings.ReceiverPath))
            {
                EventLog.LogToEventLog($"ReceiverPath MISSING IT'S VALUE IN THE CODE TABLE: Fu SAPA Configuration", System.Diagnostics.EventLogEntryType.Error);
            }

            return settings;
        }


        const string XML_LOCATION = "Fujitsu.eDoc.SAPA.BLL.XML";
        private static Dictionary<string, string> GetSAPASettings()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            try
            {
                string xmlQuery = Core.Common.GetResourceXml("GetCodeTableValues.xml", XML_LOCATION, Assembly.GetExecutingAssembly());

                var res = Fujitsu.eDoc.Core.Common.ExecuteQuery(xmlQuery);

                var xDoc = XDocument.Parse(res);

                if (xDoc != null)
                {
                    var RECORD = xDoc.Descendants("RECORD").ToList();
                    foreach (var r in RECORD)
                    {
                        dic.Add(r.Element("Key").Value, r.Element("Value").Value);
                    };

                    return dic;
                }
                return dic;
            }
            catch (Exception ex)
            {
                EventLog.LogToEventLog($"72ab5a9a-76e6-468a-8083-857902e1919f - {System.Environment.NewLine} {ex.ToString()}", System.Diagnostics.EventLogEntryType.Error);
            }
            return dic;
        }
    }

    public struct Settings
    {
        public string CaseServiceEndPoint;
        public string DistributionServiceEndPoint;
        public string DBConnection;
        public string MunicipalityCVR;
        public string CertificateSerialNumber;
        public string ReceiverPath;
    }
}
