﻿using System.ComponentModel.DataAnnotations;
#nullable disable

namespace MagicVIlla_VillaAPI.Models.DTOs.VillaDTOs
{
    public class VillaDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
