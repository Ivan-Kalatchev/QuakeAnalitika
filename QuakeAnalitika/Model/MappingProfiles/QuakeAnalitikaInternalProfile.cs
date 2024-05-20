using AutoMapper;
using QuakeAnalitika.Model;
using QuakeAnalitika.Model.Open;

namespace QuakeAnalitika.Model.MappingProfiles;

public class QuakeAnalitikaInternalProfile : Profile
{

    /// <summary>
    /// Rila internal AutoMapper configuration
    /// </summary>
    public QuakeAnalitikaInternalProfile()
    {

        CreateMap<CredentialsDto, User>();
        CreateMap<Open.User, User>();
        CreateMap<Open.Report, Model.Report>();
        CreateMap<Model.Report, Open.Report>();

    }

}