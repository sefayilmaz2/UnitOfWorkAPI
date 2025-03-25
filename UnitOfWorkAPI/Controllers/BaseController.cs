using Microsoft.AspNetCore.Mvc;
using UnitOfWorkAPI.DataAccess.Context;
using UnitOfWorkAPI.Domain.Repository;

namespace UnitOfWorkAPI.Controllers
{
    public abstract class BaseApiController<T> : ControllerBase where T : class
    {
        protected readonly UowDbContext _context;
        protected readonly IConfiguration _configuration;
        protected readonly IUnitOfWork _unitOfWork;

        protected BaseApiController(
            UowDbContext context,
            IConfiguration configuration,
            IUnitOfWork unitOfWork)
        {
            _context = context;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }
    }
}
