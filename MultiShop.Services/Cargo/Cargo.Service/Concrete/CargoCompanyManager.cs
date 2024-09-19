using Cargo.Core.Entities;
using Cargo.Service.Abstract;
using Cargo.Repository.Abstract;

namespace Cargo.Service.Concrete;

public class CargoCompanyManager(ICargoCompanyDal cargoCompanyDal) : ICargoCompanyService
{
    private readonly ICargoCompanyDal _cargoCompanyDal = cargoCompanyDal;
    public void TDelete(int id) => _cargoCompanyDal.Delete(id);
    public List<CargoCompany> TGetAll() => _cargoCompanyDal.GetAll();
    public CargoCompany TGetById(int id) => _cargoCompanyDal.GetById(id);
    public void TInsert(CargoCompany entity) => _cargoCompanyDal.Insert(entity);
    public void TUpdate(CargoCompany entity) => _cargoCompanyDal.Update(entity);
}
