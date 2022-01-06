using System;
using System.Collections.Generic;


namespace Fujitsu.eDoc.SAPA.BLL.Model
{
    //   public class DigitalPostMessage
    //   {
    //       public string MessageID { get; internal set; }
    //       public List<ObjektRegistration> ObjectRegistrations { get; set; }
    //       public PostStatus PostStatus { get; set; }
    //       public string MessageResponsibleActor { get;  set; }
    //       public readonly string ACKNOWLEDGEMSG = "Forretningskvittering";


    //       public DigitalPostMessage()
    //       {
    //           ObjectRegistrations = new List<ObjektRegistration>();
    //       }

    //   }

    //   public class ObjektRegistration
    //   {
    //       public DateTime RegisteredTime { get; set; }
    //       public Guid State { get; set; }
    //       public string StateName { get; set; }

    //       public ObjektRegistration()
    //       {

    //       }
    //}


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oio:besked:kuvert:1.0", IsNullable = false)]
    public partial class Haendelsesbesked
    {

        private HaendelsesbeskedBeskedId beskedIdField;

        private decimal beskedVersionField;

        private HaendelsesbeskedBeskedkuvert beskedkuvertField;

        private HaendelsesbeskedBeskeddata beskeddataField;

        /// <remarks/>
        public HaendelsesbeskedBeskedId BeskedId
        {
            get
            {
                return this.beskedIdField;
            }
            set
            {
                this.beskedIdField = value;
            }
        }

        /// <remarks/>
        public decimal BeskedVersion
        {
            get
            {
                return this.beskedVersionField;
            }
            set
            {
                this.beskedVersionField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvert Beskedkuvert
        {
            get
            {
                return this.beskedkuvertField;
            }
            set
            {
                this.beskedkuvertField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskeddata Beskeddata
        {
            get
            {
                return this.beskeddataField;
            }
            set
            {
                this.beskeddataField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedId
    {

        private string uUIDIdentifikatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public string UUIDIdentifikator
        {
            get
            {
                return this.uUIDIdentifikatorField;
            }
            set
            {
                this.uUIDIdentifikatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvert
    {

        private HaendelsesbeskedBeskedkuvertFiltreringsdata filtreringsdataField;

        private HaendelsesbeskedBeskedkuvertLeveranceinformation leveranceinformationField;

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertFiltreringsdata Filtreringsdata
        {
            get
            {
                return this.filtreringsdataField;
            }
            set
            {
                this.filtreringsdataField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertLeveranceinformation Leveranceinformation
        {
            get
            {
                return this.leveranceinformationField;
            }
            set
            {
                this.leveranceinformationField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertFiltreringsdata
    {

        private HaendelsesbeskedBeskedkuvertFiltreringsdataBeskedtype beskedtypeField;

        private HaendelsesbeskedBeskedkuvertFiltreringsdataBeskedAnsvarligAktoer beskedAnsvarligAktoerField;

        private HaendelsesbeskedBeskedkuvertFiltreringsdataTilladtModtager tilladtModtagerField;

        private HaendelsesbeskedBeskedkuvertFiltreringsdataRelateretObjekt relateretObjektField;

        private HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistrering[] objektRegistreringField;

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertFiltreringsdataBeskedtype Beskedtype
        {
            get
            {
                return this.beskedtypeField;
            }
            set
            {
                this.beskedtypeField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertFiltreringsdataBeskedAnsvarligAktoer BeskedAnsvarligAktoer
        {
            get
            {
                return this.beskedAnsvarligAktoerField;
            }
            set
            {
                this.beskedAnsvarligAktoerField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertFiltreringsdataTilladtModtager TilladtModtager
        {
            get
            {
                return this.tilladtModtagerField;
            }
            set
            {
                this.tilladtModtagerField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertFiltreringsdataRelateretObjekt RelateretObjekt
        {
            get
            {
                return this.relateretObjektField;
            }
            set
            {
                this.relateretObjektField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ObjektRegistrering")]
        public HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistrering[] ObjektRegistrering
        {
            get
            {
                return this.objektRegistreringField;
            }
            set
            {
                this.objektRegistreringField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertFiltreringsdataBeskedtype
    {

        private string uUIDIdentifikatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public string UUIDIdentifikator
        {
            get
            {
                return this.uUIDIdentifikatorField;
            }
            set
            {
                this.uUIDIdentifikatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertFiltreringsdataBeskedAnsvarligAktoer
    {

        private string uUIDIdentifikatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public string UUIDIdentifikator
        {
            get
            {
                return this.uUIDIdentifikatorField;
            }
            set
            {
                this.uUIDIdentifikatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertFiltreringsdataTilladtModtager
    {

        private string uRNIdentifikatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public string URNIdentifikator
        {
            get
            {
                return this.uRNIdentifikatorField;
            }
            set
            {
                this.uRNIdentifikatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertFiltreringsdataRelateretObjekt
    {

        private HaendelsesbeskedBeskedkuvertFiltreringsdataRelateretObjektObjektId objektIdField;

        private HaendelsesbeskedBeskedkuvertFiltreringsdataRelateretObjektObjektType objektTypeField;

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertFiltreringsdataRelateretObjektObjektId ObjektId
        {
            get
            {
                return this.objektIdField;
            }
            set
            {
                this.objektIdField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertFiltreringsdataRelateretObjektObjektType ObjektType
        {
            get
            {
                return this.objektTypeField;
            }
            set
            {
                this.objektTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertFiltreringsdataRelateretObjektObjektId
    {

        private string uUIDIdentifikatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public string UUIDIdentifikator
        {
            get
            {
                return this.uUIDIdentifikatorField;
            }
            set
            {
                this.uUIDIdentifikatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertFiltreringsdataRelateretObjektObjektType
    {

        private string uUIDIdentifikatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public string UUIDIdentifikator
        {
            get
            {
                return this.uUIDIdentifikatorField;
            }
            set
            {
                this.uUIDIdentifikatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistrering
    {

        private HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringObjektRegistreringId objektRegistreringIdField;

        private HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringRegistreringsAktoer registreringsAktoerField;

        private HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringRegistreringstidspunkt registreringstidspunktField;

        private HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringObjektAnsvarligMyndighed objektAnsvarligMyndighedField;

        private HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringObjektId objektIdField;

        private HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringObjektType objektTypeField;

        private HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringObjektHandling objektHandlingField;

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringObjektRegistreringId ObjektRegistreringId
        {
            get
            {
                return this.objektRegistreringIdField;
            }
            set
            {
                this.objektRegistreringIdField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringRegistreringsAktoer RegistreringsAktoer
        {
            get
            {
                return this.registreringsAktoerField;
            }
            set
            {
                this.registreringsAktoerField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringRegistreringstidspunkt Registreringstidspunkt
        {
            get
            {
                return this.registreringstidspunktField;
            }
            set
            {
                this.registreringstidspunktField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringObjektAnsvarligMyndighed ObjektAnsvarligMyndighed
        {
            get
            {
                return this.objektAnsvarligMyndighedField;
            }
            set
            {
                this.objektAnsvarligMyndighedField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringObjektId ObjektId
        {
            get
            {
                return this.objektIdField;
            }
            set
            {
                this.objektIdField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringObjektType ObjektType
        {
            get
            {
                return this.objektTypeField;
            }
            set
            {
                this.objektTypeField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringObjektHandling ObjektHandling
        {
            get
            {
                return this.objektHandlingField;
            }
            set
            {
                this.objektHandlingField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringObjektRegistreringId
    {

        private string uUIDIdentifikatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public string UUIDIdentifikator
        {
            get
            {
                return this.uUIDIdentifikatorField;
            }
            set
            {
                this.uUIDIdentifikatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringRegistreringsAktoer
    {

        private string uUIDIdentifikatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public string UUIDIdentifikator
        {
            get
            {
                return this.uUIDIdentifikatorField;
            }
            set
            {
                this.uUIDIdentifikatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringRegistreringstidspunkt
    {

        private System.DateTime tidsstempelDatoTidField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public System.DateTime TidsstempelDatoTid
        {
            get
            {
                return this.tidsstempelDatoTidField;
            }
            set
            {
                this.tidsstempelDatoTidField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringObjektAnsvarligMyndighed
    {

        private string uRNIdentifikatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public string URNIdentifikator
        {
            get
            {
                return this.uRNIdentifikatorField;
            }
            set
            {
                this.uRNIdentifikatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringObjektId
    {

        private string uUIDIdentifikatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public string UUIDIdentifikator
        {
            get
            {
                return this.uUIDIdentifikatorField;
            }
            set
            {
                this.uUIDIdentifikatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringObjektType
    {

        private string uUIDIdentifikatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public string UUIDIdentifikator
        {
            get
            {
                return this.uUIDIdentifikatorField;
            }
            set
            {
                this.uUIDIdentifikatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertFiltreringsdataObjektRegistreringObjektHandling
    {

        private string uUIDIdentifikatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public string UUIDIdentifikator
        {
            get
            {
                return this.uUIDIdentifikatorField;
            }
            set
            {
                this.uUIDIdentifikatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertLeveranceinformation
    {

        private HaendelsesbeskedBeskedkuvertLeveranceinformationDannelsestidspunkt dannelsestidspunktField;

        private HaendelsesbeskedBeskedkuvertLeveranceinformationTransaktionsId transaktionsIdField;

        private HaendelsesbeskedBeskedkuvertLeveranceinformationKildesystem kildesystemField;

        private string kildesystemIPAdresseField;

        private string kildesystemAkkreditiverField;

        private HaendelsesbeskedBeskedkuvertLeveranceinformationSikkerhedsklassificering sikkerhedsklassificeringField;

        private HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruter leveranceruterField;

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertLeveranceinformationDannelsestidspunkt Dannelsestidspunkt
        {
            get
            {
                return this.dannelsestidspunktField;
            }
            set
            {
                this.dannelsestidspunktField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertLeveranceinformationTransaktionsId TransaktionsId
        {
            get
            {
                return this.transaktionsIdField;
            }
            set
            {
                this.transaktionsIdField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertLeveranceinformationKildesystem Kildesystem
        {
            get
            {
                return this.kildesystemField;
            }
            set
            {
                this.kildesystemField = value;
            }
        }

        /// <remarks/>
        public string KildesystemIPAdresse
        {
            get
            {
                return this.kildesystemIPAdresseField;
            }
            set
            {
                this.kildesystemIPAdresseField = value;
            }
        }

        /// <remarks/>
        public string KildesystemAkkreditiver
        {
            get
            {
                return this.kildesystemAkkreditiverField;
            }
            set
            {
                this.kildesystemAkkreditiverField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertLeveranceinformationSikkerhedsklassificering Sikkerhedsklassificering
        {
            get
            {
                return this.sikkerhedsklassificeringField;
            }
            set
            {
                this.sikkerhedsklassificeringField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruter Leveranceruter
        {
            get
            {
                return this.leveranceruterField;
            }
            set
            {
                this.leveranceruterField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertLeveranceinformationDannelsestidspunkt
    {

        private System.DateTime tidsstempelDatoTidField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public System.DateTime TidsstempelDatoTid
        {
            get
            {
                return this.tidsstempelDatoTidField;
            }
            set
            {
                this.tidsstempelDatoTidField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertLeveranceinformationTransaktionsId
    {

        private string uUIDIdentifikatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public string UUIDIdentifikator
        {
            get
            {
                return this.uUIDIdentifikatorField;
            }
            set
            {
                this.uUIDIdentifikatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertLeveranceinformationKildesystem
    {

        private string uUIDIdentifikatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public string UUIDIdentifikator
        {
            get
            {
                return this.uUIDIdentifikatorField;
            }
            set
            {
                this.uUIDIdentifikatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertLeveranceinformationSikkerhedsklassificering
    {

        private string uUIDIdentifikatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public string UUIDIdentifikator
        {
            get
            {
                return this.uUIDIdentifikatorField;
            }
            set
            {
                this.uUIDIdentifikatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruter
    {

        private HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeverancerute leveranceruteField;

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeverancerute Leverancerute
        {
            get
            {
                return this.leveranceruteField;
            }
            set
            {
                this.leveranceruteField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeverancerute
    {

        private HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeveranceruteFordelingssystem fordelingssystemField;

        private HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeveranceruteModtagelsesTidspunkt modtagelsesTidspunktField;

        private HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeveranceruteLeveranceTidspunkt leveranceTidspunktField;

        private HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeveranceruteModtagetFraSystem modtagetFraSystemField;

        private HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeveranceruteErLeveretIHenholdTil erLeveretIHenholdTilField;

        private HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeveranceruteLeveranceruteLokalUdvidelse leveranceruteLokalUdvidelseField;

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeveranceruteFordelingssystem Fordelingssystem
        {
            get
            {
                return this.fordelingssystemField;
            }
            set
            {
                this.fordelingssystemField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeveranceruteModtagelsesTidspunkt ModtagelsesTidspunkt
        {
            get
            {
                return this.modtagelsesTidspunktField;
            }
            set
            {
                this.modtagelsesTidspunktField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeveranceruteLeveranceTidspunkt LeveranceTidspunkt
        {
            get
            {
                return this.leveranceTidspunktField;
            }
            set
            {
                this.leveranceTidspunktField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeveranceruteModtagetFraSystem ModtagetFraSystem
        {
            get
            {
                return this.modtagetFraSystemField;
            }
            set
            {
                this.modtagetFraSystemField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeveranceruteErLeveretIHenholdTil ErLeveretIHenholdTil
        {
            get
            {
                return this.erLeveretIHenholdTilField;
            }
            set
            {
                this.erLeveretIHenholdTilField = value;
            }
        }

        /// <remarks/>
        public HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeveranceruteLeveranceruteLokalUdvidelse LeveranceruteLokalUdvidelse
        {
            get
            {
                return this.leveranceruteLokalUdvidelseField;
            }
            set
            {
                this.leveranceruteLokalUdvidelseField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeveranceruteFordelingssystem
    {

        private string uUIDIdentifikatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public string UUIDIdentifikator
        {
            get
            {
                return this.uUIDIdentifikatorField;
            }
            set
            {
                this.uUIDIdentifikatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeveranceruteModtagelsesTidspunkt
    {

        private System.DateTime tidsstempelDatoTidField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public System.DateTime TidsstempelDatoTid
        {
            get
            {
                return this.tidsstempelDatoTidField;
            }
            set
            {
                this.tidsstempelDatoTidField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeveranceruteLeveranceTidspunkt
    {

        private System.DateTime tidsstempelDatoTidField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public System.DateTime TidsstempelDatoTid
        {
            get
            {
                return this.tidsstempelDatoTidField;
            }
            set
            {
                this.tidsstempelDatoTidField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeveranceruteModtagetFraSystem
    {

        private string uUIDIdentifikatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public string UUIDIdentifikator
        {
            get
            {
                return this.uUIDIdentifikatorField;
            }
            set
            {
                this.uUIDIdentifikatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeveranceruteErLeveretIHenholdTil
    {

        private string uUIDIdentifikatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oio:sagdok:3.0.0")]
        public string UUIDIdentifikator
        {
            get
            {
                return this.uUIDIdentifikatorField;
            }
            set
            {
                this.uUIDIdentifikatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskedkuvertLeveranceinformationLeveranceruterLeveranceruteLeveranceruteLokalUdvidelse
    {

        private byte antalLeveranceforsoegField;

        /// <remarks/>
        public byte AntalLeveranceforsoeg
        {
            get
            {
                return this.antalLeveranceforsoegField;
            }
            set
            {
                this.antalLeveranceforsoegField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oio:besked:kuvert:1.0")]
    public partial class HaendelsesbeskedBeskeddata
    {

        private Base64 base64Field;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:besked:kuvert:1.0")]
        public Base64 Base64
        {
            get
            {
                return this.base64Field;
            }
            set
            {
                this.base64Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:besked:kuvert:1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:besked:kuvert:1.0", IsNullable = false)]
    public partial class Base64
    {

        private string contenttypeField;

        private string encodingField;

        private string filetypeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("content-type")]
        public string contenttype
        {
            get
            {
                return this.contenttypeField;
            }
            set
            {
                this.contenttypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string encoding
        {
            get
            {
                return this.encodingField;
            }
            set
            {
                this.encodingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("file-type")]
        public string filetype
        {
            get
            {
                return this.filetypeField;
            }
            set
            {
                this.filetypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }









}
