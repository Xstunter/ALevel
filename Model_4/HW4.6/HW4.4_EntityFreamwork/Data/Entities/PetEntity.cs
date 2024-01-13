using HW4._4_EntityFreamwork.DbModels;

namespace HW4._4_EntityFreamwork.Data.Entities
{
    public class PetEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  CategoryEntity Category { get; set; } //navigation property
        public int? CategotyId { get; set; }
        public BreedEntity Breed { get; set; } //navigation property
        public int? BreedId { get; set; }
        public float Age { get; set; }
        public LocationEntity Location { get; set; } //navigation property
        public int? LocationId { get; set; }
    }
}
