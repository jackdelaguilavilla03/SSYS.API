using Swashbuckle.AspNetCore.Annotations;

namespace SSYS.API.IAM.Resources;
[SwaggerSchema(Required = new []{"Id","Username","Password"})]
public class MainUserResource
{
    [SwaggerSchema("Main User Identifier")]
    public int Id { get; set; }
    [SwaggerSchema("Main User Username")]
    public string Username { get; set; }
    [SwaggerSchema("Main User Password")]
    public string Password { get; set; }
    
}