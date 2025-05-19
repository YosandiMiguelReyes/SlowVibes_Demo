

using SlowVibesDemo.Data.DAO.InventoryDAO;
using System;
using System.Windows.Forms;

namespace SlowVibesDemo.Controller
{
    public class AddSaleController
    {
        Precio precioController;
        InventoryDao DataBase = new InventoryDao();

        public AddSaleController(Precio _precioController) 
        {
            precioController = _precioController;

            precioController.Load += new EventHandler(GetDefaultPrice);
            precioController.txbPrice.KeyDown += new KeyEventHandler(AddSale);
        }


        public void GetDefaultPrice(object sender, EventArgs e) 
        {
            precioController.txbPrice.Text = InventoryController.price.ToString();
        }
        public void AddSale(object sender, KeyEventArgs e) 
        {
            if(e.KeyCode == Keys.Enter) 
            {
                DataBase.AddSales(InventoryController.productName,InventoryController.price);
                precioController.DialogResult = DialogResult.OK;
                precioController.Close();

            }
        }
    }
}
