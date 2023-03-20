using BusinessLayer.Models;
using Infrastructure.Services;
using PlantedApp.Factory;
using System.Threading.Tasks;
using System.Web.Mvc;
using BusinessLayer.Helpers;
using BusinessLayer.Attributes;

namespace PlantedApp.Controllers
{
    [HandleExceptionAttribute]
    public class CommunityController : Controller
    {
        private readonly IFruitstar _fruitstar;
        private readonly IPeapolis _peapolis;
        private readonly ISeeds _seeds;

        public CommunityController(IFruitstar fruitstar, IPeapolis peapolis, ISeeds seeds)
        {
            _fruitstar = fruitstar;
            _peapolis = peapolis;
            _seeds = seeds;
        }

       
        // GET: Community
        public async Task<ActionResult> Index()
        {            
            Community community = await CreateCommunityAsync();
            var chartModel = ChartFactory.ChartBuilder("numberOfUsers", community);
            chartModel.GenerateModel();

            return View(chartModel);
        }

        public async Task<ActionResult> Communities(string chartType)
        {
            Community community = await CreateCommunityAsync();
            var chartModel = ChartFactory.ChartBuilder(chartType, community);
            chartModel.GenerateModel();

            return View(chartModel);
        }

        public async Task<ActionResult> PeapolisAndFruitstar(string chartType)
        {
            Community community = new Community();
            await ExtendCommunityWithPeapolisAsync(community);
            await ExtendCommunityWithFruitstarsAsync(community);

            var chartModel = ChartFactory.ChartBuilder(chartType, community);
            chartModel.GenerateModel();

            return View(chartModel);
        }

        public async Task<ActionResult> PeapolisAndSeeds(string chartType)
        {
            Community community = new Community();
            await ExtendCommunityWithPeapolisAsync(community);
            await ExtendCommunityWithSeedsAsync(community);

            var chartModel = ChartFactory.ChartBuilder(chartType, community);
            chartModel.GenerateModel();

            return View(chartModel);
        }

        public async Task<ActionResult> FruitstarAndSeeds(string chartType)
        {
            Community community = new Community();
            await ExtendCommunityWithFruitstarsAsync(community);
            await ExtendCommunityWithSeedsAsync(community);

            var chartModel = ChartFactory.ChartBuilder(chartType, community);
            chartModel.GenerateModel();

            return View(chartModel);
        }

        public async Task<ActionResult> ZipCodes()
        {
            Community community = await CreateCommunityAsync();
            var zipCodes = community.GetCommunityZipCodes();
            return View(zipCodes);
        }

        private async Task<Community> CreateCommunityAsync()
        {
            var community = new Community();
            await ExtendCommunityWithPeapolisAsync(community);
            await ExtendCommunityWithFruitstarsAsync(community);
            await ExtendCommunityWithSeedsAsync(community);
            return community;
        }

        public async Task ExtendCommunityWithPeapolisAsync(Community community)
        {
            community.PeapolisCollection = await _peapolis.GetAll();
        }

        private async Task ExtendCommunityWithFruitstarsAsync(Community community)
        {
            community.FruitstarCollection = await _fruitstar.GetAll();
        }

        private async Task ExtendCommunityWithSeedsAsync(Community community)
        {
            community.SeedsCollection = await _seeds.GetAll();
        }


    }
}