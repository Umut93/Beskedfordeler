using Fujitsu.eDoc.Core;
using Fujitsu.eDoc.SAPA.BLL.MessageHandlers;
using Fujitsu.eDoc.SAPA.BLL.Model.BatchMessage;
using Fujitsu.eDoc.SAPA.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Fujitsu.eDoc.SAPA.BLL
{


    [UUID("248ce14c-a863-4fb5-9e6f-7df9ea850809")]
    public class CPREventhandler : IMessageHandler
    {
        public string MessageTypeName => "CPR Hændelse";
        private const string LogName = "MsgDistributor";
        private const string XML_LOCATION = "Fujitsu.eDoc.SAPA.BLL.XML";
        private const string EMAIL_RECNO = "300258";
        private static string msgID;
        private static string personhaendelseCode;


        public void Process(XDocument message)
        {
            //The message ID
            msgID = (from n in message.Descendants()
                     where n.Name.LocalName == "BeskedId"
                     select n).First().Value;

            //Decide personhaendelseCode
            personhaendelseCode = ExtractPersonhaendelseCode(message);
            string personhaendelseMsg = string.Empty;

            if (HasCPRMessage(personhaendelseCode, ref personhaendelseMsg))
            {
                //Message concerns a specific person
                IEnumerable<XElement> URNIdentifikators = message.Descendants().Where(e => e.Name.LocalName == "ObjektRegistrering");
                string citizen = URNIdentifikators.Elements().Where(e => e.Name.LocalName == "ObjektId").FirstOrDefault().Value;
                string CPR_nummer = ExtractSocialSecurityNumber(citizen);

                //XML execution query
                string xmlQueryString = Core.Common.GetResourceXml("GetContactReferenceNumber.xml", XML_LOCATION, Assembly.GetExecutingAssembly());

                XDocument xmlQuery = XDocument.Parse(xmlQueryString);

                //Find cases that concerns on this citizen
                xmlQuery.XPathSelectElement("//QUERYDESC/RELATIONS/RELATION/CRITERIA/METAITEM").Value = CPR_nummer;
                string res = Core.Common.ExecuteQuery(xmlQuery.ToString());

                BMCaseWorkerList bMworkersList = null;
                bMworkersList = XmlUtil.DeserializeBMCaseWorker(res);


                List<IGrouping<string, BMCaseWorkers>> bMCaseWorkers = bMworkersList.BMCaseWorkers.GroupBy(Ourref => Ourref.CaseOurRef).ToList();

                foreach (var cw in bMCaseWorkers)
                {
                    List<BMCaseWorkers> listCase = bMworkersList.BMCaseWorkers.Where(x => x.CaseOurRef == cw.Key).ToList();
                    NotifyCaseWorker(listCase, personhaendelseMsg);
                    LogCases(listCase);
                }

                Fujitsu.eDoc.Core.Common.SimpleEventLogging(typeof(CPREventhandler).FullName, LogName,
                $"{MessageTypeName}\nSuccesfully processed the message id: {msgID}", System.Diagnostics.EventLogEntryType.Information);
            }

        }

        /// <summary>
        /// Extracting the personhandelseCode from the XML
        /// </summary>
        /// <param name="CPR_haendelseXML"></param>
        /// <returns></returns>
        private static string ExtractPersonhaendelseCode(XDocument CPR_haendelseXML)
        {
            personhaendelseCode = string.Empty;
            try
            {
                string pat = @"(urn:oio:cpr:personhaendelse:)(\d+)";
                Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                Match m = r.Match(CPR_haendelseXML.ToString());

                if (m.Success)
                {
                    personhaendelseCode = m.Groups[2].Value;
                }

            }

            catch (Exception ex)
            {
                Fujitsu.eDoc.Core.Common.SimpleEventLogging(typeof(CPREventhandler).FullName, LogName, $" Personhaendelse_kode for the message id: {msgID} could not be found.\n {ex}", System.Diagnostics.EventLogEntryType.Error);
            }

            return personhaendelseCode;
        }



        private static string[] GetFilesOnDirectory(string folderPath)
        {
            string[] files = null;
            try
            {

                if (Directory.Exists(folderPath))
                {
                    files = Directory.GetFiles(folderPath, "*.xml");
                }
            }
            catch (Exception ex)
            {
                Fujitsu.eDoc.Core.Common.SimpleEventLogging(typeof(CPREventhandler).FullName, LogName, $"Error on getting files in the directory {folderPath} \n {ex}", System.Diagnostics.EventLogEntryType.Error);
            }

            return files;
        }


        private static void NotifyCaseWorker(List<BMCaseWorkers> listCase, string CRPMessage)
        {
            try
            {
                bool isEmailEmpty = false;
                string webUrl = Url.GetCommonSiteNameUrl();

                string eMail = string.Empty;

                string htmlrow = string.Empty;


                foreach (var c in listCase)
                {
                    if (isEmailEmpty = string.IsNullOrEmpty(c.ToOurRefEmail))
                    {
                        continue;
                    }
                    eMail = c.ToOurRefEmail;
                    htmlrow += $@"<tr><td>{c.CaseName}</td><td>{c.CaseDescription}</td></tr>";

                }

                if (!isEmailEmpty)
                {

                    string parameters = string.Format("To={0};htmlrow={1};CRPMessage={2}", eMail, htmlrow, CRPMessage);
                    Fujitsu.eDoc.Notification.EmailNotificationManager.InvokeSendEmail(EMAIL_RECNO.ToString(), "DAN", parameters, "", listCase.First().CaseOurRef);
                }
            }

            catch (Exception ex)
            {
                Fujitsu.eDoc.Core.Common.SimpleEventLogging(typeof(CPREventhandler).FullName, LogName, $"Sending emails to caseworkers failed for the message id: {msgID}. {ex}", System.Diagnostics.EventLogEntryType.Error);
            }

        }

        /// <summary>
        /// Extracting the CPR 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string ExtractSocialSecurityNumber(string input)
        {
            string cpr = string.Empty;
            try
            {
                string pat = @"\d+";
                Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                Match m = r.Match(input);

                if (m.Success)
                {
                    cpr = m.Value;
                }
            }

            catch (Exception ex)
            {
                Fujitsu.eDoc.Core.Common.SimpleEventLogging(typeof(CPREventhandler).FullName, LogName, $"Error on extracting the socialSecurityNumber of the message id: {msgID}. {ex}", System.Diagnostics.EventLogEntryType.Error);
            }

            return cpr;

        }



        /// <summary>
        /// Checking the personhaendelse_kode resides in the DB
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private static bool HasCPRMessage(string code, ref string message)
        {
            bool hasCPRMessage = false;
            try
            {
                string xmlQuery = Core.Common.GetResourceXml("GetCPRMessage.xml", XML_LOCATION, Assembly.GetExecutingAssembly());
                xmlQuery = xmlQuery.Replace("#Code#", code);
                var res = Fujitsu.eDoc.Core.Common.ExecuteQuery(xmlQuery);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(res);
                XmlNode nMessage = doc.SelectSingleNode("RECORDS/RECORD/Message");

                if (nMessage != null)
                {
                    message = nMessage.InnerText;
                    hasCPRMessage = true;
                }
            }
            catch (Exception ex)
            {
                Fujitsu.eDoc.Core.Common.SimpleEventLogging(typeof(CPREventhandler).FullName, LogName, $"Error on getting the CPR message for the message id: {msgID} - {System.Environment.NewLine} {ex}", System.Diagnostics.EventLogEntryType.Error);
            }
            return hasCPRMessage;
        }


        /// <summary>
        /// Logging on each case.
        /// </summary>
        /// <param name="listCase"></param>
        private static void LogCases(List<BMCaseWorkers> listCase)
        {
            ILogService logService = new LogService();

            try
            {
                string xmlQuery = Core.Common.GetResourceXml("GetCPRMessage.xml", XML_LOCATION, Assembly.GetExecutingAssembly());
                xmlQuery = xmlQuery.Replace("#Code#", personhaendelseCode);
                string res = Fujitsu.eDoc.Core.Common.ExecuteQuery(xmlQuery);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(res);
                XmlNode nDesc = doc.SelectSingleNode("RECORDS/RECORD/Description");

                foreach (BMCaseWorkers c in listCase)
                {
                    logService.SaveLog(EntityToLog.Case, Int32.Parse(c.CaseRecno), $"Der er sket en hændelse på borgeren {c.ToCaseContactName}. Hændelses navn: {nDesc.InnerText}.");
                }

            }
            catch (Exception ex)
            {
                Fujitsu.eDoc.Core.Common.SimpleEventLogging(typeof(CPREventhandler).FullName, LogName, $"Error on getting the CPR message for the message id: {msgID} - {System.Environment.NewLine} {ex}", System.Diagnostics.EventLogEntryType.Error);
            }

        }


    }
}
