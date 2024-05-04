using MakeupTok.Model;
using Microsoft.EntityFrameworkCore;

namespace QuakeAnalitika.Services.Generic;

public class MakeupRepository(MakeupTokContext cont, IUserRepository usrRepo) : IMakeupRepository
{

    private readonly MakeupTokContext _context = cont;
    private readonly IUserRepository _userRepo = usrRepo;

    public async Task Delete(int id)
    {
        await _context.Makeups.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

    public async Task<Makeup> GetById(int id)
    {
        return await _context.Makeups.Include(x => x.Steps).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Makeup>> GetByUser(int userId)
    {
        throw new Exception();
    }

    public async Task<Makeup> GetNextByUser(int userId)
    {
        return await _context.Makeups.Include(x => x.Steps).FirstOrDefaultAsync();
    }

    public async Task<Makeup> Save(Makeup makeup)
    {
        throw new Exception();
    }
}
