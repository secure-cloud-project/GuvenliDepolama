using GuvenliDepolama.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;

namespace GuvenliDepolama.Manager
{
    public class SqlMnager
    {
        public string AddUser(User item)
        {
            var ret = "";
            try
            {
                using (var connection = new SqlConnection(Setting.ConnectionString))
                {

                    var param = new DynamicParameters();
                    param.Add("Name", item.Name);
                    param.Add("Surname", item.SurName);
                    param.Add("Mail", item.Mail);
                    param.Add("Password", item.Password);
                    ret = connection.Query<string>("CreateUser", param: param, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public User CheckUser(string Mail, string Password)
        {
            var ret = new User();
            try
            {
                using (var connection = new SqlConnection(Setting.ConnectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("Mail", Mail);
                    param.Add("Password", Password);

                    ret = connection.Query<User>("dbo.CheckUser", param, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }
    }
}