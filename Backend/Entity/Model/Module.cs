namespace Entity.Model;

public class Module
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}
    public bool IsDeleted {get; set;}

    public List<FormModule> FormModules {get; set;}
}
