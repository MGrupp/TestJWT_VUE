using System;
using System.Collections.Generic;
using System.Data;
using WebApiJWT.Models;

namespace WebApiJWT
{
    public class UserPE : BasePE
    {
        public UserPE()
        {
        }

        public int CreateUser(IDbConnection conexion, BOUser obj)
        {
            string sql = "INSERT INTO USER " +
                "(" +
                "EMAIL," +
                "CLAVE," +
                "COUNTRY" +
                ")" +
                " VALUES " +
                "(" +
                "'" + obj.Email + "'," +
                "'" + obj.Password + "'," +
                "'" + obj.Country + "'" +
                ")";
            int resp = 0;
            switch (Util._GestorBaseDatos)
            {
                case Util.GestorBaseDatos.MySQL:
                    DataBase.ExecuteNonQuery(sql, conexion);
                    sql = "SELECT AUTO_INCREMENT FROM information_schema.tables WHERE table_name = 'USER'";
                    resp = Convert.ToInt32(DataBase.ExecuteScalar(sql, conexion)) - 1;
                    break;
                default:
                    break;
            }
            return resp;
        }

        public void UpdateUser(IDbConnection conexion, BOUser obj)
        {
            string sql = "UPDATE USER SET" +
                " EMAIL='" + obj.Email + "'," +
                " CLAVE='" + obj.Password + "'," +
                " COUNTRY='" + obj.Country + "'" +
                " WHERE ID='" + obj.Id + "'";
            DataBase.ExecuteNonQuery(sql, conexion);
        }

        public void DeleteUser(IDbConnection conexion, int idUser)
        {
            string sql = "DELETE FROM USER WHERE ID='" + idUser + "'";
            DataBase.ExecuteNonQuery(sql, conexion);
        }

        public BOUser GetUserById(IDbConnection conexion, int idUser)
        {
            BOUser resp = null;
            string sql = "SELECT * FROM USER" +
                " WHERE ID=" + idUser;
            using (var dr = DataBase.ExecuteReader(sql, conexion))
            {
                while (dr.Read())
                {
                    resp = Load(dr);
                }
            }
            return resp;
        }

        public List<BOUser> GetAllUsers(IDbConnection conexion)
        {
            List<BOUser> resp = new List<BOUser>();
            string sql = "SELECT * FROM USER";
            using (var dr = DataBase.ExecuteReader(sql, conexion))
            {
                while (dr.Read())
                {
                    resp.Add(Load(dr));
                }
            }
            return resp;
        }

        private BOUser Load(IDataReader reader)
        {
            BOUser obj = new BOUser();
            obj.Id = NotNullDataReader.GetInt32(reader, "ID");
            obj.Email = NotNullDataReader.GetString(reader, "EMAIL");
            obj.Password = NotNullDataReader.GetString(reader, "CLAVE");
            obj.Country = NotNullDataReader.GetString(reader, "COUNTRY");
            return obj;
        }

        public BOUser UserLogin(IDbConnection conexion, BOUser obj)
        {
            BOUser resp = null;
            string sql = "SELECT * FROM USER" +
                " WHERE EMAIL = '" + obj.Email + "' AND CLAVE= '" + obj.Password + "'";
            using (var dr = DataBase.ExecuteReader(sql, conexion))
            {
                while (dr.Read())
                {
                    resp = Load(dr);
                }
            }
            return resp;
        }

    }
}