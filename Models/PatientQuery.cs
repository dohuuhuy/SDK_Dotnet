using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace microservice_1.Models
{
    public class PatientQuery
    {
        public AppDb Db { get; }

        public PatientQuery(AppDb db)
        {
            Db = db;
        }
        public async Task<PatientPost> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `patient` WHERE `id` = @id or `cmnd` = @cmnd or `mobile` = @mobile";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@cmnd",
                DbType = DbType.Int32,
                Value = id,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@mobile",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<PatientPost>> LatestPostsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `patient` ORDER BY `id` DESC LIMIT 100000;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        public async Task DeleteAllAsync()
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `patient`";
            await cmd.ExecuteNonQueryAsync();
            await txn.CommitAsync();
        }
        private async Task<List<PatientPost>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<PatientPost>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new PatientPost(Db)
                    {
                        id = reader.GetInt32("id"),
                        bvdhyd_msbn = reader.IsDBNull(reader.GetOrdinal("mobile")) ? null : reader.GetString("mobile"),
                        medpro_id = reader.IsDBNull(reader.GetOrdinal("medpro_id")) ? null : reader.GetString("medpro_id"),
                        surname = reader.IsDBNull(reader.GetOrdinal("surname")) ? null : reader.GetString("surname"),
                        name = reader.IsDBNull(reader.GetOrdinal("name")) ? null : reader.GetString("name"),
                        cmnd = reader.IsDBNull(reader.GetOrdinal("cmnd")) ? null : reader.GetString("cmnd"),
                        sex = reader.IsDBNull(reader.GetOrdinal("cmnd")) ?  true: reader.GetBoolean("sex"),
                        dantoc_id = reader.IsDBNull(reader.GetOrdinal("dantoc_id")) ? -1 : reader.GetInt32("dantoc_id"),
                        profession_id = reader.IsDBNull(reader.GetOrdinal("profession_id")) ? -1 : reader.GetInt32("profession_id"),
                        birthdate = reader.IsDBNull(reader.GetOrdinal("birthdate")) ? DateTime.MinValue : reader.GetDateTime("birthdate"),
                        birthyear = reader.IsDBNull(reader.GetOrdinal("birthyear")) ? -1 : reader.GetInt32("birthyear"),
                        job = reader.IsDBNull(reader.GetOrdinal("job")) ? null : reader.GetString("job"),
                        bhyt = reader.IsDBNull(reader.GetOrdinal("bhyt")) ? null : reader.GetString("bhyt"),
                        mobile = reader.IsDBNull(reader.GetOrdinal("mobile")) ? null : reader.GetString("mobile"),
                        email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString("email"),
                        country_code = reader.IsDBNull(reader.GetOrdinal("country_code")) ? null : reader.GetString("country_code"),
                        city_id = reader.IsDBNull(reader.GetOrdinal("city_id")) ? -1 : reader.GetInt32("city_id"),
                        district_id = reader.IsDBNull(reader.GetOrdinal("district_id")) ? -1 : reader.GetInt32("district_id"),
                        ward_id = reader.IsDBNull(reader.GetOrdinal("ward_id")) ? -1 : reader.GetInt32("ward_id"),
                        address = reader.IsDBNull(reader.GetOrdinal("address")) ? null : reader.GetString("address"),
                        note = reader.IsDBNull(reader.GetOrdinal("note")) ? null : reader.GetString("note"),
                        is_medpro = reader.IsDBNull(reader.GetOrdinal("is_medpro")) ? -1 : reader.GetInt32("is_medpro"),
                        origin_id = reader.IsDBNull(reader.GetOrdinal("origin_id")) ? -1 : reader.GetInt32("origin_id"),
                        date_create = reader.GetDateTime("date_create"),
                        date_update = reader.GetDateTime("date_update"),
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }


    }
}

