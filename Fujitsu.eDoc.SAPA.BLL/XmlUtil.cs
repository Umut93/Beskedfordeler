using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Fujitsu.eDoc.SAPA.BLL
{
    public class XmlUtil
    {
        public static XmlDocument SerializeToXmlDocument(object input)
        {
            XmlSerializer ser = new XmlSerializer(input.GetType());

            XmlDocument xd = null;

            using (MemoryStream memStm = new MemoryStream())
            {
                ser.Serialize(memStm, input);

                memStm.Position = 0;

                XmlReaderSettings settings = new XmlReaderSettings
                {
                    IgnoreWhitespace = true
                };

                using (var xtr = XmlReader.Create(memStm, settings))
                {
                    xd = new XmlDocument();
                    xd.Load(xtr);
                }
            }

            return xd;
        }

        public static void ValidateXmlDocument(string documentToValidate, string schemaPath)
        {
            XmlSchema schema;
            using (var schemaReader = XmlReader.Create(schemaPath))
            {
                schema = XmlSchema.Read(schemaReader, ValidationEventHandler);
            }

            var schemas = new XmlSchemaSet();
            schemas.Add(schema);

            var settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema,
                Schemas = schemas,
                ValidationFlags =
                XmlSchemaValidationFlags.ProcessIdentityConstraints |
                XmlSchemaValidationFlags.ReportValidationWarnings
            };
            settings.ValidationEventHandler += ValidationEventHandler;

            using (var validationReader = XmlReader.Create(documentToValidate, settings))
            {
                while (validationReader.Read())
                {
                }
            }
        }

        private static void ValidationEventHandler(object sender, ValidationEventArgs args)
        {

            using (StreamWriter writer = new StreamWriter(@"C:\sapaTemp\ValidatorLog.txt", true))
            {
                if (args.Severity == XmlSeverityType.Error)
                {
                    writer.WriteLine(args.Exception.ToString());

                }
                if (args.Severity == XmlSeverityType.Warning)
                {
                    writer.WriteLine(args.Exception.ToString());
                }
            }
        }

        public static void RemoveAllNamespaces(XElement element)
        {
            element.Name = element.Name.LocalName;

            foreach (var node in element.DescendantNodes())
            {
                var xElement = node as XElement;
                if (xElement != null)
                {
                    RemoveAllNamespaces(xElement);
                }
            }
        }

        public static Model.CaseList DeserializeCaseList(string selXml)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Model.CaseList));
                return (Model.CaseList)ser.Deserialize(new StringReader(selXml));
            }
            catch (Exception ex)
            {
                EventLog.LogToEventLog($"Deserialize XML ERROR: {System.Environment.NewLine} {ex} {System.Environment.NewLine} Xml that failed: {System.Environment.NewLine} {selXml}", System.Diagnostics.EventLogEntryType.Error);
                return null;
            }
        }

        public static Model.BatchMessage.BMCaseWorkerList DeserializeBMCaseWorker(string selXml)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Model.BatchMessage.BMCaseWorkerList));
                return (Model.BatchMessage.BMCaseWorkerList)ser.Deserialize(new StringReader(selXml));
            }
            catch (Exception ex)
            {
                EventLog.LogToEventLog($"0fb1ce84-0840-456a-b88d-03aca8fa7016 : {System.Environment.NewLine} {ex.ToString()}", System.Diagnostics.EventLogEntryType.Error);
                return null;
            }
        }

        public static Model.BatchOrgUserJob.OrgUser DeserializeOrgUser(string selXml)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Model.BatchOrgUserJob.OrgUser));
                return (Model.BatchOrgUserJob.OrgUser)ser.Deserialize(new StringReader(selXml));
            }
            catch (Exception ex)
            {
                EventLog.LogToEventLog($"36ee9830-2d51-4121-a330-8444629db64e: {System.Environment.NewLine} {ex.ToString()}", System.Diagnostics.EventLogEntryType.Error);
                return null;
            }
        }
        public static string Beautify(XmlDocument doc)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace
            };
            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {
                doc.Save(writer);
            }
            return sb.ToString();
        }

    }
}
