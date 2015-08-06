using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Reflection;

namespace MedicalManagement.Models
{
    public class Helpers
    {
        public static string connection = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
        public static SqlCommand dataReader(string query)
        {
            var cmd = new SqlCommand();
            var sqlcon = new SqlConnection(connection);
            cmd.CommandText = query;
            cmd.Connection = sqlcon;
            return cmd;
        }

        public static void ExecutarNonQuery(string query)
        {
            connection = ConfigurationManager.ConnectionStrings["conuni"].ConnectionString;
            var cmd = new SqlCommand();
            var sqlcon = new SqlConnection(connection);
            cmd.CommandText = query;
            cmd.Connection = sqlcon;
            sqlcon.Open();
            cmd.ExecuteNonQuery();
            sqlcon.Close();
        }

        public static int ExecutarNonQueryInt(string query)
        {
            int valor = 0;
            connection = ConfigurationManager.ConnectionStrings["conuni"].ConnectionString;
            var cmd = new SqlCommand();
            var sqlcon = new SqlConnection(connection);
            cmd.CommandText = query;
            cmd.Connection = sqlcon;
            sqlcon.Open();
            try
            {
                valor = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch { }
            sqlcon.Close();
            return valor;
        }

        public string GetPropertyName<T>(Expression<Func<T>> propertyLambda)
        {
            var me = propertyLambda.Body as MemberExpression;

            if (me == null)
            {
                throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }
            return me.Member.Name;
        }

        public List<T> GetAll<T>(string query) where T : class, new()
        {
            List<propiedades> listaPropiedades = new List<propiedades>();
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                propiedades p = new propiedades();
                p.Nombre = prop.Name;
                p.Datatype = prop.PropertyType;
                listaPropiedades.Add(p);
            }
            List<T> lT = new List<T>();
            var cmd = dataReader(query);
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                T t = new T();
                for (int index = 0; index < listaPropiedades.Count; index++)
                {
                    var y = listaPropiedades[index];
                    if (dr.HasColumn(y.Nombre))
                    {
                        int i = dr.GetOrdinal(y.Nombre);
                        if (y.Datatype == typeof(string) && !dr.IsDBNull(i))
                        {
                            string x = dr.GetString(i);
                            t.SetPropertyValue(y.Nombre, x);
                        }
                        if (y.Datatype == typeof(int) && !dr.IsDBNull(i))
                        {
                            var x = dr.GetInt32(i);
                            t.SetPropertyValue(y.Nombre, x);
                        }
                        if (y.Datatype == typeof(decimal) && !dr.IsDBNull(i))
                        {
                            var x = dr.GetDecimal(i);
                            t.SetPropertyValue(y.Nombre, x);
                        }
                        if (y.Datatype == typeof(DateTime) && !dr.IsDBNull(i))
                        {
                            var x = dr.GetDateTime(i);
                            t.SetPropertyValue(y.Nombre, x);
                        }
                    }
                }
                lT.Add(t);
            }
            cmd.Connection.Close();
            cmd.Connection.Dispose();
            return lT;
        }

        public List<T> GetAllParametized<T>(string query, T objec) where T : class, new()
        {
            List<propiedades> listaPropiedades = new List<propiedades>();
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                propiedades p = new propiedades();
                p.Nombre = prop.Name;
                p.Datatype = prop.PropertyType;
                listaPropiedades.Add(p);
            }
            List<T> lT = new List<T>();
            var cmd = dataReader(query);
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                propiedades p = new propiedades();
                p.Nombre = prop.Name;
                p.Datatype = prop.PropertyType;
                listaPropiedades.Add(p);
                var value = objec.GetPropertyValue(prop.Name);
                bool validDate = true;
                if ((value is DateTime))
                {
                    if ((DateTime)value <= DateTime.Parse("1/01/1900"))
                    {
                        validDate = false;
                    }
                }
                if (value != null && validDate)
                {
                    cmd.Parameters.AddWithValue(prop.Name, objec.GetPropertyValue(prop.Name));
                }
            }
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                T t = new T();
                for (int index = 0; index < listaPropiedades.Count; index++)
                {
                    var y = listaPropiedades[index];
                    if (dr.HasColumn(y.Nombre))
                    {
                        int i = dr.GetOrdinal(y.Nombre);
                        if (y.Datatype == typeof(string) && !dr.IsDBNull(i))
                        {
                            string x = dr.GetString(i);
                            t.SetPropertyValue(y.Nombre, x);
                        }
                        if (y.Datatype == typeof(int) && !dr.IsDBNull(i))
                        {
                            var x = dr.GetInt32(i);
                            t.SetPropertyValue(y.Nombre, x);
                        }
                        if (y.Datatype == typeof(decimal) && !dr.IsDBNull(i))
                        {
                            var x = dr.GetDecimal(i);
                            t.SetPropertyValue(y.Nombre, x);
                        }
                        if (y.Datatype == typeof(DateTime) && !dr.IsDBNull(i))
                        {
                            var x = dr.GetDateTime(i);
                            t.SetPropertyValue(y.Nombre, x);
                        }
                    }
                }
                lT.Add(t);
            }
            cmd.Connection.Close();
            cmd.Connection.Dispose();
            return lT;
        }

        public T GetOne<T>(string query) where T : class, new()
        {
            List<propiedades> listaPropiedades = new List<propiedades>();
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                propiedades p = new propiedades();
                p.Nombre = prop.Name;
                p.Datatype = prop.PropertyType;
                listaPropiedades.Add(p);
            }
            var cmd = dataReader(query);
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            T t = new T();
            while (dr.Read())
            {
                for (int index = 0; index < listaPropiedades.Count; index++)
                {
                    var y = listaPropiedades[index];
                    if (dr.HasColumn(y.Nombre))
                    {
                        int i = dr.GetOrdinal(y.Nombre);
                        if (y.Datatype == typeof(string) && !dr.IsDBNull(i))
                        {
                            string x = dr.GetString(i);
                            t.SetPropertyValue(y.Nombre, x);
                        }
                        if (y.Datatype == typeof(int) && !dr.IsDBNull(i))
                        {
                            var x = dr.GetInt32(i);
                            t.SetPropertyValue(y.Nombre, x);
                        }
                        if (y.Datatype == typeof(decimal) && !dr.IsDBNull(i))
                        {
                            var x = dr.GetDecimal(i);
                            t.SetPropertyValue(y.Nombre, x);
                        }
                        if (y.Datatype == typeof(DateTime) && !dr.IsDBNull(i))
                        {
                            var x = dr.GetDateTime(i);
                            t.SetPropertyValue(y.Nombre, x);
                        }
                    }
                }
            }
            return t;
        }


        public void ExecuteNonQueryParam<T>(string query, T objec) where T : class, new()
        {
            List<propiedades> listaPropiedades = new List<propiedades>();
            var checkDate = new DateTime(1900, 01, 01);
            var cmd = dataReader(query);
            cmd.Connection.Open();
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                propiedades p = new propiedades();
                p.Nombre = prop.Name;
                p.Datatype = prop.PropertyType;
                listaPropiedades.Add(p);
                var value = objec.GetPropertyValue(prop.Name);
                if (value != null)
                {
                    cmd.Parameters.AddWithValue(prop.Name, objec.GetPropertyValue(prop.Name));
                }
                if (value is DateTime)
                {
                    if ((DateTime)value < checkDate)
                    {
                        cmd.Parameters.RemoveAt(cmd.Parameters.Count-1);
                    }
                }
                
            }
            cmd.ExecuteNonQuery();
        }

       

        public class propiedades
        {
            public string Nombre { get; set; }
            public Type Datatype { get; set; }
        }


    }
}