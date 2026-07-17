using Agraria.Data.Repositories.Interfaces;
using Agraria.Domain.Interfaces;
using Agraria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Data.Repositories
{
    public class CarneRepository : ICarneRepository
    {
        private readonly Conexion _conexion;

        public CarneRepository(Conexion conexion)
        {
            _conexion = conexion ?? throw new ArgumentNullException(nameof(conexion));
        }

        public async Task<IEnumerable<Carne>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lista = new List<Carne>();

            const string sql = @"select [IdCarne],[Nombre],[IdBoxCarne],[NumeroAnimal],[FechaIngreso],[Sexo],[FechaRetiro],[FechaEnvioIndustria],[Estado] from [dbo].[Carne]";

            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;

                using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

                while (await reader.ReadAsync(cancellationToken))
                {
                    lista.Add(new Carne
                    {
                        IdCarne = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        IdBoxCarne = reader.GetInt32(2),
                        NumeroAnimal = reader.GetString(3),
                        FechaIngreso = reader.GetDateTime(4),
                        Sexo = reader.GetString(5),
                        FechaRetiro =  reader.GetDateTime(6),
                        FechaEnvioIndustria = reader.GetDateTime(7),
                        Estado = reader.GetBoolean(8)
                    });
                }
            }
            finally
            {
                _conexion.Close();
            }

            return lista;
        }

        public async Task<Carne?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            const string sql = @"select [IdCarne],[Nombre],[IdBoxCarne],[NumeroAnimal],[FechaIngreso],[Sexo],[FechaRetiro],[FechaEnvioIndustria],[Estado] from [dbo].[Carne] where [IdCarne] = @id";

            try
            {
                await _conexion.OpenAsync(cancellationToken);

                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);

                using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

                if (await reader.ReadAsync(cancellationToken))
                {
                    return new Carne
                    {
                        IdCarne = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        IdBoxCarne = reader.GetInt32(2),
                        NumeroAnimal = reader.GetString(3),
                        FechaIngreso = reader.GetDateTime(4),
                        Sexo = reader.GetString(5),
                        FechaRetiro =  reader.GetDateTime(6),
                        FechaEnvioIndustria =  reader.GetDateTime(7),
                        Estado = reader.GetBoolean(8)
                    };
                }

                return null;
            }
            finally
            {
                _conexion.Close();
            }
        }

        public async Task<int> CreateAsync(Carne carne, CancellationToken cancellationToken = default)
        {
            if (carne == null) throw new ArgumentNullException(nameof(carne));

            const string sql = @"insert into [dbo].[Carne]([Nombre],[IdBoxCarne],[NumeroAnimal],[FechaIngreso],[Sexo],[FechaRetiro],[FechaEnvioIndustria],[Estado])
                                values (@Nombre,@IdBoxCarne,@NumeroAnimal,@FechaIngreso,@Sexo,@FechaRetiro,@FechaEnvioIndustria,@Estado); select cast(SCOPE_IDENTITY() as int);";

            try
            {
                await _conexion.OpenAsync(cancellationToken);

                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@Nombre", carne.Nombre );
                cmd.Parameters.AddWithValue("@IdBoxCarne", carne.IdBoxCarne);
                cmd.Parameters.AddWithValue("@NumeroAnimal", carne.NumeroAnimal );
                cmd.Parameters.AddWithValue("@FechaIngreso", carne.FechaIngreso);
                cmd.Parameters.AddWithValue("@Sexo", carne.Sexo );
                cmd.Parameters.AddWithValue("@FechaRetiro", carne.FechaRetiro);
                cmd.Parameters.AddWithValue("@FechaEnvioIndustria", carne.FechaEnvioIndustria );
                cmd.Parameters.AddWithValue("@Estado", carne.Estado);

                var result = await cmd.ExecuteScalarAsync(cancellationToken);

                return Convert.ToInt32(result);
            }
            finally
            {
                _conexion.Close();
            }
        }

        public async Task<bool> UpdateAsync(Carne carne, CancellationToken cancellationToken = default)
        {
            if (carne == null) throw new ArgumentNullException(nameof(carne));

            const string sql = @"update [dbo].[Carne] set [Nombre] = @Nombre,[IdBoxCarne] = @IdBoxCarne,[NumeroAnimal] = @NumeroAnimal,[FechaIngreso] = @FechaIngreso,[Sexo] = @Sexo,[FechaRetiro] = @FechaRetiro,[FechaEnvioIndustria] = @FechaEnvioIndustria,[Estado] = @Estado where [IdCarne] = @id";

            try
            {
                await _conexion.OpenAsync(cancellationToken);

                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@Nombre", carne.Nombre );
                cmd.Parameters.AddWithValue("@IdBoxCarne", carne.IdBoxCarne);
                cmd.Parameters.AddWithValue("@NumeroAnimal", carne.NumeroAnimal );
                cmd.Parameters.AddWithValue("@FechaIngreso", carne.FechaIngreso );
                cmd.Parameters.AddWithValue("@Sexo", carne.Sexo );
                cmd.Parameters.AddWithValue("@FechaRetiro", carne.FechaRetiro );
                cmd.Parameters.AddWithValue("@FechaEnvioIndustria", carne.FechaEnvioIndustria );
                cmd.Parameters.AddWithValue("@Estado", carne.Estado);
                cmd.Parameters.AddWithValue("@id", carne.IdCarne);

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
            const string sql = "delete from [dbo].[Carne] where [IdCarne] = @id";

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
