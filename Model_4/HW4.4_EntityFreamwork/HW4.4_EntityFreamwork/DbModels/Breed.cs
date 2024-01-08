using System.Collections.Generic;

namespace HW4._4_EntityFreamwork.DbModels
{
    public sealed class Breed
    {
        public int Id { get; set; }
        public string BreedName { get; set; }
        public Category Category { get; set; } //navigetion property
        public int CategoryId { get; set; } 
        public List<Pet> Pets { get; set; }  //navigation property

    }
}
