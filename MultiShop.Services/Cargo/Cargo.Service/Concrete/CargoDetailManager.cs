using Cargo.Core.Entities;
using Cargo.Repository.Abstract;
using Cargo.Service.Abstract;

namespace Cargo.Service.Concrete;

public class CargoDetailManager(ICargoDetailDal cargoDetailDal) : ICargoDetailService
{
    private readonly ICargoDetailDal _cargoDetailDal = cargoDetailDal;

    public void TDelete(int id) => _cargoDetailDal.Delete(id);
    public List<CargoDetail> TGetAll() => _cargoDetailDal.GetAll();
    public CargoDetail TGetById(int id) => _cargoDetailDal.GetById(id);
    public void TInsert(CargoDetail entity) => _cargoDetailDal.Insert(entity);
    public void TUpdate(CargoDetail entity) => _cargoDetailDal.Update(entity);
}
