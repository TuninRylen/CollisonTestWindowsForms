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
    public partial class DikdortgenPrizmaVsDikdortgenPrizma : Form
    {

        Brush MyRedBrush = new SolidBrush(Color.Red);
        Brush MyBlueBrush = new SolidBrush(Color.Blue);
        Brush MyGreenBrush = new SolidBrush(Color.Green);
        Brush MyYellowBrush = new SolidBrush(Color.Yellow);

        cisimler.dPrizması dPrizması1 = new cisimler.dPrizması();
        cisimler.dPrizması dPrizması1Donusmus = new cisimler.dPrizması();

        cisimler.dPrizması dPrizması2 = new cisimler.dPrizması();
        cisimler.dPrizması dPrizması2Donusmus = new cisimler.dPrizması();

        public DikdortgenPrizmaVsDikdortgenPrizma()
        {
            InitializeComponent();
        }

        private void Cidir_Ve_Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                dPrizması1.M.X = Convert.ToDouble(textBox1.Text);
                dPrizması1.M.Y = Convert.ToDouble(textBox2.Text);
                dPrizması1.M.Z = Convert.ToDouble(textBox3.Text);
                dPrizması1.KenarX = Convert.ToDouble(textBox4.Text);
                dPrizması1.KenarY = Convert.ToDouble(textBox5.Text);
                dPrizması1.KenarZ = Convert.ToDouble(textBox6.Text);

                dPrizması1Donusmus = FormFonksiyonları.DPrizmasıDonustur(dPrizması1);

                dPrizması2.M.X = Convert.ToDouble(textBox7.Text);
                dPrizması2.M.Y = Convert.ToDouble(textBox8.Text);
                dPrizması2.M.Z = Convert.ToDouble(textBox9.Text);
                dPrizması2.KenarX = Convert.ToDouble(textBox10.Text);
                dPrizması2.KenarY = Convert.ToDouble(textBox11.Text);
                dPrizması2.KenarZ = Convert.ToDouble(textBox12.Text);

                dPrizması2Donusmus = FormFonksiyonları.DPrizmasıDonustur(dPrizması2);

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
                FormFonksiyonları.DPrizmaCiz(dPrizması1Donusmus, minGraphics, brush1);
                FormFonksiyonları.DPrizmaCiz(dPrizması2Donusmus, minGraphics, brush2);
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
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            label9.Text = "............";
            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dPrizması1Donusmus = new dPrizması(new nokta3d(0, 0, 0), 0, 0, 0);
            dPrizması2Donusmus = new dPrizması(new nokta3d(0, 0, 0), 0, 0, 0);

            CizdirVeKaydet(MyBlueBrush, MyYellowBrush);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dPrizması2.KenarX == 0 || dPrizması2.KenarY == 0 || dPrizması2.KenarZ == 0 || dPrizması1.KenarX == 0 || dPrizması1.KenarY == 0 || dPrizması1.KenarZ == 0)
            {
                MessageBox.Show("Anlamlı olmayan veya boş olmayan değerler kullanarak tekrardan deneyin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                label9.Text = carpismalar.DPrizmaVsDPrizma(dPrizması1, dPrizması2);

                if (carpismalar.DPrizmaVsDPrizma(dPrizması1, dPrizması2) == "Çarpışma Vardır")
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
