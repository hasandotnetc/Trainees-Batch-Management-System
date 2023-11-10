using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace work_02.Models
{
    public class Visitor
    {

        public int Id { get; set; }
        [Required, StringLength(40)]
        public string Name { get; set; } = default!;
        [Required, StringLength(40)]
        public string City { get; set; } = default!;
        [Required, StringLength(40)]
        public string Phone { get; set; } = default!;
        [Required, Column(TypeName ="date"),DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true), Display(Name = "Visit Date")]
        public DateTime VisitDate { get; set; }

    }
    public class GuestDbContext : DbContext
    {
        public GuestDbContext(DbContextOptions<GuestDbContext> options) : base(options)
        {

        }
        public DbSet<Visitor>Visitors  { get; set; }

    }
}
