﻿using Store.Entities.Concrete;

namespace Store.Data.Configurations
{
	public class OrderConfiguration : EntityBaseConfiguration<Order>
	{
		public OrderConfiguration()
		{
			Property(o => o.CustomerName).IsRequired().HasMaxLength(100);
			Property(o => o.CustomerDetails).IsRequired();
			Property(o => o.CustomerPhone).HasMaxLength(10);


			Ignore(o => o.Products);
		}
	}
}
