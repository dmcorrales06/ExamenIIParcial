using Datos;
using Entidades;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class ComputadoraForm : Syncfusion.Windows.Forms.Office2010Form
    {
        public ComputadoraForm()
        {
            InitializeComponent();
        }

        decimal isv = 0;
        decimal total = 0;
        decimal descuento;

        ClienteDatos userDatos = new ClienteDatos();
        Cliente client;



        private void RegresarButton_Click(object sender, EventArgs e)
        {
            Menu mainMenu = new Menu();
            Hide();
            mainMenu.Show();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            CodigoClienteTextBox.Clear();
            RespuestaTextBox.Clear();
            PrecioTextBox.Clear();
            NombreTextBox.Clear();
            TelefonoTextBox.Clear();
            SoporteCoTextBox.Clear();
            SolicitudTextBox.Clear();
            dateTimePicker1.Value = DateTime.Now;
            DescuentoTextBox.Clear();
            TotalTextBox.Clear();
            ISVTextBox.Clear();
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            client = new Cliente();

            if (CodigoClienteTextBox.Text == "")
            {
                errorProvider1.SetError(CodigoClienteTextBox, "Ingrese un código");
                CodigoClienteTextBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(NombreTextBox.Text))
            {
                errorProvider1.SetError(NombreTextBox, "Ingrese un nombre");
                NombreTextBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TelefonoTextBox.Text))
            {
                errorProvider1.SetError(TelefonoTextBox, "Ingrese un telefono");
                TelefonoTextBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(SoporteCoTextBox.Text))
            {
                errorProvider1.SetError(SoporteCoTextBox, "Ingrese un tipo de soporte");
                SoporteCoTextBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(SolicitudTextBox.Text))
            {
                errorProvider1.SetError(SolicitudTextBox, "Ingrese una descripción");
                SolicitudTextBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(PrecioTextBox.Text))
            {
                errorProvider1.SetError(PrecioTextBox, "Ingrese un precio");
                PrecioTextBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(RespuestaTextBox.Text))
            {
                errorProvider1.SetError(RespuestaTextBox, "Ingrese una respuesta");
                RespuestaTextBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                errorProvider1.SetError(dateTimePicker1, "Ingrese un fecha");
                dateTimePicker1.Focus();
                return;
            }

            client.CodigoCliente = CodigoClienteTextBox.Text;
            client.Nombre = NombreTextBox.Text;
            client.Telefono = TelefonoTextBox.Text;
            client.TipoSoporte = SoporteCoTextBox.Text;
            client.DescripSolicitud = SolicitudTextBox.Text;
            client.Precio = Convert.ToDecimal(PrecioTextBox.Text);
            client.DescripRespuesta = RespuestaTextBox.Text;
            client.Fecha = dateTimePicker1.Value;
            client.ISV = Convert.ToDecimal(ISVTextBox.Text);
            client.Descuento = Convert.ToDecimal(DescuentoTextBox.Text);
            client.Total = Convert.ToDecimal(TotalTextBox.Text);

            bool inserto = await userDatos.InsertarAsync(client);

            if (inserto)
            {
                MessageBox.Show("Cliente Guardado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cliente no guardado", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

         
        }

        private void CalcularButton_Click(object sender, EventArgs e)
        {
            Calcular();
        }


        private void Calcular()
        {
            isv = Convert.ToDecimal(PrecioTextBox.Text) * 0.15M;
            descuento = Convert.ToDecimal(PrecioTextBox.Text) * 0.2M;
            total = Convert.ToDecimal(PrecioTextBox.Text) + isv - descuento;

            ISVTextBox.Text = isv.ToString("N");
            TotalTextBox.Text = total.ToString("N");
            DescuentoTextBox.Text = descuento.ToString("N");
        }
    }
}