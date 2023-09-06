﻿using System.ComponentModel.DataAnnotations.Schema;

namespace EverydayAPI.Models
{
    public class AddUserRequest{
        public string username { get; set; }
        public string password { get; set; }
        public string userEmail { get; set; }
        [ForeignKey("jornalId")]
        public Guid jornalFavorito { get; set; }
    }
}
