namespace Entity.Model;

public class Rol
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}
    public bool IsDeleted {get; set;}

    public List<RolUser> RolUsers {get; set;} 
    public List<RolFormPermission> RolFormPermissions {get; set;}
}
