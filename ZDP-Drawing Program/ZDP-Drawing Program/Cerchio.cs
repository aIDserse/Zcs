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
    [XmlInclude(typeof(Disegno))]
    [XmlInclude(typeof(Figura))]
    [XmlInclude(typeof(Linea))]
    [XmlInclude(typeof(Curva))]
    [XmlInclude(typeof(Rettangolo))]
    [XmlInclude(typeof(Cerchio))]
    [XmlInclude(typeof(Elisse))]
    [XmlInclude(typeof(ManoLibera))]
    public class Cerchio : Figura
    {
        //Dichiaro i punti necessari + il colore in int
        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public int icolore;

        public override void Disegna(Graphics g)
        {
            byte[] bytes = BitConverter.GetBytes(icolore);
            Color colore = Color.FromArgb(bytes[2], bytes[1], bytes[0]); //-> converto il colore 
            //Da array di byte a tipo Color tramite il metodo FromArb
            Pen p = new Pen(colore, Spessore);
            g.DrawEllipse(p, P1.X, P1.Y, P2.X, P2.Y);

        }
    }
}
