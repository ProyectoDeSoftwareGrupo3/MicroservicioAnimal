namespace Domain.Entities
{
    public class AnimalRaza
    {
        public int Id {  get; set; }
        public int TipoId {get;set;}
        public string Descripcion { get; set; }    

        public AnimalTipo Tipo { get; set; }
        public List<Animal> Animales { get; set; }
    }
}
