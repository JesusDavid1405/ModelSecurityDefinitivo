namespace Entity.Model;

public class FormModule
{
    public int Id {get; set;}

    public Form Form {get; set;}
    public int FormId {get; set;}

    public Module Module {get; set;}
    public int ModuleId {get; set;}

    public bool IsDeleted {get; set;}
}
