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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace NDP_Projesi
{
    public partial class DikdortgenVsDikdortgen : Form
    {

        cisimler.dikdortgen dikdortgen = new cisimler.dikdortgen();
        cisimler.dikdortgen DonusmusDikdortgen = new cisimler.dikdortgen();

        cisimler.dikdortgen dikdortgen1 = new cisimler.dikdortgen();
        cisimler.dikdortgen DonusmusDikdortgen1 = new cisimler.dikdortgen();

        Brush MyBrushBlue = new SolidBrush(Color.Blue);
        Brush MyBrushRed = new SolidBrush(Color.Red);

        public DikdortgenVsDikdortgen()
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
                dikdortgen.M.X = Convert.ToDouble(textBox1.Text);
                dikdortgen.M.Y = Convert.ToDouble(textBox2.Text);
                dikdortgen.KenarY = Convert.ToDouble(textBox3.Text);
                dikdortgen.KenarX = Convert.ToDouble(textBox4.Text);
                DonusmusDikdortgen = FormFonksiyonları.DikdortgenDonustur(dikdortgen);

                dikdortgen1.M.X = Convert.ToDouble(textBox5.Text);
                dikdortgen1.M.Y = Convert.ToDouble(textBox6.Text);
                dikdortgen1.KenarY = Convert.ToDouble(textBox7.Text);
                dikdortgen1.KenarX = Convert.ToDouble(textBox8.Text);
                DonusmusDikdortgen1 = FormFonksiyonları.DikdortgenDonustur(dikdortgen1);
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
                FormFonksiyonları.DikdortgenCiz(DonusmusDikdortgen, minGraphics, MyBrushRed);
                FormFonksiyonları.DikdortgenCiz(DonusmusDikdortgen1, minGraphics, MyBrushBlue);

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
            if (DonusmusDikdortgen.KenarX == 0 || DonusmusDikdortgen.KenarY == 0 || DonusmusDikdortgen1.KenarX == 0 || DonusmusDikdortgen1.KenarY == 0)
                MessageBox.Show("Anlamlı olmayan veya boş olmayan değerler kullanarak tekrardan deneyin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Question);
            else
                label9.Text = carpismalar.DikdortgenVsDikdortgen(dikdortgen1, dikdortgen);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DonusmusDikdortgen.KenarX = 0;
            DonusmusDikdortgen.KenarY = 0;

            DonusmusDikdortgen1.KenarX = 0;
            DonusmusDikdortgen1.KenarY = 0;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            label9.Text = "..........";

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
