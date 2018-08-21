using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestContactMVVM.Model.Global
{
    public class ContactService : IRepository<Contact, int>
    {
        public IEnumerable<Contact> Get()
        {
            List<Contact> Contacts = new List<Contact>();

            using (SqlConnection c = new SqlConnection())
            {
                c.ConnectionString = @"Data Source=DESKTOP-JSNUG5P\SQLEXPRESS;Initial Catalog=ExoDB;Integrated Security=True;Pooling=False;Pooling=False";

                SqlCommand cmd = c.CreateCommand();
                cmd.CommandText = "select * from contact;";

                c.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Contact co = new Contact()
                    {
                        ID = (int)reader["ID"],
                        Nom = (string)reader["Nom"],
                        Prenom = (string)reader["Prenom"],
                        Email = (string)reader["Email"],
                        DateNaiss = (DateTime)reader["DateNaiss"]
                    };

                    Contacts.Add(co);
                }                
            }

            return Contacts;
        }

        public Contact Get(int ID)
        {
            throw new NotImplementedException();
        }

        public Contact Insert(Contact Entity)
        {
            using (SqlConnection c = new SqlConnection())
            {
                c.ConnectionString = @"Data Source=DESKTOP-JSNUG5P\SQLEXPRESS;Initial Catalog=ExoDB;Integrated Security=True;Pooling=False;Pooling=False";

                SqlCommand cmd = c.CreateCommand();
                cmd.CommandText = "insert into Contact (Nom, Prenom, Email, DateNaiss) output inserted.ID values (@Nom, @Prenom, @Email, @DateNaiss);";
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Nom", Value = Entity.Nom });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Prenom", Value = Entity.Prenom });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Email", Value = Entity.Email });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@DateNaiss", Value = Entity.DateNaiss });

                c.Open();

                object o = cmd.ExecuteScalar();

                //c.Close();
                if (o is int)
                {
                    Entity.ID = (int)o;
                    return Entity;
                }               
            }

            return null;
        }

        public bool Update(int ID, Contact Entity)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int ID)
        {
            using (SqlConnection c = new SqlConnection())
            {
                c.ConnectionString = @"Data Source=DESKTOP-JSNUG5P\SQLEXPRESS;Initial Catalog=ExoDB;Integrated Security=True;Pooling=False;Pooling=False";

                SqlCommand cmd = c.CreateCommand();
                cmd.CommandText = "delete from Contact where ID = @ID;";
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = ID });

                c.Open();

                int rows = cmd.ExecuteNonQuery();

                if(rows == 1)
                {
                    return true;
                }
                
                return false;                
            }
        }
    }
}
