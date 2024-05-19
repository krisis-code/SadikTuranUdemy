﻿namespace StoreApp.web.Models
{
	public class ProductViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public string Category { get; set; } = string.Empty;
	}
}
