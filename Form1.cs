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


namespace struttura
{
    public partial class Form1 : Form
    {
        public struct prodotto
        {
            public string nome;
            public float prezzo;
        }
        public prodotto [] p;
        public int dim;
        public Form1()
        {
            InitializeComponent();
            p = new prodotto [100];
            dim = 0;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

        }

        private void salva_Click(object sender, EventArgs e)
        {
            if(dim <= 100)
            {
                p[dim].nome = nome.Text;
                p[dim].prezzo = float.Parse(prezzo.Text);
                dim++;
                visualizza(p);
            }
            else
            {
                MessageBox.Show("L'array è pieno");
            }

            //Task.Delay(5000).Wait();
            //listView1.Visible = false;
            //Task.Delay(5000).Wait();
            //listView1.Visible = true;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(Modifica(p) == true)
            {
                MessageBox.Show("Elemento modificato");
            }
            else
            {
                MessageBox.Show("Elemento non trovato");
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(Cancellazione(p) == true)
            {
                visualizza(p);
                MessageBox.Show("Elemento cancellato");
            }
            else
            {
                MessageBox.Show("Elemento non trovato");
            }
            visualizza (p); 
        }
        private void button3_Click(object sender, EventArgs e)
        {
           MessageBox.Show("Il totale dei prezzi è: " + Sommaprezzi(p).ToString() + " €");
          

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Sconto(p);
            visualizza(p);
            MessageBox.Show("Prezzi aggiornati");
        }

       
        private void label10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se inserisci uno sconto negativo i prezzi verranno diminuiti di quella percentuale." + "\n" +

                "Altrimenti se inserisci uno sconto positivo i prezzi verranno aumentati di quella percentuale"
                );
        }
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il prezzo massimo è: " + Max(p).ToString() + "  € " + "Il prezzo minimo è: " + Min(p) + " €"); 
        }

        //funzioni di servizio

        //funzione per visualizzare nome e prezzo dei prodotti
        public string prodString(prodotto p)
        {
            return "Nome : " + p.nome + "  " + "Prezzo : " + p.prezzo.ToString() + " €";
        }
        //funzione visualizza elenco prodotti
        public void visualizza(prodotto[] pp)
        {
            listView1.Items.Clear();
            for(int i = 0; i < dim; i++)
            {
                listView1.Items.Add(prodString(p[i]));
            }
           
        }
        //funzione modifica
        public bool Modifica(prodotto[] pp)
        {
            bool trova = false;
            for(int i = 0; i < dim; i++)
            {
                if(p[i].nome == textBox1.Text)
                {
                    p[i].nome = textBox2.Text;
                    p[i].prezzo = float.Parse(textBox3.Text);
                    visualizza(p);
                    trova = true;
                   


                }
                
            }
           
            return trova;
            
        }
        //funzione cancellazione
        public bool Cancellazione(prodotto[] pp)
        {
            bool cerca = false;
            for(int i = 0; i < dim; i++)
            {
               if(p[i].nome == textBox4.Text)
                {
                    p[i] = p[dim-1];
                    dim--;
                    cerca = true;
                   
                    
                    
                    
                }
            }
           
            return cerca;
        }
        //funzione somma dei prezzi dei prodotti
        public float Sommaprezzi(prodotto [] pp)
        {
            float somma = 0;
            for(int i = 0; i < dim; i++)
            {
                somma = somma + p[i].prezzo;
            }
            return somma;
           
          
        }
        //funzione sconto / aumento dei prodotti
        public void Sconto(prodotto [] pp)
        {
           
           if(int.Parse(textBox5.Text) < 0)
            {
                for (int i = 0; i < dim; i++)
                {
                    p[i].prezzo = p[i].prezzo + (p[i].prezzo * int.Parse(textBox5.Text)) / 100;
                }
            }
            else
            {
                for (int i = 0; i < dim; i++)
                {
                    p[i].prezzo = p[i].prezzo + (p[i].prezzo * int.Parse(textBox5.Text)) / 100;
                }
            }
            
         
            
          
           
           
        }
        //funzione ricerca minimo e massimo prezzo
        public float Max(prodotto[] pp)
        {
            float min = 0;
            float max = 0;
            for(int i = 0; i < dim; i++)
            {
                if(i == 0)
                {
                    min = p[i].prezzo;
                    max = p[i].prezzo;
                }
                if(p[i].prezzo < min)
                {
                    min = p[i].prezzo;
                    
                }
                if(p[i].prezzo > max)
                {
                    max = p[i].prezzo;
                   
                }
             
            }
            return max;
        }
        public float Min(prodotto[] pp)
        {
            float min = 0;
            float max = 0;
            for (int i = 0; i < dim; i++)
            {
                if (i == 0)
                {
                    min = p[i].prezzo;
                    max = p[i].prezzo;
                }
                if (p[i].prezzo < min)
                {
                    min = p[i].prezzo;

                }
                if (p[i].prezzo > max)
                {
                    max = p[i].prezzo;

                }

            }
            return min;
        }

      
    }
}
