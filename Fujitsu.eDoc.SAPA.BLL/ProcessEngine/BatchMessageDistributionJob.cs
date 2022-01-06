using Fujitsu.eDoc.SAPA.BLL.MessageHandlers;
using Fujitsu.eDoc.SAPA.BLL.Model.BatchMessage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using System.Xml.Linq;


namespace Fujitsu.eDoc.SAPA.BLL.ProcessEngine
{
    public static class BatchMessageDistributionJob
    {
        private const string LogName = "MsgDistributor";
        private const string XML_LOCATION = "Fujitsu.eDoc.SAPA.BLL.XML";
        private static string msgtypeID;
        private static IMessageHandler handler;
        private static string msgID;
        public static Dictionary<string, Type> _registry;

        public static void BatchMessage()
        {

            Dictionary<string, string> codeTableConfigRecords = GetSetting();
            string value = string.Empty;

            if (codeTableConfigRecords.Count == 1)
                value = codeTableConfigRecords.First().Value;

            if (!string.IsNullOrEmpty(value))
            {
                InitializeHandlers();

                string[] files = GetFilesOnDirectory(value);

                for (int i = 0; i < files.Length; i++)
                {
                    try
                    {
                        XDocument msgXMl = XDocument.Load(files[i]);
                        msgID = GetMessageID(msgXMl);
                        msgtypeID = GetMsgTypeID(msgXMl);

                        handler = Resolve(msgtypeID);


                        if (handler != null)
                        {
                            handler.Process(msgXMl);
                            File.Delete(files[i]);
                        }
                    }

                    catch (Exception ex)
                    {
                        Fujitsu.eDoc.Core.Common.SimpleEventLogging(typeof(BatchMessageDistributionJob).FullName, LogName, $"{handler.MessageTypeName}\nProcessing of the message id {msgID} failed.\n\n{ex}", System.Diagnostics.EventLogEntryType.Error);
                        
                        try
                        {
                            MoveFile(value, files[i]);
                        }
                        catch (Exception e)
                        {
                            Fujitsu.eDoc.Core.Common.SimpleEventLogging(typeof(BatchMessageDistributionJob).FullName, LogName, $"{handler.MessageTypeName}\nUnable to move the file {files[i]} to the folder ErrorPostRequests.\n\n{e}", System.Diagnostics.EventLogEntryType.Error);
                        }
                    }
                }
            }
            else
            {
                Fujitsu.eDoc.Core.Common.SimpleEventLogging(typeof(BatchMessageDistributionJob).FullName, LogName, $"The directory for the key MessageDistribution in SAPA configuration is not set.", System.Diagnostics.EventLogEntryType.Information);
            }
        }

        private static void MoveFile(string value, string file)
        {
            DirectoryInfo errorDirectory = Directory.CreateDirectory(ReplaceDirectoryName(value));
            File.Move(file, errorDirectory.FullName + "//" + Path.GetFileName(file));
        }

        /// <summary>
        /// Getting the message ID
        /// </summary>
        /// <param name="msgXMl"></param>
        /// <returns></returns>
        private static string GetMessageID(XDocument msgXMl)
        {
            return msgID = (from n in msgXMl.Descendants()
                            where n.Name.LocalName == "BeskedId"
                            select n).First().Value;
        }

        /// <summary>
        /// Getting the message type ID from the message
        /// </summary>
        /// <param name="msgXMl"></param>
        /// <returns></returns>
        private static string GetMsgTypeID(XDocument msgXMl)
        {
            return msgtypeID = (from n in msgXMl.Descendants()
                                where n.Name.LocalName == "Beskedtype"
                                select n).First().Value;
        }


        /// <summary>
        /// Find all handlers that implements the inteface IMessageHandler
        /// </summary>
        public static void InitializeHandlers()
        {
            _registry = new Dictionary<string, Type>();
            var types = typeof(IMessageHandler).Assembly.GetTypes()
               .Where(t => typeof(IMessageHandler).IsAssignableFrom(t) && t != typeof(IMessageHandler));

            foreach (var type in types)
            {
                var uuidAttribute = type.GetCustomAttributes(typeof(UUIDAttribute), true).First();
                var uuid = ((UUIDAttribute)uuidAttribute).UUID;
                _registry.Add(uuid, type);
            }
        }

        public static IMessageHandler Resolve(string uuid)
        {
            if (_registry.TryGetValue(uuid, out var type))
            {
                return (IMessageHandler)Activator.CreateInstance(type);
            }

            else
            {
                Fujitsu.eDoc.Core.Common.SimpleEventLogging(typeof(BatchMessageDistributionJob).FullName, LogName, $"No handler could not be initialized for the UUID {uuid}. No class found.", System.Diagnostics.EventLogEntryType.Error);
            }

            return null;
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
                Fujitsu.eDoc.Core.Common.SimpleEventLogging(typeof(BatchMessageDistributionJob).FullName, LogName, $"Error on getting files in the directory {folderPath} \n {ex}", System.Diagnostics.EventLogEntryType.Error);
            }

            return files;
        }

        /// <summary>
        /// Creates a directory named ErrorPostRequests next to the defined directory PostRequests
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string ReplaceDirectoryName(string path)
        {
            if (path.Contains("PostRequests"))
            {
                path = path.Replace("PostRequests", "ErrorPostRequests");
            }

            return path;
        }

        /// <summary>
        /// Getting the configuration settings for SAPA.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetSetting()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            try
            {
                string xmlQuery = Core.Common.GetResourceXml("GetCodeTableValues.xml", XML_LOCATION, Assembly.GetExecutingAssembly());

                var res = Fujitsu.eDoc.Core.Common.ExecuteQuery(xmlQuery);

                XDocument xDoc = XDocument.Parse(res);

                if (xDoc != null)
                {
                    var RECORD = xDoc.Descendants("RECORD").ToList();

                    foreach (var r in RECORD)
                    {
                        if (r.Element("Key").Value == "MessageDistribution")
                            dic.Add(r.Element("Key").Value, r.Element("Value").Value);
                    };
                }
            }

            catch (Exception ex)
            {
                Fujitsu.eDoc.Core.Common.SimpleEventLogging(typeof(BatchMessageDistributionJob).FullName, LogName, $"Getting SAPA configurations failed - {System.Environment.NewLine} {ex}", System.Diagnostics.EventLogEntryType.Error);
            }

            return dic;
        }
    }
}
