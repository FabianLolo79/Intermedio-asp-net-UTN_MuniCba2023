using MySql.Data.MySqlClient;
using WebApplicationSistemaDeReclamos.Models;

namespace WebApplicationSistemaDeReclamos.Services
{
    public class ReclamosService
    {

        public void AltaReclamo(Reclamo reclamo)
        {
            
            MySqlConnection connection = DbUtils.RecuperarConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO reclamos (titulo, descripcion, estado, fechaAlta) VALUES "
                + " (@titulo, @descripcion, @estado, @fechaAlta);";
            command.Parameters.AddWithValue("titulo", reclamo.Titulo);
            command.Parameters.AddWithValue("descripcion", reclamo.Descripcion);
            command.Parameters.AddWithValue("estado", reclamo.Estado);
            command.Parameters.AddWithValue("fechaAlta", reclamo.FechaAlta);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void BorrarReclamo(long id)
        {
            MySqlConnection connection = DbUtils.RecuperarConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM reclamos WHERE id = @id";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            connection.Close();

        }

        public List<Reclamo> RecuperarListadoDeReclamos()
        {
            List<Reclamo> reclamos = new List<Reclamo>();
            MySqlConnection connection = DbUtils.RecuperarConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT id, titulo, descripcion, estado, fechaAlta FROM reclamos";
            MySqlDataReader datareader = command.ExecuteReader();
            Reclamo reclamo = null;
            while (datareader.Read())
            {
                reclamo = new Reclamo();
                reclamo.Id = datareader.GetInt64("id");
                reclamo.Titulo = datareader.GetString("titulo");
                reclamo.Descripcion = datareader.GetString("descripcion");
                reclamo.Estado = datareader.GetString("estado");
                reclamo.FechaAlta = datareader.GetDateTime("fechaAlta");
                reclamos.Add(reclamo);

            }
            connection.Close();

            return reclamos;
        }

    }
}
