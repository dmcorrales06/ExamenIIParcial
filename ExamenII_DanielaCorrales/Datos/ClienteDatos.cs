using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Datos
{
    public class ClienteDatos
    {

        public async Task<DataTable> DevolverListaAsync()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM cliente;";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        MySqlDataReader dr = (MySqlDataReader)await comando.ExecuteReaderAsync();
                        dt.Load(dr);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return dt;
        }
        public async Task<bool> InsertarAsync(Cliente cliente)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO cliente VALUES (@CodigoCliente, @Nombre, @Telefono, @TipoSoporte, @DescripSolicitud, @Precio,@DescripRespuesta, @fecha,@ISV,@Descuento,@Total);";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@CodigoCliente", MySqlDbType.VarChar, 20).Value = cliente.CodigoCliente;
                        comando.Parameters.Add("@Nombre", MySqlDbType.VarChar, 45).Value = cliente.Nombre;
                        comando.Parameters.Add("@Telefono", MySqlDbType.VarChar, 20).Value = cliente.Telefono;
                        comando.Parameters.Add("@TipoSoporte", MySqlDbType.VarChar, 100).Value = cliente.TipoSoporte;
                        comando.Parameters.Add("@DescripSolicitud", MySqlDbType.VarChar, 100).Value = cliente.DescripSolicitud;
                        comando.Parameters.Add("@DescripRespuesta", MySqlDbType.VarChar, 100).Value = cliente.DescripRespuesta;
                        comando.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = cliente.Precio;
                        comando.Parameters.Add("@Fecha", MySqlDbType.DateTime).Value = cliente.Fecha;
                        comando.Parameters.Add("@ISV", MySqlDbType.Decimal).Value = cliente.ISV;
                        comando.Parameters.Add("@Descuento", MySqlDbType.Decimal).Value = cliente.Descuento;
                        comando.Parameters.Add("@Total", MySqlDbType.Decimal).Value = cliente.Total;
                        await comando.ExecuteNonQueryAsync();
                        inserto = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return inserto;
        }

        public async Task<bool> EliminarAsync(string codigo)
        {
            bool elimino = false;
            try
            {
                string sql = "DELETE FROM cliente WHERE CodigoCliente = @CodigoCliente;";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@CodigoCliente", MySqlDbType.VarChar, 20).Value = codigo;
                        await comando.ExecuteNonQueryAsync();
                        elimino = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return elimino;
        }

        public async Task<Cliente> GetPorCodigo(string codigo)
        {
           Cliente cliente = new Cliente();
            try
            {
                string sql = "SELECT * FROM cliente WHERE CodigoCliente = @CodigoCliente;";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@CodigoCliente", MySqlDbType.VarChar, 20).Value = codigo;

                        MySqlDataReader dr = (MySqlDataReader)await comando.ExecuteReaderAsync();
                        if (dr.Read())
                        {
                            cliente.CodigoCliente = dr["CodigoCliente"].ToString();
                            cliente.Nombre = dr["Nombre"].ToString();
                            cliente.Telefono = dr["Telefono"].ToString();
                            cliente.TipoSoporte = dr["TipoSoporte"].ToString();
                            cliente.DescripSolicitud = dr["DescripSolicitud"].ToString();
                            cliente.Precio = Convert.ToDecimal(dr["Precio"]);
                            
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return cliente;
        }


    }
}
