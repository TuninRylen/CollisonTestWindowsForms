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
    public partial class SilindirVsKure : Form
    {
        Brush MyRedBrush = new SolidBrush(Color.Red);
        Brush MyBlueBrush = new SolidBrush(Color.Blue);
        Brush MyGreenBrush = new SolidBrush(Color.Green);
        Brush MyYellowBrush = new SolidBrush(Color.Yellow);

        cisimler.silindir silindir = new cisimler.silindir();
        cisimler.silindir silindirDonusmus = new cisimler.silindir();

        cisimler.kure kure = new cisimler.kure();
        cisimler.kure kureDonusmus = new cisimler.kure();

        public SilindirVsKure()
        {
            InitializeComponent();
        }

        private void Cidir_Ve_Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                silindir.M.X = Convert.ToDouble(textBox1.Text);
                silindir.M.Y = Convert.ToDouble(textBox2.Text);
                silindir.M.Z = Convert.ToDouble(textBox3.Text);
                silindir.H = Convert.ToDouble(textBox5.Text);
                silindir.R = Convert.ToDouble(textBox4.Text);

                silindirDonusmus = FormFonksiyonları.SilindirDonustur(silindir);

                kure.M.X = Convert.ToDouble(textBox6.Text);
                kure.M.Y = Convert.ToDouble(textBox7.Text);
                kure.M.Z = Convert.ToDouble(textBox8.Text);
                kure.R = Convert.ToDouble(textBox9.Text);

                kureDonusmus = FormFonksiyonları.KureDonustur(kure);

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
                FormFonksiyonları.SilindirCiz(silindirDonusmus, minGraphics, brush1);
                FormFonksiyonları.KureCiz(kureDonusmus, minGraphics, brush2);
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
            label9.Text = "............";
            checkBox1.Checked = false;
            checkBox2.Checked = false;

            kureDonusmus = new kure(new nokta3d(0, 0, 0), 0);
            silindirDonusmus = new silindir(new nokta3d(0, 0, 0), 0, 0);

            CizdirVeKaydet(MyBlueBrush, MyYellowBrush);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (kureDonusmus.R == 0 || silindirDonusmus.R == 0 || silindirDonusmus.H == 0)
            {
                MessageBox.Show("Anlamlı olmayan veya boş olmayan değerler kullanarak tekrardan deneyin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                label9.Text = carpismalar.SilindirVsKure(silindir, kure);

                if (carpismalar.SilindirVsKure(silindir, kure) == "Çarpışma Vardır")
                {
                    CizdirVeKaydet(MyRedBrush, MyRedBrush);
                }
                else
                {
                    CizdirVeKaydet(MyGreenBrush, MyGreenBrush);
                }
            }
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }
    }
}
