﻿using System.ComponentModel.DataAnnotations;

namespace MagicVIlla_website.Models.DTOs.VillaDTOs
{
    public class VillaCreationDTO
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
    }
}
