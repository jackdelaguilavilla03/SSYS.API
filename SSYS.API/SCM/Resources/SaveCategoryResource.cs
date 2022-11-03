using System.ComponentModel.DataAnnotations;

namespace SSYS.API.SCM.Resources;

public class SaveCategoryResource
{
    [Required]
    public string Title { get; set; } 
}