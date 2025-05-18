using System.Reflection.Metadata;
using EFModels = DreamDictionary.Database.Models;
using DreamDictionary.WebApi.Migration;
using Newtonsoft.Json;



namespace DreamDictionary.WebApi.Services
{
    public class MigrationService
    {
        private readonly EFModels.AppDbContext _dbContext;
       
        public MigrationService(EFModels.AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MigrateDatabase()
        {
            var jsonString = File.ReadAllText("../Migration/DreamDictionary.json");

            var jsonify = JsonConvert.DeserializeObject<DreamDictionaryModel>(jsonString);

            foreach (var item in jsonify.BlogHeader)
            {
                var entity = new EFModels.BlogHeader
                {
                    //BlogId = item.BlogId,
                    BlogTitle = item.BlogTitle
                };

                _dbContext.BlogHeaders.Add(entity);

            }
            //_dbContext.SaveChanges();


            foreach (var item in jsonify.BlogDetail)
            {
                var entity = new EFModels.BlogDetail
                {
                    //BlogDetailId = item.BlogDetailId,
                    BlogContent = item.BlogContent,
                    BlogId = item.BlogId
                };


                _dbContext.BlogDetails.Add(entity);

            }
            //_dbContext.SaveChanges();

            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
            }


        }
    }
}
