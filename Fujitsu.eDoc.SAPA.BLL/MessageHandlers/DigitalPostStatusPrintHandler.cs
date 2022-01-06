using Fujitsu.eDoc.SAPA.BLL.Model;
using Fujitsu.eDoc.SAPA.BLL.Model.BatchMessage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Fujitsu.eDoc.SAPA.BLL.MessageHandlers
{
    [UUID("d2bed63c-4853-4008-b6e0-a74c15b15fbf")]
    public class DigitalPostStatusPrintHandler : IMessageHandler
    {
        public string MessageTypeName => "DigitalPost_StatusPrint";
        private const string LogName = "MsgDistributor";
        private readonly Guid ERRORSTATE = Guid.Parse("e225a75c-4b63-46c4-9423-77f5c8762445");
        private IMessageDistributorConfigSF1601 sF1601Config = new MessageDistributorConfigSF1601();
        private List<MessageDistributorConfigSF1601> codeTableEntries = new List<MessageDistributorConfigSF1601>();
        private Haendelsesbesked haendelsesbesked;
        private PKO_PostStatus PKO_PostStatus;


        public void Process(XDocument haendelsesbeskedXML)
        {
            codeTableEntries = sF1601Config.GetSF1601Entries();
            System.Diagnostics.Debugger.Launch();

            if (codeTableEntries.Any())
            {

                //Deserialization
                Deseriliaze(haendelsesbeskedXML);
                DeseriliazePKO_PostStatusXML(haendelsesbesked.Beskeddata.Base64.Value);

                InsertHaendelsesBesked();
                UpdateTable();

                Fujitsu.eDoc.Core.Common.SimpleEventLogging(typeof(DigitalPostStatusPrintHandler).FullName, LogName,
               $"{MessageTypeName}\nSuccesfully processed the message id: {haendelsesbesked.BeskedId.UUIDIdentifikator}", System.Diagnostics.EventLogEntryType.Information);
            }

        }



        /// <summary>
        /// Deseriliaze haendelsesbesked
        /// </summary>
        /// <param name="message"></param>
        private void Deseriliaze(XDocument message)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Haendelsesbesked));
            using (TextReader reader = new StringReader(message.ToString()))
            {
                haendelsesbesked = (Haendelsesbesked)serializer.Deserialize(reader);
            }
        }



        /// <summary>
        /// Deseriliaze PostStatusXML
        /// </summary>
        /// <param name="encodedBase64"></param>
        private void DeseriliazePKO_PostStatusXML(string encodedBase64)
        {
            byte[] data = Convert.FromBase64String(encodedBase64);
            string decodedString = Encoding.UTF8.GetString(data);

            XmlSerializer serializer = new XmlSerializer(typeof(PKO_PostStatus));
            using (TextReader reader = new StringReader(decodedString))
            {
                PKO_PostStatus = (PKO_PostStatus)serializer.Deserialize(reader);
            }
        }


        /// <summary>
        /// Get Recno by correlationID in FuDocDispatchDetails
        /// </summary>
        public string GetFuDocDispatchDetailRecno()
        {
            string recno = string.Empty;

            string xmlQuery = $@"<operation>
                            <QUERYDESC NAMESPACE='SIRIUS' ENTITY='FuDocDispatchDetails' DATASETFORMAT='XML' TAG='RECORDS'>
                                       <RESULTFIELDS>
                                        <METAITEM TAG='Recno'>Recno</METAITEM>
                                       </RESULTFIELDS>
                                        <CRITERIA>
                                        <METAITEM NAME='CorrelationId' OPERATOR='='>
                                          <VALUE>{PKO_PostStatus.CorrelationId}</VALUE>
                                        </METAITEM>
                                     </CRITERIA>
                         </QUERYDESC>
                         </operation>";

            string result = Fujitsu.eDoc.Core.Common.ExecuteQuery(xmlQuery);

            XDocument doc = XDocument.Parse(result);

            if (Int32.Parse(doc.Root.FirstAttribute.Value) != 0)
            {
                recno = doc.Root.Element("RECORD").Element("Recno").Value;
            }

            return recno;
        }


        /// <summary>
        /// Inserting the message in FU Dispatch receipts
        /// </summary>
        private void InsertHaendelsesBesked()
        {
            Dictionary<int, Guid> suppliers = MessageActor.MessageResponsibleActors;

            var shipmentIncidentTypeCode = default(ushort);
            DateTime shipmentIncidentDateTime = DateTime.Parse("1753-01-01T00:00:00Z");
            var shipmentIncidentAmount = default(decimal);

            if (PKO_PostStatus.ForsendelseHaendelseSamling != null && PKO_PostStatus.ForsendelseHaendelseSamling.Any())
            {
                shipmentIncidentTypeCode = PKO_PostStatus.ForsendelseHaendelseSamling.Last().ForsendelseHaendelseTypeKode;
                shipmentIncidentDateTime = PKO_PostStatus.ForsendelseHaendelseSamling.Last().ForsendelseHaendelseDatoTid;
                shipmentIncidentAmount = PKO_PostStatus.ForsendelseHaendelseSamling.Last().ForsendelseHaendelseBeloeb;
            }


            string xmlQuery = $@"<operation>
                            <QUERYDESC NAMESPACE='SIRIUS' ENTITY='FuDocDispatchReceipts' DATASETFORMAT='XML' TAG='RECORDS' MAXROWS='1'>
                                       <RESULTFIELDS>
                                        <METAITEM TAG='Recno'>Recno</METAITEM>
                                        <METAITEM TAG='TransactionId'>TransactionId</METAITEM>
                                       </RESULTFIELDS>
                                       <ORDERFIELDS>
                                        <METAITEM DESC='-1'>Recno</METAITEM>
                                       </ORDERFIELDS>
                                        <CRITERIA>
                                        <METAITEM NAME='CorrelationId' OPERATOR='='>
                                          <VALUE>{PKO_PostStatus.CorrelationId}</VALUE>
                                        </METAITEM>
                                     </CRITERIA>
                         </QUERYDESC>
                         </operation>";

            string result = Fujitsu.eDoc.Core.Common.ExecuteQuery(xmlQuery);
            XDocument doc = XDocument.Parse(result);

            string transkationID = string.Empty;

            if (Int32.Parse(doc.Root.FirstAttribute.Value) != 0)
            {
                transkationID = doc.Root.Element("RECORD").Element("TransactionId").Value;
            }

            string insertQuery = $@"<operation>
                        <INSERTSTATEMENT NAMESPACE='SIRIUS' ENTITY='FuDocDispatchReceipts'>
                             <METAITEM NAME='TransactionId'>
                                <VALUE>{transkationID}</VALUE>
                            </METAITEM>
                            <METAITEM NAME='MessageUUID'>
                                <VALUE>{PKO_PostStatus.MessageUUID}</VALUE>
                            </METAITEM>
                            <METAITEM NAME='MessageIdeDoc'>
                                <VALUE>{PKO_PostStatus.MessageId}</VALUE>
                            </METAITEM>
                            <METAITEM NAME='ShipmentId'>
                                <VALUE>{PKO_PostStatus.AfsendelseIdentifikator}</VALUE>
                            </METAITEM>
                            <METAITEM NAME='TransmissionId'>
                                <VALUE>{PKO_PostStatus.TransmissionId}</VALUE>
                            </METAITEM>
                            <METAITEM NAME='CorrelationId'>
                                <VALUE>{PKO_PostStatus.CorrelationId}</VALUE>
                            </METAITEM>
                            <METAITEM NAME='MessageIdReceipt'>
                                <VALUE>{haendelsesbesked.BeskedId.UUIDIdentifikator}</VALUE>
                            </METAITEM>
                            <METAITEM NAME='ReceiptType'>
                                <VALUE>Forretningskvittering</VALUE>
                            </METAITEM>
                            <METAITEM NAME='Actor'>
                                <VALUE>{(MessageResponsibleActor)suppliers.FirstOrDefault(x => x.Value == Guid.Parse(haendelsesbesked.Beskedkuvert.Filtreringsdata.BeskedAnsvarligAktoer.UUIDIdentifikator)).Key}</VALUE>
                            </METAITEM>
                            <METAITEM NAME='StateTime'>
                                <VALUE>{PKO_PostStatus.TransaktionsDatoTid:yyyy-MM-dd hh:mm:ss.fff}</VALUE>
                            </METAITEM>
                            <METAITEM NAME='StateText'>
                                <VALUE>{PKO_PostStatus.TransaktionsStatusKode}</VALUE>
                            </METAITEM>
                            <METAITEM NAME='ErrorCode'>
                                <VALUE>{PKO_PostStatus.FejlDetaljer.FejlKode}</VALUE>
                            </METAITEM>
                            <METAITEM NAME='ErrorText'>
                                <VALUE>{PKO_PostStatus.FejlDetaljer.FejlTekst}</VALUE>
                            </METAITEM>
                            <METAITEM NAME='ShipmentIncidentTypeCode'>
                                <VALUE>{shipmentIncidentTypeCode}</VALUE>
                            </METAITEM>
                            <METAITEM NAME='ShipmentIncidentDateTime'>
                                <VALUE>{shipmentIncidentDateTime:yyyy-MM-dd hh:mm:ss.fff}</VALUE>
                            </METAITEM>
                            <METAITEM NAME='ShipmentIncidentAmount'>
                                <VALUE>{shipmentIncidentAmount}</VALUE>
                            </METAITEM>
                        </INSERTSTATEMENT>
                    </operation>";

            Fujitsu.eDoc.Core.Common.ExecuteSingleAction(insertQuery);

            Fujitsu.eDoc.Core.Common.SimpleEventLogging(typeof(DigitalPostStatusPrintHandler).FullName, LogName,
                 $"{MessageTypeName}\nMessage ID: {haendelsesbesked.BeskedId.UUIDIdentifikator} sucessfully inserted in the table FuDocDispatchReceipts", System.Diagnostics.EventLogEntryType.Information);
        }

        /// <summary>
        /// Uppdate FuDocDispatchDetails
        /// </summary>
        public void UpdateTable()
        {
            var lastObjjektRegistrering = haendelsesbesked.Beskedkuvert.Filtreringsdata.ObjektRegistrering.Last();
            Dictionary<int, Guid> suppliers = MessageActor.MessageResponsibleActors;
            MessageResponsibleActor supplier = (MessageResponsibleActor)suppliers.FirstOrDefault(x => x.Value == Guid.Parse(lastObjjektRegistrering.ObjektHandling.UUIDIdentifikator)).Key;

            MessageDistributorConfigSF1601 state = codeTableEntries.Find(config => config.UUID == Guid.Parse(lastObjjektRegistrering.ObjektHandling.UUIDIdentifikator));

            var recno = GetFuDocDispatchDetailRecno();

            if (!string.IsNullOrEmpty(recno))
            {
                string updateQuery = $@"<operation>
                          <UPDATESTATEMENT NAMESPACE='SIRIUS' ENTITY='FuDocDispatchDetails' PRIMARYKEYVALUE='{recno}'>
                            <METAITEM NAME='State'>
                              <VALUE>{state.AlternativeDesc}</VALUE>
                            </METAITEM>
                            <METAITEM NAME='StateDate'>
                              <VALUE>{lastObjjektRegistrering.Registreringstidspunkt:yyyy-MM-dd hh:mm:ss.fff}</VALUE>
                            </METAITEM>
                          </UPDATESTATEMENT>
                        </operation>";

                Fujitsu.eDoc.Core.Common.ExecuteSingleAction(updateQuery);

            }

            else
            {
                Fujitsu.eDoc.Core.Common.SimpleEventLogging(typeof(DigitalPostStatusPrintHandler).FullName, LogName,
                $"{MessageTypeName}\nCould not update table \"FuDocDispatchDetails\". Recno was not found on message: {haendelsesbesked.BeskedId.UUIDIdentifikator} with correlationID {PKO_PostStatus.CorrelationId}", System.Diagnostics.EventLogEntryType.Information);
            }

        }

    }
}
