using System;
using System.Collections.Generic;
using System.Text;

namespace TJ.UserAccount.Integration.Models
{
    // Примечание. Для запуска созданного кода может потребоваться NET Framework версии 4.5 или более поздней версии и .NET Core или Standard версии 2.0 или более поздней.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.gesmes.org/xml/2002-08-01")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.gesmes.org/xml/2002-08-01", IsNullable = false)]
    public partial class Envelope
    {

        private string subjectField;

        private EnvelopeSender senderField;

        private Cube cubeField;

        /// <remarks/>
        public string subject
        {
            get
            {
                return this.subjectField;
            }
            set
            {
                this.subjectField = value;
            }
        }

        /// <remarks/>
        public EnvelopeSender Sender
        {
            get
            {
                return this.senderField;
            }
            set
            {
                this.senderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
        public Cube Cube
        {
            get
            {
                return this.cubeField;
            }
            set
            {
                this.cubeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.gesmes.org/xml/2002-08-01")]
    public partial class EnvelopeSender
    {

        private string nameField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref", IsNullable = false)]
    public partial class Cube
    {

        private CubeCube cube1Field;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Cube")]
        public CubeCube ExchangeRate
        {
            get
            {
                return this.cube1Field;
            }
            set
            {
                this.cube1Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
    public partial class CubeCube
    {

        private ExchangeRate[] cubeField;

        private System.DateTime timeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Cube")]
        public ExchangeRate[] ExchangeRates
        {
            get
            {
                return this.cubeField;
            }
            set
            {
                this.cubeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
    public partial class ExchangeRate
    {

        private string currencyField;

        private decimal rateField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal rate
        {
            get
            {
                return this.rateField;
            }
            set
            {
                this.rateField = value;
            }
        }
    }


}
