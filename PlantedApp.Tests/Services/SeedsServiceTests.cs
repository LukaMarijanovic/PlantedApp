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
    public class SeedsServiceTests
    {
        [Fact]
        public void GetAll_ValidCall()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ISeedsRepository>()
                    .Setup(x => x.ReadAsync("~/JsonlFiles/seeds.json"))
                    .Returns(Task.FromResult(GetSeeds()));

                var cls = mock.Create<SeedsService>();

                var expected = GetSeeds();
                var actual = cls.GetAll();

                Assert.True(actual != null);
                Assert.Equal(expected.Count(), actual.Result.Count());
            }
        }

        private IEnumerable<Seeds> GetSeeds()
        {
            var seeds = new List<Seeds>
            {
                new Seeds
                {
                    Id = 1,
                    FirstName = "Amy",
                    LastName = "Sandoval"
                },
                new Seeds
                {
                    Id = 2,
                    FirstName = "Katie",
                    LastName = "Ruiz"
                },
                new Seeds
                {
                    Id = 3,
                    FirstName = "Lori",
                    LastName = "Butler"
                },
                new Seeds
                {
                    Id = 4,
                    FirstName = "Darren",
                    LastName = "Simmons"
                }
            };

            return seeds;
        }
    }
}
