using Cargo.Core.Entities;
using Cargo.Repository.Abstract;
using Cargo.Service.Abstract;

namespace Cargo.Service.Concrete;

public class CargoOperationManager(ICargoOperationDal cargoOperationDal) : ICargoOperationService
{
    private readonly ICargoOperationDal _cargoOperationDal = cargoOperationDal;

    public void TDelete(int id) => _cargoOperationDal.Delete(id);
    public List<CargoOperation> TGetAll() => _cargoOperationDal.GetAll();
    public CargoOperation TGetById(int id) => _cargoOperationDal.GetById(id);
    public void TInsert(CargoOperation entity) => _cargoOperationDal.Insert(entity);
    public void TUpdate(CargoOperation entity) => _cargoOperationDal.Update(entity);
}