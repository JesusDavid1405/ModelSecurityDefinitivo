namespace Entity.Model;

public class Form : GenericModel
{
    public string Url {get; set;}

    public List<FormModule> FormModules {get; set;}
    public List<RolFormPermission> RolFormPermissions {get; set;}

}
