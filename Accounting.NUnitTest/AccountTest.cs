using Accounting.Business.Mappers;
using Accounting.Business.Services;
using Accounting.DataAccess.DataAccess;
using Accounting.DataAccess.Infrastructure;
using Accounting.DataAccess.Infrastructure.Abstractions;
using Accounting.DataAccess.Infrastructure.Abstractions.Repositories;
using Accounting.DataAccess.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Accounting.NUnitTest
{
    public class AccountTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            //arrange 
            var mock = new Mock<IUnitOfWork>();

            mock.Setup(unitOfWork => unitOfWork.Accounts.GetAllByUserAsync(1)).Returns(GetTestAccount());

            AccountService accountService = new AccountService(
                    new AccountDataAccess(mock.Object),
                    new CurrencyRateService(),
                    new AccountMapper());

            //act
            var account = await accountService.AccountStateAsync(new Dto.Requests.AccountStateRequest
            {
                UserId = 1
            });

            Assert.AreEqual(account.IsSuccess, true);
            Assert.AreEqual(account.Accounts.Count, 1);
            Assert.AreEqual(account.Accounts[0].Id, 1);
            Assert.AreEqual(account.Accounts[0].UserId, 1);
            Assert.AreEqual(account.Accounts[0].CurrencyId, 1);
            Assert.AreEqual(account.Accounts[0].Amount, 100);

            Assert.Pass();
        }

        private async Task<IList<Domain.Models.Account>> GetTestAccount()
        {
            return new List<Domain.Models.Account>
            {
                new Domain.Models.Account
                {
                    Id =1,
                    UserId = 1,
                    Balance = 100,
                    CurrencyId =1,
                }
            };
        }

    }
}