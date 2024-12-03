using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using RunGroop.Interfaces;
using RunGroop.Models;
using RunGroop.ViewModels;

namespace RunGroop.Controllers
{
    public class DashboardController : Controller
    {

        private readonly IDashboardRepository _dashboardRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoService _photoService;
        public DashboardController(
            IDashboardRepository dashboardRepository,
            IHttpContextAccessor httpContextAccessor,
            IPhotoService photoService)
        {
            _dashboardRepository = dashboardRepository;
            _httpContextAccessor = httpContextAccessor;
            _photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            var userRaces = await _dashboardRepository.GetAllUserRaces();
            var userClubs = await _dashboardRepository.GetAllUserClubs();
            var dashboardViewModel = new DashboardViewModel()
            {
                Races = userRaces,
                Clubs = userClubs,
            };
            return View(dashboardViewModel);
        }

        public async Task<IActionResult> EditUserProfile()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var user = await _dashboardRepository.GetUserById(curUserId);
            if (user == null) return View("Error");
            
            var editUserViewModel = new EditUserDashboardViewModel()
            {
                Id = curUserId,
                Pace = user.Pace,
                Mileage = user.Mileage,
                ProfileImageUrl = user.ProfileImageUrl,
                City = user.City,
                State = user.State
            };
            return View(editUserViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditUserProfile(EditUserDashboardViewModel editUserDashboardVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View("EditProfile", editUserDashboardVM);
            }

            var user = await _dashboardRepository.GetUserById(editUserDashboardVM.Id);
            var photoResult = await _photoService.AddPhotoAsync(editUserDashboardVM.Image);

            if (editUserDashboardVM.ProfileImageUrl == "" || user.ProfileImageUrl == null)
            {
                MapUserEdit(user, editUserDashboardVM, photoResult);

                _dashboardRepository.Update(user);
                return RedirectToAction("Index");
            }
            else
            {
                try {
                    await _photoService.DeletePhotoAsync(user.ProfileImageUrl);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(editUserDashboardVM);
                };
                MapUserEdit(user, editUserDashboardVM, photoResult);

                _dashboardRepository.Update(user);
                return RedirectToAction("Index");
            }
        }

        private void MapUserEdit(AppUser user, EditUserDashboardViewModel editUserDashboardVM, ImageUploadResult photoResult)
        {
            user.Id = editUserDashboardVM.Id;
            user.Pace = editUserDashboardVM.Pace;
            user.Mileage = editUserDashboardVM.Mileage;
            user.ProfileImageUrl = photoResult.Url.ToString();
            user.City = user.City;
            user.State = user.State;
        }

    }
}