using System;
using System.ComponentModel.DataAnnotations;

namespace DevConnector.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        public string PasswordHash { get; set; }
        
        public DateTime DateRegistered { get; set; } = DateTime.UtcNow;

        public string Role { get; set; } = "User";  // Admin or User
    }
}
