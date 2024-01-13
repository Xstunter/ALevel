using HW4._4_EntityFreamwork.DbModels;
using System;
using System.Collections.Generic;

namespace HW4._4_EntityFreamwork.Data.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<PetEntity> Pets { get; set; } //navigetion property
        public List<BreedEntity> Breeds { get; set; } //navigetion property
    }
}
