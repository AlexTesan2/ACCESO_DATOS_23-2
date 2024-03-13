namespace ExamenAADAlejandroTesan.Models
{
    public class EnvioRegaloModelo
    {
        public int ID { get; set; }
        public int envioId { get; set; }
        public EnvioModelo envio { get; set; }

        public int regaloId { get; set; }
        public RegaloModelo regalo { get; set; }

        public string comentario { get; set; }
    }
}
