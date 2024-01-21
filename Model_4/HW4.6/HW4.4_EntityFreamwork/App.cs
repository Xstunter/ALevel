using HW4._4_EntityFreamwork.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4._4_EntityFreamwork
{
    public class App
    {
        private readonly IPetService _petService;
        private readonly ILocationService _locationService;
        private readonly IBreedService _breedService;
        private readonly ICategoryService _categoryService;
        public App(
            IPetService petService, 
            ILocationService locationService, 
            IBreedService breedService, 
            ICategoryService categoryService)
        {
            _petService = petService;
            _locationService = locationService;
            _breedService = breedService;
            _categoryService = categoryService;
        }
        public async Task Start()
        {
            /*await _locationService.AddLocation();*/
            /*await _categoryService.AddCategory();*/
            /*await _breedService.AddBreed();*/
            /*await _petService.AddPet();*/
        }
    }
}
