using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuakeAnalitika.Model;

[Table("Reports")]
public class Report
{

    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTime Created { get; set; } = DateTime.Now;

    public decimal Lang { get; set; }

    public decimal Lat { get; set; }

    public int Amount { get; set; }

}
