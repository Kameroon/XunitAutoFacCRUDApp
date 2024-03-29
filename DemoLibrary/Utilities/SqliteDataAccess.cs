﻿using Dapper;
using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;

namespace DemoLibrary.Utilities
{
    public class SqliteDataAccess : ISqliteDataAccess
    {
        public List<T> LoadData<T>(string sql)
        {
            //using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            IDbConnection cnn = CreateConnection();
            {
                var output = cnn.Query<T>(sql, new DynamicParameters());
                return output.ToList();
            }
        }

        public void SaveData<T>(T person, string sql)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(sql, person);
            }
        }

        public void UpdateData<T>(T person, string sql)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(sql, person);
            }
        }

        private string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private SqlConnection CreateConnection()
        {
            string connetionString = "Data Source=DESKTOP-6DSO6AT\\SQLEXPRESS; Database=JunkEFCodeFrist1; Trusted_Connection=True";

            //using (var conn = new SqlConnection(Helper.GetConnectionString()))
            return new SqlConnection(connetionString);
            
        }
    }
}
