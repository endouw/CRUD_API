using System.ComponentModel.DataAnnotations;

namespace Aspekt_Task_Endrit_Ajrulla.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        public string CompanyName { get; set;}
        
        public ICollection<Contact> Contacts { get; set; }
    }
}
