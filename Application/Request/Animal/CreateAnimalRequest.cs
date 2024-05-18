namespace Application.Request;

public class CreateAnimalRequest
{
        public int RazaId { get; set; }
        public string Nombre { get; set; }
        public bool Genero { get; set; }
        public int Edad {  get; set; }
        public decimal Peso { get; set; }
        public string Historia {  get; set; }
        
}
