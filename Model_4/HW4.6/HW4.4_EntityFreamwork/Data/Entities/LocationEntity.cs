using HW4._4_EntityFreamwork.DbModels;
using System;
using System.Collections.Generic;

namespace HW4._4_EntityFreamwork.Data.Entities
{
    public class LocationEntity
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public List<PetEntity> Pets { get; set; }  //navigation property
    }
}
