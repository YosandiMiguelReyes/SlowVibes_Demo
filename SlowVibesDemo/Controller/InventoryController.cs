

using System;
using System.Collections.Generic;
using SlowVibesDemo.Data.DAO.InventoryDAO;

namespace SlowVibesDemo.Controller
{
    
    public class InventoryController
    {
        Form1 inventory;
        InventoryDao inventoryDao = new InventoryDao();
        public InventoryController(Form1 _inventory) 
        {
            inventory = _inventory;

            #region Event handler
            inventory.btnExit.Click += new EventHandler(Exit);
            inventory.Load += new EventHandler(LoadInventoryHistori);
            inventory.txbSearch.TextChanged += new EventHandler(GetSuggestions);
            #endregion
        }



        public void Exit (object sender, EventArgs e) 
        {
            inventory.Close();
        }
        public void LoadInventoryHistori(object semder, EventArgs args) 
        {
            inventory.dataGridView1.DataSource = inventoryDao.GetSalesHistories();
        }
        public void GetSuggestions(object sender, EventArgs e) 
        {
            //= inventoryDao.GetProductSuggestion(inventory.txbSearch.Text.ToString());
            List<string> suggestions = inventoryDao.GetProductSuggestion(inventory.txbSearch.Text);
            inventory.LBsuggestions.Items.Add(suggestions[0]);

        }

    }
}
