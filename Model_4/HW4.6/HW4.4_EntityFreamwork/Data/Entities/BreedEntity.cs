using HW4._4_EntityFreamwork.DbModels;
using System;
using System.Collections.Generic;

namespace HW4._4_EntityFreamwork.Data.Entities
{
    public class BreedEntity
    {
        public int Id { get; set; }
        public string BreedName { get; set; }
        public CategoryEntity Category { get; set; } //navigetion property
        public int CategoryId { get; set; }
        public List<PetEntity> Pets { get; set; }  //navigation property
    }
}
