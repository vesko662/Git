using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Git.Data.DataConstants;

namespace Git.Data.Models
{
    public class Repository
    {
        [Key]
        public string Id{ get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(repositoryNameMinLenght)]
        [MaxLength(repositoryNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        public string OwnerId { get; set; }
        public User Owner { get; set; }

        public IEnumerable<Commit> Commits { get; set; } = new List<Commit>();
    }
}
