using Cargo.Core.Entities;

namespace Cargo.Repository.Abstract;

public interface ICargoCustomerDal : IGenericDal<CargoCustomer>
{
    CargoCustomer GetCargoCustomerById(string id);
}
