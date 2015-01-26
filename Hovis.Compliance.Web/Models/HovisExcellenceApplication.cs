using System.ComponentModel.DataAnnotations;

namespace Hovis.Compliance.Web.Models
{
    public class HovisExcellenceApplication : PersistedEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ApplicationKey { get; set; }
    }
}