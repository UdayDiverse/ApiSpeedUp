using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSpeedUp.Models
{
    public class ApiExecutionTime
    {
        [Key]
        public int Id { get; set; }

        [Column("Api Name")]
        public string ApiName { get; set; }
        public string Api { get; set; }

        [Column("Invoice Number")]
        public int InvoiceNumber { get; set; }
        [Column("Organisation Name")]
        public string OrganizationName { get; set; }
       
    }
}
