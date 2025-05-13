using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
using NOSADO.NET;

// Data Source = server name
// Initial Catalog = database name
// User ID = username
// Password = password

UserService us = new UserService();

//us.ReadAll();

us.ReadDetail("1");