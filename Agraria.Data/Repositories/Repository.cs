using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Agraria.Domain.Models;
using Agraria.Domain.Interfaces;

namespace Agraria.Data.Repositories
{
    public class Repository : IPracticaRepository
    {
        private readonly Conexion _conexion;

        public Repository(Conexion conexion)
        {
            _conexion = conexion ?? throw new ArgumentNullException(nameof(conexion));
        }

        public async Task<IEnumerable<Practicas>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lista = new List<Practicas>();
            const string sql = "SELECT idLocalidad, NombreLocalidad FROM Localidad";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
                while (await reader.ReadAsync(cancellationToken))
                {
                    lista.Add(new Practicas
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
        public async Task<Practicas?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
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
                    return new Practicas
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
        public async Task<int> CreateAsync(Practicas practicas, CancellationToken cancellationToken = default)
        {
            if (practicas == null) throw new ArgumentNullException(nameof(practicas));
            const string sql = "INSERT INTO Localidad (NombreLocalidad) VALUES (@descripcion); SELECT CAST(SCOPE_IDENTITY() AS INT);";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@descripcion", practicas.Nombre ?? string.Empty);
                var result = await cmd.ExecuteScalarAsync(cancellationToken);
                return Convert.ToInt32(result);
            }
            finally
            {
                _conexion.Close();
            }
        }
        public async Task<bool> UpdateAsync(Practicas practicas, CancellationToken cancellationToken = default)
        {
            if (practicas == null) throw new ArgumentNullException(nameof(practicas));
            const string sql = "UPDATE Localidad SET NombreLocalidad = @descripcion WHERE idLocalidad = @id";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@descripcion", practicas.Nombre ?? string.Empty);
                cmd.Parameters.AddWithValue("@id", practicas.Id);
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

