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
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace ZDP_Drawing_Program
{
    [Serializable]
    [XmlInclude(typeof(Disegno))]
    [XmlInclude(typeof(Linea))]
    [XmlInclude(typeof(Curva))]
    [XmlInclude(typeof(Rettangolo))]
    [XmlInclude(typeof(Cerchio))]
    [XmlInclude(typeof(Elisse))]
    [XmlInclude(typeof(ManoLibera))]
    public partial class Form1 : Form
    {
        //Dichiaro il disegno 
        public Disegno d;
        //Dichiaro i punti che utilizzerò, il color dialog le liste e le altre variabili
        Point p1;
        Point p2;
        Point p3;
        Point p4;
        ColorDialog dlg = new ColorDialog();
        bool manolibera;
        List<Point> ListaPuntiManoLibera = new List<Point>();
        List<Point> ListaPuntiGomma = new List<Point>();
        List<Point> ListaPuntiLinea = new List<Point>();
        Point lastPoint;
        bool isMouseDown;
        bool gomma;
        int lastspessore;
        bool disLinea;
        bool disCurva;
        bool disRettangolo;
        bool disCerchio;
        bool disElisse;
        public Form1()
        {
            d = new Disegno();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Imposto il colore di default come nero
            dlg.Color = Color.Black;
            //Lo imposto anche per la classe disegno
            d.ModificaColore(dlg.Color);
            //Imposto manolibera come falso
            manolibera = false;
            gomma = false;
            d.ModificaSpessore(1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Ripulisco lo schermo, svolgo l'undo e ridisegno il tutto
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            d.Undo();
            d.DisegnaTutto(g);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Ripulisco lo schermo, svolgo il redo e ridisegno il tutto
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            d.Redo();
            d.DisegnaTutto(g);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dlg.ShowDialog(); //apro il dialog per la modifica del colore
            d.ModificaColore(dlg.Color); //modifico il colore con quello scelto dal dialog
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bott_linea_Click(object sender, EventArgs e)
        {
            //Imposto manolibera come falso
            manolibera = false;
            gomma = false;
            disLinea = true;
            //Imposto g come tipo Graphics dentro al picturebox
            Graphics g = pictureBox1.CreateGraphics();
            //Aggiungo una linea
            d.AggiungiLinea(dlg.Color.ToArgb(), p1, p2);
            //Disegno
            d.DisegnaTutto(g);
            //Svuoto i punti, così da evitare formazione accidentale di altre figure
            p1 = Point.Empty;
            p2 = Point.Empty;
            p3 = Point.Empty;
            p4 = Point.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Imposto manolibera come falso
            manolibera = false;
            gomma = false;
            //Imposto g come tipo Graphics dentro al picturebox
            Graphics g = pictureBox1.CreateGraphics();
            //Aggiungo una curva
            d.AggiungiCurva(dlg.Color.ToArgb(), p1, p2, p3);
            //Disegno
            d.DisegnaTutto(g);
            //Svuoto i punti, così da evitare formazione accidentale di altre figure
            p1 = Point.Empty;
            p2 = Point.Empty;
            p3 = Point.Empty;
            p4 = Point.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Imposto manolibera come falso
            manolibera = false;
            gomma = false;
            //Imposto g come tipo Graphics dentro al picturebox
            Graphics g = pictureBox1.CreateGraphics();
            //Aggiungo un rettangolo
            d.AggiungiRettangolo(dlg.Color.ToArgb(), p1, p2, p1, p2);
            //Disegno
            d.DisegnaTutto(g);
            //Svuoto i punti, così da evitare formazione accidentale di altre figure
            p1 = Point.Empty;
            p2 = Point.Empty;
            p3 = Point.Empty;
            p4 = Point.Empty;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            manolibera = false;
            Graphics g = pictureBox1.CreateGraphics();
            d.AggiungiCerchio(dlg.Color.ToArgb(), p1, p2);
            d.DisegnaTutto(g);
            p1 = Point.Empty;
            p2 = Point.Empty;
            p3 = Point.Empty;
            p4 = Point.Empty;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            manolibera = false;
            gomma = false;
            Graphics g = pictureBox1.CreateGraphics();
            d.AggiungiElisse(dlg.Color.ToArgb(), p1, p2);
            d.DisegnaTutto(g);
            p1 = Point.Empty;
            p2 = Point.Empty;
            p3 = Point.Empty;
            p4 = Point.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gomma = false;
            //Attivo manolibera
            manolibera = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            gomma = true;
            manolibera = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Savlataggio!
            Form2 formato = new Form2();
            formato.ShowDialog(); //Creo un form, che semplicemente mi chiede di che tipo voglio salvare l'oggetto (bin
            //oppure XML)
            if (formato.RestituisciFormato() == "XML")
            {
                Stream myStream;
                SaveFileDialog salva = new SaveFileDialog(); //Creo un savefiledialog
                salva.Filter = "*(.xml)| *.xml"; //Imposto il filtro per fargli vedere solo xml
                if (salva.ShowDialog() == DialogResult.OK)
                {
                    //Il salvataggio in XML non va!! Non ho idea del perchè, il codice è letteralmente lo stesso
                    //che funziona con l'altra versione del programma, idem per il salvataggio in BIN!!!
                    myStream = File.Create(salva.FileName);
                    XmlSerializer writer = new XmlSerializer(typeof(Disegno));
                    writer.Serialize(myStream, d);
                    myStream.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 formato = new Form2();
            formato.ShowDialog();
            if (formato.RestituisciFormato() == "XML")
            {
                Stream myStream;
                OpenFileDialog salva = new OpenFileDialog();
                salva.Filter = "*(.xml)| *.xml";
                if (salva.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = salva.OpenFile()) != null)
                    {
                        if (MessageBox.Show("Caricare il file " + salva.FileName + " ?", "Carica", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            d.SvuotaListaFigure();
                            XmlSerializer carica = new XmlSerializer(typeof(Disegno));
                            d = (Disegno)carica.Deserialize(myStream);
                            myStream.Close();
                            Graphics g = pictureBox1.CreateGraphics();
                            g.Clear(Color.White);
                            d.DisegnaTutto(g);
                        }
                    }
                }
            }
            else if (formato.RestituisciFormato() == "BIN")
            {
                Stream myStream;
                OpenFileDialog salva = new OpenFileDialog();
                salva.Filter = "*(.bin)| *.bin";
                if (salva.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = salva.OpenFile()) != null)
                    {
                        if (MessageBox.Show("Caricare il file " + salva.FileName + " ?", "Carica", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Stream file = File.OpenRead(salva.FileName);
                            BinaryFormatter serializer = new BinaryFormatter();
                            Graphics g = pictureBox1.CreateGraphics();
                            d = (Disegno)serializer.Deserialize(file);
                            d.DisegnaTutto(g);
                            file.Close();
                        }
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Salvo il lavoro come bmp
            if (MessageBox.Show("Salvare il lavoro come bmp?", "Carica", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Creo una messagebox che chiede conferma
                SaveFileDialog salva = new SaveFileDialog();
                salva.Filter = "*(.bmp)| *.bmp"; //Filtro
                Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height); //Creo una bitmap di grandezza
                                                                                   //E larghezza del mio picturebox
                pictureBox1.DrawToBitmap(bitmap, pictureBox1.Bounds); //Ci disegno sopra tutto ciò che appare sopra
                if (salva.ShowDialog() == DialogResult.OK)
                {
                    bitmap.Save(salva.FileName); //Chiedo conferma se salvare, se affermativa creo il file e salvo
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Svuotare completamente tutto lo spazio di lavoro? \n Attenzione! Tutti i progressi verranno eliminati!", "Carica", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Chiedo conferma se svuotare tutto lo spazio di lavoro
                //Se la conferma è data, svuoto tutto lo svuotabile e resetto completamente la picturebox
                d.SvuotaListaFigure();
                d.SvuotaListaFigureRimosse();
                Bitmap flag = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = flag;
                Graphics g = pictureBox1.CreateGraphics();
                g = Graphics.FromImage(pictureBox1.Image);
                p1 = Point.Empty;
                p2 = Point.Empty;
                p3 = Point.Empty;
                p4 = Point.Empty;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        { 
            //Modifica spessore
            if (e.KeyChar == (char)Keys.Return)
            {
                int er = Regex.Matches(textBox1.Text, @"[a-zA-Z-,-.]").Count; //Controllo che non ci siano lettere all'interno
                //Della stronga da convertire
                if (textBox1.Text == "" && er == 0)
                {
                    d.ModificaSpessore(lastspessore); //Se non ce ne sono ma la stringa è vuota
                    //Lo spessore è l'ultimo registrato (appena avviato il programma è 1)
                }
                else if (er == 0)
                {
                    //Se invece è tutto a posto
                    d.ModificaSpessore(Convert.ToInt32(textBox1.Text)); //Converto in int il contenuto della textbox
                    //e lo imposto come spessore dentro la classe d
                    d.DammiSpessore(); //lo salvo come ultimo spessore registrato
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {if (isMouseDown == true && manolibera == true) //Se le condizioni sono giuste per disegnare a mano libera
            {
                ListaPuntiManoLibera.Add(e.Location); //Aggiungo alla lista di punti la locazione corrente del mouse nella picturebox
                if(ListaPuntiManoLibera.Count >= 2)
                {
                    Graphics g = pictureBox1.CreateGraphics(); //Creo g
                    Pen p = new Pen(d.DammiColore(), d.DammiSpessore()); //Creo la penna (poi scorporata all'interno della classe disegno
                    g.DrawLines(p, ListaPuntiManoLibera.ToArray()); //Disegno le linee della manolibera, senza tuttavia aggiungerle a d
                }
            }
            if (isMouseDown == true && gomma == true & manolibera == false) //Se le condizioni sono giuste per la gomma
            {
                ListaPuntiGomma.Add(e.Location); //Aggiungo alla lista di punti la locazione corrente del mouse nella picturebox
                if (ListaPuntiGomma.Count >= 2)
                {
                    Graphics g = pictureBox1.CreateGraphics(); //Creo g
                    Pen p = new Pen(Color.White, d.DammiSpessore()); //Creo la penna (bianca dato che mi basta il colore dello sfondo x la gomma)
                    g.DrawLines(p, ListaPuntiGomma.ToArray()); //Disegno le linee della gomma, senza tuttavia aggiungerle a d
                }
            }
            if(disLinea == true && isMouseDown == true && gomma == false & manolibera == false)
            {
                if(p1 != null || p1 != Point.Empty)
                {
                    Pen p = new Pen(d.DammiColore(), d.DammiSpessore()); //Creo la penna (poi scorporata all'interno della classe disegno
                    Graphics g = pictureBox1.CreateGraphics();
                    g.DrawLine(p, p1, e.Location);
                }
            }
            //Uso le due label (che si aggiornano a ogni movimento del mouse)
            //Per mostrare le coordinate a cui si disegna
            label2.Text = Convert.ToString(e.X);
            label4.Text = Convert.ToString(e.Y);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {//Funzione in cui dò il valore ai punti in cui tocco a seconda dell'ordine
            if (manolibera != true)
            {
                if (p1.X == 0)
                {
                    p1.X = e.X;
                    p1.Y = e.Y;
                }
                else
                {
                    if (p2.X == 0)
                    {
                        p2.X = e.X;
                        p2.Y = e.Y;
                    }
                    else
                    {
                        if (p3.X == 0)
                        {
                            p3.X = e.X;
                            p3.Y = e.Y;
                        }
                        else
                        {
                            p4.X = e.X;
                            p4.Y = e.Y;
                        }
                    }
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //Appuro che il mouse non è più cliccato in giù
            isMouseDown = false;
            //Se il mouse clicca col tasto sinistro
            if (e.Button == MouseButtons.Left)
            {
                lastPoint = e.Location;
                if (manolibera == true && ListaPuntiManoLibera.Count() >= 2 && gomma == false) //Se ho attivato manolibera e 
                                                                                               //Ho punti sufficienti
                {
                    //Aggiungo una figura manolibera
                    d.AggiungiManoLibera(dlg.Color.ToArgb(), ListaPuntiManoLibera.ToArray());
                    //Pulisco la listra fornitagli precedentemente, così che non si accavallino 
                    ListaPuntiManoLibera.Clear();
                    //Imposto g come tipo Graphics dentro al picturebox
                    Graphics g = pictureBox1.CreateGraphics();
                    //Disegno
                    d.DisegnaTutto(g);
                    lastPoint = Point.Empty;
                    p1 = Point.Empty;
                    p2 = Point.Empty;
                    p3 = Point.Empty;
                    p4 = Point.Empty;
                }
                if (gomma == true && ListaPuntiGomma.Count >= 2 && manolibera == false)
                {
                    d.AggiungiGomma(ListaPuntiGomma.ToArray());
                    ListaPuntiGomma.Clear();
                    Graphics g = pictureBox1.CreateGraphics();
                    d.DisegnaTutto(g);
                    lastPoint = Point.Empty;
                    p1 = Point.Empty;
                    p2 = Point.Empty;
                    p3 = Point.Empty;
                    p4 = Point.Empty;
                }
            }
            //Svuoto lastPoint cosicchè non ci siano disegni aggiuntivi non voluti
            lastPoint = Point.Empty;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //Imposto la variabile lastPoint come la posizione del mouse fintantoche il mouse è cliccato
            lastPoint = e.Location;
            //Imposto come vera la variabile mousedown
            isMouseDown = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Se avvengono combinazioni di tasti:
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Z)
            {
                //Ripulisco lo schermo, svolgo l'undo e ridisegno il tutto
                Graphics g = pictureBox1.CreateGraphics();
                g.Clear(Color.White);
                d.Undo();
                d.DisegnaTutto(g);
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Y)
            {
                //Ripulisco lo schermo, svolgo il redo e ridisegno il tutto
                Graphics g = pictureBox1.CreateGraphics();
                g.Clear(Color.White);
                d.Redo();
                d.DisegnaTutto(g);
            }
            //Qui non so perchè non vada, è letteralmente identico al metodo sul progetto originale...
            //è comunque uguale al metodo delle frecce, quindi non mi sono messo a cercare di metterlo a posto più di tanto dato che 
            //il "succo" è il metodo undo in sè, non i controlli del form
        }
    }
}
