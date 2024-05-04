using AutoMapper;
using QuakeAnalitika.Model.Open;

namespace QuakeAnalitika.Model.MappingProfiles;

public class MakeupTokInternalProfile : Profile
{

    /// <summary>
    /// Rila internal AutoMapper configuration
    /// </summary>
    public MakeupTokInternalProfile()
    {

        CreateMap<User, User>();

    }

}