using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GalaxyLibrary
{
    public class QueryConfiguration
    {
        public string Name { get; set; }
        public string RegEx { get; set; }
        public int Length { get; set; }
        public string Sample { get; set; }
        public int KeyPosition { get; set; }
        public int ValuePosition { get; set; }

        public int CalculativeStart { get; set; }
        public int CalculativeEnd { get; set; }

        public QueryConfiguration(XmlElement xmlNode)
        {
            this.Name = xmlNode.GetAttribute("Name");
            this.RegEx = xmlNode.GetAttribute("RegEx");
            this.Sample = xmlNode.GetAttribute("Sample");
        }

        public void GetAditionalConfiguration(XmlElement xmlNode)
        {
            if (xmlNode.HasAttribute("ArrayLengthMinimum"))
                this.Length = Convert.ToInt32(xmlNode.GetAttribute("ArrayLengthMinimum"));

            if (xmlNode.HasAttribute("ArrayKeyPartFromEnd"))
                this.KeyPosition = Convert.ToInt32(xmlNode.GetAttribute("ArrayKeyPartFromEnd"));

            if (xmlNode.HasAttribute("ArrayValuePartFromEnd"))
                this.ValuePosition = Convert.ToInt32(xmlNode.GetAttribute("ArrayValuePartFromEnd"));

            if (xmlNode.HasAttribute("CalculativeIndexRangeStart"))
                this.CalculativeStart = Convert.ToInt32(xmlNode.GetAttribute("CalculativeIndexRangeStart"));

            if (xmlNode.HasAttribute("CalculativeIndexRangeEnd"))
                this.CalculativeEnd = Convert.ToInt32(xmlNode.GetAttribute("CalculativeIndexRangeEnd"));


        }

    }
}
