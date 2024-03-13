using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenAADAlejandroTesan.Models
{
    public class EnvioModelo
    {
        public int Id { get; set; }
        public string fecha { get; set; }
        public string observaciones { get; set; }

        [NotMapped]
        public List<int> regalosEnvioIds { get; set; }
        public List<EnvioRegaloModelo> regalosEnvio { get; set; }

        [NotMapped]
        public string comentario { get; set; }
    }
}//https://localhost:7225/Envio
