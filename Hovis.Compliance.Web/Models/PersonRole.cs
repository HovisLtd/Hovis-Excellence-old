using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hovis.Compliance.Web.Models
{
    public class PersonRole : PersistedEntity
    {
        public PersonRole()
        {
            People = new List<Person>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}