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

namespace _13Feladat
{
    public partial class frmFo : Form
    {
        private List<int> Lista = new List<int>();
        private bool hiba = false;
        public frmFo()
        {
            InitializeComponent();
        }

        private void btnBeolvas_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader olvas = new StreamReader("adatok.txt");
                while (!olvas.EndOfStream)
                {
                    try
                    {
                        Lista.Add(int.Parse(olvas.ReadLine()));
                    }
                    catch (Exception)
                    {
                        hiba = true;
                    }
                    
                }
                olvas.Close();
                if (hiba)
                {
                    tslblLeiras.Text = $"A fájl hibás adatot is tartalmazott, ami figyelmen kívül lett hagyva.";
                }else tslblLeiras.Text = "A beolvasás sikeres, feloldódott a tömbi gomb is.";
                btnElso.Enabled = true;
                btnMasodik.Enabled = true;
                btnHarmadik.Enabled = true;
                btnNegyedik.Enabled = true;
                btnOtodik.Enabled = true;
                btnHatodik.Enabled = true;
                btnBeolvas.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Váratlan hiba történt! A program leáll. ({ex})", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btnMagyarazat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Összegzés tétele -> átlag; 2. Hányadik a 7143; " +
                "3. Hányszor fordul elő az 1170; 4. Van-e benne 8876; 5. Minimum; 6. Maximum",
                "Leírás", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBezar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnElso_Click(object sender, EventArgs e)
        {
            double osszeg, atlag, db;
            osszeg = 0; atlag = 0; db = 0;
            foreach (var l in Lista)
            {
                osszeg += l;
                db++;
            }
            atlag = osszeg / db;
            MessageBox.Show($"1. Feladat: {Math.Round(atlag, 2)}", "1.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMasodik_Click(object sender, EventArgs e)
        {
            if (!Lista.Contains(7143))
            {
                MessageBox.Show("A lista nem tartalmaz ilyen számot.");
            }
            else
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    if (Lista[i] == 7143)
                    {
                        MessageBox.Show($"2. Feladat: A 7143 a {i + 1}.", "2.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnHarmadik_Click(object sender, EventArgs e)
        {
            int hanyszor = 0;
            foreach (var l in Lista)
            {
                if (l == 1170)
                {
                    hanyszor++;
                }
            }
            MessageBox.Show($"Az 1170 {hanyszor}-szer/szor fordul elő", "3.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNegyedik_Click(object sender, EventArgs e)
        {
            if (Lista.Contains(8876))
            {
                MessageBox.Show($"A 8876-ot tartalmazza az adatok.txt", "4.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else MessageBox.Show($"A 8876-ot nem tartalmazza az adatok.txt", "4.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOtodik_Click(object sender, EventArgs e)
        {
            int minimum = Lista[0];
            for (int i = 0; i < Lista.Count; i++)
            {
                if (minimum > Lista[i])
                {
                    minimum = Lista[i];
                }
            }
            MessageBox.Show($"A minimum {minimum}", "5.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHatodik_Click(object sender, EventArgs e)
        {
            int maximum = Lista[0];
            for (int i = 0; i < Lista.Count; i++)
            {
                if (maximum < Lista[i])
                {
                    maximum = Lista[i];
                }
            }
            MessageBox.Show($"A maximum {maximum}", "5.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
