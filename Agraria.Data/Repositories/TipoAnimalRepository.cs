using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Agraria.Domain.Models;

namespace Agraria.Data.Repositories
{
    public class TipoAnimalRepository : ITipoAnimalRepository
    {
        private readonly Conexion _conexion;

        public TipoAnimalRepository(Conexion conexion)
        {
            _conexion = conexion ?? throw new ArgumentNullException(nameof(conexion));
        }

        public async Task<IEnumerable<TipoAnimal>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lista = new List<TipoAnimal>();
            const string sql = "SELECT [IdTipo], [Nombre] FROM [dbo].[TipoAnimal]";

            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
                while (await reader.ReadAsync(cancellationToken))
                {
                    lista.Add(new TipoAnimal
                    {
                        IdTipo = reader.GetInt32(0),
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

        public async Task<TipoAnimal?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            const string sql = "SELECT [IdTipo], [Nombre] FROM [dbo].[TipoAnimal] WHERE [IdTipo] = @id";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
                if (await reader.ReadAsync(cancellationToken))
                {
                    return new TipoAnimal
                    {
                        IdTipo = reader.GetInt32(0),
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

        public async Task<int> CreateAsync(TipoAnimal tipoAnimal, CancellationToken cancellationToken = default)
        {
            if (tipoAnimal == null) throw new ArgumentNullException(nameof(tipoAnimal));

            const string sql = @"INSERT INTO [dbo].[TipoAnimal] ([Nombre]) 
                                VALUES (@Nombre); 
                                SELECT CAST(SCOPE_IDENTITY() AS INT);";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@Nombre", tipoAnimal.Nombre ?? string.Empty);

                var result = await cmd.ExecuteScalarAsync(cancellationToken);
                return Convert.ToInt32(result);
            }
            finally
            {
                _conexion.Close();
            }
        }

        public async Task<bool> UpdateAsync(TipoAnimal tipoAnimal, CancellationToken cancellationToken = default)
        {
            if (tipoAnimal == null) throw new ArgumentNullException(nameof(tipoAnimal));

            const string sql = "UPDATE [dbo].[TipoAnimal] SET [Nombre] = @Nombre WHERE [IdTipo] = @id";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@Nombre", tipoAnimal.Nombre ?? string.Empty);
                cmd.Parameters.AddWithValue("@id", tipoAnimal.IdTipo);

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
            const string sql = "DELETE FROM [dbo].[TipoAnimal] WHERE [IdTipo] = @id";
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
