using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZDP_Drawing_Program
{
    public partial class Form2 : Form
    {
        string formato;
        public Form2()
        {
            InitializeComponent();
            label1.Text = "Salvataggio in \n formato XML \n Formato di tipo \n universale";
            label2.Text = "Salvataggio in \n formato Binary \n Non universale ma \n molto più veloce";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            formato = "XML";
            RestituisciFormato();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formato = "BIN";
            RestituisciFormato();
            this.Close();
        }

        public string RestituisciFormato()
        {
            return formato;
        }
    }
}
