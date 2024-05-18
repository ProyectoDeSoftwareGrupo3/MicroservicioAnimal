namespace Application.Response
{
    public class GetAnimalResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Genero { get; set; }
        public int Edad { get; set; }
        public decimal Peso { get; set; }
        public string Historia { get; set; }
        public bool Adoptado { get; set; }

        public List<GetMediaReponse> Fotos { get; set; }
        public GetAnimalRazaResponse Raza { get; set; }

    }
}
