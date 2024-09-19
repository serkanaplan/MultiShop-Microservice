using AutoMapper;
using Catalog.Dtos.AboutDtos;
using Catalog.Entites;
using Catalog.Settings;
using MongoDB.Driver;

namespace Catalog.Services.AboutServices;

public class AboutService(IMapper mapper, IDatabaseSettings databaseSettings) : IAboutService
{
    private readonly IMongoCollection<About> _aboutCollection 
    = new MongoClient(databaseSettings.ConnectionString).GetDatabase(databaseSettings.DatabaseName).GetCollection<About>(databaseSettings.AboutCollectionName);

    private readonly IMapper _mapper = mapper;
    public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
    {
        var value = _mapper.Map<About>(createAboutDto);
        await _aboutCollection.InsertOneAsync(value);
    }

    public async Task DeleteAboutAsync(string id)
    {
        await _aboutCollection.DeleteOneAsync(x => x.AboutId == id);
    }

    public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
    {
        var values = await _aboutCollection.Find(x => x.AboutId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdAboutDto>(values);
    }

    public async Task<List<ResultAboutDto>> GettAllAboutAsync()
    {
        var values = await _aboutCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultAboutDto>>(values);
    }

    public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
    {
        var values = _mapper.Map<About>(updateAboutDto);
        await _aboutCollection.FindOneAndReplaceAsync(x => x.AboutId == updateAboutDto.AboutId, values);
    }
}
