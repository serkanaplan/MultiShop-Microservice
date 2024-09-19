using Cargo.Core.Entities;
using Cargo.Repository.Abstract;
using Cargo.Repository.Concrete;
using Cargo.Repository.Repositories;

namespace Cargo.Repository.EntityFramework;

public class EfCargoDetailDal(CargoContext context) : GenericRepository<CargoDetail>(context), ICargoDetailDal
{
}
