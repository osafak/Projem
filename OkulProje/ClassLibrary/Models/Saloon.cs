using ClassLibrary.Infrastructure;
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
                this.ID = DAL.insertSql("insert into Saloon(SaloonName,SaloonQuata,SaloonAddress,SaloonLocation) values (@SaloonName,@SaloonQuata,@SaloonAddress,@SaloonLocation)", new List<MySqlParameter>()
                    {
                        new MySqlParameter("@SaloonName",this.SaloonName),
                        new MySqlParameter("@SaloonQuata",this.SaloonQuata),
                        new MySqlParameter("@SaloonAddress",this.SaloonAddress),
                        new MySqlParameter("@SaloonLocation",this.SaloonLocation)
                    });
            }
            else
            {
                DAL.insertSql("update Speakers set SaloonName = @SaloonName, SaloonQuata=@SaloonQuata, SaloonAddress=@SaloonAddress, SaloonLocation=@SaloonLocation where ID = @ID",
                   new List<MySqlParameter>()
                   {
                       new MySqlParameter("@SaloonName",this.SaloonName),
                        new MySqlParameter("@SaloonQuata",this.SaloonQuata),
                        new MySqlParameter("@SaloonAddress",this.SaloonAddress),
                        new MySqlParameter("@SaloonLocation",this.SaloonLocation),
                        new MySqlParameter("@ID",this.ID)
                   }
                   );
            }
            return this.ID;
        }

        public void Delete()
        {
            DAL.insertSql("update Saloon set IsDeleted=1 Where ID=@ID", new MySqlParameter("@ID", this.ID));
        }

        public List<Saloon> getSaloons(string filter)
        {

            List<Saloon> result = new List<Saloon>();

            DataTable data = DAL.readData("select * from Saloon where IsDeleted=0 and SaloonName Like @filter", new MySqlParameter("@filter", '%' + filter + '%'));



            foreach (DataRow dr in data.Rows)
            {

                result.Add(
                    new Saloon
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        SaloonName = dr["SaloonName"].ToString(),
                        SaloonQuata = Convert.ToInt32(dr["SaloonQuata"]),
                        SaloonAddress = dr["SaloonAddress"].ToString(),
                        SaloonLocation = dr["SaloonLocation"].ToString()
                    }
               );

            }
            return result;
        }

        public void getSaloon()
        {
            DataTable data = DAL.readData("select * from Saloon where ID=@ID", new MySqlParameter("@ID", this.ID));
            this.SaloonName = data.Rows[0]["SaloonName"].ToString();
            this.SaloonQuata = Convert.ToInt32(data.Rows[0]["SaloonQuata"].ToString());
            this.SaloonAddress = data.Rows[0]["SaloonAddress"].ToString();
            this.SaloonLocation = data.Rows[0]["SaloonLocation"].ToString();
            this.IsDeleted = Convert.ToBoolean(data.Rows[0]["IsDeleted"].ToString());
        }

    }
}
