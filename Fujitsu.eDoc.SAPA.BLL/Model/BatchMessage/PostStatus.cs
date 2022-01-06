using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Fujitsu.eDoc.SAPA.BLL.Model
{
    //[XmlRoot(ElementName = "PKO_PostStatus", Namespace = "http://serviceplatformen.dk/xml/print/PKO_PostStatus/1/types")]
    //public class PostStatus
    //{
    //    public string TransmissionId { get; set; }
    //    public string MessageUUID { get; set; }
    //    public string MessageId { get; set; }
    //    public string AfsendelseIdentifikator { get; set; }
    //    public int ForsendelseIdentifikator { get; set; }
    //    public string KanalKode { get; set; }
    //    public DateTime TransaktionsDatoTid { get; set; }
    //    public string BrugerNavn { get; set; }
    //    public string EnhedTekst { get; set; }
    //    public string AfsenderSystemIdentifikator { get; set; }
    //    public string TransaktionsStatusKode { get; set; }
    //    public string ForsendelseTypeIdentifikator { get; set; }
    //    public string CorrelationId { get; set; }
    //    public FejlDetaljerType FejlDetaljer { get; set; }
    //    public ForsendelseHaendelseSamling ForsendelseHaendelseSamling { get; set; }
    //}

    //public class FejlDetaljerType
    //{
    //    public int FejlKode { get; set; }

    //    public string FejlTekst { get; set; }
    //}

    //public class ForsendelseHaendelseSamling
    //{
    //    [XmlElement("ForsendelseHaendelse")]
    //    public List<ForsendelseHaendelse> forsendelseHaendelses = new List<ForsendelseHaendelse>();
    //}

    //public class ForsendelseHaendelse
    //{
    //    public int ForsendelseHaendelseTypeKode { get; set; }
    //    public DateTime ForsendelseHaendelseDatoTid { get; set; }
    //    public decimal ForsendelseHaendelseBeloeb { get; set; }
    //}



}

// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://serviceplatformen.dk/xml/print/PKO_PostStatus/1/types")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://serviceplatformen.dk/xml/print/PKO_PostStatus/1/types", IsNullable = false)]
public partial class PKO_PostStatus
{

    private string transmissionIdField;

    private string messageUUIDField;

    private string messageIdField;

    private string afsendelseIdentifikatorField;

    private ushort forsendelseIdentifikatorField;

    private string kanalKodeField;

    private System.DateTime transaktionsDatoTidField;

    private string brugerNavnField;

    private string enhedTekstField;

    private string afsenderSystemIdentifikatorField;

    private string transaktionsStatusKodeField;

    private string forsendelseTypeIdentifikatorField;

    private string correlationIdField;

    private PKO_PostStatusFejlDetaljer fejlDetaljerField;

    private PKO_PostStatusForsendelseHaendelse[] forsendelseHaendelseSamlingField;

    /// <remarks/>
    public string TransmissionId
    {
        get
        {
            return this.transmissionIdField;
        }
        set
        {
            this.transmissionIdField = value;
        }
    }

    /// <remarks/>
    public string MessageUUID
    {
        get
        {
            return this.messageUUIDField;
        }
        set
        {
            this.messageUUIDField = value;
        }
    }

    /// <remarks/>
    public string MessageId
    {
        get
        {
            return this.messageIdField;
        }
        set
        {
            this.messageIdField = value;
        }
    }

    /// <remarks/>
    public string AfsendelseIdentifikator
    {
        get
        {
            return this.afsendelseIdentifikatorField;
        }
        set
        {
            this.afsendelseIdentifikatorField = value;
        }
    }

    /// <remarks/>
    public ushort ForsendelseIdentifikator
    {
        get
        {
            return this.forsendelseIdentifikatorField;
        }
        set
        {
            this.forsendelseIdentifikatorField = value;
        }
    }

    /// <remarks/>
    public string KanalKode
    {
        get
        {
            return this.kanalKodeField;
        }
        set
        {
            this.kanalKodeField = value;
        }
    }

    /// <remarks/>
    public System.DateTime TransaktionsDatoTid
    {
        get
        {
            return this.transaktionsDatoTidField;
        }
        set
        {
            this.transaktionsDatoTidField = value;
        }
    }

    /// <remarks/>
    public string BrugerNavn
    {
        get
        {
            return this.brugerNavnField;
        }
        set
        {
            this.brugerNavnField = value;
        }
    }

    /// <remarks/>
    public string EnhedTekst
    {
        get
        {
            return this.enhedTekstField;
        }
        set
        {
            this.enhedTekstField = value;
        }
    }

    /// <remarks/>
    public string AfsenderSystemIdentifikator
    {
        get
        {
            return this.afsenderSystemIdentifikatorField;
        }
        set
        {
            this.afsenderSystemIdentifikatorField = value;
        }
    }

    /// <remarks/>
    public string TransaktionsStatusKode
    {
        get
        {
            return this.transaktionsStatusKodeField;
        }
        set
        {
            this.transaktionsStatusKodeField = value;
        }
    }

    /// <remarks/>
    public string ForsendelseTypeIdentifikator
    {
        get
        {
            return this.forsendelseTypeIdentifikatorField;
        }
        set
        {
            this.forsendelseTypeIdentifikatorField = value;
        }
    }

    /// <remarks/>
    public string CorrelationId
    {
        get
        {
            return this.correlationIdField;
        }
        set
        {
            this.correlationIdField = value;
        }
    }

    /// <remarks/>
    public PKO_PostStatusFejlDetaljer FejlDetaljer
    {
        get
        {
            return this.fejlDetaljerField;
        }
        set
        {
            this.fejlDetaljerField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ForsendelseHaendelse", IsNullable = false)]
    public PKO_PostStatusForsendelseHaendelse[] ForsendelseHaendelseSamling
    {
        get
        {
            return this.forsendelseHaendelseSamlingField;
        }
        set
        {
            this.forsendelseHaendelseSamlingField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://serviceplatformen.dk/xml/print/PKO_PostStatus/1/types")]
public partial class PKO_PostStatusFejlDetaljer
{

    private ushort fejlKodeField;

    private string fejlTekstField;

    /// <remarks/>
    public ushort FejlKode
    {
        get
        {
            return this.fejlKodeField;
        }
        set
        {
            this.fejlKodeField = value;
        }
    }

    /// <remarks/>
    public string FejlTekst
    {
        get
        {
            return this.fejlTekstField;
        }
        set
        {
            this.fejlTekstField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://serviceplatformen.dk/xml/print/PKO_PostStatus/1/types")]
public partial class PKO_PostStatusForsendelseHaendelse
{

    private ushort forsendelseHaendelseTypeKodeField;

    private System.DateTime forsendelseHaendelseDatoTidField;

    private decimal forsendelseHaendelseBeloebField;

    /// <remarks/>
    public ushort ForsendelseHaendelseTypeKode
    {
        get
        {
            return this.forsendelseHaendelseTypeKodeField;
        }
        set
        {
            this.forsendelseHaendelseTypeKodeField = value;
        }
    }

    /// <remarks/>
    public System.DateTime ForsendelseHaendelseDatoTid
    {
        get
        {
            return this.forsendelseHaendelseDatoTidField;
        }
        set
        {
            this.forsendelseHaendelseDatoTidField = value;
        }
    }

    /// <remarks/>
    public decimal ForsendelseHaendelseBeloeb
    {
        get
        {
            return this.forsendelseHaendelseBeloebField;
        }
        set
        {
            this.forsendelseHaendelseBeloebField = value;
        }
    }
}