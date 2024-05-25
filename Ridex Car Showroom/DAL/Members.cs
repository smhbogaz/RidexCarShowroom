﻿using System.ComponentModel.DataAnnotations;

namespace Ridex_Car_Showroom.DAL
{
    public class Members
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
