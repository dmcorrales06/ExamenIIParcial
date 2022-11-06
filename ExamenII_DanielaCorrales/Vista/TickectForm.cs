using Datos;
using Entidades;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class TickectForm : Syncfusion.Windows.Forms.Office2010Form
    {
        public TickectForm()
        {
            InitializeComponent();
        }
        ClienteDatos clientDatos = new ClienteDatos();
        Cliente cliente;

        private void TickectForm_Load(object sender, EventArgs e)
        {
            LlenarDataGrid();
        }
        private async void LlenarDataGrid()
        {
            TicketDataGridView.DataSource = await clientDatos.DevolverListaAsync();
        }

        private void RegresarButton_Click(object sender, EventArgs e)
        {
            Menu mainMenu = new Menu();
            Hide();
            mainMenu.Show();
        }

        private async void EliminarButton_Click(object sender, EventArgs e)
        {
            if (TicketDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = await clientDatos.EliminarAsync(TicketDataGridView.CurrentRow.Cells["CodigoCliente"].Value.ToString());
                if (elimino)
                {
                    LlenarDataGrid();
                    MessageBox.Show("Cliente Eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cliente no eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void BuscarButton_Click(object sender, EventArgs e)
        {
            cliente = await clientDatos.GetPorCodigo(BuscarTextBox.Text);

            if (cliente.CodigoCliente != null)
            {
                BuscarTextBox.Text = cliente.CodigoCliente;
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(BuscarTextBox, "No existe el cliente");
            }
        }


    }
}
