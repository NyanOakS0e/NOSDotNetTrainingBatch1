using System.Reflection.PortableExecutable;
using DreamDictionary.Database.Models;
using DreamDictionary.WebApi.Models;

namespace DreamDictionary.WebApi.Services
{
    public class BlogService
    {
        private readonly AppDbContext _appDbContext;

        public BlogService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ResponseModel getBlogTitles()
        {
            try
            {
                var headers = _appDbContext.BlogHeaders.ToList();

                return new ResponseModel(true, "successful", headers);

            }
            catch (Exception ex)
            {

                return new ResponseModel(false, ex.Message + ex.InnerException);

            }

        }


        public ResponseModel getBlogDetails(int id)
        {
            try
            {
                var details = _appDbContext.BlogDetails.Where(x => x.BlogId == id).ToList();
                return new ResponseModel(true, "successful", details);
            }
            catch (Exception ex)
            {
                return new ResponseModel(false, ex.Message + ex.InnerException);
            }
        }
    }
}
