using Cargo.Core.Entities;
using Cargo.Repository.Abstract;
using Cargo.Repository.Concrete;
using Cargo.Repository.Repositories;

namespace Cargo.Repository.EntityFramework;

public class EfCargoCustomerDal(CargoContext context, CargoContext cargoContext) : GenericRepository<CargoCustomer>(context), ICargoCustomerDal
{
    private readonly CargoContext _cargoContext = cargoContext;

    public CargoCustomer GetCargoCustomerById(string id) 
    => _cargoContext.CargoCustomers.Where(x => x.UserCustomerId == id).FirstOrDefault();
}
