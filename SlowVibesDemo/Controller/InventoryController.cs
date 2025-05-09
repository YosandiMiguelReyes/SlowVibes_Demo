

using System;
using SlowVibesDemo.Data.DAO.InventoryDAO;

namespace SlowVibesDemo.Controller
{
    
    public class InventoryController
    {
        Form1 inventory;
        InventoryDao inventoryDao;
        public InventoryController(Form1 _inventory) 
        {
            inventory = _inventory;

            #region Event handler
            inventory.btnExit.Click += new EventHandler(Exit);
            inventory.Load += new EventHandler(LoadInventoryHistori);
            #endregion
        }



        public void Exit (object sender, EventArgs e) 
        {
            inventory.Close();
        }
        public void LoadInventoryHistori(object semder, EventArgs args) 
        {
            inventoryDao = new InventoryDao();
            inventory.dataGridView1.DataSource = inventoryDao.GetSalesHistories();
        }
    }
}
