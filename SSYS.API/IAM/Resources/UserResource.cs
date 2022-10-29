namespace SSYS.API.IAM.Resources;

public class UserResource
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public MainUserResource MainUser { get; set; }
}