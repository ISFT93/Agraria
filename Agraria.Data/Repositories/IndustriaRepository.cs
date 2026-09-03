using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Agraria.Domain.Models;

namespace Agraria.Data.Repositories
{
    public class IndustriaRepository : IIndustriaRepository
    {
        private readonly Conexion _conexion;

        public IndustriaRepository(Conexion conexion)
        {
            _conexion = conexion ?? throw new ArgumentNullException(nameof(conexion));
        }

        public async Task<IEnumerable<Industria>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lista = new List<Industria>();
            const string sql = "SELECT [idRegistroIndustria], [idIndustria], [idProducto], [cantidadProduccion], [FechaProduccion], [idInsumos], [CantidadInsumos] FROM [dbo].[Industria]";

            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
                while (await reader.ReadAsync(cancellationToken))
                {
                    lista.Add(new Industria
                    {
                        idRegistroIndustria = reader.GetInt32(0),
                        idIndustria = reader.GetInt32(1),
                        idProducto = reader.GetInt32(2),
                        cantidadProduccion = reader.GetInt32(3),
                        FechaProduccion = reader.GetDateTime(4),
                        idInsumos = reader.GetInt32(5),
                        CantidadInsumos = reader.GetInt32(6)
                    });
                }
            }
            finally
            {
                _conexion.Close();
            }

            return lista;
        }

        public async Task<Industria?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            const string sql = "SELECT [idRegistroIndustria], [idIndustria], [idProducto], [cantidadProduccion], [FechaProduccion], [idInsumos], [CantidadInsumos] FROM [dbo].[Industria] WHERE [idRegistroIndustria] = @id";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
                if (await reader.ReadAsync(cancellationToken))
                {
                    return new Industria
                    {
                        idRegistroIndustria = reader.GetInt32(0),
                        idIndustria = reader.GetInt32(1),
                        idProducto = reader.GetInt32(2),
                        cantidadProduccion = reader.GetInt32(3),
                        FechaProduccion = reader.GetDateTime(4),
                        idInsumos = reader.GetInt32(5),
                        CantidadInsumos = reader.GetInt32(6)
                    };
                }
                return null;
            }
            finally
            {
                _conexion.Close();
            }
        }

        public async Task<int> CreateAsync(Industria industria, CancellationToken cancellationToken = default)
        {
            if (industria == null) throw new ArgumentNullException(nameof(industria));

            const string sql = @"INSERT INTO [dbo].[Industria] 
                                ([idIndustria], [idProducto], [cantidadProduccion], [FechaProduccion], [idInsumos], [CantidadInsumos]) 
                                VALUES 
                                (@idIndustria, @idProducto, @cantidadProduccion, @FechaProduccion, @idInsumos, @CantidadInsumos);
                                SELECT CAST(SCOPE_IDENTITY() AS INT);";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@idIndustria", industria.idIndustria);
                cmd.Parameters.AddWithValue("@idProducto", industria.idProducto);
                cmd.Parameters.AddWithValue("@cantidadProduccion", industria.cantidadProduccion);
                cmd.Parameters.AddWithValue("@FechaProduccion", industria.FechaProduccion);
                cmd.Parameters.AddWithValue("@idInsumos", industria.idInsumos);
                cmd.Parameters.AddWithValue("@CantidadInsumos", industria.CantidadInsumos);

                var result = await cmd.ExecuteScalarAsync(cancellationToken);
                return Convert.ToInt32(result);
            }
            finally
            {
                _conexion.Close();
            }
        }

        public async Task<bool> UpdateAsync(Industria industria, CancellationToken cancellationToken = default)
        {
            if (industria == null) throw new ArgumentNullException(nameof(industria));

            const string sql = @"UPDATE [dbo].[Industria] SET 
                                [idIndustria] = @idIndustria,
                                [idProducto] = @idProducto,
                                [cantidadProduccion] = @cantidadProduccion,
                                [FechaProduccion] = @FechaProduccion,
                                [idInsumos] = @idInsumos,
                                [CantidadInsumos] = @CantidadInsumos 
                                WHERE [idRegistroIndustria] = @idRegistroIndustria";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@idIndustria", industria.idIndustria);
                cmd.Parameters.AddWithValue("@idProducto", industria.idProducto);
                cmd.Parameters.AddWithValue("@cantidadProduccion", industria.cantidadProduccion);
                cmd.Parameters.AddWithValue("@FechaProduccion", industria.FechaProduccion);
                cmd.Parameters.AddWithValue("@idInsumos", industria.idInsumos);
                cmd.Parameters.AddWithValue("@CantidadInsumos", industria.CantidadInsumos);
                cmd.Parameters.AddWithValue("@idRegistroIndustria", industria.idRegistroIndustria);

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
            const string sql = "DELETE FROM [dbo].[Industria] WHERE [idRegistroIndustria] = @id";
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