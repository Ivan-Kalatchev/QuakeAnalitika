namespace QuakeAnalitika.Model.Open;

public class User
{

    public string Username { get; set; }

    public string Email { get; set; }

    public string ProfileImage { get; set; }

    public IEnumerable<Makeup> Makeups { get; set; }

}
