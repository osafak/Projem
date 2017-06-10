﻿using ClassLibrary.Infrastructure;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ClassLibrary.Models
{
    public class EventType
    {
        public int ID { get; set; }
        public string TypeName { get; set; }
        public Boolean IsDeleted { get; set; }
        public int save()
        {
            if (this.ID == 0)
            {
                this.ID = DAL.insertSql("insert into ActivityType values (@TypeName)", new MySqlParameter("@TypeName", this.TypeName));
            }
            else
            {
                DAL.insertSql("update ActivityType set TypeName = @TypeName where ID = @ID",
                    new List<MySqlParameter>()
                    {
                        new MySqlParameter("@TypeName",this.TypeName),
                        new MySqlParameter("@ID",this.ID)
                    }
                    );
            }
            return this.ID;
        }

        public void Delete()
        {
            DAL.insertSql("update ActivityType set IsDeleted=1 Where ID=@ID", new MySqlParameter("@ID", this.ID));
        }

        public List<EventType> getActivities(string filter)
        {

            List<EventType> result = new List<EventType>();

            DataTable data = DAL.readData("select * from ActivityType where IsDeleted=0 and TypeName Like @filter", new MySqlParameter("@filter", '%' + filter + '%'));

            foreach (DataRow dr in data.Rows)
            {

                result.Add(
                    new EventType
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        TypeName = dr["TypeName"].ToString()
                    }
               );

            }
            return result;
        }

        public void getActivity()
        {
            DataTable data = DAL.readData("select * from ActivityType where ID=@ID", new MySqlParameter("@ID", this.ID));
            this.TypeName = data.Rows[0]["TypeName"].ToString();
            this.IsDeleted = Convert.ToBoolean(data.Rows[0]["IsDeleted"].ToString());
        }
    }
}
