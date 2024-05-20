using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuakeAnalitika.Model.Open;
using QuakeAnalitika.Services;

namespace QuakeAnalitika.Controllers;

[Route("api/reports")]
[Authorize]
public class ReportsController(IReportRepository repo, IMapper mapper) : Controller
{

    private IReportRepository _repository = repo;
    private IMapper _mapper = mapper;

    [HttpGet()]
    public async Task<IActionResult> GetReports()
    {
        var mkp = await _repository.GetReports();
        var mkpfinal = _mapper.Map<Model.Open.Report[]>(mkp.ToArray());
        return Ok(mkpfinal);
    }

    [HttpPost()]
    public async Task<IActionResult> PostReport([FromBody] Report report)
    {
        var rep = _mapper.Map<Model.Report>(report);
        return Ok(_mapper.Map<Report>(await _repository.Save(rep)));
    }

    [HttpGet("/reports/new")]
    public IActionResult New()
    {
        return View();
    }

}
