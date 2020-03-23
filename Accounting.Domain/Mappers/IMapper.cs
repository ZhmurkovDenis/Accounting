using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Domain.Mappers
{
    public interface IMapper<TDomain, TDto>
    {
        TDto ToDto(TDomain domain);
        IList<TDto> ToDto(IReadOnlyCollection<TDomain> domain);
    }
}
