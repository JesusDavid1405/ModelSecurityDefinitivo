namespace Entity.Model;

public class Form
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}
    public string Url {get; set;}
    public bool IsDeleted {get; set;}

    public List<FormModule> FormModules {get; set;}
    public List<RolFormPermission> RolFormPermissions {get; set;}

}
