using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace microservice_1.Models
{
    public class PatientPost
    {
        public int id { get; set; }
        public string bvdhyd_msbn { get; set; }
        public string medpro_id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string cmnd { get; set; }
        public bool sex { get; set; }
        public int dantoc_id { get; set; }
        public int profession_id { get; set; }
        public DateTime birthdate { get; set; }
        public int birthyear { get; set; }
        public string job { get; set; }
        public string bhyt { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string country_code { get; set; }
        public int city_id { get; set; }
        public int district_id { get; set; }
        public int ward_id { get; set; }
        public string address { get; set; }
        public string note { get; set; }
        public int is_medpro { get; set; }
        public int origin_id { get; set; }
        public DateTime date_create { get; set; }
        public DateTime date_update { get; set; }


        internal AppDb Db { get; set; }
        internal PatientPost()
        {

        }


        internal PatientPost(AppDb db)
        {
            Db = db;
        }

        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();

            cmd.CommandText = @"INSERT INTO `patient` (`surname`, `name`) value ( @surname, @name)";

            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            id = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `patient` SET `Title` = @title, `Content` = @content WHERE `id` = @id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `patient` WHERE `id` = @id;";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
        }

        private void BindCmnd(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@cmnd",
                DbType = DbType.Int32,
                Value = id,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@sdt",
                DbType = DbType.Int32,
                Value = id,
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@surname",
                DbType = DbType.String,
                Value = surname,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@name",
                DbType = DbType.String,
                Value = name,
            });
        }
    }

}

