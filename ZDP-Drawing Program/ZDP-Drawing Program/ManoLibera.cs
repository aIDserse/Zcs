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
    public class ManoLibera : Figura
    {
        public int icolore;
        public Point[] ArrayPunti { get; set; } //Array di Punti per disegnare la figura
        public override void Disegna(Graphics g)
        {
            byte[] bytes = BitConverter.GetBytes(icolore);
            Color colore = Color.FromArgb(bytes[2], bytes[1], bytes[0]);
            Pen p = new Pen(colore, Spessore);
            g.DrawLines(p, ArrayPunti); //Disegno le molteplici linee per la figura a mano libera
        }
    }
}
