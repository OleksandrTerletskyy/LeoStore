using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using Store.Data.DatabaseContext;
using Store.Entities.Concrete;

namespace Store.Data
{
	public class StoreInitializer : DropCreateDatabaseAlways<StoreContext>
	{
		public StoreInitializer()
		{
			Tags = new List<Tag>
			{
				new Tag
				{
					Id = 1,
					Name = "Tablets"
				},
				new Tag
				{
					Id = 2,
					Name = "Laptops"
				},
				new Tag
				{
					Id = 3,
					Name = "Mobiles"
				},
			};
			Products = new List<Product>
			{
				new Product
				{
					Name = "ProntoTec 7",
					Description =
						"Android 4.4 KitKat Tablet PC, Cortex A8 1.2 GHz Dual Core Processor,512MB / 4GB,Dual Camera,G-Sensor (Black)",
					Tags = new List<Tag>() { Tags[0]},
					Price = 46.99m,
					Images = new List<string>() {"prontotec.jpg"},
					Currency = Currency.USD,
				},
				new Product
				{
					Name = "Samsung Galaxy",
					Description = "Android 4.4 Kit Kat OS, 1.2 GHz quad-core processor",
					Price = 120.95m,
					Tags = new List<Tag>() { Tags[0]} ,
					Images = new List<string>()
					{
						"samsung-galaxy.jpg",
						"samsung-galaxy-1.jpg",
						"samsung-galaxy-2.jpg",
						"samsung-galaxy-3.jpg",
						"samsung-galaxy-4.jpg"
					},
					Currency = Currency.USD,
				},
				new Product
				{
					Name = "NeuTab® N7 Pro 7",
					Description =
						"NeuTab N7 Pro tablet features the amazing powerful, Quad Core processor performs approximately Double multitasking running speed, and is more reliable than ever",
					Price = 59.99m,
					Tags = new List<Tag>() { Tags[0]},
					Images = new List<string>() { "neutab.jpg" },
					Currency = Currency.USD,
				},
				new Product
				{
					Name = "Dragon Touch® Y88X 7",
					Description =
						"Dragon Touch Y88X tablet featuring the incredible powerful Allwinner Quad Core A33, up to four times faster CPU, ensures faster multitasking speed than ever. With the super-portable size, you get a robust power in a device that can be taken everywhere",
					Price = 54.99m,
					Tags = new List<Tag>() { Tags[0]},
					Images = new List<string>() { "dragon-touch.jpg" },
					Currency = Currency.USD,
				},
				new Product
				{
					Name = "Alldaymall A88X 7",
					Description =
						"This Alldaymall tablet featuring the incredible powerful Allwinner Quad Core A33, up to four times faster CPU, ensures faster multitasking speed than ever. With the super-portable size, you get a robust power in a device that can be taken everywhere",
					Price = 47.99m,
					Tags = new List<Tag>() { Tags[0]} ,
					Images = new List<string>() { "Alldaymall.jpg" },
					Currency = Currency.USD,
				},
				new Product
				{
					Name = "ASUS MeMO",
					Description = "Pad 7 ME170CX-A1-BK 7-Inch 16GB Tablet. Dual-Core Intel Atom Z2520 1.2GHz CPU",
					Price = 94.99m,
					Tags = new List<Tag>() { Tags[0]},
					Images = new List<string>() { "asus-memo.jpg" },
					Currency = Currency.USD,
				},
				new Product
				{
					Name = "ASUS 15.6-Inch",
					Description = "Latest Generation Intel Dual Core Celeron 2.16 GHz Processor (turbo to 2.41 GHz)",
					Price = 249.5m,
					Tags = new List<Tag>() { Tags[1]} ,
					Images = new List<string>() { "asus-latest.jpg" },
					Currency = Currency.USD,
				},
				new Product
				{
					Name = "HP Pavilion 15-r030wm",
					Description =
						"This Certified Refurbished product is manufacturer refurbished, shows limited or no wear, and includes all original accessories plus a 90-day warranty",
					Price = 299.95m,
					Tags = new List<Tag>() { Tags[1]},
					Images = new List<string>() { "hp-pavilion.jpg" },
					Currency = Currency.USD,
				},
				new Product
				{
					Name = "Dell Inspiron 15.6-Inch",
					Description = "Intel Celeron N2830 Processor, 15.6-Inch Screen, Intel HD Graphics",
					Price = 308.00m,
					Tags = new List<Tag>() { Tags[1]},
					Images = new List<string>() { "dell-inspiron.jpg" },
					Currency = Currency.USD,
				},
				new Product
				{
					Name = "Acer Aspire E Notebook",
					Description = "15.6 HD Active Matrix TFT Color LED (1366 x 768) 16:9 CineCrystal Display",
					Price = 299.95m,
					Tags = new List<Tag>() { Tags[1]},
					Images = new List<string>() { "acer-aspire.jpg" },
					Currency = Currency.USD,
				},
				new Product
				{
					Name = "HP Stream 13",
					Description =
						"Intel Celeron N2840 Processor. 2 GB DDR3L SDRAM, 32 GB Solid-State Drive and 1TB OneDrive Cloud Storage for one year",
					Price = 202.99m,
					Tags = new List<Tag>() { Tags[1]},
					Images = new List<string>() { "hp-stream.jpg" },
					Currency = Currency.USD,
				},
				new Product
				{
					Name = "Nokia Lumia 521",
					Description = "T-Mobile Cell Phone 4G - White. 5MP Camera - Snap creative photos with built-in digital lenses",
					Price = 63.99m,
					Tags = new List<Tag>() { Tags[2]},
					Images = new List<string>() { "nokia-lumia.jpg" },
					Currency = Currency.USD,
				},
				new Product
				{
					Name = "HTC Desire 816",
					Description = "13 MP Rear Facing BSI Camera / 5 MP Front Facing",
					Price = 177.99m,
					Tags = new List<Tag>() { Tags[2]},
					Images = new List<string>() { "htc-desire.jpg" },
					Currency = Currency.USD,
				},
				new Product
				{
					Name = "Sanyo Innuendo",
					Description =
						"Uniquely designed 3G-enabled messaging phone with side-flipping QWERTY keyboard and external glow-thru OLED dial pad that 'disappears' when not in use",
					Price = 54.99m,
					Tags = new List<Tag>() { Tags[2]},
					Images = new List<string>() { "sanyo-innuendo.jpg" },
					Currency = Currency.USD,
				},
				new Product
				{
					Name = "Ulefone N9000",
					Description = "Unlocked world GSM phone. 3G-850/2100, 2G -850/900/1800/1900",
					Price = 133.99m,
					Tags = new List<Tag>() { Tags[2]},
					Images = new List<string>() { "ulefone.jpg" },
					Currency = Currency.USD,
				}
			};
		}
		protected override void Seed(StoreContext context)
		{
			try
			{
				Tags.ForEach(t => context.Tags.Add(t));
				Products.ForEach(p => context.Products.Add(p));
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}

		private static List<Tag> Tags { get; set; }

		private static List<Product> Products { get; set; }
	}
}
