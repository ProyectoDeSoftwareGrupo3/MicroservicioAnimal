namespace Application.Response
{
    public class DeleteAnimalResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Adoptado { get; set; }
        public CreateAnimalRazaResponse Raza { get; set; }
    }
}
