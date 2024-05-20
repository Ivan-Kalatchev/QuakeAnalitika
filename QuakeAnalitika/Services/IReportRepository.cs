using QuakeAnalitika.Model;

namespace QuakeAnalitika.Services;

public interface IReportRepository
{

    public Task<IEnumerable<Report>> GetReports();

    public Task<Report> Save(Report report);

}
