using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace work_01.Models
{
    public class Batch
    {
        public Batch()
        {
            this.Trainees = new List<Trainee>();
        }
        public int BatchId { get; set; }
        [Required, StringLength(40), Display(Name = "Batch Code")]
        public string BatchCode { get; set; } = default!;
        //nev
        public virtual ICollection<Trainee> Trainees { get; set; }

    }
    public class Trainee
    {
        public int TraineeId { get; set; }
        [Required, StringLength(40), Display(Name = "Trainee Name")]
        public string TraineeName { get; set; } = default!;
        [Required, StringLength(20), Display(Name = "Trainee Contact")]
        public string TraineeContact { get; set; } = default!;
        [Required, StringLength(30), Display(Name = "Trainee Email")]
        public string TraineeEmail { get; set; } = default!;
        //fk
        [ForeignKey("Batch"), Display(Name = "Batch")]
        public int BatchId { get; set; }
        //nev
        public virtual Batch? Batch { get; set; } = default!;
    }
    public class TraineeDbContext : DbContext
    {
        public TraineeDbContext(DbContextOptions<TraineeDbContext> options) : base(options)
        {

        }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Trainee> Trainees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Batch>().HasData(new List<Batch>()
            {
                new Batch { BatchId=1,BatchCode = "WADA/PNTL-A/56/01" },
                new Batch { BatchId=2,BatchCode = "NSA/PNTL-M/48/01" },
                new Batch { BatchId=3,BatchCode = "ESAD-CS/PNTL-A/51/01" }
            });
        }
    }

    
}
