namespace Domain.Entities;

public class Foto
{
    public int Id {get;set;}
    public string url {get;set;}
    public Guid GaleriaId {get;set;}
    public AnimalGaleria Galeria {get;set;}
}
