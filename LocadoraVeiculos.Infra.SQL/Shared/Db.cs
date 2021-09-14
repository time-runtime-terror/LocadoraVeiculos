using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;

namespace LocadoraVeiculos.netCore.Infra.SQL.Shared
{
    public delegate T ConverterDelegate<T>(IDataReader reader);

    public static class Db
    {
        private static readonly string connectionString = string.Empty;
        private static readonly string providerName = string.Empty;
        private static DbProviderFactory providerFactory;

        static Db()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            connectionString = config.Build().GetConnectionString("SqlServer");

            providerName = config.Build().GetSection("providerName").Value;

            DbProviderFactories.RegisterFactory(providerName, SqlClientFactory.Instance);

            providerFactory = DbProviderFactories.GetFactory(providerName);
        }

        public static int Insert(string sql, Dictionary<string, object> parameters)
        {
            int id;

            IDbConnection connection = providerFactory.CreateConnection();
            connection.ConnectionString = connectionString;

            IDbCommand command = providerFactory.CreateCommand();
            command.Connection = connection;

            command.CommandText = sql.AppendSelectIdentity();
            command.SetParameters(parameters);

            connection.Open();

            id = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();

            return id;
        }

        public static void Update(string sql, Dictionary<string, object> parameters = null)
        {
            IDbConnection connection = providerFactory.CreateConnection();
            connection.ConnectionString = connectionString;

            IDbCommand command = providerFactory.CreateCommand();
            command.Connection = connection;

            command.CommandText = sql;
            command.SetParameters(parameters);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }

        public static void Delete(string sql, Dictionary<string, object> parameters)
        {
            Update(sql, parameters);
        }

        public static List<T> GetAll<T>(string sql, ConverterDelegate<T> convert, Dictionary<string, object> parameters = null)
        {
            var list = new List<T>();

            IDbConnection connection = providerFactory.CreateConnection();
            connection.ConnectionString = connectionString;

            IDbCommand command = providerFactory.CreateCommand();
            command.Connection = connection;

            command.CommandText = sql;
            command.SetParameters(parameters);

            connection.Open();

            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var obj = convert(reader);
                    list.Add(obj);
                }
            }

            connection.Close();

            return list;
        }

        public static T Get<T>(string sql, ConverterDelegate<T> convert, Dictionary<string, object> parameters)
        {
            T t = default;

            IDbConnection connection = providerFactory.CreateConnection();
            connection.ConnectionString = connectionString;

            IDbCommand command = providerFactory.CreateCommand();
            command.Connection = connection;

            command.CommandText = sql;
            command.SetParameters(parameters);

            connection.Open();

            using (IDataReader reader = command.ExecuteReader())
                if (reader.Read())
                    t = convert(reader);

            return t;
        }

        public static bool Exists(string sql, Dictionary<string, object> parameters)
        {
            int numberRows;

            IDbConnection connection = providerFactory.CreateConnection();
            connection.ConnectionString = connectionString;

            IDbCommand command = providerFactory.CreateCommand();
            command.Connection = connection;

            command.CommandText = sql;
            command.SetParameters(parameters);

            connection.Open();

            numberRows = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();

            return numberRows > 0;
        }

        private static void SetParameters(this IDbCommand command, Dictionary<string, object> parameters)
        {
            if (parameters == null || parameters.Count == 0)
                return;

            foreach (var parameter in parameters)
            {
                string name = parameter.Key;

                object value = parameter.Value.IsNullOrEmpty() ? DBNull.Value : parameter.Value;

                IDataParameter newParameter = command.CreateParameter();

                newParameter.ParameterName = name;

                newParameter.Value = value;

                command.Parameters.Add(newParameter);
            }
        }

        private static string AppendSelectIdentity(this string sql)
        {
            return sql + ";SELECT SCOPE_IDENTITY()";
        }

        private static bool IsNullOrEmpty(this object value)
        {
            return (value is string && string.IsNullOrEmpty((string)value)) ||
                    value == null;
        }

    } 
}
