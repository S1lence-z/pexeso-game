using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Security.Cryptography;

namespace Pexeso_DU
{
    public partial class Form1 : Form
    {
        string[] abeceda = { "A", "Á", "B", "C", "È", "D", "Ï", "E", "É", "Ì", "F", "G", "H",
            "I", "Í", "J", "K", "L", "M", "N", "Ò", "O", "Ó", "P", "Q", "R", "Ø", "S", "Š", "T",
            "", "U", "Ú", "Ù", "V", "W", "X", "Y", "İ", "Z", "" };

        (int radky, int sloupce) pocet_karet = (0, 0);

        (int, int) restart_parametry = (0, 0);

        int odsazeni = 50;

        int pocet_karet_okna = 800;

        static List<Button> vygenerovane_karty = new();

        // globální promìnné, které mi budou rozhodovat o vıhøe
        List<Button> vybrane_karty = new();
        int prave_otocenych = 0;
        int celkem_otocenych = 0;

        enum aktualniStav { start, hra, vyhra };

        aktualniStav stav;

        bool warning_status = true;
        string warning_text = "Nejprve prosím vyberte rozmìry hrací plochy!";

        static List<int> Zamichej(List<int> lst)
        {
            Random random = new Random();
            int random_cislo;
            int pointer = lst.Count - 1;
            List<int> zamichany_lst = new();

            while (pointer >= 0)
            {
                random_cislo = random.Next();
                zamichany_lst.Add(lst[(pointer + random_cislo) % lst.Count]);
                lst.RemoveAt((pointer + random_cislo) % lst.Count);
                pointer--;
            }
            return zamichany_lst;
        }

        void vytvorPexeso()
        {
            if (pocet_karet == (0, 0))
            {
                MessageBox.Show(
                    warning_text,
                    "Varování",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                warning_status = false;
                return;
            }

            // vytvoøím si list dvojic èísel, budou to pak pozice v poli abeceda, tedy jednotlivá písmena
            List<int> karty_jmena = new List<int>();

            for (int i = 0; i < (pocet_karet.radky * pocet_karet.sloupce) / 2; i++)
            {
                karty_jmena.Add(i);
                karty_jmena.Add(i);
            }
            karty_jmena = Zamichej(karty_jmena);

            // pozice karet na místa
            int karta_x = (pocet_karet_okna - odsazeni) / pocet_karet.radky;
            int karta_y = (pocet_karet_okna - odsazeni - 10) / pocet_karet.sloupce;

            // loop na vytvoøení jednotlivıch karet
            for (int i = 0; i < pocet_karet.radky; i++)
            {
                for (int j = 0; j < pocet_karet.sloupce; j++)
                {
                    Button karta = new Button();

                    karta.Width = karta_x - 5;
                    karta.Height = karta_y - 5;
                    karta.Left = i * karta_x + 20;
                    karta.Top = j * karta_y;

                    int hodnota_karty = karty_jmena[karty_jmena.Count - 1];
                    karty_jmena.RemoveAt(karty_jmena.Count - 1);
                    string pismeno = abeceda[hodnota_karty];

                    Atributy noveAtributy = new(pismeno);

                    karta.Text = noveAtributy.skryty_napis;
                    karta.Tag = noveAtributy;

                    karta.Parent = this;
                    karta.Click += karta_Click!;
                    karta.Enabled = true;
                    karta.Visible = true;
                    karta.BackColor = Color.Yellow;
                    karta.Font = new Font("Arial", 20);

                    vygenerovane_karty.Add(karta);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximumSize = new Size(pocet_karet_okna, pocet_karet_okna);
            this.MinimumSize = new Size(pocet_karet_okna, pocet_karet_okna);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightSkyBlue;
            label1.Text = "Vybrané rozmìry: " + pocet_karet.radky + " x " + pocet_karet.sloupce;
            NastavStav(aktualniStav.start);
        }

        void NastavStav(aktualniStav novy_stav)
        {
            switch (novy_stav)
            {
                case aktualniStav.start:
                    pocet_karet = (0, 0);
                    smallest.Visible = true;
                    middle.Visible = true;
                    largest.Visible = true;
                    start.Visible = true;
                    label1.Visible = true;
                    button5.Visible = false;
                    button6.Visible = false;

                    break;

                case aktualniStav.hra:
                    smallest.Visible = false;
                    middle.Visible = false;
                    largest.Visible = false;
                    start.Visible = false;
                    label1.Visible = false;
                    button5.Visible = false;
                    button6.Visible = false;
                    if (stav == aktualniStav.start || stav == aktualniStav.vyhra)
                    {
                        vytvorPexeso();
                    }
                    break;

                case aktualniStav.vyhra:
                    smallest.Visible = false;
                    middle.Visible = false;
                    largest.Visible = false;
                    start.Visible = false;
                    label1.Visible = false;
                    button5.Visible = true;
                    button6.Visible = true;
                    break;

            }
            if (warning_status == false)
            {
                warning_status = true;
                NastavStav(aktualniStav.start);
            }
            else
            {
                stav = novy_stav;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pocet_karet = (6, 4);
            label1.Text = "Vybrané rozmìry: " + pocet_karet.radky + " x " + pocet_karet.sloupce;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pocet_karet = (6, 5);
            label1.Text = "Vybrané rozmìry: " + pocet_karet.radky + " x " + pocet_karet.sloupce;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pocet_karet = (6, 6);
            label1.Text = "Vybrané rozmìry: " + pocet_karet.radky + " x " + pocet_karet.sloupce;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NastavStav(aktualniStav.hra);
        }

        private void karta_Click(object sender, EventArgs e)
        {
            Button tlacitko = (Button)sender;
            Atributy ulozene_atributy = tlacitko.Tag as Atributy;

            if ((ulozene_atributy!.otocene == false) && (prave_otocenych < 2))
            {
                ulozene_atributy.otocene = true;
                tlacitko.BackColor = Color.Brown;
                tlacitko.Text = ulozene_atributy.znak_abecedy;
                vybrane_karty.Add(tlacitko);
                prave_otocenych += 1;
                celkem_otocenych += 1;
            }
            else if ((ulozene_atributy.otocene == true) && (prave_otocenych == 1))
            {
                // zaznamenej klik
            }
            else
            {
                prave_otocenych = 0;

                if (vybrane_karty[0].Text == vybrane_karty[1].Text)
                {
                    for (int i = 0; i < vybrane_karty.Count; i++)
                    {
                        vybrane_karty[i].BackColor = Color.Red;
                        vybrane_karty[i].Click -= karta_Click!;
                    }
                    vybrane_karty.Clear();

                    if (celkem_otocenych == (pocet_karet.radky * pocet_karet.sloupce))
                    {
                        foreach (var tlaciko in vygenerovane_karty)
                        {
                            tlaciko.Dispose();
                        }
                        vygenerovane_karty.Clear();
                        celkem_otocenych = 0;

                        restart_parametry = pocet_karet;

                        NastavStav(aktualniStav.vyhra);

                    }
                }
                else
                {
                    for (int i = 0; i < vybrane_karty.Count; i++)
                    {
                        Atributy jejichVlastnosti = vybrane_karty[i].Tag as Atributy;
                        jejichVlastnosti!.otocene = false;
                        vybrane_karty[i].Text = jejichVlastnosti.skryty_napis;
                        vybrane_karty[i].BackColor = Color.Yellow;
                    }
                    celkem_otocenych -= 2;
                    vybrane_karty.Clear();
                }

            }

        }

        public class Atributy
        {
            public bool otocene;
            public string? znak_abecedy;
            public string? skryty_napis;

            public Atributy(string? znak)
            {
                this.znak_abecedy = znak;
                this.otocene = false;
                this.skryty_napis = " ";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NastavStav(aktualniStav.start);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pocet_karet = restart_parametry;
            NastavStav(aktualniStav.hra);
        }
    }
}