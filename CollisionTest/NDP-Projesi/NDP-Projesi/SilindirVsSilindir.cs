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

namespace NDP_Projesi
{
    public partial class SilindirVsSilindir : Form
    {
        Brush MyRedBrush = new SolidBrush(Color.Red);
        Brush MyBlueBrush = new SolidBrush(Color.Blue);
        Brush MyGreenBrush = new SolidBrush(Color.Green);
        Brush MyYellowBrush = new SolidBrush(Color.Yellow);

        cisimler.silindir silindir1 = new cisimler.silindir();
        cisimler.silindir silindir1Donusmus = new cisimler.silindir();

        cisimler.silindir silindir2 = new cisimler.silindir();
        cisimler.silindir silindir2Donusmus = new cisimler.silindir();

        public SilindirVsSilindir()
        {
            InitializeComponent();
        }

        private void Cidir_Ve_Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                silindir1.M.X = Convert.ToDouble(textBox1.Text);
                silindir1.M.Y = Convert.ToDouble(textBox2.Text);
                silindir1.M.Z = Convert.ToDouble(textBox3.Text);
                silindir1.H = Convert.ToDouble(textBox4.Text);
                silindir1.R = Convert.ToDouble(textBox5.Text);

                silindir1Donusmus = FormFonksiyonları.SilindirDonustur(silindir1);

                silindir2.M.X = Convert.ToDouble(textBox6.Text);
                silindir2.M.Y = Convert.ToDouble(textBox7.Text);
                silindir2.M.Z = Convert.ToDouble(textBox8.Text);
                silindir2.H = Convert.ToDouble(textBox9.Text);
                silindir2.R = Convert.ToDouble(textBox10.Text);

                silindir2Donusmus = FormFonksiyonları.SilindirDonustur(silindir2);

                CizdirVeKaydet(MyBlueBrush, MyYellowBrush);

            }
            catch
            {
                MessageBox.Show("Boş Alan Bırakmayınız!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CizdirVeKaydet(Brush brush1, Brush brush2)
        {

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics minGraphics = Graphics.FromImage(bmp);

            if (checkBox2.Checked == true)
            {
                FormFonksiyonları.GridleriCiz3D(minGraphics);
            }
            if (checkBox1.Checked == true)
            {
                FormFonksiyonları.EksenleriCiz3D(minGraphics);
            }

            try
            {
                FormFonksiyonları.SilindirCiz(silindir1Donusmus, minGraphics, brush1);
                FormFonksiyonları.SilindirCiz(silindir2Donusmus, minGraphics, brush2);
            }
            catch
            {
                if (checkBox2.Checked == true)
                {
                    FormFonksiyonları.GridleriCiz3D(minGraphics);
                }

                if (checkBox1.Checked == true)
                {
                    FormFonksiyonları.EksenleriCiz3D(minGraphics);
                }
            }

            pictureBox1.Image = bmp;
            pictureBox1.Update();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CizdirVeKaydet(MyBlueBrush, MyYellowBrush);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CizdirVeKaydet(MyBlueBrush, MyYellowBrush);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            label9.Text = "............";
            checkBox1.Checked = false;
            checkBox2.Checked = false;

            silindir1Donusmus = new silindir(new nokta3d(0, 0, 0), 0, 0);
            silindir2Donusmus = new silindir(new nokta3d(0, 0, 0), 0, 0);

            CizdirVeKaydet(MyBlueBrush, MyYellowBrush);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (silindir1Donusmus.R == 0 || silindir1Donusmus.H == 0 || silindir2Donusmus.R == 0 || silindir2Donusmus.H == 0)
            {
                MessageBox.Show("Anlamlı olmayan veya boş olmayan değerler kullanarak tekrardan deneyin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                label9.Text = carpismalar.SilindirVsSilindir(silindir1, silindir2);

                if (carpismalar.SilindirVsSilindir(silindir1, silindir2) == "Çarpışma Vardır")
                {
                    CizdirVeKaydet(MyRedBrush, MyRedBrush);
                }
                else
                {
                    CizdirVeKaydet(MyGreenBrush, MyGreenBrush);
                }
            }
        }
    }
}
