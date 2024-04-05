using BoatApp.Domain.Mappers;
using MapsterMapper;

namespace BoatApp.Maui.Services.Mappers;

public class ServiceMapper : IServiceMapper
{
    private readonly IMapper _mapper;

    public ServiceMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TDestination Map<TSource, TDestination>(TSource value)
    {
        return _mapper.Map<TSource, TDestination>(value);
    }

    public TDestination Map<TDestination>(object value)
    {
        return _mapper.Map<TDestination>(value);
    }
}
