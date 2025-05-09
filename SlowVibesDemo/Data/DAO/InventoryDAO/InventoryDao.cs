

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SlowVibesDemo.Data.DAO.String_Connection;
using SlowVibesDemo.Data.DTO.entities;

namespace SlowVibesDemo.Data.DAO.InventoryDAO
{
    public class InventoryDao : ConnectionString
    {
        MySqlDataReader reader;
        MySqlCommand cmd;
        List<SalesHistory> salesHistories = new List<SalesHistory>();

        public List<SalesHistory> GetSalesHistories()
        {
            cmd = new MySqlCommand("Select * from saleshistory",connection);
            try
            {
                connection.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows) 
                {
                    while (reader.Read())
                    {
                        salesHistories.Add(new SalesHistory
                        {
                            Id = reader.GetInt32(0),
                            ProductName = reader.GetString(1),
                            SaleDate = reader.GetDateTime(2),
                            SalePrice = reader.GetInt32(3),
                            Profit = reader.GetInt32(4),
                            ReinvestmentAmount = reader.GetInt32(5),
                        });

                    }
                }
            }
            catch (Exception  ex) 
            {
                MessageBox.Show("Ocurrio un erro al intentar cargar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return salesHistories;
        }
    }
}
