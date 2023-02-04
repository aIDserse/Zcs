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
    //Indico serializzabilità
    [Serializable]
    public class Curva : Figura
    {
        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public Point P3 { get; set; }
        public int icolore;
        public override void Disegna(Graphics g)
        {
            byte[] bytes = BitConverter.GetBytes(icolore);
            Color colore = Color.FromArgb(bytes[2], bytes[1], bytes[0]);
            Pen p = new Pen(colore, Spessore);
            g.DrawCurve(p, new Point[] { P1, P2, P3 });
        }
    }
}

