namespace NOSDotNetTrainingBatch1
{
    class Product
    {

        public int id { get; set; }
        public string productCode { get; set; }
        public string productName { get; set; }
        public decimal price { get; set; }


        public Product(int id, string productCode, string productName, decimal price)
        {
            this.id = id;
            this.productCode = productCode;
            this.productName = productName;
            this.price = price;
        }

        public override string ToString()
        {
            return $"Code: {productCode}, Name: {productName}, Price: {price}";
        }
    }
}
