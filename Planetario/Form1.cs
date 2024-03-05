using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Planetario
{
    public partial class Form1 : Form
    {
        Planetario planetario = new Planetario();
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Pianeta p1 = new Pianeta(200, Vector.Parse("300;200"), Vector.Parse("1;1"), Color.Orange);
            planetario.Pianeti.Add(p1);
            listBox1.Items.Add(p1);

            Pianeta p2 = new Pianeta(150, Vector.Parse("550;600"), Vector.Parse("1;-1"), Color.DarkGreen);
            planetario.Pianeti.Add(p2);
            listBox1.Items.Add(p2);

            Pianeta p3 = new Pianeta(50, Vector.Parse("400;50"), Vector.Parse("1;0"), Color.LightBlue);
            planetario.Pianeti.Add(p3);
            listBox1.Items.Add(p3);

            Pianeta p4 = new Pianeta(100, Vector.Parse("550;0"), Vector.Parse("-2;2"), Color.DarkRed);
            planetario.Pianeti.Add(p4);
            listBox1.Items.Add(p4);

            Pianeta p5 = new Pianeta(100, Vector.Parse("1050;50"), Vector.Parse("0;2"), Color.Blue);
            planetario.Pianeti.Add(p5);
            listBox1.Items.Add(p5);

            Pianeta p6 = new Pianeta(100, Vector.Parse("1000;50"), Vector.Parse("0;2"), Color.Yellow);
            planetario.Pianeti.Add(p6);
            listBox1.Items.Add(p6);
        } 

        private void timer1_Tick(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            if(comboBox1.SelectedIndex != 0)
            {
                Image i = (Image)BackgroundImage.Clone();
                g.DrawImageUnscaledAndClipped(i, ClientRectangle);
            }
            planetario.Muovi();
            Disegna();
        }

        public void Disegna()
        {
            g = this.CreateGraphics();
            foreach (Pianeta p in planetario.Pianeti)
            {
                SolidBrush Brush = new SolidBrush(p.Colore);
                g.FillEllipse(Brush, (float)p.Posizione.X, (float)p.Posizione.Y, (float)p.Massa / 3, (float)p.Massa / 3);
            }
        }

        //bottone Avvia
        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
            label7.Text = planetario.DeltaT.ToString();
        }
        //bottone Ferma il tempo
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        //bottone Aggiungi Pianeta
        private void button3_Click(object sender, EventArgs e)
        {
            double massa = double.Parse(textBox1.Text);
            Vector posizione = Vector.Parse(textBox2.Text);
            Vector velocita = Vector.Parse(textBox3.Text);
            string color = textBox4.Text;
            Color colore = Color.FromName(color);

            Pianeta p = new Pianeta(massa, posizione, velocita, colore);
            listBox1.Items.Add(p);
            planetario.Pianeti.Add(p);
        }
        //bottone Rimuovi Pianeta
        private void button4_Click(object sender, EventArgs e)
        {
            Pianeta p = (Pianeta)listBox1.SelectedItem;
            planetario.Pianeti.Remove(p);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
        //bottone DeltaT +
        private void button5_Click(object sender, EventArgs e)
        {
            planetario.DeltaT++;
            label7.Text = planetario.DeltaT.ToString();
        }
        //bottone DeltaT -
        private void button6_Click(object sender, EventArgs e)
        {
            planetario.DeltaT--;
            label7.Text = planetario.DeltaT.ToString();
        }
    }
}
