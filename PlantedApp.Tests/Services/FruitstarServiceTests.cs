using Autofac.Extras.Moq;
using BusinessLayer.Models;
using DataAccessLayer.Repositories;
using Infrastructure.Services.ServiceImplementation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PlantedApp.Tests.Services
{
    public class FruitstarServiceTests
    {
        [Fact]
        public void GetAll_ValidCall()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IFruitstarRepository>()
                    .Setup(x => x.ReadAsync("~/JsonlFiles/fruitstar.json"))
                    .Returns(Task.FromResult(GetFruitstar()));

                var cls = mock.Create<FruitstarService>();

                var expected = GetFruitstar();
                var actual = cls.GetAll();

                Assert.True(actual != null);
                Assert.Equal(expected.Count(), actual.Result.Count());
            }
        }

        private IEnumerable<Fruitstar> GetFruitstar()
        {
            var fruitstars = new List<Fruitstar>
            {
                new Fruitstar
                {
                    Id = "1",
                    FirstName = "Amy",
                    LastName = "Sandoval"
                },
                new Fruitstar
                {
                    Id = "2",
                    FirstName = "Katie",
                    LastName = "Ruiz"
                },
                new Fruitstar
                {
                    Id = "3",
                    FirstName = "Lori",
                    LastName = "Butler"
                },
                new Fruitstar
                {
                    Id = "4",
                    FirstName = "Darren",
                    LastName = "Simmons"
                }
            };

            return fruitstars;
        }
    }
}
