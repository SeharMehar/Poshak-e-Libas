using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Poshak_e_Labas.Models;

namespace Poshak_lab7.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<BridalProduct> Products { get; set; } = new();

        public void OnGet()
        {
            string cs = _configuration.GetConnectionString("DefaultConnection")!;

            using SqlConnection con = new SqlConnection(cs);
            con.Open();

            string query = "SELECT ProductID, ProductName, Category, FabricType, Price, StockQuantity FROM dbo.BridalProducts ORDER BY ProductID DESC";

            using SqlCommand cmd = new SqlCommand(query, con);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Products.Add(new BridalProduct
                {
                    ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                    ProductName = reader["ProductName"] as string ?? string.Empty,
                    Category = reader["Category"] as string ?? string.Empty,
                    FabricType = reader["FabricType"] as string ?? string.Empty,
                    Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                    StockQuantity = reader.GetInt32(reader.GetOrdinal("StockQuantity"))
                });
            }
        }
    }
}