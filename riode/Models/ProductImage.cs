﻿namespace riode.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Image { get; set; } = null!;
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
