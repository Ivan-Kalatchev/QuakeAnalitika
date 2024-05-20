using FluentValidation;
using Microsoft.EntityFrameworkCore;
using QuakeAnalitika.Model;
using QuakeAnalitika.Services;

namespace QuakeAnalitika.Services.Generic;

public class ReportRepository(QuakeAnalitikaContext cont) : IReportRepository
{

    private readonly QuakeAnalitikaContext _context = cont;

    public async Task<IEnumerable<Report>> GetReports()
    {
        return await _context.Reports.Where(x => x.Created > DateTime.Now.AddDays(-1)).ToListAsync();
    }

    public async Task<Report> Save(Report report)
    {
        _context.Reports.Add(report);
        await _context.SaveChangesAsync();
        return report;
    }
}
