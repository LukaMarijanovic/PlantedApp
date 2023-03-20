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
    public class PeapolisServiceTests
    {
        [Fact]
        public void GetAll_ValidCall()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IPeapolisRepository>()
                    .Setup(x => x.ReadAsync("~/JsonlFiles/peapolis.json"))
                    .Returns(Task.FromResult(GetPeapolis()));

                var cls = mock.Create<PeapolisService>();

                var expected = GetPeapolis();
                var actual = cls.GetAll();

                Assert.True(actual != null);
                Assert.Equal(expected.Count(), actual.Result.Count());
            }
        }

        private IEnumerable<Peapolis> GetPeapolis()
        {
            var peapolis = new List<Peapolis>
            {
                new Peapolis
                {
                    Id = 1,
                    Name = "Amy Sandoval"
                },
                new Peapolis
                {
                    Id = 2,
                    Name = "Katie Ruiz"
                },
                new Peapolis
                {
                    Id = 3,
                    Name = "Lori Butler"
                },
                new Peapolis
                {
                    Id = 4,
                    Name = "Darren Simmons"
                }
            };

            return peapolis;
        }
    }
}
