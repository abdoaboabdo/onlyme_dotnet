using System;
using AutoMapper;
using OnlyMe.DAL.Entities.Varieties;
using OnlyMe.DAL.Models.Varieties;
using OnlyMe.Repository.Interfaces;
using OnlyMe.Services.BaseService;

namespace OnlyMe.Services.Services.VarietiesService
{
    public class VarietyService : BaseService<Variety, VarietyVM, int>, IVarietyService
    {
        public VarietyService(IRepository<Variety, int> repository, IMapper mapper) : base(repository, mapper)
        {

        }
        public override VarietyVM MapEntityToModel(Variety entity)
        {
            return _mapper.Map<VarietyVM>(entity);
        }
        public override Variety MapModelToEntity(VarietyVM entity)
        {
            return _mapper.Map<Variety>(entity);
        }
        protected override Func<Variety, VarietyVM> FuncToVM()
        {
            return c => MapEntityToModel(c);
        }
    }
}
