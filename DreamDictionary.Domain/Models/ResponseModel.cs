namespace DreamDictionary.WebApi.Models
{
    public class ResponseModel
    {

        public ResponseModel(bool isSuccess, string message, object data = null)
        {
            this.isSuccess = isSuccess;
            this.message = message;
            this.data = data;
        }
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}
