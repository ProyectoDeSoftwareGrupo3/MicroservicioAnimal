namespace Application.Response
{
    public class CreateAnimalRazaResponse
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public GetAnimalTipoResponse Tipo { get; set; }
    }
}
