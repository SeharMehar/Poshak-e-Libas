using System.ComponentModel.DataAnnotations;

namespace Poshak_e_Labas.Models
{
    public class BridalProduct
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        [Required]
        [StringLength(50)]
        public string FabricType { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public int StockQuantity { get; set; }
    }
}