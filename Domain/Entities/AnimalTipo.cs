namespace Domain.Entities
{
    public class AnimalTipo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public List<AnimalRaza> Razas { get; set;}
    }
}
