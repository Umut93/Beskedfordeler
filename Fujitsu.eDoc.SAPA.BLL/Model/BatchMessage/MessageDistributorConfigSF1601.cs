using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fujitsu.eDoc.SAPA.BLL.Model.BatchMessage
{
    public class MessageDistributorConfigSF1601 : IMessageDistributorConfigSF1601
    {
        public string Recno { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ToDate { get; set; }

        public bool IsExpired
        {
            get
            {
                if (!string.IsNullOrEmpty(ToDate) && DateTime.Now > DateTime.Parse(ToDate))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Guid UUID { get; set; }
        public int SortID { get; set; }
        public string AlternativeDesc { get; set; }

        public MessageDistributorConfigSF1601(string recno, string code, string description, string toDate, Guid uUID, int sortID, string alternativeDesc)
        {
            Recno = recno;
            Code = code;
            Description = description;
            ToDate = toDate;
            UUID = uUID;
            SortID = sortID;
            AlternativeDesc = alternativeDesc;
        }

        public MessageDistributorConfigSF1601()
        {

        }

        /// <summary>
        /// Getting rows from the code table: FU Beskedfordeler SF1601
        /// </summary>
        public List<MessageDistributorConfigSF1601> GetSF1601Entries()
        {
            List<MessageDistributorConfigSF1601> entries = new List<MessageDistributorConfigSF1601>();

            string query = $@"<operation> 
                    <QUERYDESC NAMESPACE='SIRIUS' ENTITY='code table: FU Beskedfordeler SF1601' SELECTTYPE='DATASET' DATASETFORMAT='XML' TAG='RECORDS' LANGUAGE='DAN'> 
                            <RESULTFIELDS>
                            <METAITEM TAG='Recno'>Recno</METAITEM>
                            <METAITEM TAG='Code'>Code</METAITEM>
                            <METAITEM TAG='SortID'>SortID</METAITEM>
                            <METAITEM TAG='ToDate'>ToDate</METAITEM>
                            <METAITEM TAG='UUID'>UUID</METAITEM>
                            <METAITEM TAG='Description'>Description</METAITEM>
                            <METAITEM TAG='AlternativeDesc'>AlternativeDesc</METAITEM>
                            </RESULTFIELDS>
                        </QUERYDESC>
                        </operation>";

            string result = Fujitsu.eDoc.Core.Common.ExecuteQuery(query);

            if (!string.IsNullOrEmpty(result))
            {
                var xDoc = XDocument.Parse(result);

                foreach (var item in xDoc.Root.Elements())
                {
                    entries.Add(new MessageDistributorConfigSF1601
                    {
                        Recno = item.Element("Recno").Value,
                        Code = item.Element("Code").Value,
                        Description = item.Element("Description").Value,
                        ToDate = item.Element("ToDate").Value,
                        UUID = Guid.Parse(item.Element("UUID").Value),
                        SortID = int.Parse(item.Element("SortID").Value),
                        AlternativeDesc = item.Element("AlternativeDesc").Value,
                    });
                }
            }
            return entries;
        }
    }
}
