namespace Application.Response;

public class CreateAnimalResponse
{
        public int Id { get; set; }
        public int AnimalTipoId { get; set; }
        public int UsuarioId { get; set; }
        public int GaleriaId { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad {  get; set; }
        public decimal Peso { get; set; }
        public string Historia {  get; set; }
        public bool Adoptado { get; set; }
}
