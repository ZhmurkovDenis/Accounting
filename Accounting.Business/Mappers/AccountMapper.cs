using Accounting.Domain.Mappers;
using Accounting.Domain.Models;
using Accounting.Dto.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Business.Mappers
{
    public class AccountMapper : GenericMapper<Domain.Models.Account, Dto.Dto.Account>, IAccountMapper
    {
        public override Dto.Dto.Account ToDto(Domain.Models.Account domain)
        {
            return new Dto.Dto.Account
            {
                Id = domain.Id,
                Amount = domain.Balance,
                CurrencyId = domain.CurrencyId,
                UserId = domain.UserId
            };
        }
    }
}
