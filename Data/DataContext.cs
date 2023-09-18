using Microsoft.EntityFrameworkCore;
using SurveyForm.Models;

namespace SurveyForm.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        }

        // Bind DB table name to attribute
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveysAnswer> SurveysAnswers { get; set; }


        // Defining / Creating Foreign Key and Relationship
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>()
                .HasMany(s => s.SurveyAnswers)
                .WithOne(sa => sa.Survey)
                .HasForeignKey(sa => sa.SurveyId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
