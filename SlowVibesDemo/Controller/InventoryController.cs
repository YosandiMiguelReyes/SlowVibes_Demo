

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SlowVibesDemo.Data.DAO.InventoryDAO;

namespace SlowVibesDemo.Controller
{

    public class InventoryController 
    {
        public static string productName;
        public static int price;
        Precio PrecioForm;
        Form1 inventory;
        InventoryDao inventoryDao = new InventoryDao();
        public InventoryController(Form1 _inventory) 
        {
            inventory = _inventory;

            #region Event handler inventory
            inventory.btnExit.Click += new EventHandler(Exit);
            inventory.Load += new EventHandler(LoadInventoryHistori);
            inventory.txbSearch.TextChanged += new EventHandler(GetSuggestions);
            inventory.txbSearch.KeyDown += new KeyEventHandler(keydown_SuggestionMovement);
            inventory.LBsuggestions.KeyDown += new KeyEventHandler(SelectSuggestion);
            #endregion

            //------------------------------------------
        }


        public void Exit (object sender, EventArgs e) 
        {
            inventory.Close();
        }
        public void LoadInventoryHistori(object semder, EventArgs args) 
        {

            inventory.LBsuggestions.Visible = false;
            inventory.dataGridView1.DataSource = inventoryDao.GetSalesHistories();
        }

        public void GetSuggestions(object sender, EventArgs e) 
        {
            List<string> suggestions = inventoryDao.GetProductSuggestion(inventory.txbSearch.Text.ToString());

            if (suggestions.Count > 0 && inventory.txbSearch.Text.Trim() != string.Empty) 
            {
                inventory.LBsuggestions.DataSource = suggestions;
                inventory.LBsuggestions.Visible = true;
            }
            else 
            {
                inventory.LBsuggestions.Visible = false;
            }
            
        }

        public void keydown_SuggestionMovement(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Down && inventory.LBsuggestions.Visible == true) 
            {
                inventory.LBsuggestions.Focus();
            }
        
        }
        public void SelectSuggestion(object sender, KeyEventArgs e) 
        {

            if (e.KeyCode == Keys.Enter && inventory.LBsuggestions.Visible == true)
            {
                productName = inventory.LBsuggestions.SelectedItem.ToString();
                price = inventoryDao.GetProductPriceByName(productName);
                inventory.txbSearch.Focus(); // Devuelve el foco al TextBox
                inventory.LBsuggestions.Visible = false;
                PrecioForm = new Precio();
                PrecioForm.ShowDialog();

                
            }
        }

    }
}
