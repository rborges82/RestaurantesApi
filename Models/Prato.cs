namespace RestaurantesApi.Models
{
    public class Prato
    {
        public int PratoId { get; set; }
        public string PratoNome { get; set; }
        public double Preco { get; set; }
        public Restaurante Restaurante { get; set; }
    }
}