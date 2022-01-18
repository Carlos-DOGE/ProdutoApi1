using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProdutoApi.Models;

namespace ProdutoApi.Data
{
    public interface IDatacontext
    {
        DbSet<Produto> Produtos { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}