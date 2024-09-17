using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Esercizio_16._1._2024
{
    public partial class Form1 : Form
    {
        private List<voti> listVoti;
        private string fileName = "./Elenco studente.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listVoti = new List<voti>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nomestudente = textBox1.Text;
            string materia = textBox2.Text;
            string classe = textBox3.Text;
            int voto = Convert.ToInt32(textBox4.Text);

            voti voti = new voti(nomestudente, materia, classe, voto);
            listVoti.Add(voti);

            listBox1.Items.Add(voti.Nomestudente +"; "+ voti.Materia + "; " + voti.Classe + "; " + voti.Voto) ;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(fileName);
            
            foreach (voti voti in listVoti)
            {
                sw.WriteLine($"{voti.Nomestudente};{voti.Materia};{voti.Classe};{voti.Voto}");
            }
            sw.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
    class voti
    {
        private string _nomestudente;
        private string _materia;
        private string _classe;
        private int _voto;

        public voti(string nomestudente, string materia, string classe, int voto)
        {
            Nomestudente = nomestudente;
            Materia = materia; 
            Classe = classe;
            Voto = voto;
        }

        public string Nomestudente
        {
            get => _nomestudente;
            set => _nomestudente = value;
        }
        public string Materia
        {
            get => _materia;
            set => _materia = value;
        }
        public string Classe
        {
            get => _classe;
            set => _classe = value;
        }
        public int Voto
        {
            get => _voto;
            set => _voto = value;
        }

    }
}
