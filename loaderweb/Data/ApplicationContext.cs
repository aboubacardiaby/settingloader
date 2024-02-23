using Microsoft.EntityFrameworkCore;

namespace loaderweb.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
         : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Loan>()
        //      .HasOne<Customer>(s => s.Customer)
        //      .WithMany(g => g.Loans)
        //      .HasForeignKey(s => s.CustId);

        //    modelBuilder.Entity<LoanApplication>()
        //      .HasOne<Customer>(s => s.Customer)
        //      .WithMany(g => g.LoanApplications)
        //      .HasForeignKey(s => s.CustId);

        //    //modelBuilder.Entity<Payment>()
        //    //.HasOne<Loan>(s => s.loan)
        //    //.WithMany(g => g.Payments)
        //    //.HasForeignKey(s => s.LoanNumber);


        //}
        public DbSet<Product> tblProduct { get; set; }
    }
}
