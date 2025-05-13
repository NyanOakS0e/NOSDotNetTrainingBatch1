// See https://aka.ms/new-console-template for more information



using Microsoft.Data.SqlClient;
using SQL_Services_Shared;


//AdoDotNetService sqlService = new AdoDotNetService(new SqlConnectionStringBuilder()
//{
//    DataSource = ".",
//    InitialCatalog = "NOSDotNetTrainingBatch1",
//    UserID = "sa",
//    Password = "sasa@123",
//    TrustServerCertificate = true,
//});

//Console.WriteLine("Enter ID: ");
//int id = int.Parse(Console.ReadLine()!);

//var parameters = new SqlParameter[]
//{
//    new SqlParameter("@ID", id)
//};
//var data = sqlService.QueryV2<User>("SELECT * FROM dbo.Users");

//Console.ReadLine();



//DapperService dapperService = new DapperService(new SqlConnectionStringBuilder()
//{
//    DataSource = ".",
//    InitialCatalog = "NOSDotNetTrainingBatch1",
//    UserID = "sa",
//    Password = "sasa@123",
//    TrustServerCertificate = true,
//});

//string query = "SELECT * FROM dbo.Users WHERE ID = @ID";

//var lst = dapperService.Query<User>(query, new User()
//{
//    ID = id
//});

//Console.ReadLine();



AppDbContext db = new AppDbContext();


db.Users.Add(new User()
{
    Name = "Ali",
    Email = "ali@gmail.com"
});

db.SaveChanges();

var lst = db.Users.ToList();

foreach (var item in lst)
{
    Console.WriteLine(item.Name);
}

var item2 = db.Users.Where(x => x.ID == 1).FirstOrDefault();

Console.ReadLine();

