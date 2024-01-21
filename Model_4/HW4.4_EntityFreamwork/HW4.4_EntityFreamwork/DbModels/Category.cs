using System.Collections.Generic;

namespace HW4._4_EntityFreamwork.DbModels
{
    public sealed class Category
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public List<Pet> Pets { get; set; } //navigetion property
        public List<Breed> Breeds  { get; set; } //navigetion property
    }
}
