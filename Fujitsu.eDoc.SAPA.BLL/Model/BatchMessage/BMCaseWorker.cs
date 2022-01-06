using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Fujitsu.eDoc.SAPA.BLL.Model.BatchMessage
{

    [XmlRoot(ElementName = "RECORDS")]
    public class BMCaseWorkerList
    {
        [XmlElement(ElementName = "RECORD")]
        public List<BMCaseWorkers> BMCaseWorkers { get; set; }
    }
    public class BMCaseWorkers
    {
         /// <summary>
        /// CASE 
        /// </summary>
        [XmlElement(ElementName = "Recno")]
        public string CaseRecno { get; set; }

        [XmlElement(ElementName = "OurRef")]
        public string CaseOurRef { get; set; }

        [XmlElement(ElementName = "Description")]
        public string CaseDescription { get; set; }

        [XmlElement(ElementName = "CaseType")]
        public string CaseCaseType { get; set; }

        [XmlElement(ElementName = "CaseName")]
        public string CaseName { get; set; }

        /// <summary>
        /// CASE 
        /// </summary>     
        [XmlElement(ElementName = "ToCaseContactName")]
        public string ToCaseContactName { get; set; }

        [XmlElement(ElementName = "ToCaseContactReferencenumber")]
        public string ToCaseContactReferencenumber { get; set; }

        [XmlElement(ElementName = "OurRef.email")]
        public string ToOurRefEmail { get; set; }

    }
}

