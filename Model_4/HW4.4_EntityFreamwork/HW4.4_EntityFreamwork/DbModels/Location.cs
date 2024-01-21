using System.Collections.Generic;

namespace HW4._4_EntityFreamwork.DbModels
{
    public sealed class Location
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public List<Pet> Pets { get; set; }  //navigation property
    }
}
