using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Agraria.Domain.Models;

namespace Agraria.Data.Repositories
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly Conexion _conexion;

        public ProductosRepository(Conexion conexion)
        {
            _conexion = conexion ?? throw new ArgumentNullException(nameof(conexion));
        }

        public async Task<IEnumerable<Productos>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lista = new List<Productos>();
            const string sql = "SELECT [idProducto] ,[Nombre],[Descripcion] FROM [dbo].[Productos]\r\n";

            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
                while (await reader.ReadAsync(cancellationToken))
                {
                    lista.Add(new Productos
                    {
                        idProducto = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Descripcion = reader.GetString(2)
                    });
                }
            }
            finally
            {
                _conexion.Close();
            }

            return lista;
        }

        public async Task<Productos?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            const string sql = "SELECT idProducto, Nombre FROM Producto WHERE idProducto = @id";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
                if (await reader.ReadAsync(cancellationToken))
                {
                    return new Productos
                    {
                        idProducto = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Descripcion = reader.GetString(2)
                    };
                }
                return null;
            }
            finally
            {
                _conexion.Close();
            }
        }

        public async Task<int> CreateAsync(Productos productos, CancellationToken cancellationToken = default)
        {
            if (productos == null) throw new ArgumentNullException(nameof(productos));
            const string sql = "INSERT INTO [dbo].[Productos]([idProducto],[Nombre],[Descripcion] VALUES (<idProducto, int,>,<Nombre, nvarchar(100),>,<Descripcion, nvarchar(255),>); SELECT CAST(SCOPE_IDENTITY() AS INT);";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@Nombre", productos.Nombre ?? string.Empty);
                cmd.Parameters.AddWithValue("@Descripcion", productos.Descripcion ?? string.Empty);

                var result = await cmd.ExecuteScalarAsync(cancellationToken);
                return Convert.ToInt32(result);
            }
            finally
            {
                _conexion.Close();
            }
        }

        public async Task<bool> UpdateAsync(Productos productos, CancellationToken cancellationToken = default)
        {
            if (productos == null) throw new ArgumentNullException(nameof(productos));
            const string sql = "UPDATE [dbo].[Productos] SET [idProducto] = <idProducto, int,>,[Nombre] = <Nombre, nvarchar(100),> ,[Descripcion] = <Descripcion, nvarchar(255),>, WHERE idProducto = @id";
            try
            {
                await _conexion.OpenAsync(cancellationToken);
                using var cmd = _conexion.Conector.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@idProducto", productos.idProducto);
                cmd.Parameters.AddWithValue("@Nombre", productos.Nombre ?? string.Empty);
                cmd.Parameters.AddWithValue("@Descripcion", productos.Descripcion ?? string.Empty);
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
            const string sql = "DELETE FROM Productos WHERE idProducto = @id";
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
