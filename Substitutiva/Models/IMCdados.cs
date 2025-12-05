namespace Substitutiva.Models
{
    public class IMCdados
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public double IMC { get; set; }
        public string Classificacao { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
    }
}
