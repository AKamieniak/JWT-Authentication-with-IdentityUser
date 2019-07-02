using System;
using JWT.Models.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace JWT.Models
{
    public class User : IdentityUser<int>, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
