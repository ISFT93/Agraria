using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Agraria.Domain.Models;
using Agraria.Data.Repositories.Interfaces;


namespace Agraria.Data.Repositories
{
    public class EngordeRepository : IEngordeRepository
    {
        private readonly Conexion _conexion;

        public EngordeRepository(Conexion conexion)
        {
            _conexion = conexion ?? throw new ArgumentNullException(nameof(conexion));
        }
        public async Task<IEnumerable<Engorde>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lista = new List<Engorde>();
            const string sql = "select IdEngorde, Nombre from Engorde\r\n";

            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
                while (await reader.ReadAsync(cancellationToken))
                {
                    lista.Add(new Engorde
                    {
                        IdEngorde = reader.GetInt32(0),
                        IdBox = reader.GetInt32(1),
                        Nombre = reader.GetString(2),
                        FechaIngreso = reader.GetDateTime(3),
                        Cantidad = reader.GetInt32(4),
                        FechaActualizado = reader.GetDateTime(5),
                        Semanas = reader.GetInt32(6),
                        Peso = reader.GetInt32(7),
                        IdAlimento = reader.GetInt32(8),
                        AlimentoPorDia = reader.GetInt32(9),
                        Estado = reader.GetBoolean(10),


                    });
                }
            }
            finally
            {
                _conexion.Close();
            }

            return lista;
        }

        public async Task<Engorde?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            const string sql = "SELECT idLocalidad, NombreLocalidad FROM Localidad WHERE idLocalidad = @id";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
                if (await reader.ReadAsync(cancellationToken))
                {
                    return new Engorde
                    {
                        IdEngorde = reader.GetInt32(0),
                        IdBox = reader.GetInt32(1),
                        Nombre = reader.GetString(2),
                        FechaIngreso = reader.GetDateTime(3),
                        Cantidad = reader.GetInt32(4),
                        FechaActualizado = reader.GetDateTime(5),
                        Semanas = reader.GetInt32(6),
                        Peso = reader.GetInt32(7),
                        IdAlimento = reader.GetInt32(8),
                        AlimentoPorDia = reader.GetInt32(9),
                        Estado = reader.GetBoolean(10),
                    };
                }
                return null;
            }
            finally
            {
                _conexion.Close();
            }
        }

        public async Task<int> CreateAsync(Engorde engorde, CancellationToken cancellationToken = default)
        {
            if (engorde == null) throw new ArgumentNullException(nameof(engorde));
            const string sql = "INSERT INTO [dbo].[Engorde] ([IdBox], [Nombre], [FechaIngreso], [Cantidad], [FechaActualizado], [Semanas], [Peso], [IdAlimento], [AlimentoPorDia], [Estado]) VALUES (@idBox, @nombre, @fechaIngreso, @cantidad, @fechaActualizado, @semanas, @peso, @idAlimento, @alimentoPorDia, @estado); SELECT CAST(SCOPE_IDENTITY() AS INT);";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@descripcion", engorde.Nombre ?? string.Empty);
                var result = await cmd.ExecuteScalarAsync(cancellationToken);
                return Convert.ToInt32(result);
            }
            finally
            {
                _conexion.Close();
            }
        }

        public async Task<bool> UpdateAsync(Engorde engorde, CancellationToken cancellationToken = default)
        {
            if (engorde == null) throw new ArgumentNullException(nameof(engorde));
            const string sql = "UPDATE [dbo].[Engorde] SET [Nombre] = @descripcion WHERE [IdEngorde] = @id";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@descripcion", engorde.Nombre ?? string.Empty);
                cmd.Parameters.AddWithValue("@id", engorde.IdEngorde);
                var rows = await cmd.ExecuteNonQueryAsync(cancellationToken);
                return rows > 0;
            }
            finally
            {
                _conexion.Close();
            }
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            const string sql = "DELETE FROM Engorde WHERE idLocalidad = @id";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                var rows = await cmd.ExecuteNonQueryAsync(cancellationToken);
                return rows > 0;
            }
            finally
            {
                _conexion.Close();
            }
           }
        }
}
