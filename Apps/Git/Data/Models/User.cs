using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Git.Data.DataConstants;

namespace Git.Data.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(defaultMinLenght)]
        [MaxLength(defaultMaxLenght)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public IEnumerable<Repository> Repositories { get; set; } = new List<Repository>();

        public IEnumerable<Commit> Commits { get; set; } = new List<Commit>();
    }
}
