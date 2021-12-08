using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Hafıza_Geliştirici
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread th = new Thread(yükleniyor);th.Start();
        }
        private void yükleniyor()
        {
            button3.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            lvlcounter.Text = Properties.Settings.Default["LEVEL"].ToString();
            kısımcounter.Text = Properties.Settings.Default["KISIM"].ToString();
            Properties.Settings.Default.Save();
            Thread.Sleep(3000);
            button3.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
        }
        private void panelsıfırla()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel)
                c.BackColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(oyun);
            th.Start();

        }
        int agircekim = 0;

        private void panellerigizle()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel)
                    c.Visible = false;
            }
        }

        private void panelsec(int id,int panel)
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel)
                {
                    if (c.Name == "l"+panel+"_p" + id.ToString())
                    {
                        c.BackColor = Color.Blue;
                        break;
                    }
                }
            }
        }
        private void oyun()
        {
            panellerigizle();
            if (kısımcounter.Text == "33")
            {
                webBrowser1.Visible = true;
                label4.Text = "BİTİRİLDİ";
                kısımcounter.Text = "32";
            }
            else
            {
                switch (lvlcounter.Text)
                {
                    case "1":
                        l1_p1.Visible = true;
                        break;
                    case "2":
                        l2_p1.Visible = true;
                        l2_p2.Visible = true;
                        break;
                    case "3":
                        l3_p1.Visible = true;
                        l3_p2.Visible = true;
                        l3_p3.Visible = true;
                        l3_p4.Visible = true;
                        break;
                    case "4":
                        l4_p1.Visible = true;
                        l4_p2.Visible = true;
                        l4_p3.Visible = true;
                        l4_p4.Visible = true;
                        l4_p5.Visible = true;
                        l4_p6.Visible = true;
                        l4_p7.Visible = true;
                        l4_p8.Visible = true;
                        break;
                    case "5":
                        l5_p1.Visible = true;
                        l5_p2.Visible = true;
                        l5_p3.Visible = true;
                        l5_p4.Visible = true;
                        l5_p5.Visible = true;
                        l5_p6.Visible = true;
                        l5_p7.Visible = true;
                        l5_p8.Visible = true;
                        l5_p9.Visible = true;
                        l5_p10.Visible = true;
                        l5_p11.Visible = true;
                        l5_p12.Visible = true;
                        l5_p13.Visible = true;
                        l5_p14.Visible = true;
                        l5_p15.Visible = true;
                        l5_p16.Visible = true;
                        break;
                    case "6":
                        l6_p1.Visible = true;
                        l6_p2.Visible = true;
                        l6_p3.Visible = true;
                        l6_p4.Visible = true;
                        l6_p5.Visible = true;
                        l6_p6.Visible = true;
                        l6_p7.Visible = true;
                        l6_p8.Visible = true;
                        l6_p9.Visible = true;
                        l6_p10.Visible = true;
                        l6_p11.Visible = true;
                        l6_p12.Visible = true;
                        l6_p13.Visible = true;
                        l6_p14.Visible = true;
                        l6_p15.Visible = true;
                        l6_p16.Visible = true;
                        l6_p17.Visible = true;
                        l6_p18.Visible = true;
                        l6_p19.Visible = true;
                        l6_p20.Visible = true;
                        l6_p21.Visible = true;
                        l6_p22.Visible = true;
                        l6_p23.Visible = true;
                        l6_p24.Visible = true;
                        l6_p25.Visible = true;
                        l6_p26.Visible = true;
                        l6_p27.Visible = true;
                        l6_p28.Visible = true;
                        l6_p29.Visible = true;
                        l6_p30.Visible = true;
                        l6_p31.Visible = true;
                        l6_p32.Visible = true;
                        break;
                } //visible
                label4.Text = "İZLEYİCİ";
                label2.Visible = false;
                label3.Visible = false;
                button3.Visible = false;
                int kısım = Convert.ToInt32(kısımcounter.Text);
                int level = Convert.ToInt32(lvlcounter.Text);
                List<int> hamleler = new List<int>();
                Random rastgele = new Random();
                Thread.Sleep(200);
                foreach (Control c in this.Controls)
                {
                    if (c is Panel)
                        c.Enabled = false;
                }
                for (int i = Convert.ToInt32(Math.Pow(2, Convert.ToInt32(lvlcounter.Text) - 1)); i >= 1; i--)
                {
                    hamleler.Add(i);
                }
                hamleler = hamleler.OrderBy(a => Guid.NewGuid()).ToList();
                for (int i = 0; i < kısım; i++)
                {
                    panelsec(hamleler[i], level);
                    Thread.Sleep(rastgele.Next(500, agircekim + 800));
                }
                panelsıfırla();
                foreach (Control c in this.Controls)
                {
                    if (c is Panel)
                        c.Enabled = true;
                }
                label4.Text = "OYUNCU";

                for (; ; )
                {
                    if (kontrol == true)
                    {
                        this.Dispose();
                        break;
                    }
                    if (hamlesayisi != 0 && hamle != 0)
                    {
                        try
                        {
                            if (hamleler[hamlesayisi - 1] == hamle)
                            {
                                panelsec(hamle, level);
                                if (kısım == hamlesayisi)
                                {
                                    if (hamleler[hamlesayisi - 1] == hamle)
                                    {
                                        hamlesayisi = 0;
                                        hamle = 0;
                                        hamleler.Clear();
                                        label2.Visible = true;
                                        label3.Visible = true;
                                        button3.Visible = true;
                                        panelsıfırla();
                                        label3.Text = "Kazandın.";
                                        if (kısımcounter.Text == Math.Pow(2, Convert.ToInt32(lvlcounter.Text) - 1).ToString())
                                        {
                                            lvlcounter.Text = Convert.ToString(Convert.ToInt32(lvlcounter.Text) + 1);
                                            kısımcounter.Text = "1";
                                        }
                                        else
                                            kısımcounter.Text = Convert.ToString(Convert.ToInt32(kısımcounter.Text) + 1);
                                        agircekim = 0;
                                        button3.PerformClick();
                                    }
                                    else
                                    {
                                        hamlesayisi = 0;
                                        hamle = 0;
                                        hamleler.Clear();
                                        panelsıfırla();
                                        label3.Text = "Kaybettin.";
                                        agircekim += 100;
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                hamlesayisi = 0;
                                hamle = 0;
                                hamleler.Clear();
                                panelsıfırla();
                                label2.Visible = true;
                                label3.Visible = true;
                                button3.Visible = true;
                                label3.Text = "Kaybettin.";
                                agircekim += 100;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            hamlesayisi = 0;
                            hamle = 0;
                            hamleler.Clear();
                            panelsıfırla();
                            label2.Visible = true;
                            label3.Visible = true;
                            button3.Visible = true;
                            label3.Text = "Kaybettin.";
                            agircekim += 100;
                            break;
                        }
                    }
                }
                label4.Text = "BEKLENİYOR";
                Thread.Sleep(100);
            }
        }

        int hamlesayisi = 0;
        int hamle = 0;
        private void p1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p1_Click(object sender, EventArgs e)
        {
            Panel B = (Panel)sender;
            int name = Convert.ToInt32(B.Name.Split('p')[1]);
            hamlesayisi++;
            hamle = name;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Thread th = new Thread(oyun);
            th.Start();
        }
        bool kontrol = false;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default["LEVEL"] = lvlcounter.Text;
            Properties.Settings.Default["KISIM"] = kısımcounter.Text;
            Properties.Settings.Default.Save();
            kontrol = true;
        }
    }
}
