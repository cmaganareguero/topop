﻿
namespace topop.Domain.Models
{
    public class UserRol
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int RolId { get; set; }
        public Rol Rol { get; set; }
    }
}
