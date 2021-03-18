using OnlyMe.DAL.Entities.Varieties;
using OnlyMe.DAL.Models.Varieties;
using OnlyMe.Services.BaseService;

namespace OnlyMe.Services.Services.VarietiesService
{
    public interface IVarietyService : IService<Variety, VarietyVM, int>
    {
    }
}
