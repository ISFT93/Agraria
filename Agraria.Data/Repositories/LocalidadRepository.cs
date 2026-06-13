using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Agraria.Domain.Models;

namespace Agraria.Data.Repositories
{
    public class LocalidadRepository : ILocalidadRepository
    {
        private readonly Conexion _conexion;

        public LocalidadRepository(Conexion conexion)
        {
            _conexion = conexion ?? throw new ArgumentNullException(nameof(conexion));
        }

        public async Task<IEnumerable<Localidad>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lista = new List<Localidad>();
            const string sql = "SELECT idLocalidad, NombreLocalidad FROM Localidad";

            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
                while (await reader.ReadAsync(cancellationToken))
                {
                    lista.Add(new Localidad
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1)
                    });
                }
            }
            finally
            {
                _conexion.Close();
            }

            return lista;
        }

        public async Task<Localidad?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
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
                    return new Localidad
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1)
                    };
                }
                return null;
            }
            finally
            {
                _conexion.Close();
            }
        }

        public async Task<int> CreateAsync(Localidad localidad, CancellationToken cancellationToken = default)
        {
            if (localidad == null) throw new ArgumentNullException(nameof(localidad));
            const string sql = "INSERT INTO Localidad (NombreLocalidad) VALUES (@descripcion); SELECT CAST(SCOPE_IDENTITY() AS INT);";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@descripcion", localidad.Nombre ?? string.Empty);
                var result = await cmd.ExecuteScalarAsync(cancellationToken);
                return Convert.ToInt32(result);
            }
            finally
            {
                _conexion.Close();
            }
        }

        public async Task<bool> UpdateAsync(Localidad localidad, CancellationToken cancellationToken = default)
        {
            if (localidad == null) throw new ArgumentNullException(nameof(localidad));
            const string sql = "UPDATE Localidad SET NombreLocalidad = @descripcion WHERE idLocalidad = @id";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@descripcion", localidad.Nombre ?? string.Empty);
                cmd.Parameters.AddWithValue("@id", localidad.Id);
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
            const string sql = "DELETE FROM Localidad WHERE idLocalidad = @id";
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