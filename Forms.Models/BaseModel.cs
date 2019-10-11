using System.ComponentModel.DataAnnotations.Schema;

namespace Forms.Models
{
    public class BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
