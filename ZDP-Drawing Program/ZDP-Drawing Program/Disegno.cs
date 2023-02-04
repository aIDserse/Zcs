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
    public class Disegno
    {
        //4 attributi necessari + inizializzazione

        public List<Figura> ListaFigure { get; set; }
        public List<Figura> ListaFigureRimosse { get; set; }
        public int spessore;
        public Color colore;
        public Disegno()
        {
            ListaFigure = new List<Figura>();
            ListaFigureRimosse = new List<Figura>();
        }
        public void SvuotaListaFigure()
        {
            ListaFigure.Clear();
        }
        public void SvuotaListaFigureRimosse()
        {
            ListaFigureRimosse.Clear();
        }
        public int DammiSpessore()
        {
            return spessore;
        }
        public Color DammiColore()
        {
            return colore;
        }
        public void ModificaSpessore(int newspessore)
        {
            spessore = newspessore;
        }
        public void ModificaColore(Color newcolore)
        {
            colore = newcolore;
        }
        public void AggiungiLinea(int i, Point p1, Point p2) 
            //Vengono forniti il colore e i punti necessari
            //il colore è dato sottoforma di intero
            //Fornito grazie al metodo toArgb nella classe Form1. Il colore verrà poi riconvertito
            //all'interno della classe linea stessa
            //Idem ovviamente per tutti gli altri metodi
        {
            i = colore.ToArgb();
            ListaFigure.Add(new Linea() { icolore = i, Spessore = spessore, P1 = p1, P2 = p2 });
        }
        public void AggiungiCurva(int i, Point p1, Point p2, Point p3)
        {
            i = colore.ToArgb();
            ListaFigure.Add(new Curva() { icolore = i, Spessore = spessore, P1 = p1, P2 = p2, P3 = p3, });
        }
        public void AggiungiRettangolo(int i, Point p1, Point p2, Point p3, Point p4)
        {
            i = colore.ToArgb();
            ListaFigure.Add(new Rettangolo() { icolore = i, Spessore = spessore, P1 = p1, P2 = p2 });
        }
        public void AggiungiCerchio(int i, Point p1, Point p2)
        {
            i = colore.ToArgb();
            ListaFigure.Add(new Cerchio() { icolore = i, Spessore = spessore, P1 = p1, P2 = p2 });
        }
        public void AggiungiElisse(int i, Point p1, Point p2)
        {
            i = colore.ToArgb();
            ListaFigure.Add(new Elisse() { icolore = i, Spessore = spessore, P1 = p1, P2 = p2 });
        }
        public void AggiungiManoLibera(int i, Point[] ArrayPunti)
        {
            i = colore.ToArgb();
            ListaFigure.Add(new ManoLibera() { icolore = i, Spessore = spessore, ArrayPunti = ArrayPunti });
        }
        public void AggiungiGomma(Point[] ArrayPunti)
        {
            ListaFigure.Add(new Gomma() { Spessore = spessore, ArrayPunti = ArrayPunti });
        }
        public void Undo() //Metodo undo -> tolgo la figura da cui torno indietro dall'array delle figure
            //Disegnate e lo aggiungo alla lista delle figure da cui si può eventualmente fare redo
        {
            if (ListaFigure.Count() >= 1) //Se ListaFigure (lista di figure disegnate è maggiore o uguale a 1
            {
                ListaFigureRimosse.Add(ListaFigure[ListaFigure.Count - 1]);
                ListaFigure.RemoveAt(ListaFigure.Count() - 1);
            }
        }
        public void Redo()
        {
            if (ListaFigureRimosse.Count() >= 1) //Se è stato fatto redo almeno una volta:
                //Rimetto la figura dall'array dei redo a quello dei disegnati
            {
                ListaFigure.Add(ListaFigureRimosse.Last());
                ListaFigureRimosse.RemoveAt(ListaFigureRimosse.Count() - 1);
            }
        }
        public void DisegnaTutto(Graphics g) //Disegno ogni figura dentro ListaFigure
        {
            foreach (Figura f in ListaFigure)
            {
                f.Disegna(g);
            }
        }
    }
}
