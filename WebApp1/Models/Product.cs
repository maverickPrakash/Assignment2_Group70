﻿namespace WebApp1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cost { get; set; }
        public string Asset_condition { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public Product() { }
    }
}
