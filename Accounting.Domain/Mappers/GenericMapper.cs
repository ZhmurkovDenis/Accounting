using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Domain.Mappers
{
    public abstract class GenericMapper<TDomain, TDto> : IMapper<TDomain, TDto>
    {
        public abstract TDto ToDto(TDomain domain);

        public IList<TDto> ToDto(IReadOnlyCollection<TDomain> domain)
        {
            return domain.Select(ToDto).ToList();
        }
    }
}
