using AutoMapper;
using MakeupTok.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuakeAnalitika.Services;

namespace QuakeAnalitika.Controllers;

[Route("api/users")]
[Authorize]
public class UsersController(IUserRepository repo,
    IMapper mapper) : Controller
{

    private IUserRepository _repository = repo;
    private IMapper _mapper = mapper;

    [HttpPut("{id}")]
    public IActionResult UpdateMakeup()
    {
        return Ok(new Makeup());
    }

    [HttpPost()]
    public async Task<IActionResult> Register([FromBody] Model.Open.User user)
    {
        return Ok(await _repository.SaveUserAsync(_mapper.Map<User>(user)));
    }

}
