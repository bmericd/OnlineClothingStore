﻿namespace OnlineClothingStore.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Color { get; set; } = String.Empty;

        public ICollection<ProductCategory>? ProductCategories { get; set; }
    }
}
