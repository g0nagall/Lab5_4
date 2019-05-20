using System;

namespace lab5_4
{
	class Warehouse : IComparable<Warehouse>
	{
		private string Manufacturer { get; set; }
		private string TypeOfItem { get; set; }
		private double Price { get; set; }
		private double Dimension { get; set; }

		public void InputProduct()
		{
			// Manufacturer input.
			Console.Write("Enter manufacturer of product: ");
			do
			{
				Manufacturer = Console.ReadLine();
				if (Manufacturer.All(char.IsLetterOrDigit))
				{
					break;
				}
				else
				{
					Console.WriteLine("Name of manufacturer should only consist of letters and digits!");
				}
			} while (Manufacturer == null);

			// Type of item input.
			Console.Write("Enter type of item: ");
			do
			{
				TypeOfItem = Console.ReadLine();
				if (TypeOfItem.All(char.IsLetter))
				{
					break;
				}
				else
				{
					Console.WriteLine("Type of product should only consist of letters!");
				}

			} while (TypeOfItem == null);

			// Price input.
			double tempPrice = new double();
			while (double.TryParse(Console.ReadLine(), out tempPrice) == false)
			{
				Console.Write("Wrong price input! Try again: ");
			}
			Price = tempPrice;

			// Dimension input.
			double tempDimension = new double();
			while (double.TryParse(Console.ReadLine(), out tempDimension) == false)
			{
				Console.Write("Wrong dimension input! Try again: ");
			}
			Dimension = tempDimension;
		}

		// Method for outputting products.
		public void OutputProduct()
		{
			Console.WriteLine($"Manufacturer is {Manufacturer}");
			Console.WriteLine($"Type of item is {TypeOfItem}");
			Console.WriteLine($"Price is {Price}");
			Console.WriteLine($"Dimension is {Dimension}");
		}

		// Method for search.
		public static void FindProduct(Warehouse[] products)
		{
			Console.WriteLine("You want to find product by price, type or dimension?:");
			string searchValue = Console.ReadLine();
			switch (searchValue)
			{
				case "price":
					SearchByPrice(products);
					break;
				case "type":
					SearchByType(products);
					break;
				case "dimension":
					SearchByDimension(products);
					break;
				default:
					Console.WriteLine("Wrong value!");
					break;
			}
		}

		// Additional search method for price.
		private static void SearchByPrice(Warehouse[] products)
		{
			bool someImportantValue = true;
			Console.Write("Enter searched price: ");
			double searchedPrice;
			while (double.TryParse(Console.ReadLine(), out searchedPrice) == false)
			{
				Console.Write("Wrong value! Try again: ");
			}

			foreach (var product in products)
			{
				if (product.Price == searchedPrice)
				{
					product.OutputProduct();
					someImportantValue = false;
				}
			}
			if (someImportantValue)
			{
				Console.WriteLine("There is no such products");
			}
		}

		// Additional search method for type
		private static void SearchByType(Warehouse[] products)
		{
			bool someImportantValue = true;
			Console.Write("Enter searched type: ");
			string searchedType = Console.ReadLine();

			foreach (var product in products)
			{
				if (product.TypeOfItem == searchedType)
				{
					product.OutputProduct();
					someImportantValue = false;
				}
			}
			if (someImportantValue)
			{
				Console.WriteLine("There is no such products");
			}
		}

		//Additional search method for dimension
		private static void SearchByDimension(Warehouse[] products)
		{
			bool someImportantValue = true;
			Console.Write("Enter searched dimension: ");
			double searchedDimension;
			while (double.TryParse(Console.ReadLine(), out searchedDimension) == false)
			{
				Console.Write("Wrong value! Try again: ");
			}

			foreach (var product in products)
			{
				if (product.Dimension == searchedDimension)
				{
					product.OutputProduct();
					someImportantValue = false;
				}
			}
			if (someImportantValue)
			{
				Console.WriteLine("There is no such products");
			}
		}

		// CompareTo override.
		public int CompareTo(Warehouse temp)
		{
			return this.Price.CompareTo(temp.Price);
		}
	}
}
