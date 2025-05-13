
using NOSDotNetTrainingBatch1;


InventoryService inventoryService = new InventoryService();
Menu menu = new Menu();

BeforeSystem:
menu.ShowMenu();

Console.WriteLine("Choose: ");
string userChoice = Console.ReadLine()!;

if (userChoice == "1")
{
    inventoryService.createProduct();
}

else if (userChoice == "2")
{
    inventoryService.ViewProducts();
}
else if (userChoice == "3")
{
    inventoryService.UpdateProduct();
}
else if (userChoice == "4")
{
    inventoryService.DeleteProduct();
}


Console.WriteLine("Type '5' for showing menu again");
string choice = Console.ReadLine()!;

if (choice == "5")
{
    goto BeforeSystem;
}






//Console.WriteLine(string.Join("\n", Data.products));
