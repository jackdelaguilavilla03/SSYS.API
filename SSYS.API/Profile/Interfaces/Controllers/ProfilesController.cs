using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SSYS.API.Profile.Domain.Services;
using SSYS.API.Profile.Resources;

namespace SSYS.API.Profile.Interfaces.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProfilesController : ControllerBase
{
    private readonly IProfileService _profileService;
    private readonly IMapper _mapper;

    public ProfilesController(IProfileService profileService, IMapper mapper)
    {
        _profileService = profileService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ProfileResource>> GetAllAsync()
    {
        var profiles = await _profileService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Domain.Model.Entities.Profile>, IEnumerable<ProfileResource>>(profiles);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveProfileResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var profile = _mapper.Map<SaveProfileResource, Domain.Model.Entities.Profile>(resource);

        var result = await _profileService.SaveAsync(profile);

        if (!result.Success)
            return BadRequest(result.Message);

        var profileResource = _mapper.Map<Domain.Model.Entities.Profile, ProfileResource>(result.Resource);

        return Created(nameof(PostAsync), profileResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProfileResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var profile = _mapper.Map<SaveProfileResource, Domain.Model.Entities.Profile>(resource);

        var result = await _profileService.UpdateAsync(id, profile);

        if (!result.Success)
            return BadRequest(result.Message);

        var profileResource = _mapper.Map<Domain.Model.Entities.Profile, ProfileResource>(result.Resource);

        return Ok(profileResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _profileService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var profileResource = _mapper.Map<Domain.Model.Entities.Profile, ProfileResource>(result.Resource);

        return Ok(profileResource);
    }
}