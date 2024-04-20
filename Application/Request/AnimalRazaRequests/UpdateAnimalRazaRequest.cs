namespace Application.Request;

public class UpdateAnimalRazaRequest
{
    public int Id {get;set;}
    public int TipoId {get;set;}
    public string Descripcion { get; set; }       
}
