using System.ComponentModel.DataAnnotations;

namespace WebApiTest.Models
{
    /// <summary>
    /// 产品数据结构
    /// </summary>
    public class Product
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        // 最小值0.01
        [Range(minimum: 0.01, maximum: (double)decimal.MaxValue)]
        public decimal Price { get; set; }
    }
}