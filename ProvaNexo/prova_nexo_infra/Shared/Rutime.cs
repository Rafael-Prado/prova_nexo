
using Dapper;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace prova_nexo_infra.Shared
{
    public static class Runtime
    {
        public static string ConnectionStringConfig;

        private static SqlConnection connection;

        public static SqlConnection Connection
        {
            get
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                    connection = null;
                    connection = new SqlConnection(ConnectionStringConfig);
                }
                else
                {
                    connection = new SqlConnection(ConnectionStringConfig);
                }

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                return connection;
            }
        }

        public static IEnumerable<T> Query<T>(string sql, object param = null)
        {
            using (var conn = new SqlConnection(ConnectionStringConfig))
            {
                conn.Open();
                var list = conn.Query<T>(sql, param);
                conn.Close();
                return list;
            }
        }

        public static IEnumerable Query(string sql, object param = null)
        {
            using (var conn = new SqlConnection(ConnectionStringConfig))
            {
                conn.Open();
                var list = conn.Query(sql, param);
                conn.Close();
                return list;
            }
        }

        public static async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
        {
            using (var conn = new SqlConnection(ConnectionStringConfig))
            {
                conn.Open();
                var list = await conn.QueryAsync<T>(sql, param);
                conn.Close();
                return list;
            }
        }

        public static T QuerySingle<T>(string sql, object param = null)
        {
            using (var conn = new SqlConnection(ConnectionStringConfig))
            {
                conn.Open();
                var item = conn.QuerySingle<T>(sql, param);
                conn.Close();
                return item;
            }
        }

        public static T QueryFirstOrDefault<T>(string sql, object param = null)
        {
            using (var conn = new SqlConnection(ConnectionStringConfig))
            {
                conn.Open();
                var item = conn.QueryFirstOrDefault<T>(sql, param);
                conn.Close();
                return item;
            }
        }

        public static T QueryFirst<T>(string sql, object param = null)
        {
            using (var conn = new SqlConnection(ConnectionStringConfig))
            {
                conn.Open();
                var item = conn.QueryFirst<T>(sql, param);
                conn.Close();
                return item;
            }
        }

        public static long Execute(string sql)
        {
            using (var conn = new SqlConnection(ConnectionStringConfig))
            {
                conn.Open();
                var id = conn.ExecuteScalar(sql);
                conn.Close();
                return id == null ? 0 : long.Parse(id.ToString());
            }
        }
    }
}
