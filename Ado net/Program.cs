﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ADOnet
{
    class PatientDoctor
    {
        public int id { get; set; }
        public string PatienName { get; set; }
        public string DoctorName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<PatientDoctor> listPd = new List<PatientDoctor>();

            
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DafaultConnection"].ConnectionString;
                var sqlClient = "SELECT * FROM Patient; SELECT * FROM Doctor";
                var adapter = new SqlDataAdapter(sqlClient, connection);
                var dataset = new DataSet();
               
                adapter.Fill(dataset);

                var dataTable = dataset.Tables[0];
                var dataTable1 = dataset.Tables[1];

                var newRow = dataTable.NewRow();
                newRow["Id"] = 9;
                newRow["Name"] = "Pous";
                newRow["Age"] = "45";

                dataTable.Rows.Add(newRow);

                var commandBuilder = new SqlCommandBuilder(adapter);

                adapter.Update(dataset);

                foreach (var row in dataTable.Rows)
                {
                    Console.WriteLine(row);
                }
            }
            //using (SqlConnection connection = new SqlConnection())
            //{
            //    connection.ConnectionString = ConfigurationManager.ConnectionStrings["DafaultConnection"].ConnectionString;
            //    connection.Open();

            //    using (var command = connection.CreateCommand())
            //    {
            //        command.CommandText = @"select p.id as PatientId, p.name as PatientName , d.name as DoctorName from Patient p
            //                                left join PatientDoctor pd on pd.PatientId= p.id
            //                                left join Doctor d on pd.DoctorId =d.id";

            //        using (var reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                listPd.Add(new PatientDoctor
            //                {
            //                    id = (int)reader["PatientId"],
            //                    PatienName = reader["PatientName"] != DBNull.Value ? (string)reader["PatientName"] : string.Empty,
            //                    DoctorName = reader["DoctorName"] != DBNull.Value ? (string)reader["DoctorName"] : string.Empty
            //                });
            //            }
            //        }
            //    }
            //}

            //var group = listPd.GroupBy(x => x.PatienName);
            //foreach (IGrouping<string, PatientDoctor> g in group)
            //{
            //    Console.Write(g.Key + "\n");
            //    foreach (var t in g)
            //    {
            //        Console.Write("\t\t" + t.DoctorName + "\n");
            //    }
            //}

            //using (SqlConnection connection = new SqlConnection())
            //{
            //    connection.ConnectionString = @"Data Source=VAL\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=true";
            //    connection.Open();

            //    using (var command = connection.CreateCommand())
            //    {
            //        command.CommandText = @"INSERT INTO Patient(Name, Age)
            //                                 VALUES ('Viktor', 48);";

            //        var write = command.ExecuteNonQuery();
            //        Console.WriteLine(write);
            //    }
            //}


            //using (SqlConnection connection = new SqlConnection())
            //{
            //    connection.ConnectionString = @"Data Source=VAL\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=true";
            //    connection.Open();

            //    using (var command = connection.CreateCommand())
            //    {
            //        command.CommandText = @"DELETE FROM Patient WHERE id=5 ";

            //        var write = command.ExecuteNonQuery();
            //        Console.WriteLine(write);
            //    }
            //}
        }
    }
}
