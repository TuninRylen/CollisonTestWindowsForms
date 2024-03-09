using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NDP_Projesi.cisimler;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NDP_Projesi
{
    public partial class DaireVsDaire : Form
    {
        cisimler.daire daire1 = new cisimler.daire();
        cisimler.daire daire2 = new cisimler.daire();

        cisimler.daire DonusmusDaire1 = new cisimler.daire();
        cisimler.daire DonusmusDaire2 = new cisimler.daire();

        Brush MyBrushBlue = new SolidBrush(Color.Blue);
        Brush MyBrushGray = new SolidBrush(Color.Gray);
        Brush MyBrushRed = new SolidBrush(Color.Red);
        public DaireVsDaire()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Cidir_Ve_Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                daire1.M.X = Convert.ToDouble(textBox1.Text);
                daire1.M.Y = Convert.ToDouble(textBox2.Text);
                daire1.R = Convert.ToDouble(textBox3.Text);
                DonusmusDaire1 = FormFonksiyonları.DaireDonustur(daire1);

                daire2.M.X = Convert.ToDouble(textBox5.Text);
                daire2.M.Y = Convert.ToDouble(textBox6.Text);
                daire2.R = Convert.ToDouble(textBox7.Text);
                DonusmusDaire2 = FormFonksiyonları.DaireDonustur(daire2);
            }
            catch
            {
                MessageBox.Show("Boş Alan Bırakmayınız!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            CizdirVeKaydet();
        }

        public void CizdirVeKaydet()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics minGraphics = Graphics.FromImage(bmp);

            if (checkBox2.Checked == true)
            {
                FormFonksiyonları.GridleriCiz2D(minGraphics);
            }
            if (checkBox1.Checked == true)
            {
                FormFonksiyonları.EksenleriCiz2D(minGraphics);
            }

            try
            {
                FormFonksiyonları.DaireCiz(DonusmusDaire1, minGraphics, MyBrushRed);
                FormFonksiyonları.DaireCiz(DonusmusDaire2, minGraphics, MyBrushBlue);

            }
            catch
            {
                if (checkBox2.Checked == true)
                {
                    FormFonksiyonları.GridleriCiz2D(minGraphics);
                }

                if (checkBox1.Checked == true)
                {
                    FormFonksiyonları.EksenleriCiz2D(minGraphics);
                }
            }
            pictureBox1.Image = bmp;
            pictureBox1.Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DonusmusDaire1.R == 0 || DonusmusDaire2.R == 0)
            {
                MessageBox.Show("Anlamlı olmayan veya boş olmayan değerler kullanarak tekrardan deneyin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            else
            {
                label9.Text = carpismalar.DaireVsDaire(daire1, daire2);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            label9.Text = "............";
   
            DonusmusDaire1.R = 0;

            DonusmusDaire2.R = 0;

            CizdirVeKaydet();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CizdirVeKaydet();

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CizdirVeKaydet();

        }
    }
}
