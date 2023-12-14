using System.ComponentModel.DataAnnotations;

namespace Aspekt_Task_Endrit_Ajrulla.Models
{
    public class Country
    {
        [Key]

        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public ICollection<Contact> Contacts { get; set; }


    }
}
