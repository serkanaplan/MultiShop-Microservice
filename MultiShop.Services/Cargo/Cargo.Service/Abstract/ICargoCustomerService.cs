using Cargo.Core.Entities;

namespace Cargo.Service.Abstract;

public interface ICargoCustomerService : IGenericService<CargoCustomer>
{
    CargoCustomer TGetCargoCustomerById(string id);
}
