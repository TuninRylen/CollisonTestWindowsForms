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
    public partial class KureVsKure : Form
    {

        Brush MyRedBrush = new SolidBrush(Color.Red);
        Brush MyBlueBrush = new SolidBrush(Color.Blue);
        Brush MyGreenBrush = new SolidBrush(Color.Green);
        Brush MyYellowBrush = new SolidBrush(Color.Yellow);

        cisimler.kure kure1 = new cisimler.kure();
        cisimler.kure kure1Donusmus = new cisimler.kure();

        cisimler.kure kure2 = new cisimler.kure();
        cisimler.kure kure2Donusmus = new cisimler.kure();

        public KureVsKure()
        {
            InitializeComponent();
        }

        private void Cidir_Ve_Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                kure1.M.X = Convert.ToDouble(textBox1.Text);
                kure1.M.Y = Convert.ToDouble(textBox2.Text);
                kure1.M.Z = Convert.ToDouble(textBox3.Text);
                kure1.R = Convert.ToDouble(textBox4.Text);

                kure1Donusmus = FormFonksiyonları.KureDonustur(kure1);

                kure2.M.X = Convert.ToDouble(textBox6.Text);
                kure2.M.Y = Convert.ToDouble(textBox7.Text);
                kure2.M.Z = Convert.ToDouble(textBox8.Text);
                kure2.R = Convert.ToDouble(textBox9.Text);

                kure2Donusmus = FormFonksiyonları.KureDonustur(kure2);

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
                FormFonksiyonları.KureCiz(kure1Donusmus, minGraphics, brush1);
                FormFonksiyonları.KureCiz(kure2Donusmus, minGraphics, brush2);
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
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            label9.Text = "............";
            checkBox1.Checked = false;
            checkBox2.Checked = false;

            kure1Donusmus = new kure(new nokta3d(0, 0, 0), 0);
            kure2Donusmus = new kure(new nokta3d(0, 0, 0), 0);

            CizdirVeKaydet(MyBlueBrush, MyYellowBrush);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (kure1Donusmus.R == 0 || kure2Donusmus.R == 0)
            {
                MessageBox.Show("Anlamlı olmayan veya boş olmayan değerler kullanarak tekrardan deneyin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                label9.Text = carpismalar.KureVsKure(kure1, kure2);

                if (carpismalar.KureVsKure(kure1, kure2) == "Çarpışma Vardır")
                {
                    CizdirVeKaydet(MyRedBrush, MyRedBrush);
                }
                else
                {
                    CizdirVeKaydet(MyGreenBrush, MyGreenBrush);
                }
            }
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }
    }
}
