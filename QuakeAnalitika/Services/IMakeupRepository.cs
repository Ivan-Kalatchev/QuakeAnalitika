using MakeupTok.Model;

namespace QuakeAnalitika.Services;

public interface IMakeupRepository
{

    public Task<Makeup> GetById(int id);

    public Task<Makeup> Save(Makeup makeup);

    public Task Delete(int id);

    public Task<IEnumerable<Makeup>> GetByUser(int userId);

    public Task<Makeup> GetNextByUser(int userId);

}
