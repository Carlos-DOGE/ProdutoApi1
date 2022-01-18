namespace ProdutoApi.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public int productCode { get; set; }
        public string context { get; set; }
        public decimal unitPrice { get; set; }
        public string priceList { get; set; }
    }

}

