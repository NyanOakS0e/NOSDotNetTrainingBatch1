// See https://aka.ms/new-console-template for more information

using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using NOSDotNetTrainingBatch1.ConsoleApp;


Console.WriteLine("Enter name");
string name = Console.ReadLine()!;
Console.WriteLine("Enter email");
string email = Console.ReadLine()!;


DapperService dapperService = new DapperService();

string query = "Insert into Users (Name, Email) values (@Name, @Email)";

dapperService.Execute(query, new User
{
    Name = name,
    Email = email
});


var lst = dapperService.Query<User>("SELECT * FROM dbo.Users");




foreach (User row in lst)
{
    Console.WriteLine($"{row.ID} - {row.Name} - {row.Email}");
}



public class User
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

}