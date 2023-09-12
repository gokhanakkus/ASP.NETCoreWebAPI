using System.ComponentModel.DataAnnotations;

namespace App.WebAPI.DTOs
{
    public class ProductUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ürün adı zorunludur.")]
        [StringLength(255, ErrorMessage = "Ürün adı en fazla 255 karakter olmalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olmalıdır.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat 0.01'den büyük olmalıdır.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stok miktarı zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Stok miktarı 1'den büyük olmalıdır.")]
        public int Stock { get; set; }

    }

}
