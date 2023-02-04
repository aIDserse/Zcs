using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace ZDP_Drawing_Program
{
    //Indico serializzabilità + includo in xml
    [Serializable]
    [XmlInclude(typeof(Linea))]
    [XmlInclude(typeof(Curva))]
    [XmlInclude(typeof(Rettangolo))]
    [XmlInclude(typeof(Cerchio))]
    [XmlInclude(typeof(Elisse))]
    [XmlInclude(typeof(ManoLibera))]
    [XmlInclude(typeof(Gomma))]
    public abstract class Figura
    {
        //public Color Colore{get; private set;}
        public int Spessore { get; set; }
        public int Colore { get; set; }
        public abstract void Disegna(Graphics g);
    }
}
