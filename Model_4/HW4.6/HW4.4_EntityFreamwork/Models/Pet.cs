namespace HW4._4_EntityFreamwork.DbModels
{
    public sealed class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; } //navigation property
        public int? CategotyId { get; set; }
        public Breed Breed { get; set; } //navigation property
        public int? BreedId { get; set; }
        public float Age { get; set; }
        public Location Location { get; set; } //navigation property
        public int? LocationId { get; set; }
        public string Image_url { get; set; }
        public string Description { get; set;}
    }
}
