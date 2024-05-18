namespace Domain.Entities;

public class Media
{
    public int Id {get;set;}
    public string url {get;set;}
    public int AnimalId {get;set;}
    
    public Animal Animal { get;set;}
}
