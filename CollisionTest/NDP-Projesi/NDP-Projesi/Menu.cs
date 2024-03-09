namespace NDP_Projesi
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DikdortgenVsNokta form = new DikdortgenVsNokta();
            form.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            KureVsKure form = new KureVsKure();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DikdortgenVsDaire form = new DikdortgenVsDaire();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DikdortgenVsDikdortgen form = new DikdortgenVsDikdortgen();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DaireVsDaire form = new DaireVsDaire();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DaireVsNokta form = new DaireVsNokta();
            form.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DikdortgenPrizmaVsNokta form = new DikdortgenPrizmaVsNokta();
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            KureVsNokta form = new KureVsNokta();
            form.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SilindirVsNokta form = new SilindirVsNokta();
            form.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SilindirVsSilindir form = new SilindirVsSilindir();
            form.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SilindirVsKure form = new SilindirVsKure();
            form.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DikdortgenPrizmaVsKure form = new DikdortgenPrizmaVsKure();
            form.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DikdortgenPrizmaVsDikdortgenPrizma form = new DikdortgenPrizmaVsDikdortgenPrizma();
            form.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DuzlemVsDikdortgenPrizma form = new DuzlemVsDikdortgenPrizma();
            form.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DuzlemVsKure form = new DuzlemVsKure();
            form.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DuzlemVsSilindir form = new DuzlemVsSilindir();
            form.ShowDialog();
        }
    }
}