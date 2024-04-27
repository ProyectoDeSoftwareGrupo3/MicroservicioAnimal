using Domain.Entities;

namespace Application.Response;

public class CreateAnimalGaleriaResponse
{
    public int Id {get;set;}
    public string Descripcion {get;set;}
    public List<GetFotoReponse> Fotos { get;set;}
}
