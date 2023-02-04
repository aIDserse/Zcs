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
    [Serializable]
    public class Gomma : Figura
    {
        public Point[] ArrayPunti { get; set; } //Array di Punti per disegnare la figura
        public override void Disegna(Graphics g)
        {
            if(ArrayPunti.Count() >= 2)
            {
                Pen p = new Pen(Color.White, Spessore);
                g.DrawLines(p, ArrayPunti); //Disegno le molteplici linee per la figura a mano libera
            }
        }
    }
}
