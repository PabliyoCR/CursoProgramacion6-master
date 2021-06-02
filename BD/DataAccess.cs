using Dapper;
using Dapper.Mapper;
using Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration config;

        // Constructor
        public DataAccess(IConfiguration _Config)
        {
            config = _Config;
        }

        // Metodo para poder guardar el string de conexión
        public SqlConnection DbConnection => new SqlConnection(
                new SqlConnectionStringBuilder(
                        config.GetConnectionString("Conn")
                    ).ConnectionString
            );

        // Metodo para hacer la representación del mapeo de datos de una entidad
        // (Representación de un objeto). Enlista las propiedades.
        // Metodología Dapper
        // IEnumerable es una lista de microsoft
        // T representa una entidad dentro
        // sp = Stored Procedure que se va a consumir
        // Param = Parametros del sp

        // timeout es el tiempo de espera que tiene un metodo para
        // recibir la informacion que se necesita (null son 30s)
        public async Task<IEnumerable<T>> QueryAsync<T>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                // using se utiliza cuando una clase implementa la interfaz IDisposable
                // esto asegura que tendrá el método Dispose que es utilizado
                // para liberar recursos no administrados como un archivo,
                // una conexión de red, una conexión con base de datos.

                // exec se utiliza por convencion cuando un procedimiento
                // almecenado va a ser ejecutado
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T>(
                        sql: sp,
                        param: Param,
                        commandType: System.Data.CommandType.StoredProcedure,
                        commandTimeout: Timeout
                    );
                    return await result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Query directo. Tipo dinámico. Me interesa las propiedades de la
        // entidad y no la entidad en sí
        public async Task<IEnumerable<dynamic>> QueryAsync(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync(sql: sp,
                        param: Param,
                        commandType: System.Data.CommandType.StoredProcedure,
                        commandTimeout: Timeout
                    );
                    return await result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Mapeo de una entidad con varias relaciones: B, C, D ...
        // Ejecuta un query de un listado donde se involucren 2 entidades
        // Dapper admite la relacion de 7 entidades máximo
        public async Task<IEnumerable<T>> QueryAsync<T, B>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B>(sql: sp,
                        param: Param,
                        commandType: System.Data.CommandType.StoredProcedure,
                        commandTimeout: Timeout
                    );
                    return await result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C>(sql: sp,
                        param: Param,
                        commandType: System.Data.CommandType.StoredProcedure,
                        commandTimeout: Timeout
                    );
                    return await result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C, D>(sql: sp,
                        param: Param,
                        commandType: System.Data.CommandType.StoredProcedure,
                        commandTimeout: Timeout
                    );
                    return await result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C, D, E>(sql: sp,
                        param: Param,
                        commandType: System.Data.CommandType.StoredProcedure,
                        commandTimeout: Timeout
                    );
                    return await result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E, F>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C, D, E, F>(sql: sp,
                        param: Param,
                        commandType: System.Data.CommandType.StoredProcedure,
                        commandTimeout: Timeout
                    );
                    return await result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E, F, G>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C, D, E, F, G>(sql: sp,
                        param: Param,
                        commandType: System.Data.CommandType.StoredProcedure,
                        commandTimeout: Timeout
                    );
                    return await result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Metodo para obtener los detalles para editar una entidad
        public async Task<T> QueryFirstAsync<T>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryFirstOrDefaultAsync<T>(sql: sp,
                        param: Param,
                        commandType: System.Data.CommandType.StoredProcedure,
                        commandTimeout: Timeout
                    );
                    return await result;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Metodo para hacer la representacion de las operaciones CRUD
        public async Task<DBEntity> ExecuteAsync(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = await exec.ExecuteReaderAsync(sql: sp,
                        param: Param,
                        commandType: System.Data.CommandType.StoredProcedure,
                        commandTimeout: Timeout
                    );
                    await result.ReadAsync();
                    return new()
                    {
                        // Mapeo de errores que sql envia
                        CodeError = result.GetInt32(0),
                        MsgError = result.GetString(1)
                    };
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
