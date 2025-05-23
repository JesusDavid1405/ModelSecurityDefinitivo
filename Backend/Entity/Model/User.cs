namespace Entity.Model;

public class User : BaseModel
{
    public string Username { get; set; } 
    public string Email { get; set; }
    public string Password {get; set;}
    public DateTime CreatedDate {get; set;}
    public bool Active {get; set;}

    public Person Person {get; set;}
    public int PersonId {get; set;}

    //Probablemente de error
    public List<RolUser> RolUsers {get; set; }
}
 