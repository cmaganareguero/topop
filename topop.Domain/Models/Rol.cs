﻿
namespace topop.Domain.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserRol> UserRol { get; set; }

    }
}
