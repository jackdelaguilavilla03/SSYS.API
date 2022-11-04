using Swashbuckle.AspNetCore.Annotations;

namespace SSYS.API.IAM.Resources;
[SwaggerSchema(Required = new []{"Id","Username","Password"})]
public abstract class AccountResource
{
    [SwaggerSchema("Main User Identifier")]
    public int Id { get; set; }
    
}