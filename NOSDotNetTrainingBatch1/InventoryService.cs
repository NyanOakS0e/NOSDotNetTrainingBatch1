using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOSDotNetTrainingBatch1
{
    internal class InventoryService
    {
        public void createProduct()
        {
           
            Console.WriteLine("Invntory Management System");
            Console.WriteLine("==========================");


            BeforePrice:

            Console.WriteLine("Enter the name");
            string name = Console.ReadLine()!;


            Console.WriteLine("Enter the price");
            string price = Console.ReadLine()!;

            bool isDecimal = decimal.TryParse(price, out decimal priceValue);

            if (!isDecimal)
            {
                Console.WriteLine("Invalid price. Please enter a valid decimal number.");
                goto BeforePrice;
            }

            Data.ProductId++;

            string productCode = "P" + Data.ProductId.ToString().PadLeft(3, '0');

            Product product = new Product(Data.ProductId, productCode, name, priceValue);

            Data.products.Add(product);

            Console.WriteLine("Wanna do again?");
            string doAgain = Console.ReadLine()!;

            if (doAgain.ToLower() == "yes")
            {
                goto BeforePrice;
            }
            else if (doAgain.ToLower() == "no")
            {
                Console.WriteLine("Thank you for using the system.");

            }
        }


        public void ViewProducts()
        {
            foreach (Product item in Data.products)
            {
                Console.WriteLine(@$"
            Product ID = {item.id}
            Product Code -{item.productCode}
            Product Name - {item.productName}
            Product Price - {item.price}");
            }
        }


        public void UpdateProduct()
        {

        }



        public void DeleteProduct()
        {

        }
    }
}
