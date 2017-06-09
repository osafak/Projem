using ClassLibrary.Infrastucture;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class Saloon
    {
        public int ID { get; set; }
        public string SaloonName { get; set; }
        public int SaloonQuata { get; set; }
        public string SaloonAddress { get; set; }
        public string SaloonLocation { get; set; }
        public Boolean IsDeleted { get; set; }

        public int save()
        {
            if (this.ID == 0)
            {
                this.ID = DAL.insertSql("insert into Saloon(FacultyName) values (@FacultyName)", new MySqlParameter("@FacultyName", this.SaloonName));
            }
            else
            {
                DAL.insertSql("update Faculty set FacultyName = @FacultyName where ID = @ID",
                    new List<MySqlParameter>()
                    {
                        new MySqlParameter("@FacultyName",this.SaloonName),
                        new MySqlParameter("@ID",this.ID)
                    }
                    );
            }
            return this.ID;
        }

        public void Delete()
        {
            DAL.insertSql("update Faculty set IsDeleted=1 Where ID=@ID", new MySqlParameter("@ID", this.ID));
        }

        public List<Saloon> getFaculties(string filter)
        {

            List<Saloon> result = new List<Saloon>();

            DataTable data = DAL.readData("select * from Faculty where IsDeleted=0 and FacultyName Like @filter", new MySqlParameter("@filter", '%' + filter + '%'));



            foreach (DataRow dr in data.Rows)
            {

                result.Add(
                    new Saloon
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        SaloonName = dr["FacultyName"].ToString()
                    }
               );

            }
            return result;
        }

        public void getFaculty()
        {
            DataTable data = DAL.readData("select * from Faculty where ID=@ID", new MySqlParameter("@ID", this.ID));
            this.SaloonName = data.Rows[0]["FacultyName"].ToString();
            this.IsDeleted = Convert.ToBoolean(data.Rows[0]["IsDeleted"].ToString());
        }

    }
}
