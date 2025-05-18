// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using Migration;
using Newtonsoft.Json;
using NOS_DreamDictionary_Database.Models;
using SQL_Services_Shared;

Console.WriteLine("Hello, World!");

AppDbContext context = new AppDbContext();

var jsonString = File.ReadAllText("DreamDictionary.json");

var jsonify = JsonConvert.DeserializeObject<DreamDictionary>(jsonString)!;


foreach (var item in jsonify.BlogHeader)
{
    context.BlogHeaders.Add(new BlogHeader
    {
        BlogId = item.BlogId,
        BlogTitle = item.BlogTitle!
    });

    context.SaveChanges();
}




