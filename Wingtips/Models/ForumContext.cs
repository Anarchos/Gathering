using System.Data.Entity;

namespace Wingtips.Models
{
    public class ForumContext : DbContext
    {
        public ForumContext()
            : base("Wingtips")
        {
        }
        public DbSet<Member> Member { get; set; }
        public DbSet<Member> Products { get; set; }
    }
}