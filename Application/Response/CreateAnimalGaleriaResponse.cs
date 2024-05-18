namespace Application.Response;

public class CreateAnimalGaleriaResponse
{
    public int Id {get;set;}
    public string Descripcion {get;set;}
    public List<GetMediaReponse> Media { get;set;}
}
