using Newtonsoft.Json;
using NOS_DreamDictionary_Database.Models;

namespace NOS_DreamDictionary_WebAPI.Services
{
    public class MigrationService
    {

        private readonly AppDbContext _context;

        public MigrationService(AppDbContext context)
        {
            _context = context;
        }

        public void SeedDatabase()
        {
            var jsonString = File.ReadAllText("DreamDictionary.json");

            var jsonify = JsonConvert.DeserializeObject<DreamDictionary>(jsonString)!;


            foreach (var item in jsonify.BlogHeader)
            {
                _context.BlogHeaders.Add(new BlogHeader
                {
                    BlogId = item.BlogId,
                    BlogTitle = item.BlogTitle!
                });

                _context.SaveChanges();
            }

            foreach (var item in jsonify.BlogDetail)
            {
                _context.BlogDetails.Add(new Blogdetail
                {
                    Blo
                });
            }
        }
    }
}
