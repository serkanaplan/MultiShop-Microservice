using Catalog.Dtos.FeatureSliderDtos;

namespace Catalog.Services.FeatureSliderServices;

public interface IFeatureSliderService
{
    Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
    Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
    Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
    Task DeleteFeatureSliderAsync(string id);
    Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id);
    Task FeatureSliderChageStatusToTrue(string id);
    Task FeatureSliderChageStatusToFalse(string id);
}
