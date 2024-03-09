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
    public partial class DuzlemVsDikdortgenPrizma : Form
    {
        Brush MyRedBrush = new SolidBrush(Color.Red);
        Brush MyBlueBrush = new SolidBrush(Color.Blue);
        Brush MyGreenBrush = new SolidBrush(Color.Green);
        Brush MyYellowBrush = new SolidBrush(Color.Yellow);

        cisimler.dPrizması dPrizması = new cisimler.dPrizması();
        cisimler.dPrizması dPrizmasıDonusmus = new cisimler.dPrizması();

        cisimler.düzlem duzlem = new cisimler.düzlem();
        cisimler.düzlem duzlemDonusmus = new cisimler.düzlem(); 

        public DuzlemVsDikdortgenPrizma()
        {
            InitializeComponent();
        }

        private void Cidir_Ve_Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                dPrizması.M.X = Convert.ToDouble(textBox1.Text);
                dPrizması.M.Y = Convert.ToDouble(textBox2.Text);
                dPrizması.M.Z = Convert.ToDouble(textBox3.Text);
                dPrizması.KenarX = Convert.ToDouble(textBox4.Text);
                dPrizması.KenarY = Convert.ToDouble(textBox5.Text);
                dPrizması.KenarZ = Convert.ToDouble(textBox6.Text);

                dPrizmasıDonusmus = FormFonksiyonları.DPrizmasıDonustur(dPrizması);

                duzlem.DüzlemÜzerindeNokta1.X = Convert.ToDouble(textBox7.Text);
                duzlem.DüzlemÜzerindeNokta1.Y = Convert.ToDouble(textBox8.Text);
                duzlem.DüzlemÜzerindeNokta1.Z = Convert.ToDouble(textBox9.Text);
                nokta3d dNokta1 = new nokta3d(duzlem.DüzlemÜzerindeNokta1.X, duzlem.DüzlemÜzerindeNokta1.Y, duzlem.DüzlemÜzerindeNokta1.Z);

                duzlem.DüzlemÜzerindeNokta2.X = Convert.ToDouble(textBox10.Text);
                duzlem.DüzlemÜzerindeNokta2.Y = Convert.ToDouble(textBox11.Text);
                duzlem.DüzlemÜzerindeNokta2.Z = Convert.ToDouble(textBox12.Text);
                nokta3d dNokta2 = new nokta3d(duzlem.DüzlemÜzerindeNokta2.X, duzlem.DüzlemÜzerindeNokta2.Y, duzlem.DüzlemÜzerindeNokta2.Z);

                duzlem.DüzlemÜzerindeNokta3.X = Convert.ToDouble(textBox13.Text);
                duzlem.DüzlemÜzerindeNokta3.Y = Convert.ToDouble(textBox14.Text);
                duzlem.DüzlemÜzerindeNokta3.Z = Convert.ToDouble(textBox15.Text);
                nokta3d dNokta3 = new nokta3d(duzlem.DüzlemÜzerindeNokta3.X, duzlem.DüzlemÜzerindeNokta3.Y, duzlem.DüzlemÜzerindeNokta3.Z);

                duzlem = new cisimler.düzlem(dNokta1,dNokta2,dNokta3);

                duzlemDonusmus = FormFonksiyonları.DuzlemDonustur(duzlem);

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
                FormFonksiyonları.DuzlemCiz(duzlemDonusmus, minGraphics, brush2);
                FormFonksiyonları.DPrizmaCiz(dPrizmasıDonusmus, minGraphics, brush1);
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
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            label9.Text = "............";
            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dPrizmasıDonusmus = new dPrizması(new nokta3d(0, 0, 0), 0, 0, 0);
            duzlemDonusmus = new düzlem(new nokta3d(0, 0, 0), new nokta3d(0, 0, 0), new nokta3d(0, 0, 0));

            CizdirVeKaydet(MyBlueBrush, MyYellowBrush);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dPrizması.KenarX == 0 || dPrizması.KenarY == 0 || dPrizması.KenarZ == 0)
            {
                MessageBox.Show("Anlamlı olmayan veya boş olmayan değerler kullanarak tekrardan deneyin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                label9.Text = carpismalar.DuzlemVsDPrizma(duzlem, dPrizması);

                if (carpismalar.DuzlemVsDPrizma(duzlem, dPrizması) == "Çarpışma Vardır")
                {
                    CizdirVeKaydet(MyRedBrush, MyRedBrush);
                }
                else
                {
                    CizdirVeKaydet(MyGreenBrush, MyGreenBrush);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CizdirVeKaydet(MyBlueBrush, MyYellowBrush);

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CizdirVeKaydet(MyBlueBrush, MyYellowBrush);

        }
    }
}
