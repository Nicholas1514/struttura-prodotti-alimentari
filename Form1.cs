using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void salva_Click(object sender, EventArgs e)
        {
            p[dim].nome = nome.Text;
            p[dim].prezzo = float.Parse(prezzo.Text);
            dim++;
            visualizza(p);
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Modifica(p);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Cancellazione(p);
            visualizza (p); 
        }
        private void button3_Click(object sender, EventArgs e)
        {
           Sommaprezzi(p);

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Sconto(p);
            visualizza(p);
        }
        //funzioni di servizio
        public string prodString(prodotto p)
        {
            return "Nome : " + p.nome + "  " + "Prezzo : " + p.prezzo.ToString();
        }
        public void visualizza(prodotto[] pp)
        {
            listView1.Items.Clear();
            for(int i = 0; i < dim; i++)
            {
                listView1.Items.Add(prodString(p[i]));
            }
           
        }
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
                    MessageBox.Show("ELEMENTO MODIFICATO");


                }
                
            }
            if(trova == false)
            {
                MessageBox.Show("ELEMENTO NON TROVATO");
            }
            return trova;
            
        }
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
                    MessageBox.Show("ELEMENTO CANCELLATO");
                    
                    
                    
                }
            }
            if(cerca == false)
            {
                MessageBox.Show("ELEMENTO NON TROVATO");
            }
            return cerca;
        }
        public void Sommaprezzi(prodotto [] pp)
        {
            float somma = 0;
            for(int i = 0; i < dim; i++)
            {
                somma = somma + p[i].prezzo;
            }
            MessageBox.Show("Il totale è:" + "\n" + somma + " €");
          
        }
        public void Sconto(prodotto [] pp)
        {
           
                for (int i = 0; i < dim; i++)
                {
                    p[i].prezzo = (p[i].prezzo * int.Parse(textBox5.Text)) / 100;
                }
            
          
           
           
        }

     
    }
}
