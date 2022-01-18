using Microsoft.EntityFrameworkCore;
using ProdutoApi.Models;

namespace ProdutoApi.Data
{
    public class DataContext : DbContext, IDatacontext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
        public DbSet<Produto> Produtos { get; set; }
    }
}