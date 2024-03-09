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

namespace NDP_Projesi
{
    public partial class DikdortgenVsNokta : Form
    {
        cisimler.dikdortgen dikdortgen = new cisimler.dikdortgen();
        cisimler.daire daire = new cisimler.daire();

        cisimler.dikdortgen DonusmusDikdortgen = new cisimler.dikdortgen();
        cisimler.daire DonusmusDaire = new cisimler.daire();

        cisimler.nokta2d nokta = new cisimler.nokta2d();

        Brush MyBrushBlue = new SolidBrush(Color.Blue);
        Brush MyBrushGray = new SolidBrush(Color.Gray);
        Brush MyBrushRed = new SolidBrush(Color.Red);
        public DikdortgenVsNokta()
        {
            InitializeComponent();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
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
                FormFonksiyonları.DikdortgenCiz(DonusmusDikdortgen, minGraphics, MyBrushBlue);
                FormFonksiyonları.DaireCiz(DonusmusDaire, minGraphics, MyBrushRed);
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

        private void Cidir_Ve_Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                dikdortgen.M.X = Convert.ToDouble(textBox1.Text);
                dikdortgen.M.Y = Convert.ToDouble(textBox2.Text);
                dikdortgen.KenarY = Convert.ToDouble(textBox3.Text);
                dikdortgen.KenarX = Convert.ToDouble(textBox4.Text);
                DonusmusDikdortgen = FormFonksiyonları.DikdortgenDonustur(dikdortgen);

                nokta.X = Convert.ToDouble(textBox5.Text);
                nokta.Y = Convert.ToDouble(textBox6.Text);
                daire.M.X = Convert.ToDouble(textBox5.Text);
                daire.M.Y = Convert.ToDouble(textBox6.Text);
                daire.R = 0.25;
                DonusmusDaire = FormFonksiyonları.DaireDonustur(daire);
            }
            catch
            {
                MessageBox.Show("Boş Alan Bırakmayınız!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            CizdirVeKaydet();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DonusmusDikdortgen.KenarX = 0;
            DonusmusDikdortgen.KenarY = 0;

            nokta.X = 0;
            nokta.Y = 0;
            DonusmusDaire.R = 0;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            label9.Text = "...........";

            CizdirVeKaydet();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DonusmusDikdortgen.KenarX == 0 || DonusmusDikdortgen.KenarY == 0)
                MessageBox.Show("Anlamlı olmayan veya boş olmayan değerler kullanarak tekrardan deneyin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Question);
            else
                label9.Text = carpismalar.NoktaVsDikdortgen(nokta, dikdortgen);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CizdirVeKaydet();

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CizdirVeKaydet();

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
