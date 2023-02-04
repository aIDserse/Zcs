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
    public class Elisse : Figura
    {
        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public int icolore;
        public override void Disegna(Graphics g)
        {
            byte[] bytes = BitConverter.GetBytes(icolore);
            Color colore = Color.FromArgb(bytes[2], bytes[1], bytes[0]);
            Pen p = new Pen(colore, Spessore);
            int xMax = Math.Max(P1.X, P2.X);
            int yMax = Math.Max(P1.Y, P2.Y);
            int xMin = Math.Min(P1.X, P2.X);
            int yMin = Math.Min(P1.Y, P2.Y);
            Rectangle c = new Rectangle(xMin, yMin, xMax - xMin, yMax - yMin);
            g.DrawEllipse(p, c);
        }
    }
}
