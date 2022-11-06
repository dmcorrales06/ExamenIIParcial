using System;

namespace Vista
{
    public partial class Menu : Syncfusion.Windows.Forms.Office2010Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void CelularButton_Click(object sender, EventArgs e)
        {
          CelularForm celularForm = new CelularForm();
            Hide();
            celularForm.Show();
        }

        private void ComputadoraButton_Click(object sender, EventArgs e)
        {
            ComputadoraForm computadoraForm = new ComputadoraForm();
            Hide();
            computadoraForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TickectForm tickectForm = new TickectForm();
            Hide();
            tickectForm.Show();
        }
    }
}
