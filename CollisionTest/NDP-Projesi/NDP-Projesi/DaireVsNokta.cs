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
    public partial class DaireVsNokta : Form
    {
        cisimler.daire daire1 = new cisimler.daire();
        cisimler.daire daire2 = new cisimler.daire();

        cisimler.daire DonusmusDaire1 = new cisimler.daire();
        cisimler.daire DonusmusDaire2 = new cisimler.daire();

        cisimler.nokta2d nokta = new cisimler.nokta2d();

        Brush MyBrushBlue = new SolidBrush(Color.Blue);
        Brush MyBrushGray = new SolidBrush(Color.Gray);
        Brush MyBrushRed = new SolidBrush(Color.Red);
        public DaireVsNokta()
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
                FormFonksiyonları.DaireCiz(DonusmusDaire1, minGraphics, MyBrushBlue);
                FormFonksiyonları.DaireCiz(DonusmusDaire2, minGraphics, MyBrushRed);
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
                daire1.M.X = Convert.ToDouble(textBox1.Text);
                daire1.M.Y = Convert.ToDouble(textBox2.Text);
                daire1.R = Convert.ToDouble(textBox3.Text);
                DonusmusDaire1 = FormFonksiyonları.DaireDonustur(daire1);

                nokta.X = Convert.ToDouble(textBox5.Text);
                nokta.Y = Convert.ToDouble(textBox6.Text);
                daire2.M.X = Convert.ToDouble(textBox5.Text);
                daire2.M.Y = Convert.ToDouble(textBox6.Text);
                daire2.R = 0.25;
                DonusmusDaire2 = FormFonksiyonları.DaireDonustur(daire2);
            }
            catch
            {
                MessageBox.Show("Boş Alan Bırakmayınız!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            CizdirVeKaydet();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            label9.Text = "............";

            nokta.X = 0;
            nokta.Y = 0;
            DonusmusDaire1.R = 0;
            DonusmusDaire2.R = 0;

            CizdirVeKaydet();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DonusmusDaire1.R == 0)
                MessageBox.Show("Anlamlı olmayan veya boş olmayan değerler kullanarak tekrardan deneyin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Question);
            else
                label9.Text = carpismalar.NoktaVsDaire(nokta, daire1);
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
