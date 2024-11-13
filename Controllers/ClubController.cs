using Microsoft.AspNetCore.Mvc;
using RunGroop.Interfaces;
using RunGroop.Models;
using RunGroop.ViewModels;

namespace RunGroop.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;
        private readonly IPhotoService _photoService;
        public ClubController(IClubRepository clubRepository, IPhotoService photoService)
        {
            _clubRepository = clubRepository;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index() //C
        {
            IEnumerable<Club> clubs = await _clubRepository.GetAll(); //M
            return View(clubs); //V
        } 
        
        public async Task<IActionResult> Detail(int id)
        {
            Club club = await _clubRepository.GetByIdAsync(id);
            return View(club);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClubViewModel clubViewModel)
        {
            if (!ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(clubViewModel.Image);
                var club = new Club
                {
                    Title = clubViewModel.Title,
                    Description = clubViewModel.Description,
                    Image = result.Url.ToString(),
                    ClubCategory = clubViewModel.ClubCategory,
                    Address = new Address
                    {
                        Street = clubViewModel.Address.Street,
                        City = clubViewModel.Address.City,
                        State = clubViewModel.Address.State,
                    }
                };
                _clubRepository.Add(club);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            };

            return View(clubViewModel);
        }

    }
}