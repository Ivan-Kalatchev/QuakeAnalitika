using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuakeAnalitika.Model;
using QuakeAnalitika.Services;

namespace QuakeAnalitika.Controllers;

[Route("api/users")]
public class UsersController(IUserRepository repo,
    IMapper mapper) : Controller
{

    private IUserRepository _repository = repo;
    private IMapper _mapper = mapper;

    [HttpPost()]
    public async Task<IActionResult> Register([FromBody] Model.Open.CredentialsDto user)
    {
        return Ok(await _repository.SaveUserAsync(_mapper.Map<User>(user)));
    }

}
