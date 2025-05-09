
using MySql.Data.MySqlClient;

namespace SlowVibesDemo.Data.DAO.String_Connection
{
    public class ConnectionString
    {
        protected MySqlConnection connection = new MySqlConnection("Server=localhost;Database=slowvibes;Uid=root;Pwd=Vibras12;");
    }
}
