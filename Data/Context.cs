using Microsoft.EntityFrameworkCore;
using Trivia;

namespace Data
{
    public class Context : DbContext
    {
        public DbSet<Score> Scores { get; set; }

        public Context()
        { }


        public Context(DbContextOptions<Context> options)
            : base(options)
        {

        }
    }
}