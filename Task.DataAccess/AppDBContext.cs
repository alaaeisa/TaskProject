

using Microsoft.EntityFrameworkCore;
using TaskProject.DataAccess.Domain.Contact;

namespace TaskProject.DataAccess
{
    public class AppDBContext : DbContext
    {
        public DbContext CurrentDbContext { get { return this; } }
        public AppDBContext(DbContextOptions options) : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var cascadeFKs = builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade && !fk.IsOwnership);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        }
        public async Task<int> UpdateAsync<T>(T obj) where T : class
        {
            Entry<T>(obj).State = EntityState.Modified;
            return await SaveChangesAsync(obj);
        }

        public async Task<int> DeleteAsync<T>(T obj) where T : class
        {
            Entry<T>(obj).State = EntityState.Deleted;
            return await SaveChangesAsync(obj);
        }

        private async Task<int> SaveChangesAsync<T>(T obj) where T : class
        {
            int result = await SaveChangesAsync();
            Entry(obj).State = EntityState.Detached;
            return await System.Threading.Tasks.Task.FromResult(result);
        }

        public void DetachEntity<T>(T obj) where T : class
        {
            Entry(obj).State = EntityState.Detached;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    
        public DbSet<Contact> Contacts { get; set; }

    }
}
