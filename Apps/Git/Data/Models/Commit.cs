using System;
using System.ComponentModel.DataAnnotations;
using static Git.Data.DataConstants;

namespace Git.Data.Models
{
    public class Commit
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(defaultMinLenght)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public string CreatorId { get; set; }
        public User Creator { get; set; }

        public string RepositoryId { get; set; }

        public Repository Repository { get; set; }
    }
}
