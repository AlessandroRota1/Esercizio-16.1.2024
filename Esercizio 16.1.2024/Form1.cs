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
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    listVoti.Clear();
                    listBox1.Items.Clear();
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parti = line.Split(';');
                        if (parti.Length == 4)
                        {
                            string nomestudente = parti[0];
                            string materia = parti[1];
                            string classe = parti[2];
                            int voto = int.Parse(parti[3]);

                            // Crea un nuovo oggetto voti e aggiungilo alla lista
                            voti nuovoVoto = new voti(nomestudente, materia, classe, voto);
                            listVoti.Add(nuovoVoto);

                            // Aggiungi la stringa corrispondente nella ListBox
                            listBox1.Items.Add($"{nomestudente}; {materia}; {classe}; {voto}");
                        }
                    }
                MessageBox.Show("Lista importata con successo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Nome dello studente da modificare preso da textBox5
            string vecchionomestudente = textBox5.Text;

            // Nuovi valori presi dalle TextBox6, TextBox7, TextBox8, TextBox9
            string nuovonomestudente = textBox6.Text;
            string nuovamateria = textBox7.Text;
            string nuovaclasse = textBox8.Text;
            int nuovovoto = Convert.ToInt32(textBox9.Text);

            // Variabile per verificare se abbiamo trovato lo studente
            bool trovato = false;

            // Scorriamo tutta la lista per trovare lo studente con il nome da modificare
            for (int i = 0; i < listVoti.Count; i++)
            {
                // Se il nome dello studente nella lista corrisponde al nome da modificare
                if (listVoti[i].Nomestudente == vecchionomestudente)
                {
                    // Modifica i valori dell'elemento trovato
                    listVoti[i].Nomestudente = nuovonomestudente;
                    listVoti[i].Materia = nuovamateria;
                    listVoti[i].Classe = nuovaclasse;
                    listVoti[i].Voto = nuovovoto;

                    // Aggiorna la ListBox nello stesso indice
                    listBox1.Items[i] = $"{nuovonomestudente}; {nuovamateria}; {nuovaclasse}; {nuovovoto}";

                    // Imposta la variabile a true per indicare che lo studente è stato trovato
                    trovato = true;

                    // Esci dal ciclo perché lo studente è stato trovato e modificato
                    break;
                }
            }

            // Mostra un messaggio di conferma o di errore se non è stato trovato
            if (trovato)
            {
                MessageBox.Show("Modifica effettuata con successo!");
            }
            else
            {
                MessageBox.Show("Studente non trovato.");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Nome dello studente da cancellare preso dalla textBox10
            string nomeStudenteDaCancellare = textBox10.Text;

            // Variabile per verificare se lo studente è stato trovato
            bool trovato = false;

            // Scorriamo la lista per trovare lo studente da cancellare
            for (int i = 0; i < listVoti.Count; i++)
            {
                // Se il nome dello studente nella lista corrisponde a quello da cancellare
                if (listVoti[i].Nomestudente == nomeStudenteDaCancellare)
                {
                    // Rimuovi l'elemento dalla lista
                    listVoti.RemoveAt(i);

                    // Rimuovi l'elemento dalla ListBox usando lo stesso indice
                    listBox1.Items.RemoveAt(i);

                    // Imposta la variabile a true per indicare che lo studente è stato trovato e cancellato
                    trovato = true;

                    // Esci dal ciclo perché lo studente è stato trovato e cancellato
                    break;
                }
            }

            // Mostra un messaggio di conferma o di errore se lo studente non è stato trovato
            if (trovato)
            {
                MessageBox.Show("Studente cancellato con successo!");
            }
            else
            {
                MessageBox.Show("Studente non trovato.");
            }

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
