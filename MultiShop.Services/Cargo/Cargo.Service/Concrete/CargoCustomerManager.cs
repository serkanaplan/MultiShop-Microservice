using Cargo.Core.Entities;
using Cargo.Repository.Abstract;
using Cargo.Service.Abstract;

namespace Cargo.Service.Concrete;

public class CargoCustomerManager(ICargoCustomerDal cargoCustomerDal) : ICargoCustomerService
{
    private readonly ICargoCustomerDal _cargoCustomerDal = cargoCustomerDal;
    public void TDelete(int id) => _cargoCustomerDal.Delete(id);
    public List<CargoCustomer> TGetAll() => _cargoCustomerDal.GetAll();
    public CargoCustomer TGetById(int id) => _cargoCustomerDal.GetById(id);
    public CargoCustomer TGetCargoCustomerById(string id) => _cargoCustomerDal.GetCargoCustomerById(id);
    public void TInsert(CargoCustomer entity) => _cargoCustomerDal.Insert(entity);
    public void TUpdate(CargoCustomer entity) => _cargoCustomerDal.Update(entity);
}