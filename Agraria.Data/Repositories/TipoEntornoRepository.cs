using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Agraria.Domain.Models;

namespace Agraria.Data.Repositories
{
    public class TipoEntornoRepository : ITipoEntornoRepository
    {
        private readonly Conexion _conexion;

        public TipoEntornoRepository(Conexion conexion)
        {
            _conexion = conexion ?? throw new ArgumentNullException(nameof(conexion));
        }

        public async Task<IEnumerable<TipoEntorno>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lista = new List<TipoEntorno>();
            const string sql = "SELECT IdTipoEntorno, Nombre FROM TipoEntorno";

            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
                while (await reader.ReadAsync(cancellationToken))
                {
                    lista.Add(new TipoEntorno
                    {
                        IdTipoEntorno = reader.GetInt32(0),
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

        public async Task<TipoEntorno?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            const string sql = "SELECT IdTipoEntorno, Nombre FROM TipoEntorno WHERE IdTipoEntorno = @id";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
                if (await reader.ReadAsync(cancellationToken))
                {
                    return new TipoEntorno
                    {
                        IdTipoEntorno = reader.GetInt32(0),
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

        public async Task<int> CreateAsync(TipoEntorno tipoentorno, CancellationToken cancellationToken = default)
        {
            if (tipoentorno == null) throw new ArgumentNullException(nameof(tipoentorno));
            const string sql = "INSERT INTO [dbo].[TipoEntorno] ([Nombre]) VALUES (<Nombre, varchar(100),>); SELECT CAST(SCOPE_IDENTITY() AS INT);";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@Nombre", tipoentorno.Nombre ?? string.Empty);

                var result = await cmd.ExecuteScalarAsync(cancellationToken);
                return Convert.ToInt32(result);
            }
            finally
            {
                _conexion.Close();
            }
        }

        public async Task<bool> UpdateAsync(TipoEntorno tipoentorno, CancellationToken cancellationToken = default)
        {
            if (tipoentorno == null) throw new ArgumentNullException(nameof(tipoentorno));
            const string sql = "UPDATE [dbo].[TipoEntorno]  SET [Nombre] = <Nombre, varchar(100),WHERE IdTipoEntorno = @id";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@Nombre", tipoentorno.Nombre ?? string.Empty);
                cmd.Parameters.AddWithValue("@IdTipoEntorno", tipoentorno.IdTipoEntorno);
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
            const string sql = "DELETE FROM TipoEntorno WHERE IdTipoEntorno = @id";
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
