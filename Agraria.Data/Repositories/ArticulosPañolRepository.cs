using Agraria.Domain.Interfaces;
using Agraria.Domain.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Agraria.Data.Repositories
{
    public class ArticulosPañolRepository : IArticulosPañolRepository
    {
        private readonly Conexion _conexion;

        public ArticulosPañolRepository(Conexion conexion)
        {
            _conexion = conexion ?? throw new ArgumentNullException(nameof(conexion));
        }

        public async Task<IEnumerable<ArticulosPañol>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lista = new List<ArticulosPañol>();
            const string sql = "SELECT [IdArtPañol],[NombreProducto],[Cantidad],[IdUnidad],[FechaIngreso],[IdEntorno],[Responsable],[Estado] FROM [dbo].[ArticulosPañol]\r\n";

            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
                while (await reader.ReadAsync(cancellationToken))
                {
                    lista.Add(new ArticulosPañol
                    {
                        IdArtPañol = reader.GetInt32(0),
                        NombreProducto = reader.GetString(1),
                        Cantidad = reader.GetInt32(2),
                        IdUnidad = reader.GetInt32(3),
                        FechaIngreso = reader.GetDateTime(4),
                        IdEntorno = reader.GetInt32(5),
                        Responsable = reader.GetString(6),
                        Estado = reader.GetBoolean(7)
                    });
                }
            }
            finally
            {
                _conexion.Close();
            }

            return lista;
        }

        public async Task<ArticulosPañol?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            const string sql = "SELECT IdArtPañol, NombreProducto FROM ArticulosPañol WHERE IdArtPañol = @id";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
                if (await reader.ReadAsync(cancellationToken))
                {
                    return new ArticulosPañol
                    {
                        IdArtPañol = reader.GetInt32(0),
                        NombreProducto = reader.GetString(1),
                        Cantidad = reader.GetInt32(2),
                        IdUnidad = reader.GetInt32(3),
                        FechaIngreso = reader.GetDateTime(4),
                        IdEntorno = reader.GetInt32(5),
                        Responsable = reader.GetString(6),
                        Estado = reader.GetBoolean(7)
                    };
                }
                return null;
            }
            finally
            {
                _conexion.Close();
            }
        }

        public async Task<int> CreateAsync(ArticulosPañol articulosPañol, CancellationToken cancellationToken = default)
        {
            if (articulosPañol == null) throw new ArgumentNullException(nameof(articulosPañol));
            const string sql = "INSERT INTO [dbo].[ArticulosPañol] ([NombreProducto],[Cantidad],[IdUnidad],[FechaIngreso],[IdEntorno],[Responsable],[Estado]) VALUES(<NombreProducto, varchar(100),>,<Cantidad, int,>,<IdUnidad, int,>,<FechaIngreso, date,>,<IdEntorno, int,>,<Responsable, varchar(100),>,<Estado, bit,>)\r\n; SELECT CAST(SCOPE_IDENTITY() AS INT);";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@NombreProducto", articulosPañol.NombreProducto ?? string.Empty);
                cmd.Parameters.AddWithValue("@Cantidad", articulosPañol.Cantidad);
                cmd.Parameters.AddWithValue("@IdUnidad", articulosPañol.IdUnidad);
                cmd.Parameters.AddWithValue("@FechaIngreso", articulosPañol.FechaIngreso);
                cmd.Parameters.AddWithValue("@IdEntorno", articulosPañol.IdEntorno);
                cmd.Parameters.AddWithValue("@Responsable", articulosPañol.Responsable ?? string.Empty);
                cmd.Parameters.AddWithValue("@Estado", articulosPañol.Estado);

                var result = await cmd.ExecuteScalarAsync(cancellationToken);
                return Convert.ToInt32(result);
            }
            finally
            {
                _conexion.Close();
            }
        }

        public async Task<bool> UpdateAsync(ArticulosPañol articulosPañol, CancellationToken cancellationToken = default)
        {
            if (articulosPañol == null) throw new ArgumentNullException(nameof(articulosPañol));
            const string sql = "UPDATE [dbo].[ArticulosPañol]  SET [NombreProducto] = <NombreProducto, varchar(100),> ,[Cantidad] = <Cantidad, int,>,[IdUnidad] = <IdUnidad, int,>,[FechaIngreso] = <FechaIngreso, date,>,[IdEntorno] = <IdEntorno, int,>,[Responsable] = <Responsable, varchar(100),>,[Estado] = <Estado, bit,> WHERE IdArtPañol = @id";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@NombreProducto", articulosPañol.NombreProducto ?? string.Empty);
                cmd.Parameters.AddWithValue("@Cantidad", articulosPañol.Cantidad);
                cmd.Parameters.AddWithValue("@IdUnidad", articulosPañol.IdUnidad);
                cmd.Parameters.AddWithValue("@FechaIngreso", articulosPañol.FechaIngreso);
                cmd.Parameters.AddWithValue("@IdEntorno", articulosPañol.IdEntorno);
                cmd.Parameters.AddWithValue("@Responsable", articulosPañol.Responsable ?? string.Empty);
                cmd.Parameters.AddWithValue("@Estado", articulosPañol.Estado);
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
            const string sql = "DELETE FROM [dbo].[ArticulosPañol] WHERE IdArtPañol = @id";
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
