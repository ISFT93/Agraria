using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Agraria.Domain.Models;

namespace Agraria.Data.Repositories
{
    public class ProduccionVegetalRepository : IProduccionVegetalRepository
    {
      
            private readonly Conexion _conexion;

            public ProduccionVegetalRepository(Conexion conexion)
            {
                _conexion = conexion ?? throw new ArgumentNullException(nameof(conexion));
            }

            public async Task<IEnumerable<ProduccionVegetal>> GetAllAsync(CancellationToken cancellationToken = default)
            {
                var lista = new List<ProduccionVegetal>();
                // Se ordenaron las columnas para coincidir exactamente con el orden del mapeo (0 al 5)
                const string sql = "SELECT [IdProduccion], [CantidadPlantines], [FechaCultivo], [FechaCosecha], [CantidadAtados], [Estado] FROM [dbo].[ProduccionVegetal]";

                try
                {
                    await _conexion.OpenAsync(cancellationToken);
                    using var cmd = _conexion.Conector.CreateCommand();
                    cmd.CommandText = sql;
                    using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
                    while (await reader.ReadAsync(cancellationToken))
                    {
                        lista.Add(new ProduccionVegetal
                        {
                            IdProduccion = reader.GetInt32(0),
                            CantidadPlantines = reader.GetInt32(1),
                            FechaCultivo = reader.GetDateTime(2),
                            FechaCosecha = reader.GetDateTime(3),
                            CantidadAtados = reader.GetInt32(4),
                            Estado = reader.GetBoolean(5)
                        });
                    }
                }
                finally
                {
                    _conexion.Close();
                }

                return lista;
            }

            public async Task<ProduccionVegetal?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            {
                const string sql = "SELECT [IdProduccion], [CantidadPlantines], [FechaCultivo], [FechaCosecha], [CantidadAtados], [Estado] FROM [dbo].[ProduccionVegetal] WHERE IdProduccion = @id";
                try
                {
                    await _conexion.OpenAsync(cancellationToken);
                    using var cmd = _conexion.Conector.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@id", id);

                    using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
                    if (await reader.ReadAsync(cancellationToken))
                    {
                        return new ProduccionVegetal
                        {
                            IdProduccion = reader.GetInt32(0),
                            CantidadPlantines = reader.GetInt32(1),
                            FechaCultivo = reader.GetDateTime(2),
                            FechaCosecha = reader.GetDateTime(3),
                            CantidadAtados = reader.GetInt32(4),
                            Estado = reader.GetBoolean(5)
                        };
                    }
                    return null;
                }
                finally
                {
                    _conexion.Close();
                }
            }

            public async Task<int> CreateAsync(ProduccionVegetal produccionvegetal, CancellationToken cancellationToken = default)
            {
                if (produccionvegetal == null) throw new ArgumentNullException(nameof(produccionvegetal));

                const string sql = @"INSERT INTO [dbo].[ProduccionVegetal] 
                                ([CantidadPlantines], [FechaCultivo], [FechaCosecha], [CantidadAtados], [Estado]) 
                                VALUES 
                                (@CantidadPlantines, @FechaCultivo, @FechaCosecha, @CantidadAtados, @Estado);
                                SELECT CAST(SCOPE_IDENTITY() AS INT);";
                try
                {
                    await _conexion.OpenAsync(cancellationToken);
                    using var cmd = _conexion.Conector.CreateCommand();
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@CantidadPlantines", produccionvegetal.CantidadPlantines);
                    cmd.Parameters.AddWithValue("@FechaCultivo", produccionvegetal.FechaCultivo);
                    cmd.Parameters.AddWithValue("@FechaCosecha", produccionvegetal.FechaCosecha);
                    cmd.Parameters.AddWithValue("@CantidadAtados", produccionvegetal.CantidadAtados);
                    cmd.Parameters.AddWithValue("@Estado", produccionvegetal.Estado);

                    var result = await cmd.ExecuteScalarAsync(cancellationToken);
                    return Convert.ToInt32(result);
                }
                finally
                {
                    _conexion.Close();
                }
            }

            public async Task<bool> UpdateAsync(ProduccionVegetal produccionvegetal, CancellationToken cancellationToken = default)
            {
                if (produccionvegetal == null) throw new ArgumentNullException(nameof(produccionvegetal));

                const string sql = @"UPDATE [dbo].[ProduccionVegetal] SET 
                                [CantidadPlantines] = @CantidadPlantines, 
                                [FechaCultivo] = @FechaCultivo, 
                                [FechaCosecha] = @FechaCosecha, 
                                [CantidadAtados] = @CantidadAtados, 
                                [Estado] = @Estado 
                                WHERE IdProduccion = @IdProduccion";
                try
                {
                    await _conexion.OpenAsync(cancellationToken);
                    using var cmd = _conexion.Conector.CreateCommand();
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@CantidadPlantines", produccionvegetal.CantidadPlantines);
                    cmd.Parameters.AddWithValue("@FechaCultivo", produccionvegetal.FechaCultivo);
                    cmd.Parameters.AddWithValue("@FechaCosecha", produccionvegetal.FechaCosecha);
                    cmd.Parameters.AddWithValue("@CantidadAtados", produccionvegetal.CantidadAtados);
                    cmd.Parameters.AddWithValue("@Estado", produccionvegetal.Estado);
                    cmd.Parameters.AddWithValue("@IdProduccion", produccionvegetal.IdProduccion);

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
                const string sql = "DELETE FROM [dbo].[ProduccionVegetal] WHERE IdProduccion = @id";
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